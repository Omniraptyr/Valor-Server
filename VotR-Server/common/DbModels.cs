using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common.resources;
using log4net;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace common
{
    public abstract class RedisObject
    {
        //Note do not modify returning buffer
        private Dictionary<RedisValue, KeyValuePair<byte[], bool>> _entries;

        protected void Init(IDatabase db, string key, string field = null)
        {
            Key = key;
            Database = db;

            if (field == null)
                _entries = db.HashGetAll(key)
                    .ToDictionary(
                        x => x.Name,
                        x => new KeyValuePair<byte[], bool>(x.Value, false));
            else
            {
                var entry = new[] { new HashEntry(field, db.HashGet(key, field)) };
                _entries = entry.ToDictionary(x => x.Name, 
                    x => new KeyValuePair<byte[], bool>(x.Value, false));
            }
        }

        public IDatabase Database { get; private set; }
        public string Key { get; private set; }

        public IEnumerable<RedisValue> AllKeys => _entries.Keys;

        public bool IsNull => _entries.Count == 0;

        protected byte[] GetValueRaw(RedisValue key)
        {
            if (!_entries.TryGetValue(key, out var val))
                return null;

            return (byte[]) val.Key?.Clone();
        }

        protected T GetValue<T>(RedisValue key, T def = default(T))
        {
            if (!_entries.TryGetValue(key, out var val) || val.Key == null)
                return def;

            if (typeof (T) == typeof (int))
                return (T) (object) int.Parse(Encoding.UTF8.GetString(val.Key));

            if (typeof (T) == typeof (uint))
                return (T) (object) uint.Parse(Encoding.UTF8.GetString(val.Key));

            if (typeof (T) == typeof (ushort))
                return (T) (object) ushort.Parse(Encoding.UTF8.GetString(val.Key));

            if (typeof (T) == typeof (bool))
                return (T) (object) (val.Key[0] != 0);

            if (typeof (T) == typeof (DateTime))
                return (T) (object) DateTime.FromBinary(BitConverter.ToInt64(val.Key, 0));

            if (typeof (T) == typeof (byte[]))
                return (T) (object) val.Key;

            if (typeof (T) == typeof (ushort[]))
            {
                var ret = new ushort[val.Key.Length/2];
                Buffer.BlockCopy(val.Key, 0, ret, 0, val.Key.Length);
                return (T) (object) ret;
            }

            if (typeof (T) == typeof (int[]) ||
                typeof (T) == typeof (uint[]))
            {
                var ret = new int[val.Key.Length/4];
                Buffer.BlockCopy(val.Key, 0, ret, 0, val.Key.Length);
                return (T) (object) ret;
            }

            if (typeof (T) == typeof (string))
                return (T) (object) Encoding.UTF8.GetString(val.Key);

            throw new NotSupportedException();
        }

        protected void SetValue<T>(RedisValue key, T val)
        {
            byte[] buff;
            if (typeof (T) == typeof (int) || typeof (T) == typeof (uint) ||
                typeof (T) == typeof (ushort) || typeof (T) == typeof (string))
                buff = Encoding.UTF8.GetBytes(val.ToString());

            else if (typeof (T) == typeof (bool))
                buff = new[] {(byte) ((bool) (object) val ? 1 : 0)};

            else if (typeof (T) == typeof (DateTime))
                buff = BitConverter.GetBytes(((DateTime) (object) val).ToBinary());

            else if (typeof (T) == typeof (byte[]))
                buff = (byte[]) (object) val;

            else if (typeof (T) == typeof (ushort[]))
            {
                var v = (ushort[]) (object) val;
                buff = new byte[v.Length*2];
                Buffer.BlockCopy(v, 0, buff, 0, buff.Length);
            }

            else if (typeof (T) == typeof (int[]) ||
                     typeof (T) == typeof (uint[]))
            {
                var v = (int[]) (object) val;
                buff = new byte[v.Length*4];
                Buffer.BlockCopy(v, 0, buff, 0, buff.Length);
            }

            else
                throw new NotSupportedException();

            if (!_entries.ContainsKey(Key) || _entries[Key].Key == null || !buff.SequenceEqual(_entries[Key].Key))
                _entries[key] = new KeyValuePair<byte[], bool>(buff, true);
        }

        private List<HashEntry> _update;

        public Task FlushAsync(ITransaction transaction = null)
        {
            ReadyFlush();
            return transaction == null ?
                Database.HashSetAsync(Key, _update.ToArray()) :
                transaction.HashSetAsync(Key, _update.ToArray());
        }

        private void ReadyFlush()
        {
            if (_update == null)
                _update = new List<HashEntry>();
            _update.Clear();

            foreach (var name in _entries.Keys)
                if (_entries[name].Value)
                    _update.Add(new HashEntry(name, _entries[name].Key));

            foreach (var update in _update)
                _entries[update.Name] = new KeyValuePair<byte[], bool>(_entries[update.Name].Key, false);
        }

        /*public async Task ReloadAsync(ITransaction trans = null, string field = null)
        {
            if (field != null && _entries != null)
            {
                var tf = trans != null ? 
                    trans.HashGetAsync(Key, field) :
                    Database.HashGetAsync(Key, field);

                try
                {
                    await tf;
                    _entries[field] = new KeyValuePair<byte[], bool>(
                        tf.Result, false);
                }
                catch { }
                return;
            }

            var t = trans != null ?
                trans.HashGetAllAsync(Key) :
                Database.HashGetAllAsync(Key);

            try
            {
                await t;
                _entries = t.Result.ToDictionary(
                    x => x.Name, x => new KeyValuePair<byte[], bool>(x.Value, false));
            }
            catch { }
        }*/

        public void Reload(string field = null)
        {
            if (field != null && _entries != null)
            {
                _entries[field] = new KeyValuePair<byte[], bool>(
                    Database.HashGet(Key, field), false);
                return;
            }

            _entries = Database.HashGetAll(Key)
                .ToDictionary(
                    x => x.Name,
                    x => new KeyValuePair<byte[], bool>(x.Value, false));
        }
    }

    public class DbLoginInfo
    {
        private readonly IDatabase _db;

        internal DbLoginInfo(IDatabase db, string uuid)
        {
            _db = db;
            UUID = uuid;
            var json = (string) db.HashGet("logins", uuid.ToUpperInvariant());
            if (json == null)
                IsNull = true;
            else
                JsonConvert.PopulateObject(json, this);
        }

        [JsonIgnore]
        public string UUID { get; }

        [JsonIgnore]
        public bool IsNull { get; }

        public string Salt { get; set; }
        public string HashedPassword { get; set; }
        public int AccountId { get; set; }

        public void Flush()
        {
            _db.HashSet("logins", UUID.ToUpperInvariant(), JsonConvert.SerializeObject(this));
        }
    }

    public class DbAccount : RedisObject
    {
        public DbAccount(IDatabase db, int accId, string field = null)
        {
            AccountId = accId;
            Init(db, "account." + accId, field);

            if (field != null)
                return;

            if (DiscordId != null)
                DiscordRank = (int) db.HashGet("discordRank", DiscordId);
            
            var time = Utils.FromUnixTimestamp(BanLiftTime);
            if (!Banned || (BanLiftTime <= -1 || time > DateTime.UtcNow)) return;
            Banned = false;
            BanLiftTime = 0;
            FlushAsync();
        }

        public int AccountId { get; }
        public int DiscordRank { get; }

        public int AccountIdOverride
        {
            get => GetValue<int>("accountIdOverride");
            set => SetValue("accountIdOverride", value);
        }
        public int AccountIdOverrider { get; set; }
        
        internal string LockToken { get; set; }

        public string UUID
        {
            get => GetValue<string>("uuid");
            set => SetValue("uuid", value);
        }

        public string Name
        {
            get => GetValue<string>("name");
            set => SetValue("name", value);
        }

        public bool Admin
        {
            get => GetValue<bool>("admin");
            set => SetValue("admin", value);
        }

        public bool NameChosen
        {
            get => GetValue<bool>("nameChosen");
            set => SetValue("nameChosen", value);
        }

        public bool Verified
        {
            get => GetValue<bool>("verified");
            set => SetValue("verified", value);
        }

        public bool AgeVerified
        {
            get => GetValue<bool>("ageVerified");
            set => SetValue("ageVerified", value);
        }

        public bool FirstDeath
        {
            get => GetValue<bool>("firstDeath");
            set => SetValue("firstDeath", value);
        }

        public int PetYardType
        {
            get => GetValue<int>("petYardType");
            set => SetValue("petYardType", value);
        }

        public int GuildId
        {
            get => GetValue<int>("guildId");
            set => SetValue("guildId", value);
        }

        public int GuildRank
        {
            get => GetValue<int>("guildRank");
            set => SetValue("guildRank", value);
        }

        public int GuildFame
        {
            get => GetValue<int>("guildFame");
            set => SetValue("guildFame", value);
        }

        public int VaultCount
        {
            get => GetValue<int>("vaultCount");
            set => SetValue("vaultCount", value);
        }

        public ushort[] Gifts
        {
            get => GetValue<ushort[]>("gifts") ?? new ushort[0];
            set => SetValue("gifts", value);
        }

        public int MaxCharSlot
        {
            get => GetValue<int>("maxCharSlot");
            set => SetValue("maxCharSlot", value);
        }

        public DateTime RegTime
        {
            get => GetValue<DateTime>("regTime");
            set => SetValue("regTime", value);
        }

        public bool Guest
        {
            get => GetValue<bool>("guest");
            set => SetValue("guest", value);
        }

        public int Elite
        {
            get => GetValue<int>("elite");
            set => SetValue("elite", value);
        }

        public int Credits
        {
            get => GetValue<int>("credits");
            set => SetValue("credits", value);
        }

        public int Onrane
        {
            get => GetValue<int>("onrane");
            set => SetValue("onrane", value);
        }

        public int Kantos
        {
            get => GetValue<int>("kantos");
            set => SetValue("kantos", value);
        }

        public int TotalOnrane
        {
            get => GetValue<int>("totalOnrane");
            set => SetValue("totalOnrane", value);
        }

        public int TotalKantos
        {
            get => GetValue<int>("totalKantos");
            set => SetValue("totalKantos", value);
        }

        public int RaidToken
        {
            get => GetValue<int>("raidToken");
            set => SetValue("raidToken", value);
        }

        public int SorStorage
        {
            get => GetValue<int>("sorStorage");
            set => SetValue("sorStorage", value);
        }

        public int BronzeLootbox
        {
            get => GetValue<int>("lootBox1");
            set => SetValue("lootBox1", value);
        }
        public int SilverLootbox
        {
            get => GetValue<int>("lootBox2");
            set => SetValue("lootBox2", value);
        }
        public int GoldLootbox
        {
            get => GetValue<int>("lootBox3");
            set => SetValue("lootBox3", value);
        }
        public int EliteLootbox
        {
            get => GetValue<int>("lootBox4");
            set => SetValue("lootBox4", value);
        }
        public int PremiumLootbox
        {
            get => GetValue<int>("lootbox5");
            set => SetValue("lootbox5", value);
        }

        public int TotalCredits
        {
            get => GetValue<int>("totalCredits");
            set => SetValue("totalCredits", value);
        }

        public bool Striked
        {
            get => GetValue<bool>("striked");
            set => SetValue("striked", value);
        }

        public int Fame
        {
            get => GetValue<int>("fame");
            set => SetValue("fame", value);
        }

        public int TotalFame
        {
            get => GetValue<int>("totalFame");
            set => SetValue("totalFame", value);
        }

        public int Tokens
        {
            get => GetValue<int>("tokens");
            set => SetValue("tokens", value);
        }

        public int TotalTokens
        {
            get => GetValue<int>("totalTokens");
            set => SetValue("totalTokens", value);
        }

        public int NextCharId
        {
            get => GetValue<int>("nextCharId");
            set => SetValue("nextCharId", value);
        }

        public int LegacyRank
        {
            get => GetValue<int>("rank");
            set => SetValue("rank", value);
        }

        public ushort[] Skins
        {
            get => GetValue<ushort[]>("skins") ?? new ushort[0];
            set => SetValue("skins", value);
        }

        public int[] LockList
        {
            get => GetValue<int[]>("lockList") ?? new int[0];
            set => SetValue("lockList", value);
        }

        public int[] IgnoreList
        {
            get => GetValue<int[]>("ignoreList") ?? new int[0];
            set => SetValue("ignoreList", value);
        }

        public bool Banned
        {
            get => GetValue<bool>("banned");
            set => SetValue("banned", value);
        }

        public string Notes
        {
            get => GetValue<string>("notes");
            set => SetValue("notes", value);
        }

        public bool Hidden
        {
            get => GetValue<bool>("hidden");
            set => SetValue("hidden", value);
        }

        public int GlowColor
        {
            get => GetValue<int>("glow");
            set => SetValue("glow", value);
        }

        public string PassResetToken
        {
            get => GetValue<string>("passResetToken");
            set => SetValue("passResetToken", value);
        }

        public string IP
        {
            get => GetValue<string>("ip");
            set => SetValue("ip", value);
        }

        public int[] PetList
        {
            get => GetValue<int[]>("petList") ?? new int[0];
            set => SetValue("petList", value);
        }

        public uint LastMarketId
        {
            get => GetValue<uint>("lastMarketId");
            set => SetValue("lastMarketId", value);
        }

        public int BanLiftTime
        {
            get => GetValue<int>("banLiftTime");
            set => SetValue("banLiftTime", value);
        }

        public List<string> Emotes
        {
            get => GetValue<string>("emotes")?.CommaToArray<string>()?.ToList() ?? new List<string>();
            set => SetValue("emotes", value?.ToArray().ToCommaSepString() ?? String.Empty);
        }

        public Int32 LastSeen
        {
            get => GetValue<Int32>("lastSeen");
            set => SetValue("lastSeen", value);
        }

        public int Size
        {
            get => GetValue<int>("size");
            set => SetValue("size", value);
        }

        public bool RankManager
        {
            get => GetValue<bool>("rankManager");
            set => SetValue("rankManager", value);
        }

        public string DiscordId
        {
            get => GetValue<string>("discordId");
            set => SetValue("discordId", value);
        }

        public int Rank => DiscordRank > LegacyRank ? DiscordRank : LegacyRank;

        public PrivateMessages PrivateMessages
        {
            get
            {
                var pMessages = GetValue<string>("privateMessages");
                return pMessages != null
                    ? Utils.FromJson<PrivateMessages>(pMessages)
                    : null;
            }
            set => SetValue("privateMessages", value.ToJson());
        }

        public Task AddPrivateMessage(int senderId, string subject, string message)
        {
            var messages = PrivateMessages ?? new PrivateMessages(AccountId, new List<PrivateMessages.PrivateMessage>());
            if (messages.NeedsFix())
                messages.FixFromOldBuild(this);
            var msg = new PrivateMessages.PrivateMessage(senderId, AccountId, subject, message, DateTime.UtcNow.ToUnixTimestamp());
            messages.Messages.Add(msg);
            PrivateMessages = messages;
            return FlushAsync();
        }

        public void RefreshLastSeen()
        {
            LastSeen = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }

    public struct DbClassStatsEntry
    {
        public int BestLevel;
        public int BestFame;
    }

    public class DbClassStats : RedisObject
    {
        public DbAccount Account { get; }

        public DbClassStats(DbAccount acc, ushort? type = null)
        {
            Account = acc;
            Init(acc.Database, "classStats." + acc.AccountId, type?.ToString());
        }

        public void Unlock(ushort type)
        {
            var field = type.ToString();
            string json = GetValue<string>(field);
            if (json == null)
                SetValue(field, JsonConvert.SerializeObject(new DbClassStatsEntry
                {
                    BestLevel = 0,
                    BestFame = 0
                }));
        }

        public void Update(DbChar character)
        {
            var field = character.ObjectType.ToString();
            var finalFame = Math.Max(character.Fame, character.FinalFame);
            string json = GetValue<string>(field);
            if (json == null)
                SetValue(field, JsonConvert.SerializeObject(new DbClassStatsEntry
                {
                    BestLevel = character.Level,
                    BestFame = finalFame
                }));
            else
            {
                var entry = JsonConvert.DeserializeObject<DbClassStatsEntry>(json);
                if (character.Level > entry.BestLevel)
                    entry.BestLevel = character.Level;
                if (finalFame > entry.BestFame)
                    entry.BestFame = finalFame;
                SetValue(field, JsonConvert.SerializeObject(entry));
            }
        }

        public DbClassStatsEntry this[ushort type]
        {
            get
            {
                string v = GetValue<string>(type.ToString());
                if (v != null) return JsonConvert.DeserializeObject<DbClassStatsEntry>(v);
                return default(DbClassStatsEntry);
            }
            set => SetValue(type.ToString(), JsonConvert.SerializeObject(value));
        }

    }

    public class DbChar : RedisObject
    {
        public DbAccount Account { get; }
        public int CharId { get; }

        public DbChar(DbAccount acc, int charId)
        {
            Account = acc;
            CharId = charId;
            Init(acc.Database, "char." + acc.AccountId + "." + charId);
        }

        public ushort ObjectType
        {
            get => GetValue<ushort>("charType");
            set => SetValue("charType", value);
        }

        public int Level
        {
            get => GetValue<int>("level");
            set => SetValue("level", value);
        }

        public int Experience
        {
            get => GetValue<int>("exp");
            set => SetValue("exp", value);
        }

        public int Fame
        {
            get => GetValue<int>("fame");
            set => SetValue("fame", value);
        }

        public int FinalFame
        {
            get => GetValue<int>("finalFame");
            set => SetValue("finalFame", value);
        }

        public ushort[] Items
        {
            get => GetValue<ushort[]>("items");
            set => SetValue("items", value);
        }

        public int HP
        {
            get => GetValue<int>("hp");
            set => SetValue("hp", value);
        }

        public int MP
        {
            get => GetValue<int>("mp");
            set => SetValue("mp", value);
        }

        public int[] Stats
        {
            get => GetValue<int[]>("stats");
            set => SetValue("stats", value);
        }

        public int Tex1
        {
            get => GetValue<int>("tex1");
            set => SetValue("tex1", value);
        }

        public int Tex2
        {
            get => GetValue<int>("tex2");
            set => SetValue("tex2", value);
        }

        public string Effect
        {
            get => GetValue<string>("effect");
            set => SetValue("effect", value);
        }

        public bool MarksEnabled
        {
            get => GetValue<bool>("marksEnabled");
            set => SetValue("marksEnabled", value);
        }

        public bool AscensionEnabled
        {
            get => GetValue<bool>("ascensionEnabled");
            set => SetValue("ascensionEnabled", value);
        }

        public int Mark
        {
            get => GetValue<int>("mark");
            set => SetValue("mark", value);
        }

        public int Node1
        {
            get => GetValue<int>("node1");
            set => SetValue("node1", value);
        }

        public int Node2
        {
            get => GetValue<int>("node2");
            set => SetValue("node2", value);
        }

        public int Node3
        {
            get => GetValue<int>("node3");
            set => SetValue("node3", value);
        }

        public int Node4
        {
            get => GetValue<int>("node4");
            set => SetValue("node4", value);
        }

        public int Skin
        {
            get => GetValue<int>("skin");
            set => SetValue("skin", value);
        }

        public int PetId
        {
            get => GetValue<int>("petId");
            set => SetValue("petId", value);
        }

        public byte[] FameStats
        {
            get => GetValue<byte[]>("fameStats");
            set => SetValue("fameStats", value);
        }

        public DateTime CreateTime
        {
            get => GetValue<DateTime>("createTime");
            set => SetValue("createTime", value);
        }

        public DateTime LastSeen
        {
            get => GetValue<DateTime>("lastSeen");
            set => SetValue("lastSeen", value);
        }

        public bool Dead
        {
            get => GetValue<bool>("dead");
            set => SetValue("dead", value);
        }

        public int HealthStackCount
        {
            get => GetValue<int>("hpPotCount");
            set => SetValue("hpPotCount", value);
        }

        public int MagicStackCount
        {
            get => GetValue<int>("mpPotCount");
            set => SetValue("mpPotCount", value);
        }

        public bool HasBackpack
        {
            get => GetValue<bool>("hasBackpack");
            set => SetValue("hasBackpack", value);
        }

        public int XPBoostTime
        {
            get => GetValue<int>("xpBoost");
            set => SetValue("xpBoost", value);
        }

        //ReSharper disable InconsistentNaming
        public int LDBoostTime
        {
            get => GetValue<int>("ldBoost");
            set => SetValue("ldBoost", value);
        }

        public int LTBoostTime
        {
            get => GetValue<int>("ltBoost");
            set => SetValue("ltBoost", value);
        }
    }

    public class DbDeath : RedisObject
    {
        public DbAccount Account { get; }
        public int CharId { get; }

        public DbDeath(DbAccount acc, int charId)
        {
            Account = acc;
            CharId = charId;
            Init(acc.Database, "death." + acc.AccountId + "." + charId);
        }

        public ushort ObjectType
        {
            get => GetValue<ushort>("objType");
            set => SetValue("objType", value);
        }

        public int Level
        {
            get => GetValue<int>("level");
            set => SetValue("level", value);
        }

        public int TotalFame
        {
            get => GetValue<int>("totalFame");
            set => SetValue("totalFame", value);
        }

        public string Killer
        {
            get => GetValue<string>("killer");
            set => SetValue("killer", value);
        }

        public bool FirstBorn
        {
            get => GetValue<bool>("firstBorn");
            set => SetValue("firstBorn", value);
        }

        public DateTime DeathTime
        {
            get => GetValue<DateTime>("deathTime");
            set => SetValue("deathTime", value);
        }
    }

    public struct DbNewsEntry
    {
        [JsonIgnore] public DateTime Date;
        public string Icon;
        public string Title;
        public string Text;
        public string Link;
    }

    public class DbNews // TODO. Check later, range results might be bugged...
    {
        public DbNews(IDatabase db, int count)
        {
            Entries = db.SortedSetRangeByRankWithScores("news", 0, 10)
                .Select(x =>
                {
                    var ret = JsonConvert.DeserializeObject<DbNewsEntry>(
                        Encoding.UTF8.GetString(x.Element));
                    ret.Date = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(x.Score);
                    return ret;
                }).ToArray();
        }

        public DbNewsEntry[] Entries { get; }
    }

    public class DbVault : RedisObject
    {
        public DbAccount Account { get; }

        public DbVault(DbAccount acc)
        {
            Account = acc;
            Init(acc.Database, "vault." + acc.AccountId);
        }

        public ushort[] this[int index]
        {
            get => GetValue<ushort[]>("vault." + index) ?? 
                   Enumerable.Repeat((ushort)0xffff, 8).ToArray();
            set => SetValue("vault." + index, value);
        }
    }

    public abstract class RInventory : RedisObject
    {
        public string Field { get; protected set; }

        public ushort[] Items
        {
            get => GetValue<ushort[]>(Field) ?? Enumerable.Repeat((ushort)0xffff, 20).ToArray();
            set => SetValue(Field, value);
        }
    }

    public class DbVaultSingle : RInventory
    {
        public DbVaultSingle(DbAccount acc, int vaultIndex)
        {
            Field = "vault." + vaultIndex;
            Init(acc.Database, "vault." + acc.AccountId, Field);

            var items = GetValue<ushort[]>(Field);
            if (items != null)
                return;

            var trans = Database.CreateTransaction();
            SetValue(Field, Items);
            FlushAsync(trans);
            trans.Execute(CommandFlags.FireAndForget);
        }
    }
    
    public class DbCharInv : RInventory
    {
        public DbCharInv(DbAccount acc, int charId)
        {
            Field = "items";
            Init(acc.Database, "char." + acc.AccountId + "." + charId, Field);
        }
    }

    public struct DbLegendEntry
    {
        public readonly int AccId;
        public readonly int ChrId;

        public DbLegendEntry(int accId, int chrId)
        {
            AccId = accId;
            ChrId = chrId;
        }
    }

    public static class DbLegend
    {
        private const int MaxListings = 20;
        private const int MaxGlowingRank = 10;
        private static readonly Dictionary<string, TimeSpan> TimeSpans = new Dictionary<string, TimeSpan>
        {
            {"week", TimeSpan.FromDays(7) },
            {"month", TimeSpan.FromDays(30) },
            {"all", TimeSpan.MaxValue }
        };

        public static void Clean(IDatabase db)
        {
            // remove legend entries that expired
            foreach (var span in TimeSpans)
            {
                if (span.Value == TimeSpan.MaxValue)
                {
                    // bound legend by count
                    db.SortedSetRemoveRangeByRankAsync($"legends:{span.Key}:byFame",
                        0, -MaxListings - 1, CommandFlags.FireAndForget);
                    continue;
                }

                // bound legend by time
                var outdated = db.SortedSetRangeByScore(
                    $"legends:{span.Key}:byTimeOfDeath", 0,
                    DateTime.UtcNow.ToUnixTimestamp());
                
                var trans = db.CreateTransaction();
                trans.SortedSetRemoveAsync($"legends:{span.Key}:byFame", outdated, CommandFlags.FireAndForget);
                trans.SortedSetRemoveAsync($"legends:{span.Key}:byTimeOfDeath", outdated, CommandFlags.FireAndForget);
                trans.ExecuteAsync(CommandFlags.FireAndForget);
            }

            // refresh legend hash
            db.KeyDeleteAsync("legend", CommandFlags.FireAndForget);
            foreach (var span in TimeSpans)
            {
                var legendTask = db.SortedSetRangeByRankAsync($"legends:{span.Key}:byFame", 
                    0, MaxGlowingRank - 1, Order.Descending);
                legendTask.ContinueWith(r =>
                {
                    var trans = db.CreateTransaction();
                    foreach (var e in r.Result)
                    {
                        var accId = BitConverter.ToInt32(e, 0);
                        trans.HashSetAsync("legend", accId, "",
                            flags: CommandFlags.FireAndForget);
                    }
                    trans.ExecuteAsync(CommandFlags.FireAndForget);
                });
            }

            db.StringSetAsync("legends:updateTime", DateTime.UtcNow.ToUnixTimestamp(),
                flags: CommandFlags.FireAndForget);
        }

        public static void Insert(IDatabase db,
            int accId, int chrId, int totalFame)
        {
            var buff = new byte[8];
            Buffer.BlockCopy(BitConverter.GetBytes(accId), 0, buff, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(chrId), 0, buff, 4, 4);

            // add entry to each legends list
            var trans = db.CreateTransaction();
            foreach (var span in TimeSpans)
            {
                trans.SortedSetAddAsync($"legends:{span.Key}:byFame", 
                    buff, totalFame, CommandFlags.FireAndForget);

                if (span.Value == TimeSpan.MaxValue)
                    continue;

                double t = DateTime.UtcNow.Add(span.Value).ToUnixTimestamp();
                trans.SortedSetAddAsync($"legends:{span.Key}:byTimeOfDeath", 
                    buff, t, CommandFlags.FireAndForget);
            }
            trans.ExecuteAsync();

            // add legend if character falls within MaxGlowingRank
            foreach (var span in TimeSpans)
            {
                db.SortedSetRankAsync($"legends:{span.Key}:byFame", buff, Order.Descending)
                    .ContinueWith(r =>
                    {
                        if (r.Result >= MaxGlowingRank)
                            return;

                        db.HashSetAsync("legend", accId, "",
                            flags: CommandFlags.FireAndForget);
                    });
            }

            db.StringSetAsync("legends:updateTime", DateTime.UtcNow.ToUnixTimestamp(),
                flags: CommandFlags.FireAndForget);
        }

        public static DbLegendEntry[] Get(IDatabase db, string timeSpan)
        {
            if (!TimeSpans.ContainsKey(timeSpan))
                return new DbLegendEntry[0];
            
            var listings = db.SortedSetRangeByRank(
                $"legends:{timeSpan}:byFame", 
                0, MaxListings - 1, Order.Descending);

            return listings
                .Select(e => new DbLegendEntry(
                    BitConverter.ToInt32(e, 0),
                    BitConverter.ToInt32(e, 4)))
                .ToArray();
        }
    }

    public class DbGuild : RedisObject
    {
        internal readonly object MemberLock; // maybe use redis locking?

        internal DbGuild(IDatabase db, int id)
        {
            MemberLock = new object();

            Id = id;
            Init(db, "guild." + id);
        }

        public DbGuild(DbAccount acc)
        {
            MemberLock = new object();

            Id = acc.GuildId;
            Init(acc.Database, "guild." + Id);
        }

        public int Id { get; }

        public string Name
        {
            get => GetValue<string>("name");
            set => SetValue("name", value);
        }

        public int Level
        {
            get => GetValue<int>("level");
            set => SetValue("level", value);
        }

        public int Fame
        {
            get => GetValue<int>("fame");
            set => SetValue("fame", value);
        }

        public int TotalFame
        {
            get => GetValue<int>("totalFame");
            set => SetValue("totalFame", value);
        }

        public int[] Members // list of member account id's
        {
            get => GetValue<int[]>("members") ?? new int[0];
            set => SetValue("members", value);
        }

        public int[] Allies // list of ally guild id's UNIMPLEMENTED
        {
            get => GetValue<int[]>("allies") ?? new int[0];
            set => SetValue("allies", value);
        }

        public string Board
        {
            get => GetValue<string>("board") ?? "";
            set => SetValue("board", value);
        }
    }

    public class DbIpInfo
    {
        private readonly IDatabase _db;

        internal DbIpInfo(IDatabase db, string ip)
        {
            _db = db;
            IP = ip;
            var json = (string) db.HashGet("ips", ip);
            if (json == null)
                IsNull = true;
            else
                JsonConvert.PopulateObject(json, this);
        }

        [JsonIgnore]
        public string IP { get; }

        [JsonIgnore]
        public bool IsNull { get; }

        public HashSet<int> Accounts { get; set; }
        public bool Banned { get; set; }
        public string Notes { get; set; }

        public void Flush()
        {
            _db.HashSetAsync("ips", IP, JsonConvert.SerializeObject(this));
        }
    }

    public class DbPetAbility
    {
        private readonly DbPet _owner;
        private readonly string _typeKey;
        private readonly string _levelKey;
        private readonly string _powerKey;

        public DbPetAbility(DbPet owner, int abilityId)
        {
            _owner = owner;
            _typeKey = $"A{abilityId}Type";
            _levelKey = $"A{abilityId}Level";
            _powerKey = $"A{abilityId}Power";
        }

        public PAbility Type
        {
            get => (PAbility)_owner.GetValue(_typeKey);
            set => _owner.SetValue(_typeKey, (int)value);
        }

        public int Level
        {
            get => _owner.GetValue(_levelKey);
            set => _owner.SetValue(_levelKey, value);
        }

        public int Power
        {
            get => _owner.GetValue(_powerKey);
            set => _owner.SetValue(_powerKey, value);
        }
    }

    public class DbPet : RedisObject
    {
        public const int NumAbilities = 3;

        public DbAccount Account { get; }
        public int PetId { get; set; }
        public DbPetAbility[] Ability { get; }

        public DbPet(DbAccount acc, int petId)
        {
            Account = acc;
            PetId = petId;

            Init(acc.Database, $"pet.{acc.AccountId}.{petId}");

            Ability = new DbPetAbility[NumAbilities];
            for (var i = 0; i < NumAbilities; i++)
                Ability[i] = new DbPetAbility(this, i);
        }

        public ushort ObjectType
        {
            get => GetValue<ushort>("objType");
            set => SetValue<ushort>("objType", value);
        }

        public PRarity Rarity
        {
            get => (PRarity)GetValue<ushort>("rarity");
            set => SetValue<ushort>("rarity", (ushort)value);
        }

        public int MaxLevel
        {
            get => GetValue<int>("maxLevel");
            set => SetValue<int>("maxLevel", value);
        }

        internal int GetValue(string key)
        {
            return GetValue<int>(key);
        }

        internal void SetValue(string key, int value)
        {
            SetValue<int>(key, value);
        }
    }
    
    public class PlayerShopItem : ISellableItem
    {
        public uint Id { get; }
        public ushort ItemId { get; }
        public int Price { get; }
        public int InsertTime { get; }
        public int AccountId { get; }
        public int Count => -1;

        private bool _lastItem;

        public PlayerShopItem(uint id, ushort itemId, int price, int time, int accId)
        {
            Id = id;
            ItemId = itemId;
            Price = price;
            InsertTime = time;
            AccountId = accId;
        }

        public bool IsLastMarketedItem(uint lastMarketId)
        {
            return _lastItem = lastMarketId == Id;
        }

        public void Write(NWriter wtr)
        {
            wtr.Write(Id);
            wtr.Write(ItemId);
            wtr.Write(Price);
            wtr.Write(InsertTime);
            wtr.Write(Count);
            wtr.Write(_lastItem);
        }
    }

    public class DbMarket
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DbMarket));

        private static readonly object ListLock = new object();

        private readonly List<PlayerShopItem> _entries;

        private readonly IDatabase _db;
        private readonly string _key;
        

        public DbMarket(IDatabase db)
        {
            _db = db;
            _key = "market";

            var entries = db.HashGetAll(_key)
                .Select(x => new PlayerShopItem(
                    BitConverter.ToUInt32(x.Value, 0),
                    BitConverter.ToUInt16(x.Value, 4),
                    BitConverter.ToInt32(x.Value, 6),
                    BitConverter.ToInt32(x.Value, 10),
                    BitConverter.ToInt32(x.Value, 14)))
                .OrderBy(x => x.InsertTime);

            _entries = new List<PlayerShopItem>(entries);
        }

        public Task<bool> InsertAsync(PlayerShopItem shopItem, ITransaction transaction = null)
        {
            var trans = transaction ?? _db.CreateTransaction();

            var buff = new byte[18];
            Buffer.BlockCopy(BitConverter.GetBytes(shopItem.Id), 0, buff, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(shopItem.ItemId), 0, buff, 4, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(shopItem.Price), 0, buff, 6, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(shopItem.InsertTime), 0, buff, 10, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(shopItem.AccountId), 0, buff, 14, 4);

            trans.AddCondition(Condition.HashNotExists(_key, shopItem.Id));
            var task = trans.HashSetAsync(_key, shopItem.Id, buff)
                .ContinueWith(t => Item2List(shopItem, t, true));

            task.ContinueWith(e =>
                    Log.Error(e.Exception.InnerException.ToString()),
                    TaskContinuationOptions.OnlyOnFaulted);

            if (transaction == null)
                trans.ExecuteAsync();

            return task;
        }

        public Task<bool> RemoveAsync(PlayerShopItem shopItem, ITransaction transaction = null)
        {
            var trans = transaction ?? _db.CreateTransaction();

            trans.AddCondition(Condition.HashExists(_key, shopItem.Id));
            var task = trans.HashDeleteAsync(_key, shopItem.Id)
                .ContinueWith(t => Item2List(shopItem, t, false));

            task.ContinueWith(e =>
                    Log.Error(e.Exception.InnerException.ToString()),
                    TaskContinuationOptions.OnlyOnFaulted);

            if (transaction == null)
                trans.ExecuteAsync();

            return task;
        }
        
        private bool Item2List(PlayerShopItem shopItem, Task<bool> t, bool add)
        {
            var success = !t.IsCanceled && t.Result;
            if (success)
            {
                using (TimedLock.Lock(ListLock))
                {
                    if (add)
                        _entries.Add(shopItem);
                    else
                        _entries.Remove(shopItem);
                }
            }

            return success;
        }

        public PlayerShopItem GetById(uint id)
        {
            using (TimedLock.Lock(ListLock))
            {
                return _entries.SingleOrDefault(e => e.Id == id);
            }
        }

        public PlayerShopItem[] GetAll()
        {
            using (TimedLock.Lock(ListLock))
            {
                return _entries.ToArray();
            }
        }
    }

    public class DbTinker
    {
        private const string KEY = "tinkerQuests";

        private static readonly ILog log = LogManager.GetLogger(typeof(DbTinker));
        private static readonly object listLock = new object();

        private readonly List<Tinker> entries; 
        private readonly IDatabase db;

        public DbTinker(IDatabase db)
        {
            this.db = db;
            entries = new List<Tinker>(db.HashGetAll(KEY).Select(x => Tinker.Load(BitConverter.ToUInt32(x.Value, 0), Encoding.UTF8.GetString(x.Value, 4, ((byte[])x.Value).Length - 4))));
        }

        public Task<bool> InsertAsync(Tinker quest, ITransaction transaction = null)
        {
            var trans = transaction ?? db.CreateTransaction();

            var buff = new byte[4 + quest.ByteLength];
            Buffer.BlockCopy(BitConverter.GetBytes(quest.DbId), 0, buff, 0, 4);
            Buffer.BlockCopy(quest.Bytes, 0, buff, 4, quest.ByteLength);

            trans.AddCondition(Condition.HashNotExists(KEY, quest.DbId));
            var task = trans.HashSetAsync(KEY, quest.DbId, buff)
                .ContinueWith(t => UpdateList(quest, t, true));

            task.ContinueWith(e =>
                    log.Error(e.Exception.InnerException.ToString()),
                    TaskContinuationOptions.OnlyOnFaulted);

            if (transaction == null)
                trans.ExecuteAsync();

            return task;
        }

        public async void UpdateAsync(Tinker quest, ITransaction transaction = null)
        {
            try
            {
                await DeleteAsync(quest, transaction);
                await InsertAsync(quest, transaction);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private Task<bool> DeleteAsync(Tinker quest, ITransaction transaction = null)
        {
            var trans = transaction ?? db.CreateTransaction();

            trans.AddCondition(Condition.HashExists(KEY, quest.DbId));
            var task = trans.HashDeleteAsync(KEY, quest.DbId)
                .ContinueWith(t => UpdateList(quest, t, false));
            task.ContinueWith(e =>
                log.Error(e.Exception.InnerException.ToString()),
                TaskContinuationOptions.OnlyOnFaulted);

            if (transaction == null)
                trans.ExecuteAsync();

            return task;
        }

        private bool UpdateList(Tinker quest, Task<bool> task, bool add)
        {
            if (!(!task.IsCanceled && task.Result)) return false;
            using (TimedLock.Lock(listLock))
            {
                if (add)
                    entries.Add(quest);
                else
                    entries.Remove(quest);
            }
            return true;
        }

        public Tinker GetQuestForAccount(int accountId)
        {
            using (TimedLock.Lock(listLock))
            {
                return entries.FirstOrDefault(_ => _.OwnerId == accountId);
            }
        }

        public Tinker GenerateNew(DbAccount account)
        {
            var tinker = new Tinker((uint)entries.Count, Tinker.CreateNew(account.AccountId, 0x2352, 1));
            InsertAsync(tinker);
            return tinker;
        }
    }
}