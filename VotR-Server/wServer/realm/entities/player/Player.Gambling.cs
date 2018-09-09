using System.Collections.Generic;
using System.Linq;
using common;
using wServer.networking.packets.outgoing;
using wServer.realm.worlds.logic;

namespace wServer.realm.entities
{
    partial class Player
    {
        internal bool isGambling = false;
        internal Dictionary<Player, int> potentialGambler = new Dictionary<Player, int>();
        internal Player gambleTarget;
        internal bool gambleChosen = false;
        internal string gamble;
        internal int betAmount;

        public void RequestGamble(string name, int amount)
        {
            if (Owner is Test)
                return;

            Manager.Database.ReloadAccount(_client.Account);
            var acc = _client.Account;

            if (!acc.NameChosen)
            {
                SendError("You must choose a name before gambling.");
                return;
            }

            if (Owner.Name != "Nexus")
            {
                SendError("You must be in the Nexus in order to gamble.");
                return;
            }

            if (Database.GuestNames.Contains(name))
            {
                SendError("'" + name + "' needs to choose a unique name before they gamble.");
                return;
            }

            var target = Owner.GetUniqueNamedPlayer(name);
            if (target == null || !target.CanBeSeenBy(this))
            {
                SendError("'" + name + "' not found.");
                return;
            }

            if (target.Client.Account.Elite == 1 && Client.Account.Elite == 0 
                || target.Client.Account.Elite == 0 && Client.Account.Elite == 1)
            {
                SendError("Both parties must either be or not be Elite Accounts in order to gamble.");
                return;
            }

            if (target.Client.Account.AccountId == Client.Account.AccountId) {
                SendError("You can not gamble yourself.");
                return;
            }

            if (this.betAmount != target.betAmount)
            {
                SendError("You must have the same bet amount in order to gamble.");
                return;
            }

            if (target._client.Account.IgnoreList.Contains(AccountId))
                return; // account is ignored

            if (target.gambleTarget != null)
            {
                SendError("'" + target.Name + "' is already gambling.");
                return;
            }

            var thisAcc = Client.Account;
            var theirAcc = target.Client.Account;


            if (potentialGambler.ContainsKey(target))
            {
                if (this.Credits >= amount && target.Credits >= amount)
                {
                    isGambling = true;
                    target.isGambling = true;

                    gambleTarget = target;
                    target.gambleTarget = this;

                    potentialGambler.Clear();
                    target.potentialGambler.Clear();

                    this.SendInfo("10 seconds to choose rock, paper or scissors. (To choose rock /pg r) (To choose paper /pg p) (To choose scissors /pg s)");
                    target.SendInfo("10 seconds to choose rock, paper or scissors. (To choose rock /pg r) (To choose paper /pg p) (To choose scissors /pg s)");
                }
                else
                {
                    this.SendInfo("A gambler doesn't have enough gold..tsk tsk.");
                    target.SendInfo("A gambler doesn't have enough gold..tsk tsk.");
                    isGambling = false;
                    target.isGambling = false;
                    gambleTarget = null;
                    target.gambleTarget = null;
                    gamble = "";
                    target.gamble = "";
                    return;
                }
                Owner.Timers.Add(new WorldTimer(10000, (world, t) =>
                {
                    
                    this.SendInfo("Time is up!");
                    target.SendInfo("Time is up!");
                    isGambling = false;
                    target.isGambling = false;
                    gambleTarget = null;
                    target.gambleTarget = null;
   
                //match the gambles
                if (target.gambleChosen == true && this.gambleChosen == true)
                    {
                        if (this.gamble == "Paper" && target.gamble == "Rock")
                        {
                            //this wins
                            this.SendInfo(this.Name + " wins with " + this.gamble);
                            target.SendInfo(this.Name + " wins with " + this.gamble);

                            gambleChosen = false;
                            target.gambleChosen = false;
                            this.gamble = "";
                            target.gamble = "";
                            Client.Manager.Database.UpdateCredit(thisAcc, amount);
                            Credits += amount;
                            this.ForceUpdate(Credits);


                            target.Client.Manager.Database.UpdateCredit(theirAcc, -amount);
                            target.Credits -= amount;
                            target.ForceUpdate(Credits);

                            return;
                        }
                        if (this.gamble == "Rock" && target.gamble == "Paper")
                        {
                            //opponent wins
                            this.SendInfo(target.Name + " wins with " + target.gamble);
                            target.SendInfo(target.Name + " wins with " + target.gamble);

                            gambleChosen = false;
                            target.gambleChosen = false;
                            this.gamble = "";
                            target.gamble = "";
                            Client.Manager.Database.UpdateCredit(thisAcc, -amount);
                            Credits -= amount;
                            this.ForceUpdate(Credits);

                            target.Client.Manager.Database.UpdateCredit(theirAcc, amount);
                            target.Credits += amount;
                            target.ForceUpdate(Credits);
                            return;
                        }
                        if (this.gamble == "Rock" && target.gamble == "Scissors")
                        {
                            //this wins
                            this.SendInfo(this.Name + " wins with " + this.gamble);
                            target.SendInfo(this.Name + " wins with " + this.gamble);

                            gambleChosen = false;
                            target.gambleChosen = false;
                            this.gamble = "";
                            target.gamble = "";
                            Client.Manager.Database.UpdateCredit(thisAcc, amount);
                            Credits += amount;
                            this.ForceUpdate(Credits);

                            target.Client.Manager.Database.UpdateCredit(theirAcc, -amount);
                            target.Credits -= amount;
                            target.ForceUpdate(Credits);
                            return;
                        }
                        if (target.gamble == "Scissors" && this.gamble == "Rock")
                        {
                            //Opponent wins
                            this.SendInfo(target.Name + " wins with " + target.gamble);
                            target.SendInfo(target.Name + " wins with " + target.gamble);

                            gambleChosen = false;
                            target.gambleChosen = false;
                            this.gamble = "";
                            target.gamble = "";
                            Client.Manager.Database.UpdateCredit(thisAcc, -amount);
                            Credits -= amount;
                            this.ForceUpdate(Credits);

                            target.Client.Manager.Database.UpdateCredit(theirAcc, amount);
                            target.Credits += amount;
                            target.ForceUpdate(Credits);
                            return;
                        }
                        if (target.gamble == "Rock" && this.gamble == "Scissors")
                        {
                            //opponent wins
                            this.SendInfo(target.Name + " wins with " + target.gamble);
                            target.SendInfo(target.Name + " wins with " + target.gamble);

                            gambleChosen = false;
                            target.gambleChosen = false;
                            this.gamble = "";
                            target.gamble = "";
                            Client.Manager.Database.UpdateCredit(thisAcc, -amount);
                            Credits -= amount;
                            this.ForceUpdate(Credits);

                            target.Client.Manager.Database.UpdateCredit(theirAcc, amount);
                            target.Credits += amount;
                            target.ForceUpdate(Credits);
                            return;
                        }
                        if (target.gamble == "Scissors" && this.gamble == "Paper")
                        {
                            //opponent
                            this.SendInfo(target.Name + " wins with " + target.gamble);
                            target.SendInfo(target.Name + " wins with " + target.gamble);

                            gambleChosen = false;
                            target.gambleChosen = false;
                            this.gamble = "";
                            target.gamble = "";
                            Client.Manager.Database.UpdateCredit(thisAcc, -amount);
                            Credits -= amount;
                            this.ForceUpdate(Credits);

                            target.Client.Manager.Database.UpdateCredit(theirAcc, amount);
                            target.Credits += amount;
                            target.ForceUpdate(Credits);
                            return;
                        }
                        if (target.gamble == "Paper" && this.gamble == "Scissors")
                        {
                            //this wins
                            this.SendInfo(this.Name + " wins with " + this.gamble);
                            target.SendInfo(this.Name + " wins with " + this.gamble);

                            gambleChosen = false;
                            target.gambleChosen = false;
                            this.gamble = "";
                            target.gamble = "";
                            Client.Manager.Database.UpdateCredit(thisAcc, amount);
                            Credits += amount;
                            this.ForceUpdate(Credits);

                            target.Client.Manager.Database.UpdateCredit(theirAcc, -amount);
                            target.Credits -= amount;
                            target.ForceUpdate(Credits);
                            return;
                        }
                        if (target.gamble == "Paper" && this.gamble == "Paper")
                        {
                            //tie
                            this.SendInfo("The match was a tie with " + this.gamble);
                            target.SendInfo("The match was a tie with " + this.gamble);
                            this.gamble = "";
                            target.gamble = "";
                            gambleChosen = false;
                            target.gambleChosen = false;
                            return;
                        }
                        if (target.gamble == "Rock" && this.gamble == "Rock")
                        {
                            //tie
                            this.SendInfo("The match was a tie with " + this.gamble);
                            target.SendInfo("The match was a tie with " + this.gamble);
                            this.gamble = "";
                            target.gamble = "";
                            gambleChosen = false;
                            target.gambleChosen = false;
                            return;
                        }
                        if (target.gamble == "Scissors" && this.gamble == "Scissors")
                        {
                            //tie
                            this.SendInfo("The match was a tie with " + this.gamble);
                            target.SendInfo("The match was a tie with " + this.gamble);
                            this.gamble = "";
                            target.gamble = "";
                            gambleChosen = false;
                            target.gambleChosen = false;
                            return;
                        }
                    }
                    else
                    {
                        if (target.gambleChosen == false)
                        {
                            this.SendInfo(target.Name + " stalled the match and therefore lost!");
                            target.SendInfo(target.Name + " stalled the match and therefore lost!");

                            Client.Manager.Database.UpdateCredit(thisAcc, amount);
                            Credits += amount;
                            this.ForceUpdate(Credits);

                            target.Client.Manager.Database.UpdateCredit(theirAcc, -amount);
                            target.Credits -= amount;
                            target.ForceUpdate(Credits);
                        }
                        if (this.gambleChosen == false)
                        {
                            this.SendInfo(this.Name + " stalled the match and therefore lost!");
                            target.SendInfo(this.Name + " stalled the match and therefore lost!");

                            Client.Manager.Database.UpdateCredit(thisAcc, -amount);
                            Credits -= amount;
                            this.ForceUpdate(Credits);

                            target.Client.Manager.Database.UpdateCredit(theirAcc, amount);
                            target.Credits += amount;
                            target.ForceUpdate(Credits);
                        }
                        if (this.gambleChosen == false && target.gambleChosen == false)
                        {
                            this.SendInfo("Both gamblers stalled the match and therefore it's a tie!");
                            target.SendInfo("Both gamblers stalled the match and therefore it's a tie!");

                        }

                        this.gamble = "";
                        target.gamble = "";
                        gambleChosen = false;
                        target.gambleChosen = false;
                        return;
                    }
                    



                }));
            }
            else
            {
                target.potentialGambler[this] = 1000 * 20;
                target._client.SendPacket(new GambleStart()
                {
                    Name = Name,
                    Amount = amount
                });
                SendInfo("You have sent a gamble request to " + name + " for " + amount + " gold.");
                return;
            }
        }
    }
}