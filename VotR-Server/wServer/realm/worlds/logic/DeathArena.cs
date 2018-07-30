using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using common.resources;
using StackExchange.Redis;
using wServer.logic.loot;
using wServer.networking;
using wServer.networking.packets.outgoing;
using wServer.networking.packets.outgoing.arena;
using wServer.realm.entities;
using wServer.realm.terrain;

namespace wServer.realm.worlds.logic
{
    class DeathArena : World
    {
        public enum ArenaState
        {
            NotStarted,
            CountDown,
            Start,
            Rest,
            Spawn,
            Fight,
            Awaiting,
            Ended
        }

        private enum CountDownState
        {
            Notify60,
            Notify30,
            StartGame,
            Done
        }

        // random enemies used for all levels
        private readonly string[] _randomEnemies =
        {
            "Djinn", "Beholder", "White Demon of the Abyss", "Flying Brain", "Slime God", "Arena Risen Mummy",
            "Native Sprite God", "Ent God", "Medusa", "Ghost God", "Leviathan", "Elite Skeleton", "Angelic Commander"
        };

        // _bossLevel defines the wave at which the random bosses change
        // _randomBosses defines the set of bosses that are used for a particular boss level
        private int _bossLevel = 0;
        private readonly int[] _changeBossLevel = new int[] { 0, 4, 10, 16, 23, 30 /*0, 1, 6, 11, 16, 21, 36*/ };

        private readonly string[][] _randomBosses = new string[][]
        {
            new string[]
            {
                "Dreadstump the Pirate King", "Red Demon", "Phoenix Lord", "Henchman of Oryx", "Mama Megamoth"
            },
            new string[]
            {
                "Stheno the Snake Queen", "Archdemon Malphas", "Septavius the Ghost God",
                "Limon the Sprite God", "Dr Terrible"
            },
            new string[]
            {
                "Thessal the Mermaid Goddess", "Crystal Prisoner", "Lord of the Lost Lands",
                "Septavius the Ghost God", "Limon the Sprite God", "Dr Terrible",
                "Archdemon Malphas", "Epic Larva"
            },
            new string[]
            {
                "Tomb Support", "Tomb Defender", "Tomb Attacker", "Oryx the Mad God 2OA",
                "Grand Sphinx", "Queen of Hearts", "Thessal the Mermaid Goddess", "Gigacorn", "BedlamGod",
                "Crystal Prisoner", "Lord of the Lost Lands", "Epic Larva", "TF The Fallen", "Larry Gigsman, the Superhuman"
            },
            new string[]
            {
                "Thessal the Mermaid Goddess", "Tomb Support", "Tomb Defender", "Tomb Attacker",
                "Queen of Hearts", "Grand Sphinx", "Oryx the Mad God 2OA", "Cube God", "Skull Shrine",
                "TF The Fallen", "Larry Gigsman, the Superhuman"
            },
            new string[]
            {
                "Oryx the Mad God 2OA", "Cube God", "Skull Shrine", "TF The Fallen", "Larry Gigsman, the Superhuman", "BedlamGod"
            }
        };

        private readonly new Dictionary<int, string[]> _waveRewards = new Dictionary<int, string[]>
        {
            { 5,  new string[] { "10 Gold", "Onrane", "100 Gold" } },
            { 10, new string[] {"100 Gold", "Onrane", "Tiny Sor Fragment" } },
            { 20, new string[] { "Onrane", "Wine Cellar Incantation", "Tiny Sor Fragment" } },
            { 25, new string[] {"100 Gold", "Onrane", "Gold Cache", "Wine Cellar Incantation", "Two Tiny Sor Fragments" } },
            { 30, new string[] {"Onrane", "100 Gold", "Onrane Cache", "Wine Cellar Incantation", "Two Tiny Sor Fragments" }},
            { 50, new string[] {"Onrane Cache", "Medium Sor Fragment", "Wine Cellar Incantation", "Two Tiny Sor Fragments" } }
        };

        private ArenaState _arenaState;
        private CountDownState _countDown;

        private int _wave;
        private long _restTime;
        private long _time;
        private int _startingPlayers;
        private int _difficulty;
        private bool _isOpen;

        private List<IntPoint> _outerSpawn;
        private List<IntPoint> _centralSpawn;

        public static DeathArena Instance { get; private set; }
        public ArenaState CurrentState => _arenaState;

        public DeathArena(ProtoWorld proto, Client client = null)
            : base(proto)
        {
            Instance = this;
            _isOpen = true;
            WorldLoot.Add(new ItemLoot("Oryx's Arena Key", 0));
            _arenaState = ArenaState.NotStarted;
            _wave = 1;
        }

        protected override void Init()
        {
            base.Init();

            if (IsLimbo) return;

            InitArena();
        }

        private void InitArena()
        {
            // setup spawn regions
            _outerSpawn = new List<IntPoint>();
            _centralSpawn = new List<IntPoint>();
            var w = Map.Width;
            var h = Map.Height;
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {
                    if (Map[x, y].Region == TileRegion.Arena_Central_Spawn)
                        _centralSpawn.Add(new IntPoint(x, y));

                    if (Map[x, y].Region == TileRegion.Arena_Edge_Spawn)
                        _outerSpawn.Add(new IntPoint(x, y));
                }
        }

        public string ArenaStateCheck()
        {
            if(_arenaState == ArenaState.Ended)
            {
                return "Ended";
            }
            if (_arenaState == ArenaState.Start)
            {
                return "Start";
            }
            if (_arenaState == ArenaState.CountDown)
            {
                return "Counting";
            }
            if (_arenaState == ArenaState.Fight)
            {
                return "Fight";
            }
            if (_arenaState == ArenaState.Rest)
            {
                return "Rest";
            }
            if (_arenaState == ArenaState.Spawn)
            {
                return "Spawn";
            }
            if (_arenaState == ArenaState.Awaiting)
            {
                return "Waiting";
            }
            if (_arenaState == ArenaState.NotStarted)
            {
                return "Not Started";
            }
            return "Error.";
        }

        public override bool AllowedAccess(Client client)
        {
            return _isOpen;
        }

        public override World GetInstance(Client client)
        {
            var manager = client.Manager;

            // join existing open arena if possible
            foreach (var world in manager.Worlds.Values)
            {
                var da = world as DeathArena;
                if (world.IsLimbo || da == null || da._arenaState == ArenaState.Ended)
                    continue;

                return world;
            }

            var arena = Manager.AddWorld(
                new DeathArena(manager.Resources.Worlds[Name], client) { IsLimbo = false });
            Manager.Monitor.UpdateWorldInstance(World.DeathArena, arena);
            return arena;
        }

        private void SpawnEnemies()
        {
            var enemies = new List<string>();
            var r = new Random();

            for (int i = 0; i < Math.Ceiling((_wave + _difficulty) / 2f); i++)
                enemies.Add(_randomEnemies[r.Next(0, _randomEnemies.Length)]);

            foreach (string i in enemies)
            {
                var id = Manager.Resources.GameData.IdToObjectType[i];

                var pos = _outerSpawn[r.Next(0, _outerSpawn.Count)];
                var xloc = pos.X + 0.5f;
                var yloc = pos.Y + 0.5f;

                var enemy = Entity.Resolve(Manager, id);
                enemy.Move(xloc, yloc);
                EnterWorld(enemy);
            }
        }

        private void SpawnBosses()
        {
            var bosses = new List<string>();
            var r = new Random();

            for (int i = 0; i < 1; i++)
                bosses.Add(_randomBosses[_bossLevel][r.Next(0, _randomBosses[_bossLevel].Length)]);

            foreach (string i in bosses)
            {
                ushort id = Manager.Resources.GameData.IdToObjectType[i];

                var pos = _centralSpawn[r.Next(0, _centralSpawn.Count)];
                var xloc = pos.X + 0.5f;
                var yloc = pos.Y + 0.5f;

                var enemy = Entity.Resolve(Manager, id);
                enemy.Move(xloc, yloc);
                EnterWorld(enemy);
            }
        }

        public override void Tick(RealmTime time)
        {
            base.Tick(time);

            if (IsLimbo)
                return;
            if (Deleted)
            {
                LockPortal();
                return;
            }

            _time += time.ElapsedMsDelta;

            switch (_arenaState)
            {
                case ArenaState.NotStarted:
                    _arenaState = ArenaState.CountDown;
                    break;
                case ArenaState.CountDown:
                    Countdown(time);
                    break;
                case ArenaState.Start:
                    Start(time);
                    break;
                case ArenaState.Rest:
                    Rest(time);
                    break;
                case ArenaState.Spawn:
                    Spawn(time);
                    break;
                case ArenaState.Fight:
                    Fight(time);
                    break;
                case ArenaState.Awaiting:
                    WaitForPlayersToLeave(time);
                    break;
                case ArenaState.Ended:
                    break;
                default:
                    _arenaState = ArenaState.Start;
                    break;
            }
        }

        private void Countdown(RealmTime time)
        {
            if (_countDown == CountDownState.Notify60)
            {
                _countDown = CountDownState.Notify30;

                foreach (var w in Manager.Worlds.Values)
                    foreach (var p in w.Players.Values)
                        if (p.Owner == this)
                            p.SendInfo("Game starting in 60 seconds.");
                        else
                        {
                            p.SendError("<ANNOUNCEMENT> Oryx's Arena closing in 1 min. Head to the nexus to join!");
                            if (p.Owner is Nexus || p.Owner is Vault)
                            {
                                p.Client.SendPacket(new GlobalNotification
                                {
                                    Type = GlobalNotification.ADD_ARENA,
                                    Text = "{\"name\":\"Oryx Arena\",\"open\":true}"
                                });
                            }
                        }
            }

            if (_countDown == CountDownState.Notify30 && _time > 30000)
            {
                _countDown = CountDownState.StartGame;

                foreach (var w in Manager.Worlds.Values)
                    foreach (var p in w.Players.Values)
                        if (p.Owner == this)
                            p.SendInfo("Game starting in 30 seconds.");
                        else
                            p.SendError("<ANNOUNCEMENT> Oryx's Arena closing in 30 seconds. Head to the nexus to join!");
            }

            if (_countDown == CountDownState.StartGame && _time > 60000)
            {
                _countDown = CountDownState.Done;
                _arenaState = ArenaState.Start;
                _time = 0;
                _startingPlayers = Players.Count;
                _difficulty = Players.Count(p => p.Value.Level >= 15);

                Manager.Monitor.ClosePortal(World.DeathArena);

                foreach (var p in Manager.Worlds.Values.SelectMany(w => w.Players.Values).Where(p => p.Owner is Nexus || p.Owner is Vault))
                    p.Client.SendPacket(new GlobalNotification
                    {
                        Type = GlobalNotification.ADD_ARENA,
                        Text = "{\"name\":\"Oryx Arena\",\"open\":false}"
                    });
            }
        }

        private void WaitForPlayersToLeave(RealmTime time)
        {
            if (Players.Count == 0)
            {
                _arenaState = ArenaState.Ended;
                LockPortal();
            }

            if (!Enemies.Any(e => e.Value.ObjectDesc.Enemy && !e.Value.Spawned))
            {
                _wave++;
                _restTime = _time;
                _arenaState = ArenaState.Rest;

                if (_bossLevel + 1 < _changeBossLevel.Length &&
                    _changeBossLevel[_bossLevel + 1] <= _wave)
                    _bossLevel++;

                Rest(time, true);
            }
        }

        private void Start(RealmTime time)
        {
            _isOpen = false;
            _arenaState = ArenaState.Rest;
            Rest(time, true);
        }

        private void Rest(RealmTime time, bool recover = false)
        {
            if (recover)
            {
                foreach (var plr in Players.Values)
                {
                    plr.ApplyConditionEffect(ConditionEffectIndex.Healing, 5000);
                    if (plr.HasConditionEffect(ConditionEffects.Hexed))
                    {
                        plr.ApplyConditionEffect(new ConditionEffect()
                        {
                            Effect = ConditionEffectIndex.Speedy,
                            DurationMS = 0
                        });
                    }
                    plr.ApplyConditionEffect(Player.NegativeEffs);
                }

                BroadcastPacket(new ImminentArenaWave()
                {
                    CurrentRuntime = (int)_time,
                    Wave = _wave
                }, null);

                HandleWaveRewards();

                return;
            }

            if (_time - _restTime < 5000)
                return;

            _arenaState = ArenaState.Spawn;
        }

        private void Spawn(RealmTime time)
        {
            SpawnEnemies();
            SpawnBosses();
            _arenaState = ArenaState.Fight;
        }


        private void Fight(RealmTime time)
        {
            if (!Enemies.Any(e => e.Value.ObjectDesc.Enemy && !e.Value.Spawned && !e.Value.Name.Contains("Torii")))
            {
                _wave++;
                _restTime = _time;
                _arenaState = ArenaState.Rest;

                if (_bossLevel + 1 < _changeBossLevel.Length &&
                    _changeBossLevel[_bossLevel + 1] <= _wave)
                    _bossLevel++;

                Rest(time, true);
            }
        }

        private void HandleWaveRewards()
        {
            if (!_waveRewards.ContainsKey(_wave))
                return;

            // initialize reward items
            var gameData = Manager.Resources.GameData;
            var items = new List<Item>();
            foreach (var reward in _waveRewards[_wave])
            {
                ushort itemType;
                Item item = null;

                if (!gameData.IdToObjectType.TryGetValue(reward, out itemType))
                    continue;

                if (!gameData.Items.TryGetValue(itemType, out item))
                    continue;

                items.Add(item);
            }

            if (items.Count <= 0)
                return;

            // hand out rewards
            var r = new Random();
            foreach (var player in Players.Values.Where(p => !p.HasConditionEffect(ConditionEffects.Hidden)))  // no rewards for lurkers
            {
                var item = items[r.Next(0, items.Count)];
                var changes = player.Inventory.CreateTransaction();
                var slot = changes.GetAvailableInventorySlot(item);
                if (slot != -1)
                {
                    changes[slot] = item;
                    Inventory.Execute(changes);
                }
                else
                {
                    player.SendError("[Oryx's Arena] We were unable to give you a reward, your inventory is full ");
                }
            }
        }

        private void LockPortal()
        {
            var nexus = Manager.GetWorld(World.Nexus) as Nexus;
            Entity en = Entity.Resolve(Manager, "Locked Oryx's Arena Portal");
            en.Move(33, 9);
            nexus.EnterWorld(en);
        }

        public override int EnterWorld(Entity entity)
        {
            var ret = base.EnterWorld(entity);

            var p = entity as Player;
            if (p != null)
                p.SendInfo("Welcome to Oryx's Arena. Take caution, you can die here. ");

            return ret;
        }
    }
}