using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using common;
using common.resources;
using wServer.realm.entities;
using wServer.realm.worlds;
using wServer.realm.worlds.logic;
using wServer.networking.packets.incoming;
using wServer.networking.packets.outgoing;
using File = TagLib.File;
using MarketResult = wServer.realm.entities.MarketResult;

namespace wServer.realm.commands
{
    internal class JoinGuildCommand : Command
    {
        public JoinGuildCommand() : base("join") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.Client.ProcessPacket(new JoinGuild()
            {
                GuildName = args
            });
            return true;
        }
    }

    internal class TutorialCommand : Command
    {
        public TutorialCommand() : base("tutorial") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.Client.Reconnect(new Reconnect()
            {
                Host = "",
                Port = 2050,
                GameId = World.PetYard,
                Name = "Tutorial"
            });
            return true;
        }
    }

    internal class ServerCommand : Command
    {
        public ServerCommand() : base("world") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.SendInfo($"[{player.Owner.Id}] {player.Owner.GetDisplayName()} ({player.Owner.Players.Count} players)");
            return true;
        }
    }

    internal class PauseCommand : Command
    {
        public PauseCommand() : base("pause") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            if (player.SpectateTarget != null)
            {
                player.SendError("The use of pause is disabled while spectating.");
                return false;
            }

            if (player.HasConditionEffect(ConditionEffects.Paused))
            {
                player.ApplyConditionEffect(new ConditionEffect()
                {
                    Effect = ConditionEffectIndex.Paused,
                    DurationMS = 0
                });
                player.SendInfo("Game resumed.");
                return true;
            }

            var owner = player.Owner;
            if (owner != null && (owner is Arena || owner is ArenaSolo || owner is DeathArena))
            {
                player.SendInfo("Can't pause in arena.");
                return false;
            }
            if (owner.Difficulty >= 4)
            {
                player.SendInfo("Can't pause in a dungeon greater than difficulty 4!");
                return false;
            }
            if (player.Owner.EnemiesCollision.HitTest(player.X, player.Y, 8).OfType<Enemy>().Any())
            {
                player.SendError("Not safe to pause.");
                return false;
            }

            player.ApplyConditionEffect(new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Paused,
                DurationMS = -1
            });
            player.SendInfo("Game paused.");
            return true;
        }
    }

    internal class TeleportCommand : Command
    {
        public TeleportCommand() : base("tp", alias: "teleport") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            foreach (var i in player.Owner.Players.Values)
            {
                if (!i.Name.EqualsIgnoreCase(args)) 
                    continue;

                if (!i.CanBeSeenBy(player))
                    break;

                player.Teleport(time, i.Id);
                return true;
            }

            player.SendError($"Unable to find player: <{args}>");
            return false;
        }
    }

    internal class TellCommand : Command
    {
        public TellCommand() : base("tell", alias: "t") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            if (!player.NameChosen)
            {
                player.SendError("Choose a name!");
                return false;
            }

            if (player.Muted)
            {
                player.SendError("You are muted. You can not tell at this time.");
                return false;
            }

            int index = args.IndexOf(' ');
            if (index == -1)
            {
                player.SendError("Usage: /tell <player name> <text>");
                return false;
            }

            string playername = args.Substring(0, index);
            string msg = args.Substring(index + 1);

            if (player.Name.ToLower() == playername.ToLower())
            {
                player.SendInfo("Quit telling yourself!");
                return false;
            }

            if (!player.Manager.Chat.Tell(player, playername, msg))
            {
                player.SendError($"<{playername}> not found.");
                return false;
            }
            return true;
        }
    }

    internal class GCommand : Command
    {
        public GCommand() : base("g", alias: "guild") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            if (!player.NameChosen)
            {
                player.SendError("Choose a name!");
                return false;
            }

            if (player.Muted)
            {
                player.SendError("Muted. You can not guild chat at this time.");
                return false;
            }

            if (String.IsNullOrEmpty(player.Guild))
            {
                player.SendError("You need to be in a guild to guild chat.");
                return false;
            }

            return player.Manager.Chat.Guild(player, args);
        }
    }

    internal class LocalCommand : Command
    {
        public LocalCommand() : base("l") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            if (!player.NameChosen)
            {
                player.SendError("Choose a name!");
                return false;
            }

            if (player.Muted)
            {
                player.SendError("Muted. You can not local chat at this time.");
                return false;
            }

            if (player.CompareAndCheckSpam(args, time.TotalElapsedMs))
            {
                return false;
            }

            var sent = player.Manager.Chat.Local(player, args);
            if (!sent)
            {
                player.SendError("Failed to send message. Use of extended ascii characters and ascii whitespace (other than space) is not allowed.");
            }
            else
            {
                player.Owner.ChatReceived(player, args);
            }

            

            return sent;
        }
    }

    internal class HelpCommand : Command
    {
        //actually the command is 'help', but /help is intercepted by client
        public HelpCommand() : base("commands") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            StringBuilder sb = new StringBuilder("Available commands: ");
            var cmds = player.Manager.Commands.Commands.Values.Distinct()
                .Where(x => x.HasPermission(player) && x.ListCommand)
                .ToArray();
            Array.Sort(cmds, (c1, c2) => c1.CommandName.CompareTo(c2.CommandName));
            for (int i = 0; i < cmds.Length; i++)
            {
                if (i != 0) sb.Append(", ");
                sb.Append(cmds[i].CommandName);
            }

            player.SendInfo(sb.ToString());
            return true;
        }
    }

    internal class IgnoreCommand : Command
    {
        public IgnoreCommand() : base("ignore") { }

        protected override bool Process(Player player, RealmTime time, string playerName)
        {
            if (player.Owner is Test)
                return false;

            if (String.IsNullOrEmpty(playerName))
            {
                player.SendError("Usage: /ignore <player name>");
                return false;
            }

            if (player.Name.ToLower() == playerName.ToLower())
            {
                player.SendInfo("Can't ignore yourself!");
                return false;
            }

            var target = player.Manager.Database.ResolveId(playerName);
            var targetAccount = player.Manager.Database.GetAccount(target);
            var srcAccount = player.Client.Account;

            if (target == 0 || targetAccount == null || targetAccount.Hidden && player.Admin == 0)
            {
                player.SendError("Player not found.");
                return false;
            }

            player.Manager.Database.IgnoreAccount(srcAccount, targetAccount, true);

            player.Client.SendPacket(new AccountList()
            {
                AccountListId = 1, // ignore list
                AccountIds = srcAccount.IgnoreList
                    .Select(i => i.ToString())
                    .ToArray()
            });

            player.SendInfo("<" + playerName + "> has been added to your ignore list.");
            return true;
        }
    }

    internal class UnignoreCommand : Command
    {
        public UnignoreCommand() : base("unignore") { }

        protected override bool Process(Player player, RealmTime time, string playerName)
        {
            if (player.Owner is Test)
                return false;

            if (String.IsNullOrEmpty(playerName))
            {
                player.SendError("Usage: /unignore <player name>");
                return false;
            }

            if (player.Name.ToLower() == playerName.ToLower())
            {
                player.SendInfo("You are no longer ignoring yourself. Good job.");
                return false;
            }

            var target = player.Manager.Database.ResolveId(playerName);
            var targetAccount = player.Manager.Database.GetAccount(target);
            var srcAccount = player.Client.Account;

            if (target == 0 || targetAccount == null || targetAccount.Hidden && player.Admin == 0)
            {
                player.SendError("Player not found.");
                return false;
            }

            player.Manager.Database.IgnoreAccount(srcAccount, targetAccount, false);

            player.Client.SendPacket(new AccountList()
            {
                AccountListId = 1, // ignore list
                AccountIds = srcAccount.IgnoreList
                    .Select(i => i.ToString())
                    .ToArray()
            });

            player.SendInfo("<" + playerName + "> no longer ignored.");
            return true;
        }
    }

    internal class LockCommand : Command
    {
        public LockCommand() : base("lock") { }

        protected override bool Process(Player player, RealmTime time, string playerName)
        {
            if (player.Owner is Test)
                return false;

            if (String.IsNullOrEmpty(playerName))
            {
                player.SendError("Usage: /lock <player name>");
                return false;
            }

            if (player.Name.ToLower() == playerName.ToLower())
            {
                player.SendInfo("Can't lock yourself!");
                return false;
            }

            var target = player.Manager.Database.ResolveId(playerName);
            var targetAccount = player.Manager.Database.GetAccount(target);
            var srcAccount = player.Client.Account;

            if (target == 0 || targetAccount == null || targetAccount.Hidden && player.Admin == 0)
            {
                player.SendError("Player not found.");
                return false;
            }

            player.Manager.Database.LockAccount(srcAccount, targetAccount, true);

            player.Client.SendPacket(new AccountList()
            {
                AccountListId = 0, // locked list
                AccountIds = player.Client.Account.LockList
                    .Select(i => i.ToString())
                    .ToArray(),
                LockAction = 1
            });

            player.SendInfo("<" + playerName + "> is now locked.");
            return true;
        }
    }

    internal class UnlockCommand : Command
    {
        public UnlockCommand() : base("unlock") { }

        protected override bool Process(Player player, RealmTime time, string playerName)
        {
            if (player.Owner is Test)
                return false;

            if (String.IsNullOrEmpty(playerName))
            {
                player.SendError("Usage: /unlock <player name>");
                return false;
            }

            if (player.Name.ToLower() == playerName.ToLower())
            {
                player.SendInfo("You are no longer locking yourself. Nice!");
                return false;
            }

            var target = player.Manager.Database.ResolveId(playerName);
            var targetAccount = player.Manager.Database.GetAccount(target);
            var srcAccount = player.Client.Account;

            if (target == 0 || targetAccount == null || targetAccount.Hidden && player.Admin == 0)
            {
                player.SendError("Player not found.");
                return false;
            }

            player.Manager.Database.LockAccount(srcAccount, targetAccount, false);

            player.Client.SendPacket(new AccountList()
            {
                AccountListId = 0, // locked list
                AccountIds = player.Client.Account.LockList
                    .Select(i => i.ToString())
                    .ToArray(),
                LockAction = 0
            });

            player.SendInfo("<" + playerName + "> is no longer locked.");
            return true;
        }
    }

    internal class UptimeCommand : Command
    {
        public UptimeCommand() : base("uptime") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            var t = TimeSpan.FromMilliseconds(time.TotalElapsedMs);

            var answer = t.Days != 0 
                ? $"{t.Days:D2} days, {t.Hours:D2} hours, {t.Minutes:D2} minutes"
                : $"{t.Hours:D2} hours, {t.Minutes:D2} minutes";

            player.SendInfo("The server has been up for: " + answer + ".");
            return true;
        }
    }

  /*  class NpeCommand : Command
    {
        public NpeCommand() : base("npe") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.Stats[0] = 100;
            player.Stats[1] = 100;
            player.Stats[2] = 10;
            player.Stats[3] = 0;
            player.Stats[4] = 10;
            player.Stats[5] = 10;
            player.Stats[6] = 10;
            player.Stats[7] = 10;
            player.Level = 1;
            player.Experience = 0;
            
            player.SendInfo("You character stats, level, and experience has be npe'ified.");
            return true;
        }
    }
    */
    internal class PositionCommand : Command
    {
        public PositionCommand() : base("pos", alias: "position") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.SendInfo("Current Position: " + (int)player.X + ", " + (int)player.Y);
            return true;
        }
    }

    internal class TradeCommand : Command
    {
        public TradeCommand() : base("trade") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            if (String.IsNullOrWhiteSpace(args))
            {
                player.SendError("Usage: /trade <player name>");
                return false;
            }

            player.RequestTrade(args);
            return true;
        }
    }

    internal class GambleCommand : Command
    {
        public GambleCommand() : base("gamble") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {

            string[] arguments = args.Split(' ');
            if (arguments.Length != 2)
            {
                player.SendError("Error!");
                return false;
            }

            if (String.IsNullOrWhiteSpace(arguments[0]))
            {
                player.SendError("Invalid player!");
                return false;
            }

            if (String.IsNullOrWhiteSpace(arguments[1]))
            {
                player.SendError("Invalid amount!");
                return false;
            }

            if (Convert.ToInt32(arguments[1]) < 0)
            {
                player.SendError("You need to set your gamble to a positive integer.");
                return false;
            }

            if (Convert.ToInt32(arguments[1]) <= 100000)
            {
                player.RequestGamble(arguments[0], Convert.ToInt32(arguments[1]));
                if (arguments[1] == "betamount")
                {
                    player.RequestGamble(arguments[0], player.betAmount);
                }
                else
                {
                    player.betAmount = Convert.ToInt32(arguments[1]);
                }
            }
            else
            {
                player.SendError("You are going to go broke at this rate...");
                return false;
            }
            
            return true;
        }
    }

    internal class SetGambleCommand : Command
    {
        public SetGambleCommand() : base("setgamble") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {

            var amount2 = int.Parse(args);

            if (player.isGambling == true)
            {
                player.SendInfo("You can't change the amount while gambling already!");
                return false;
            }
            if (string.IsNullOrEmpty(args))
            {
                player.SendInfo("/setgamble <amount>");
                return false;
            }

            if (!(amount2 <= 100000))
            {
                player.SendError("You need to lower your gamble amount..");
                return false;
            }

            if(amount2 < 0)
            {
                player.SendError("You need to set your gamble to a positive integer.");
                return false;
            }

            player.betAmount = amount2;
            return true;
        }
    }

    internal class CheckGambleCommand : Command
    {
        public CheckGambleCommand() : base("checkgamble") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.SendInfo("Your set gamble is currently " + player.betAmount);
            return true;
        }
    }


    internal class TimeCommand : Command
    {
        public TimeCommand() : base("time") { }
      
        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.SendInfo("Time for you to get a watch!");
            return true;
        }
    }

    /*  class ArenaCommand : Command
      {
          public ArenaCommand() : base("arena") { }

          protected override bool Process(Player player, RealmTime time, string args)
          {
              player.Client.Reconnect(new Reconnect()
              {
                  Host = "",
                  Port = 2050,
                  GameId = World.Arena,
                  Name = "Arena"
              });
              return true;
          }
      }

      class DeathArenaCommand : Command
      {
          public DeathArenaCommand() : base("oa") { }

          protected override bool Process(Player player, RealmTime time, string args)
          {
              player.Client.Reconnect(new Reconnect()
              {
                  Host = "",
                  Port = 2050,
                  GameId = World.DeathArena,
                  Name = "Oryx's Arena"
              });
              return true;
          }
      }*/

    internal class PickGambleCommand : Command
    {
        public PickGambleCommand() : base("pg") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            if (String.IsNullOrWhiteSpace(args))
            {
                player.SendError("You didnt choose rock, paper or scissors!");
                return false;
            }
            switch (args)
            {
                case "r":
                    player.gamble = "Rock";
                    player.gambleChosen = true;
                    break;
                case "p":
                    player.gamble = "Paper";
                    player.gambleChosen = true;
                    break;
                case "s":
                    player.gamble = "Scissors";
                    player.gambleChosen = true;
                    break;
                default:
                    player.SendError("You didnt choose rock, paper or scissors!");
                    break;
            }
            return true;
        }
    }

  /*  class SoloArenaCommand : Command
    {
        public SoloArenaCommand() : base("sa") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.Client.Reconnect(new Reconnect()
            {
                Host = "",
                Port = 2050,
                GameId = World.ArenaSolo,
                Name = "Arena Solo"
            });
            return true;
        }
    }*/

    internal class GhallCommand : Command
    {
        public GhallCommand() : base("ghall") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            if (player.GuildRank == -1)
            {
                player.SendError("You need to be in a guild.");
                return false;
            }
            player.Client.Reconnect(new Reconnect()
            {
                Host = "",
                Port = 2050,
                GameId = World.GuildHall,
                Name = "Guild Hall"
            });
            return true;
        }
    }

    internal class LefttoMaxCommand : Command
    {
        public LefttoMaxCommand() : base("lefttomax", alias: "l2m") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            var pd = player.Manager.Resources.GameData.Classes[player.ObjectType];
            var str = "";

            for (var i = 0; i < pd.Stats.Length; i++) {
                var l2m = (player.AscensionEnabled 
                              ? pd.Stats[i].MaxValue + (i < 2 ? 50 : 10) 
                              : pd.Stats[i].MaxValue) 
                          - player.Stats.Base[i];

                if (l2m != 0) str += player.Stats.StatIndexToFullName(i) + ": " 
                              + l2m + (i == pd.Stats.Length - 1 ? "" : ", ");

                if (i == pd.Stats.Length - 1) player.SendInfo(str);
            }
            return true;
        }
    }

    internal class GLandCommand : Command
    {
        public GLandCommand() : base("gland", alias: "glands") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            if (!(player.Owner is Realm))
            {
                player.SendError("This command requires you to be in realm first.");
                return false;
            }
            
            player.TeleportPosition(time, 1512 + 0.5f, 1048 + 0.5f);
            return true;
        }
    }

    internal class WhoCommand : Command
    {
        public WhoCommand() : base("who") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.SendInfo($"There are '{player.Owner.Players.Count}' people in your area.");
            return true;
        }
    }

    internal class OnlineCommand : Command
    {
        public OnlineCommand() : base("online") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            var servers = player.Manager.InterServer.GetServerList();
            var players = 
                (from server in servers
                 from plr in server.playerList
                 where !plr.Hidden || player.Client.Account.Admin
                 select plr.Name)
                .ToArray();

            var sb = $"There are '{players.Length}' people online.";
            player.SendInfo(sb);
            return true;
        }
    }

    internal class WhereCommand : Command
    {
        public WhereCommand() : base("where") { }

        protected override bool Process(Player player, RealmTime time, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                player.SendInfo("Usage: /where <player name>");
                return true;
            }

            var servers = player.Manager.InterServer.GetServerList();

            foreach (var server in servers)
                foreach (PlayerInfo plr in server.playerList)
                {
                    if (!plr.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) ||
                        plr.Hidden && !player.Client.Account.Admin)
                        continue;

                    player.SendInfo($"<{plr.Name}> is playing on '{server.name}' at '{plr.WorldName}'.");
                    return true;
                }

            var pId = player.Manager.Database.ResolveId(name);
            if (pId == 0)
            {
                player.SendInfo($"No player with the name <{name}>.");
                return true;
            }

            var acc = player.Manager.Database.GetAccount(pId, "lastSeen");
            if (acc.LastSeen == 0)
            {
                player.SendInfo($"<{name}> not online. Has not been seen since the dawn of time.");
                return true;
            }

            var dt = Utils.FromUnixTimestamp(acc.LastSeen);
            player.SendInfo($"<{name}> not online. Player last seen {Utils.TimeAgo(dt)}.");
            return true;
        }
    }

    internal class MarketCommand : Command
    {
        public MarketCommand() : base("market") { }

        private static readonly Regex _regex = new Regex(@"^(\d+) (\d+)$", RegexOptions.IgnoreCase);

        protected override bool Process(Player player, RealmTime time, string args) {
            if (player.Client.Account.Elite == 1) {
                player.SendError("Elite accounts can't use the marketplace!");
                return false;
            }

            if (!(player.Owner is Marketplace)) {
                player.SendError("Can only market items in Marketplace.");
                return false;
            }

            var match = _regex.Match(args);
            if (!match.Success || (match.Groups[1].Value.ToInt32()) > 16 || (match.Groups[1].Value.ToInt32()) < 1) {
                player.SendError("Usage: /market <slot> <amount>. Only slot numbers 1-16 are valid and amount must be a positive value.");
                return false;
            }

            if (!int.TryParse(match.Groups[2].Value, out var amount)) {
                player.SendError("Amount is too large. Try something below 2147483648...");
                return false;
            }

            var slot = match.Groups[1].Value.ToInt32() + 3;

            var result = player.AddToMarket(slot, amount);
            if (result != MarketResult.Success) {
                player.SendError(result.GetDescription());
                return false;
            }

            player.SendInfo("Success! Your item has been placed on the market.");
            return true;
        }
    }

    internal class MarketAllCommand : Command
    {
        public MarketAllCommand() : base("marketall", alias: "mall") { }

        private static readonly Regex Regex = new Regex(@"^([A-Za-z0-9 ]+) (\d+)$", RegexOptions.IgnoreCase);

        protected override bool Process(Player player, RealmTime time, string args) {

            if (player.Client.Account.Elite == 1) {
                player.SendError("Elite accounts can't use the marketplace!");
                return false;
            }

            if (!(player.Owner is Marketplace)) {
                player.SendError("Can only market items in Marketplace.");
                return false;
            }

            var match = Regex.Match(args);
            var gameData = player.Manager.Resources.GameData;
            var sold = 0;
            var err = false;

            if (!match.Success) {
                player.SendError("Usage: /marketall <item name> <price>.");
                return false;
            }

            string itemName = match.Groups[1].Value;

            // allow both DisplayId and Id for query
            if (!gameData.DisplayIdToObjectType.TryGetValue(itemName, out var objType)) {
                if (!gameData.IdToObjectType.TryGetValue(itemName, out objType)) {
                    player.SendError("Unknown item type!");
                    return false;
                }
            }

            if (!gameData.Items.ContainsKey(objType)) {
                player.SendError("Unknown item type!");
                return false;
            }

            if (gameData.Items[objType].Soulbound) {
                player.SendError("Can't market soulbound items!");
                return false;
            }

            if (!int.TryParse(match.Groups[2].Value, out var price)) {
                player.SendError("Price is too large. Try something below 2147483648...");
                return false;
            }

            for (var i = 4; i < player.Inventory.Length; i++) {
                if (player.Inventory[i]?.ObjectType != null && player.Inventory[i]?.ObjectType == objType) {
                    var result = player.AddToMarket(i, price);
                    if (result != MarketResult.Success) {
                        player.SendError(result.GetDescription());
                        err = true;
                    } else {
                        sold++;
                    }

                }
            }


            if (err) {
                if (sold > 0) {
                    player.SendErrorFormat("Errors occurred, only {0} item{1} sold.", sold, sold > 1 ? "s" : "");
                } else {
                    player.SendError("Errors occurred, couldn't market items.");
                }

            } else if (sold > 0) {
                player.SendInfoFormat("Success! Your {0} item{1} ha{2} been placed on the market.", sold, sold > 1 ? "s" : "", sold > 1 ? "ve" : "s");
            } else {
                player.SendErrorFormat("No {0} found in your inventory.", gameData.Items[objType].DisplayName);
            }


            return true;
        }
    }

    internal class MyMarketCommand : Command
    {
        public MyMarketCommand() : base("myMarket") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            var shopItems = player.GetMarketItems();
            if (shopItems.Length <= 0)
            {
                player.SendInfo("You have no items currently listed on the market.");
                return true;
            }

            player.SendInfo($"Your items ({shopItems.Length}): (format: [id] Name, fame)");
            foreach (var shopItem in shopItems)
            {
                var item = player.Manager.Resources.GameData.Items[shopItem.ItemId];
                player.SendInfo($"[{shopItem.Id}] {item.DisplayName}, {shopItem.Price}");
            }
            return true;
        }
    }

    internal class OopsCommand : Command
    {
        public OopsCommand() : base("oops") { }
        
        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.RemoveItemFromMarketAsync(player.Client.Account.LastMarketId)
                .ContinueWith(t =>
                {
                    if (t.Result != MarketResult.Success)
                    {
                        player.SendError(t.Result.GetDescription());
                        return;
                    }

                    player.SendInfo("Removal succeeded. The item has been placed in your gift chest.");
                    player.Client.SendPacket(new GlobalNotification
                    {
                        Text = "giftChestOccupied"
                    });
                })
                .ContinueWith(e =>
                    Log.Error(e.Exception.InnerException.ToString()),
                    TaskContinuationOptions.OnlyOnFaulted);

            return true;
        }
    }

    internal class RMarketCommand : Command
    {
        public RMarketCommand() : base("rmarket") { }
        
        protected override bool Process(Player player, RealmTime time, string args)
        {
            uint id;
            if (string.IsNullOrEmpty(args) ||
                !uint.TryParse(args, out id))
            {
                player.SendError("Usage: /rmarket <id>. Ids for your listed items can be found with the /mymarket command.");
                return false;
            }

            player.RemoveItemFromMarketAsync(id)
                .ContinueWith(t =>
                {
                    if (t.Result != MarketResult.Success)
                    {
                        player.SendError(t.Result.GetDescription());
                        return;
                    }

                    player.SendInfo("Removal succeeded. The item has been placed in your gift chest.");
                    player.Client.SendPacket(new GlobalNotification
                    {
                        Text = "giftChestOccupied"
                    });
                })
                .ContinueWith(e =>
                    Log.Error(e.Exception.InnerException.ToString()),
                    TaskContinuationOptions.OnlyOnFaulted);
            
            return true;
        }
    }

    internal class MarketplaceCommand : Command
    {
        public MarketplaceCommand() : base("marketplace") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.Client.Reconnect(new Reconnect()
            {
                Host = "",
                Port = 2050,
                GameId = World.MarketPlace,
                Name = "Marketplace"
            });
            return true;
        }
    }

    internal class RemoveAccountOverrideCommand : Command
    {
        public RemoveAccountOverrideCommand() : base("removeOverride", 0, listCommand: false) { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            var acc = player.Client.Account;
            if (acc.AccountIdOverrider == 0)
            {
                player.SendError("Account isn't overridden.");
                return false;
            }

            var overriderAcc = player.Manager.Database.GetAccount(acc.AccountIdOverrider);
            if (overriderAcc == null)
            {
                player.SendError("Account not found!");
                return false;
            }

            overriderAcc.AccountIdOverride = 0;
            overriderAcc.FlushAsync();
            player.SendInfo("Account override removed.");
            return true;
        }
    }

    internal class CurrentSongCommand : Command
    {
        public CurrentSongCommand() : base("currentsong", alias: "song") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            var properName = player.Owner.Music;
            var file = File.Create(Environment.CurrentDirectory + $"/resources/web/music/{properName}.mp3");
            var artist = file.Tag.FirstPerformer ?? "Unknown";
            var title = file.Tag.Title ?? properName;
            var album = file.Tag.Album != null ? $" from {file.Tag.Album}" : "";
            var filename = $" ({properName}.mp3)";
            
            player.SendInfo($"Current Song: {title} by {artist}{album}{filename}.");
            return true;
        }
    }

    internal class GuildKickCommand : Command
    {
        public GuildKickCommand() : base("gkick") { }

        protected override bool Process(Player player, RealmTime time, string name)
        {
            if (player.Owner is Test)
                return false;

            var manager = player.Client.Manager;

            // if resigning
            if (player.Name.Equals(name))
            {
                // chat needs to be done before removal so we can use
                // srcPlayer as a source for guild info
                manager.Chat.Guild(player, "<" + player.Name + "> has left the guild.", true);

                if (!manager.Database.RemoveFromGuild(player.Client.Account))
                {
                    player.SendError("Guild not found.");
                    return false;
                }

                player.Guild = "";
                player.GuildRank = 0;

                return true;
            }

            // get target account id
            var targetAccId = manager.Database.ResolveId(name);
            if (targetAccId == 0)
            {
                player.SendError("Player not found");
                return false;
            }

            // find target player (if connected)
            var targetClient = (from client in manager.Clients.Keys
                                where client.Account != null
                                where client.Account.AccountId == targetAccId
                                select client)
                                .FirstOrDefault();

            // try to remove connected member
            if (targetClient != null)
            {
                if (player.Client.Account.GuildRank >= 20 &&
                    player.Client.Account.GuildId == targetClient.Account.GuildId &&
                    player.Client.Account.GuildRank > targetClient.Account.GuildRank)
                {
                    var targetPlayer = targetClient.Player;

                    if (!manager.Database.RemoveFromGuild(targetClient.Account))
                    {
                        player.SendError("Guild not found.");
                        return false;
                    }

                    targetPlayer.Guild = "";
                    targetPlayer.GuildRank = 0;

                    manager.Chat.Guild(player,
                        "<" + targetPlayer.Name + "> has been kicked from the guild by <" + player.Name + ">", true);
                    targetPlayer.SendInfo("You have been kicked from the guild.");
                    return true;
                }

                player.SendError("Can't remove member. Insufficient privileges.");
                return false;
            }

            // try to remove member via database
            var targetAccount = manager.Database.GetAccount(targetAccId);

            if (player.Client.Account.GuildRank >= 20 &&
                player.Client.Account.GuildId == targetAccount.GuildId &&
                player.Client.Account.GuildRank > targetAccount.GuildRank)
            {
                if (!manager.Database.RemoveFromGuild(targetAccount))
                {
                    player.SendError("Guild not found.");
                    return false;
                }

                manager.Chat.Guild(player,
                    "<" + targetAccount.Name + "> has been kicked from the guild by <" + player.Name + ">", true);
                return true;
            }

            player.SendError("Can't remove member. Insufficient privileges.");
            return false;
        }
    }

    internal class GuildInviteCommand : Command
    {
        public GuildInviteCommand() : base("invite", alias: "ginvite") { }

        protected override bool Process(Player player, RealmTime time, string playerName)
        {
            if (player.Owner is Test)
                return false;

            if (player.Client.Account.GuildRank < 20)
            {
                player.SendError("Insufficient privileges.");
                return false;
            }

            var targetAccId = player.Client.Manager.Database.ResolveId(playerName);
            if (targetAccId == 0)
            {
                player.SendError("Player not found");
                return false;
            }

            var targetClient = (from client in player.Client.Manager.Clients.Keys
                                where client.Account != null
                                where client.Account.AccountId == targetAccId
                                select client)
                    .FirstOrDefault();

            if (targetClient != null)
            {
                if (targetClient.Player == null ||
                    targetClient.Account == null ||
                    !targetClient.Account.Name.Equals(playerName))
                {
                    player.SendError("Could not find the player to invite.");
                    return false;
                }

                if (!targetClient.Account.NameChosen)
                {
                    player.SendError("Player needs to choose a name first.");
                    return false;
                }

                if (targetClient.Account.GuildId > 0)
                {
                    player.SendError("Player is already in a guild.");
                    return false;
                }

                targetClient.Player.GuildInvite = player.Client.Account.GuildId;

                targetClient.SendPacket(new InvitedToGuild()
                {
                    Name = player.Name,
                    GuildName = player.Guild
                });
                return true;
            }

            player.SendError("Could not find the player to invite.");
            return false;
        }
    }

    internal class GuildWhoCommand : Command
    {
        public GuildWhoCommand() : base("gwho", alias: "mates") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            if (player.Client.Account.GuildId == 0)
            {
                player.SendError("You are not in a guild!");
                return false;
            }
            
            var pServer = player.Manager.Config.serverInfo.name;
            var pGuild = player.Client.Account.GuildId;
            var servers = player.Manager.InterServer.GetServerList();
            var result =
                (from server in servers
                 from plr in server.playerList
                 where plr.GuildId == pGuild
                 group plr by server);
            
            
            player.SendInfo("Guild members online:");

            foreach (var group in result)
            {
               
                var server = (pServer == group.Key.name) ? $"[{group.Key.name}]" : group.Key.name;
                var players = group.ToArray();
                var sb = new StringBuilder($"{server}: ");
                for (var i = 0; i < players.Length; i++)
                {
                    if (i != 0)
                        sb.Append(", ");

                    sb.Append(players[i].Name);
                }
                player.SendInfo(sb.ToString());
            }
            return true;
        }
    }

    internal class ServersCommand : Command
    {
        public ServersCommand() : base("servers", alias: "svrs") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            var playerSvr = player.Manager.Config.serverInfo.name;
            var servers = player.Manager.InterServer
                .GetServerList()
                .Where(s => s.type == ServerType.World)
                .ToArray();

            var sb = new StringBuilder($"Servers online ({servers.Length}):\n");
            foreach (var server in servers)
            {
                var currentSvr = server.name.Equals(playerSvr);
                if (currentSvr)
                {
                    sb.Append("[");
                }
                sb.Append(server.name);
                if (currentSvr)
                {
                    sb.Append("]");
                }
                sb.Append($" ({server.players}/{server.maxPlayers}");
                if (server.queueLength > 0)
                {
                    sb.Append($" + {server.queueLength} queued");
                }
                sb.Append(")");
                if (server.adminOnly)
                {
                    sb.Append(" Admin only");
                }
                sb.Append("\n");
            }
            
            player.SendInfo(sb.ToString());
            return true;
        }
    }
}
