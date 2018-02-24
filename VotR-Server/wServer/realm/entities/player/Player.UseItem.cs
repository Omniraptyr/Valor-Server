using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using common.resources;
using StackExchange.Redis;
using wServer.networking.packets;
using wServer.networking.packets.outgoing;
using wServer.networking.packets.outgoing.pets;
using wServer.realm.worlds;
using wServer.realm.worlds.logic;
using PetYard = wServer.realm.worlds.logic.PetYard;

namespace wServer.realm.entities
{
    partial class Player
    {

        public const int MaxAbilityDist = 14;

        public int DrainedHP = 0;

        public static readonly ConditionEffect[] NegativeEffs2 = new ConditionEffect[]
        {
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Slowed
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Paralyzed
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Weak
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Stunned
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Confused
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Blind
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Quiet
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.ArmorBroken
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Bleeding
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Dazed
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Sick
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Drunk
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Hallucinating
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Hexed
            },
            new ConditionEffect()
            {
                Effect= ConditionEffectIndex.Unstable
            },
            new ConditionEffect()
            {
                Effect= ConditionEffectIndex.Darkness
            },
            new ConditionEffect()
            {
                Effect= ConditionEffectIndex.Curse
            },
            new ConditionEffect()
            {
                Effect= ConditionEffectIndex.Exhausted
            }
        };

        public static readonly ConditionEffect[] NegativeEffs = new ConditionEffect[]
        {
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Slowed,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Paralyzed,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Weak,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Stunned,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Confused,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Blind,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Quiet,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.ArmorBroken,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Bleeding,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Dazed,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Sick,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Drunk,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Hallucinating,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect = ConditionEffectIndex.Hexed,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect= ConditionEffectIndex.Unstable,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect= ConditionEffectIndex.Darkness,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect= ConditionEffectIndex.Curse,
                DurationMS = 0
            },
            new ConditionEffect()
            {
                Effect= ConditionEffectIndex.Exhausted,
                DurationMS = 0
            }
        };

        private readonly object _useLock = new object();
        public void UseItem(RealmTime time, int objId, int slot, Position pos)
        {
            using (TimedLock.Lock(_useLock))
            {
                var entity = Owner.GetEntity(objId);
                if (entity == null)
                {
                    Client.SendPacket(new InvResult() { Result = 1 });
                    return;
                }

                if (entity is Player && objId != Id)
                {
                    Client.SendPacket(new InvResult() { Result = 1 });
                    return;
                }

                var container = entity as IContainer;

                // eheh no more clearing BBQ loot bags
                if (this.Dist(entity) > 3)
                {
                    Client.SendPacket(new InvResult() { Result = 1 });
                    return;
                }

                var cInv = container?.Inventory.CreateTransaction();

                // get item
                Item item = null;
                foreach (var stack in Stacks.Where(stack => stack.Slot == slot))
                {
                    item = stack.Pull();

                    if (item == null)
                        return;

                    break;
                }
                if (item == null)
                {
                    if (container == null)
                        return;

                    item = cInv[slot];
                }

                if (item == null)
                    return;

                // make sure not trading and trying to cunsume item
                if (tradeTarget != null && item.Consumable)
                    return;

                if (MP < item.MpCost)
                {
                    Client.SendPacket(new InvResult() { Result = 1 });
                    return;
                }


                // use item
                var slotType = 10;
                if (slot < cInv.Length)
                {
                    slotType = container.SlotTypes[slot];

                    if (item.Consumable)
                    {
                        var gameData = Manager.Resources.GameData;
                        var db = Manager.Database;

                        Item successor = null;
                        if (item.SuccessorId != null)
                            successor = gameData.Items[gameData.IdToObjectType[item.SuccessorId]];
                        cInv[slot] = successor;

                        var trans = db.Conn.CreateTransaction();
                        if (container is GiftChest)
                            if (successor != null)
                                db.SwapGift(Client.Account, item.ObjectType, successor.ObjectType, trans);
                            else
                                db.RemoveGift(Client.Account, item.ObjectType, trans);
                        var task = trans.ExecuteAsync();
                        task.ContinueWith(t =>
                            {
                                var success = !t.IsCanceled && t.Result;
                                if (!success || !Inventory.Execute(cInv)) // can result in the loss of an item if inv trans fails...
                                {
                                    entity.ForceUpdate(slot);
                                    return;
                                }

                                if (slotType > 0)
                                {
                                    FameCounter.UseAbility();
                                } else
                                {
                                    if (item.ActivateEffects.Any(eff => eff.Effect == ActivateEffects.Heal ||
                                                                        eff.Effect == ActivateEffects.HealNova ||
                                                                        eff.Effect == ActivateEffects.Magic ||
                                                                        eff.Effect == ActivateEffects.MagicNova))
                                    {
                                        FameCounter.DrinkPot();
                                    }
                                }


                                Activate(time, item, pos);
                            });
                        task.ContinueWith(e =>
                            Log.Error(e.Exception.InnerException.ToString()),
                            TaskContinuationOptions.OnlyOnFaulted);
                        return;
                    }

                    if (slotType > 0)
                    {
                        FameCounter.UseAbility();
                    }
                }
                else
                {
                    FameCounter.DrinkPot();
                }

                if (item.Consumable || item.SlotType == slotType || item.InvUse)
                    Activate(time, item, pos);
                else
                    Client.SendPacket(new InvResult() { Result = 1 });
            }
        }

        private void Activate(RealmTime time, Item item, Position target)
        {
            ActivateSecondaryPower(SecondaryPowerIdentify());
            MP -= item.MpCost;
            if (CheckFurious())
            {
                if (item.MpCost > 0)
                    WeakBlast(time, item, target);
            }
            if (CheckDran())
            {
                if (item.MpCost > 0)
                    AEHealNoRest(time, item, target, 60);
            }
            if (CheckStar())
            {
                if (item.MpCost > 0)
                    AEMagicNoRest(time, item, target, item.MpCost / 4);
            }
            if (CheckInfernus())
            {
                if (item.MpCost > 0)
                    BurstFire(time, item, target);
            }
            if (Surge >= item.SurgeCost)
                Surge -= item.SurgeCost;


            if (HP < item.HpCost)
                HP = item.HpCost;
            else
                HP -= item.HpCost;
            foreach (var eff in item.ActivateEffects)
            {
                switch (eff.Effect)
                {
                    case ActivateEffects.GenericActivate:
                        AEGenericActivate(time, item, target, eff);
                        break;
                    case ActivateEffects.BulletNova:
                        AEBulletNova(time, item, target, eff);
                        break;
                    case ActivateEffects.Shoot:
                        AEShoot(time, item, target, eff);
                        break;
                    case ActivateEffects.StatBoostSelf:
                        AEStatBoostSelf(time, item, target, eff);
                        break;
                    case ActivateEffects.StatBoostAura:
                        AEStatBoostAura(time, item, target, eff);
                        break;
                    case ActivateEffects.ConditionEffectSelf:
                        AEConditionEffectSelf(time, item, target, eff);
                        break;
                    case ActivateEffects.ConditionEffectAura:
                        AEConditionEffectAura(time, item, target, eff);
                        break;
                    case ActivateEffects.ClearConditionEffectAura:
                        AEClearConditionEffectAura(time, item, target, eff);
                        break;
                    case ActivateEffects.Heal:
                        AEHeal(time, item, target, eff);
                        break;
                    case ActivateEffects.HealNova:
                        AEHealNova(time, item, target, eff);
                        break;
                    case ActivateEffects.Magic:
                        AEMagic(time, item, target, eff);
                        break;
                    case ActivateEffects.MagicNova:
                        AEMagicNova(time, item, target, eff);
                        break;
                    case ActivateEffects.Teleport:
                        AETeleport(time, item, target, eff);
                        break;
                    case ActivateEffects.VampireBlast:
                        AEVampireBlast(time, item, target, eff);
                        break;
                    case ActivateEffects.Trap:
                        AETrap(time, item, target, eff);
                        break;
                    case ActivateEffects.StasisBlast:
                        StasisBlast(time, item, target, eff);
                        break;
                    case ActivateEffects.Decoy:
                        AEDecoy(time, item, target, eff);
                        break;
                    case ActivateEffects.Lightning:
                        AELightning(time, item, target, eff);
                        break;
                    case ActivateEffects.PoisonGrenade:
                        AEPoisonGrenade(time, item, target, eff);
                        break;
                    case ActivateEffects.RemoveNegativeConditions:
                        AERemoveNegativeConditions(time, item, target, eff);
                        break;
                    case ActivateEffects.RemoveNegativeConditionsSelf:
                        AERemoveNegativeConditionSelf(time, item, target, eff);
                        break;
                    case ActivateEffects.FixedStat:
                        AEFixedStat(time, item, target, eff);
                        break;
                    case ActivateEffects.IncrementStat:
                        AEIncrementStat(time, item, target, eff);
                        break;
                    case ActivateEffects.Create:
                        AECreate(time, item, target, eff);
                        break;
                    case ActivateEffects.Dye:
                        AEDye(time, item, target, eff);
                        break;
                    case ActivateEffects.ShurikenAbility:
                        AEShurikenAbility(time, item, target, eff);
                        break;
                    case ActivateEffects.Fame:
                        AEAddFame(time, item, target, eff);
                        break;
                    case ActivateEffects.Backpack:
                        AEBackpack(time, item, target, eff);
                        break;
                    case ActivateEffects.XPBoost:
                        AEXPBoost(time, item, target, eff);
                        break;
                    case ActivateEffects.LDBoost:
                        AELDBoost(time, item, target, eff);
                        break;
                    case ActivateEffects.LTBoost:
                        AELTBoost(time, item, target, eff);
                        break;
                    case ActivateEffects.UnlockPortal:
                        AEUnlockPortal(time, item, target, eff);
                        break;
                    case ActivateEffects.CreatePet:
                        AECreatePet(time, item, target, eff);
                        break;
                    case ActivateEffects.UnlockEmote:
                        AEUnlockEmote(time, item, eff);
                        break;
                    case ActivateEffects.HealingGrenade:
                        AEHealingGrenade(time, item, target, eff);
                        break;
                    case ActivateEffects.SorForge:
                        AESorForge(time, item, target, eff);
                        break;
                    case ActivateEffects.TreasureActivate:
                        AETreasureActivate(time, item, target, eff);
                        break;
                    case ActivateEffects.OnraneActivate:
                        AEOnraneActivate(time, item, target, eff);
                        break;
                    case ActivateEffects.RandomOnrane:
                        AERandomOnrane(time, item, target, eff);
                        break;
                    case ActivateEffects.URandomOnrane:
                        AEURandomOnrane(time, item, target, eff);
                        break;
                    case ActivateEffects.RandomGold:
                        AERandomGold(time, item, target, eff);
                        break;
                    case ActivateEffects.SamuraiAbility:
                        AESamuraiAbility(time, item, target, eff);
                        break;
                    case ActivateEffects.Banner:
                        AEBanner(time, item, target, eff);
                        break;
                    case ActivateEffects.SiphonAbility:
                        AESiphonAbility(time, item, target, eff);
                        break;
                    case ActivateEffects.Heal2:
                        AEHeal2(time, item, target, eff);
                        break;
                    case ActivateEffects.Magic2:
                        AEMagic2(time, item, target, eff);
                        break;
                    case ActivateEffects.DiceActivate:
                        AEDiceActivate(time, item, target, eff);
                        break;
                    case ActivateEffects.BigStasisBlast:
                        BigStasisBlast(time, item, target, eff);
                        break;
                    case ActivateEffects.UnlockSkin:
                        AEUnlockSkin(time, item, target, eff);
                        break;
                    case ActivateEffects.SorConstruct:
                        AESorConstruct(time, item, target, eff);
                        break;
                    case ActivateEffects.ActivateFragment:
                        AEActivateFragment(time, item, target, eff);
                        break;
                    case ActivateEffects.BurstInferno:
                        AEBurstInferno(time, item, target, eff);
                        break;
                    case ActivateEffects.DDiceActivate:
                        AEDDiceActivate(time, item, target, eff);
                        break;
                    default:
                        Log.WarnFormat("Activate effect {0} not implemented.", eff.Effect);
                        break;
                }
            }
        }
        private void AEDDiceActivate(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            Random rnd = new Random();
            int ability = rnd.Next(1, 7);
            switch (ability)
            {
                case 1:
                    ApplyConditionEffect(ConditionEffectIndex.Bravery, eff.DurationMS);
                    break;
                case 2:
                    ApplyConditionEffect(ConditionEffectIndex.Armored, eff.DurationMS);
                    break;
                case 3:
                    ApplyConditionEffect(ConditionEffectIndex.Berserk, eff.DurationMS);
                    break;
                case 4:
                    ApplyConditionEffect(ConditionEffectIndex.Speedy, eff.DurationMS);
                    break;
                case 5:
                    ApplyConditionEffect(ConditionEffectIndex.Healing, eff.DurationMS);
                    break;
                case 6:
                    ApplyConditionEffect(ConditionEffectIndex.Damaging, eff.DurationMS);
                    break;
            }
        }
        private void AEUnlockEmote(RealmTime time, Item item, ActivateEffect eff)
        {
            if (Client.Player.Owner == null || Client.Player.Owner is Test)
            {
                SendInfo("Can't use emote unlocks in test worlds.");
                return;
            }

            var emotes = Client.Account.Emotes;
            if (!emotes.Contains(eff.Id))
                emotes.Add(eff.Id);
            Client.Account.Emotes = emotes;
            Client.Account.FlushAsync();
            SendInfo($"{eff.Id} Emote unlocked successfully");
        }

        private void AECreatePet(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            if (!Manager.Config.serverSettings.enablePets)
            {
                SendError("Cannot create pet. Pets are currently disabled.");
                return;
            }

            var petYard = Owner as PetYard;
            if (petYard == null)
            {
                SendError("server.use_in_petyard");
                return;
            }

            var pet = Pet.Create(Manager, this, item);
            if (pet == null)
                return;

            var sPos = petYard.GetPetSpawnPosition();
            pet.Move(sPos.X, sPos.Y);
            Owner.EnterWorld(pet);

            Client.SendPacket(new HatchPetMessage()
            {
                PetName = pet.Skin,
                PetSkin = pet.SkinId
            });
        }

        private void AEUnlockPortal(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var gameData = Manager.Resources.GameData;

            // find locked portal
            var portals = Owner.StaticObjects.Values
                .Where(s => s is Portal && s.ObjectDesc.ObjectId.Equals(eff.LockedName) && s.DistSqr(this) <= 9)
                .Select(s => s as Portal);
            if (!portals.Any())
                return;
            var portal = portals.Aggregate(
                (curmin, x) => (curmin == null || x.DistSqr(this) < curmin.DistSqr(this) ? x : curmin));
            if (portal == null)
                return;

            // get proto of world
            ProtoWorld proto;
            if (!Manager.Resources.Worlds.Data.TryGetValue(eff.DungeonName, out proto))
            {
                Log.Error("Unable to unlock portal. \"" + eff.DungeonName + "\" does not exist.");
                return;
            }

            if (proto.portals == null || proto.portals.Length < 1)
            {
                Log.Error("World is not associated with any portals.");
                return;
            }

            // create portal of unlocked world
            var portalType = (ushort)proto.portals[0];
            var uPortal = Resolve(Manager, portalType) as Portal;
            if (uPortal == null)
            {
                Log.ErrorFormat("Error creating portal: {0}", portalType);
                return;
            }

            var portalDesc = gameData.Portals[portal.ObjectType];
            var uPortalDesc = gameData.Portals[portalType];

            // create world
            World world;
            if (proto.id < 0)
                world = Manager.GetWorld(proto.id);
            else
            {
                DynamicWorld.TryGetWorld(proto, Client, out world);
                world = Manager.AddWorld(world ?? new World(proto));
            }
            uPortal.WorldInstance = world;

            // swap portals
            if (!portalDesc.NexusPortal || !Manager.Monitor.RemovePortal(portal))
                Owner.LeaveWorld(portal);
            uPortal.Move(portal.X, portal.Y);
            uPortal.Name = uPortalDesc.DisplayId;
            var uPortalPos = new Position() { X = portal.X - .5f, Y = portal.Y - .5f };
            if (!uPortalDesc.NexusPortal || !Manager.Monitor.AddPortal(world.Id, uPortal, uPortalPos))
                Owner.EnterWorld(uPortal);

            // setup timeout
            if (!uPortalDesc.NexusPortal)
            {
                var timeoutTime = gameData.Portals[portalType].Timeout;
                Owner.Timers.Add(new WorldTimer(timeoutTime * 1000, (w, t) => w.LeaveWorld(uPortal)));
            }

            // announce
            Owner.BroadcastPacket(new Notification
            {
                Color = new ARGB(0xFF00FF00),
                ObjectId = Id,
                Message = "Unlocked by " + Name
            }, null, PacketPriority.Low);
            foreach (var player in Owner.Players.Values)
                player.SendInfo(string.Format("{{\"key\":\"{{server.dungeon_unlocked_by}}\",\"tokens\":{{\"dungeon\":\"{0}\",\"name\":\"{1}\"}}}}", world.SBName, Name));
        }

        private void AELTBoost(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            if (LTBoostTime < 0 || (LTBoostTime > eff.DurationMS && eff.DurationMS >= 0))
                return;

            LTBoostTime = eff.DurationMS;
            InvokeStatChange(StatsType.LTBoostTime, LTBoostTime / 1000, true);
        }

        private void AELDBoost(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            if (LDBoostTime < 0 || (LDBoostTime > eff.DurationMS && eff.DurationMS >= 0))
                return;

            LDBoostTime = eff.DurationMS;
            InvokeStatChange(StatsType.LDBoostTime, LDBoostTime / 1000, true);
        }

        private void AEXPBoost(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            if (XPBoostTime < 0 || (XPBoostTime > eff.DurationMS && eff.DurationMS >= 0))
                return;

            XPBoostTime = eff.DurationMS;
            XPBoosted = true;
            InvokeStatChange(StatsType.XPBoostTime, XPBoostTime / 1000, true);
        }

        private void AEBackpack(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            if (Rank >= 10)
            {
                HasBackpack = true;
            }
            else
            {
                SendError("You must be a donator to use this item!");
            }
        }

        private void AEAddFame(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            if (Owner is Test || Client.Account == null)
                return;

            var acc = Client.Account;
            var trans = Manager.Database.Conn.CreateTransaction();
            Manager.Database.UpdateCurrency(acc, eff.Amount, CurrencyType.Fame, trans)
                .ContinueWith(t =>
                {
                    CurrentFame = acc.Fame;
                });
            trans.Execute(CommandFlags.FireAndForget);
        }

        private void AEShurikenAbility(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            if (!HasConditionEffect(ConditionEffects.NinjaSpeedy))
            {
                ApplyConditionEffect(ConditionEffectIndex.NinjaSpeedy);
                return;
            }

            if (MP >= item.MpEndCost)
            {
                MP -= item.MpEndCost;
                AEShoot(time, item, target, eff);
            }

            ApplyConditionEffect(ConditionEffectIndex.NinjaSpeedy, 0);
        }

        private void AESamuraiAbility(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            if (!HasConditionEffect(ConditionEffects.SamuraiBerserk))
            {
                ApplyConditionEffect(ConditionEffectIndex.SamuraiBerserk);
                return;
            }

            if (MP >= item.MpEndCost)
            {
                MP -= item.MpEndCost;
                List<Packet> pkts = new List<Packet>();
                this.AOE(eff.Range / 2, false, enemy =>
                {
                    (enemy as Enemy).Damage(this, time,
                        (int)Stats.GetAttackDamage(eff.TotalDamage, eff.TotalDamage),
                        false, new ConditionEffect[0]);
                });
                pkts.Add(new ShowEffect()
                {
                    EffectType = EffectType.AreaBlast,
                    TargetObjectId = Id,
                    Color = new ARGB(0x000000),
                    Pos1 = new Position() { X = eff.Range / 2 }
                });
                BroadcastSync(pkts, p => this.Dist(p) < 25);
            }

            ApplyConditionEffect(ConditionEffectIndex.SamuraiBerserk, 0);
        }

        private void AEBanner(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            BroadcastSync(new ShowEffect()
            {
                EffectType = EffectType.Throw,
                Color = new ARGB(0x0000ff),
                TargetObjectId = Id,
                Pos1 = target
            }, p => this.Dist(p) < 25);
            Owner.Timers.Add(new WorldTimer(1500, (world, t) =>
            {
                Banner banner = new Banner(this, eff.Range, eff.Amount, eff.DurationMS);
                banner.Move(target.X, target.Y);
                world.EnterWorld(banner);
            }));
        }

        private void AESiphonAbility(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            int wisBoost = Stats[7] ^ 2;
            int drained = DrainedHP;
            int mpAvailable = MP;
            if (!HasConditionEffect(ConditionEffects.DrakzixCharging))
            {
                ApplyConditionEffect(ConditionEffectIndex.DrakzixCharging);
                return;
            }

            List<Packet> pkts = new List<Packet>();
            pkts.Add(new ShowEffect()
            {
                EffectType = EffectType.Flow,
                TargetObjectId = Id,
                Pos1 = target,
                Color = new ARGB(0xFFA500)
            });

            pkts.Add(new ShowEffect()
            {
                EffectType = EffectType.Diffuse,
                TargetObjectId = Id,
                Color = new ARGB(0xFFA500),
                Pos1 = target,
                Pos2 = new Position { X = target.X + eff.Range, Y = target.Y }
            });
            List<Enemy> enemies = new List<Enemy>();

            Owner.AOE(target, eff.Range, false, enemy =>
            {
                (enemy as Enemy).Damage(this, time, ((((MP * 2) + (wisBoost ^ 2)) * (drained / 2)) / 4) + eff.Amount, false,
                    new ConditionEffect[0]);
            });
            BroadcastSync(pkts, p => this.Dist(p) < 25);

            MP = Stats[1] / 2;
            DrainedHP = 0;

            ApplyConditionEffect(ConditionEffectIndex.DrakzixCharging, 0);
            ApplyConditionEffect(ConditionEffectIndex.Empowered, eff.DurationMS);
        }

        private void AEDye(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            if (item.Texture1 != 0)
                Texture1 = item.Texture1;
            if (item.Texture2 != 0)
                Texture2 = item.Texture2;
        }

        private void AESorForge(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            Client.SendPacket(new SorForge()
            {
                IsForge = true
            });
        }

        private void AESorConstruct(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var inv = Inventory;
            for (int c = 0; c < inv.Length; c++)
            {
                if (inv[c] == null) continue;
                if (inv[c].ObjectId == "Sor Fragment 1")
                {
                    for (int d = 0; d < inv.Length; d++)
                    {
                        if (inv[d] == null) continue;
                        if (inv[d].ObjectId == "Sor Fragment 2")
                        {
                            for (int i = 0; i < inv.Length; i++)
                            {
                                if (inv[i] == null) continue;
                                if (inv[i].ObjectId == "Sor Fragment 3")
                                {
                                    inv[i] = Manager.Resources.GameData.Items[0x49e5];
                                    inv[d] = null;
                                    inv[c] = null;
                                    SaveToCharacter();
                                    SendInfo("You have successfully constructed a Sor Crystal!");
                                    break;
                                }
                                else
                                {
                                    SendError("You do not have a Sor Fragment 3 in your inventory.");
                                }
                            }
                        }
                        else
                        {
                            SendError("You do not have a Sor Fragment 2 in your inventory.");
                        }
                    }
                }
                else
                {
                    SendError("You do not have a Sor Fragment 1 in your inventory.");
                }
            }
        }

        private void AETreasureActivate(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var acc = Client.Account;
            Client.Manager.Database.UpdateCredit(acc, eff.Amount);
            Credits += eff.Amount;
            this.ForceUpdate(Credits);

        }

        /* private void AEFameActivate(RealmTime time, Item item, Position target, ActivateEffect eff)
         {
             var acc = Client.Account;
             Client.Manager.Database.UpdateFame(acc, eff.Amount);
             Fame += eff.Amount;
             this.ForceUpdate(Fame);

         }*/

        private void AEOnraneActivate(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var acc = Client.Account;
            Client.Manager.Database.UpdateOnrane(acc, eff.Amount);
            Onrane += eff.Amount;
            this.ForceUpdate(Credits);

        }

        private void AEActivateFragment(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            ushort[] fragmentList = { 0x61c3, 0x61c2, 0x61c1 };
            var acc = Client.Account;
            Random rnd = new Random();
            int Chance = Random.Next(0, 8);
            switch (Chance)
            {
                case 0:
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    SendInfo("You received 1 Sor Fragment.");
                    break;

                case 1:
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    SendInfo("You received 2 Sor Fragments.");
                    break;

                case 2:
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    SendInfo("You received 3 Sor Fragments.");
                    break;

                case 3:
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    SendInfo("You received 4 Sor Fragments.");
                    break;

                case 4:
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    SendInfo("Astonishing! You've received 5 Sor Fragments!");
                    break;

                case 5:
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    SendInfo("You received 1 Sor Fragment.");
                    break;

                case 6:
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    SendInfo("You received 1 Sor Fragment.");
                    break;

                case 7:
                    Manager.Database.AddGift(acc, fragmentList[rnd.Next(fragmentList.Length)]);
                    SendInfo("You received 1 Sor Fragment.");
                    break;
            }

        }

        private void AERandomOnrane(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var acc = Client.Account;
            int OnraneChance = Random.Next(0, 5);
            switch (OnraneChance)
            {
                case 0:
                    Client.Manager.Database.UpdateOnrane(acc, 2);
                    Onrane += 2;
                    this.ForceUpdate(Onrane);
                    SendInfo("You have obtained 2 Onrane.");
                    break;

                case 1:
                    Client.Manager.Database.UpdateOnrane(acc, 4);
                    Onrane += 4;
                    this.ForceUpdate(Onrane);
                    SendInfo("You have obtained 4 Onrane.");
                    break;

                case 2:
                    Client.Manager.Database.UpdateOnrane(acc, 6);
                    Onrane += 6;
                    this.ForceUpdate(Onrane);
                    SendInfo("You have obtained 6 Onrane.");
                    break;

                case 3:
                    Client.Manager.Database.UpdateOnrane(acc, 8);
                    Onrane += 8;
                    this.ForceUpdate(Onrane);
                    SendInfo("You have obtained 8 Onrane.");
                    break;

                case 4:
                    Client.Manager.Database.UpdateOnrane(acc, 10);
                    Onrane += 10;
                    this.ForceUpdate(Onrane);
                    SendInfo("You have obtained 10 Onrane.");
                    break;
            }

        }

        private void AERandomGold(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var acc = Client.Account;
            int GoldChance = Random.Next(0, 3);
            switch (GoldChance)
            {
                case 0:
                    Client.Manager.Database.UpdateCredit(acc, 250);
                    Credits += 250;
                    this.ForceUpdate(Credits);
                    SendInfo("You have obtained 250 Gold.");
                    break;

                case 1:
                    Client.Manager.Database.UpdateCredit(acc, 500);
                    Credits += 500;
                    this.ForceUpdate(Credits);
                    SendInfo("You have obtained 500 Gold.");
                    break;

                case 2:
                    Client.Manager.Database.UpdateCredit(acc, 750);
                    Credits += 750;
                    this.ForceUpdate(Credits);
                    SendInfo("You have obtained 750 Gold.");
                    break;
            }

        }
        private void AEURandomOnrane(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var acc = Client.Account;
            int OnraneChance = Random.Next(0, 5);
            switch (OnraneChance)
            {
                case 0:
                    Client.Manager.Database.UpdateOnrane(acc, 12);
                    Onrane += 12;
                    this.ForceUpdate(Onrane);
                    SendInfo("You have obtained 12 Onrane.");
                    break;

                case 1:
                    Client.Manager.Database.UpdateOnrane(acc, 14);
                    Onrane += 14;
                    this.ForceUpdate(Onrane);
                    SendInfo("You have obtained 14 Onrane.");
                    break;

                case 2:
                    Client.Manager.Database.UpdateOnrane(acc, 16);
                    Onrane += 16;
                    this.ForceUpdate(Onrane);
                    SendInfo("You have obtained 16 Onrane.");
                    break;

                case 3:
                    Client.Manager.Database.UpdateOnrane(acc, 18);
                    Onrane += 18;
                    this.ForceUpdate(Onrane);
                    SendInfo("You have obtained 18 Onrane.");
                    break;

                case 4:
                    Client.Manager.Database.UpdateOnrane(acc, 20);
                    Onrane += 20;
                    this.ForceUpdate(Onrane);
                    SendInfo("You have obtained 20 Onrane.");
                    break;
            }


        }



        private void AECreate(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var gameData = Manager.Resources.GameData;

            ushort objType;
            if (!gameData.IdToObjectType.TryGetValue(eff.Id, out objType) ||
                !gameData.Portals.ContainsKey(objType))
                return; // object not found, ignore

            var entity = Resolve(Manager, objType);
            var timeoutTime = gameData.Portals[objType].Timeout;

            entity.Move(X, Y);
            Owner.EnterWorld(entity);

            (entity as Portal).PlayerOpened = true;
            (entity as Portal).Opener = Name;

            Owner.Timers.Add(new WorldTimer(timeoutTime * 1000, (world, t) => world.LeaveWorld(entity)));

            Owner.BroadcastPacket(new Notification
            {
                Color = new ARGB(0xFF00FF00),
                ObjectId = Id,
                Message = "Opened by " + Name
            }, null, PacketPriority.Low);
            foreach (var player in Owner.Players.Values)
                player.SendInfo("{\"key\":\"{server.dungeon_opened_by}\",\"tokens\":{\"dungeon\":\"" + gameData.Portals[objType].DungeonName + "\",\"name\":\"" + Name + "\"}}");
        }

        private void AEIncrementStat(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var idx = StatsManager.GetStatIndex((StatsType)eff.Stats);
            var statInfo = Manager.Resources.GameData.Classes[ObjectType].Stats;

            Stats.Base[idx] += eff.Amount;
            if (Stats.Base[idx] > statInfo[idx].MaxValue)
            {
                Stats.Base[idx] = statInfo[idx].MaxValue;

                // pot boosting
                var boostAmount = 1;
                if (idx == 0 || idx == 1)
                    boostAmount = 20;
                Stats.Boost.ActivateBoost[idx].AddOffset(boostAmount);
                Stats.ReCalculateValues();
            }
        }

        private void AEFixedStat(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var idx = StatsManager.GetStatIndex((StatsType)eff.Stats);
            Stats.Base[idx] = eff.Amount;
        }

        private void AERemoveNegativeConditionSelf(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            ApplyConditionEffect(NegativeEffs);
            BroadcastSync(new ShowEffect()
            {
                EffectType = EffectType.AreaBlast,
                TargetObjectId = Id,
                Color = new ARGB(0xffffffff),
                Pos1 = new Position() { X = 1 }
            }, p => this.DistSqr(p) < RadiusSqr);
        }

        private void AERemoveNegativeConditions(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            this.AOE(eff.Range, true, player => player.ApplyConditionEffect(NegativeEffs));
            BroadcastSync(new ShowEffect()
            {
                EffectType = EffectType.AreaBlast,
                TargetObjectId = Id,
                Color = new ARGB(0xffffffff),
                Pos1 = new Position() { X = eff.Range }
            }, p => this.DistSqr(p) < RadiusSqr);
        }

        private void AEPoisonGrenade(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            BroadcastSync(new ShowEffect()
            {
                EffectType = EffectType.Throw,
                Color = new ARGB(0xffddff00),
                TargetObjectId = Id,
                Pos1 = target
            }, p => this.DistSqr(p) < RadiusSqr);

            var x = new Placeholder(Manager, 1500);
            x.Move(target.X, target.Y);
            Owner.EnterWorld(x);
            Owner.Timers.Add(new WorldTimer(1500, (world, t) =>
            {
                world.BroadcastPacketNearby(new ShowEffect()
                {
                    EffectType = EffectType.AreaBlast,
                    Color = new ARGB(0xffddff00),
                    TargetObjectId = x.Id,
                    Pos1 = new Position() { X = eff.Radius }
                }, x, null, PacketPriority.High);

                world.AOE(target, eff.Radius, false,
                    enemy => PoisonEnemy(world, enemy as Enemy, eff));
            }));
        }

        private void AELightning(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            const double coneRange = Math.PI / 4;
            var mouseAngle = Math.Atan2(target.Y - Y, target.X - X);

            // get starting target
            var startTarget = this.GetNearestEntity(MaxAbilityDist, false, e => e is Enemy &&
                Math.Abs(mouseAngle - Math.Atan2(e.Y - Y, e.X - X)) <= coneRange);

            // no targets? bolt air animation
            if (startTarget == null)
            {
                var noTargets = new Packet[3];
                var angles = new double[] { mouseAngle, mouseAngle - coneRange, mouseAngle + coneRange };
                for (var i = 0; i < 3; i++)
                {
                    var x = (int)(MaxAbilityDist * Math.Cos(angles[i])) + X;
                    var y = (int)(MaxAbilityDist * Math.Sin(angles[i])) + Y;
                    noTargets[i] = new ShowEffect()
                    {
                        EffectType = EffectType.Trail,
                        TargetObjectId = Id,
                        Color = new ARGB(0xffff0088),
                        Pos1 = new Position()
                        {
                            X = x,
                            Y = y
                        },
                        Pos2 = new Position() { X = 350 }
                    };
                }
                BroadcastSync(noTargets, p => this.DistSqr(p) < RadiusSqr);
                return;
            }

            var current = startTarget;
            var targets = new Entity[eff.MaxTargets];
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i] = current;
                var next = current.GetNearestEntity(10, false, e =>
                {
                    if (!(e is Enemy) ||
                        e.HasConditionEffect(ConditionEffects.Invincible) ||
                        e.HasConditionEffect(ConditionEffects.Stasis) ||
                        Array.IndexOf(targets, e) != -1)
                        return false;

                    return true;
                });

                if (next == null)
                    break;

                current = next;
            }

            var pkts = new List<Packet>();
            for (var i = 0; i < targets.Length; i++)
            {
                if (targets[i] == null)
                    break;

                var prev = i == 0 ? this : targets[i - 1];

                (targets[i] as Enemy).Damage(this, time, eff.TotalDamage, false);

                if (eff.ConditionEffect != null)
                    targets[i].ApplyConditionEffect(new ConditionEffect()
                    {
                        Effect = eff.ConditionEffect.Value,
                        DurationMS = (int)(eff.EffectDuration * 1000)
                    });

                pkts.Add(new ShowEffect()
                {
                    EffectType = EffectType.Lightning,
                    TargetObjectId = prev.Id,
                    Color = new ARGB(0xffff0088),
                    Pos1 = new Position()
                    {
                        X = targets[i].X,
                        Y = targets[i].Y
                    },
                    Pos2 = new Position() { X = 350 }
                });
            }
            BroadcastSync(pkts, p => this.DistSqr(p) < RadiusSqr);
        }

        private void AEDecoy(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var decoy = new Decoy(this, eff.DurationMS, 4);
            decoy.Move(X, Y);
            Owner.EnterWorld(decoy);
        }

        private void StasisBlast(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var pkts = new List<Packet>
            {
                new ShowEffect()
                {
                    EffectType = EffectType.Concentrate,
                    TargetObjectId = Id,
                    Pos1 = target,
                    Pos2 = new Position() {X = target.X + 3, Y = target.Y},
                    Color = new ARGB(0xffffffff)
                }
            };

            Owner.AOE(target, 3, false, enemy =>
            {
                if (enemy.HasConditionEffect(ConditionEffects.StasisImmune))
                {
                    pkts.Add(new Notification()
                    {
                        ObjectId = enemy.Id,
                        Color = new ARGB(0xff00ff00),
                        Message = "Immune"
                    });
                }
                else if (!enemy.HasConditionEffect(ConditionEffects.Stasis))
                {
                    enemy.ApplyConditionEffect(ConditionEffectIndex.Stasis, eff.DurationMS);

                    Owner.Timers.Add(new WorldTimer(eff.DurationMS, (world, t) =>
                        enemy.ApplyConditionEffect(ConditionEffectIndex.StasisImmune, 3000)));

                    pkts.Add(new Notification()
                    {
                        ObjectId = enemy.Id,
                        Color = new ARGB(0xffff0000),
                        Message = "Stasis"
                    });
                }
            });
            BroadcastSync(pkts, p => this.DistSqr(p) < RadiusSqr);
        }
        private void BigStasisBlast(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var pkts = new List<Packet>
            {
                new ShowEffect()
                {
                    EffectType = EffectType.Concentrate,
                    TargetObjectId = Id,
                    Pos1 = target,
                    Pos2 = new Position() {X = target.X + 6, Y = target.Y},
                    Color = new ARGB(0x00FF00)
                }
            };

            Owner.AOE(target, 6, false, enemy =>
            {
                if (enemy.HasConditionEffect(ConditionEffects.StasisImmune))
                {
                    pkts.Add(new Notification()
                    {
                        ObjectId = enemy.Id,
                        Color = new ARGB(0xff00ff00),
                        Message = "Immune"
                    });
                }
                else if (!enemy.HasConditionEffect(ConditionEffects.Stasis))
                {
                    enemy.ApplyConditionEffect(ConditionEffectIndex.Stasis, eff.DurationMS);

                    Owner.Timers.Add(new WorldTimer(eff.DurationMS, (world, t) =>
                        enemy.ApplyConditionEffect(ConditionEffectIndex.StasisImmune, 3000)));

                    pkts.Add(new Notification()
                    {
                        ObjectId = enemy.Id,
                        Color = new ARGB(0xffff0000),
                        Message = "Stasis"
                    });
                }
            });
            BroadcastSync(pkts, p => this.DistSqr(p) < RadiusSqr);
        }
        private void AETrap(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            BroadcastSync(new ShowEffect()
            {
                EffectType = EffectType.Throw,
                Color = new ARGB(0xff9000ff),
                TargetObjectId = Id,
                Pos1 = target
            }, p => this.DistSqr(p) < RadiusSqr);

            Owner.Timers.Add(new WorldTimer(1500, (world, t) =>
            {
                var trap = new Trap(
                    this,
                    eff.Radius,
                    eff.TotalDamage,
                    eff.ConditionEffect ?? ConditionEffectIndex.Slowed,
                    eff.EffectDuration);
                trap.Move(target.X, target.Y);
                world.EnterWorld(trap);
            }));
        }

        private void AEVampireBlast(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var pkts = new List<Packet>
            {
                new ShowEffect()
                {
                    EffectType = EffectType.Trail,
                    TargetObjectId = Id,
                    Pos1 = target,
                    Color = new ARGB(0xFFFF0000)
                },
                new ShowEffect
                {
                    EffectType = EffectType.Diffuse,
                    Color = new ARGB(0xFFFF0000),
                    TargetObjectId = Id,
                    Pos1 = target,
                    Pos2 = new Position { X = target.X + eff.Radius, Y = target.Y }
                }
            };

            var totalDmg = 0;
            var enemies = new List<Enemy>();
            Owner.AOE(target, eff.Radius, false, enemy =>
            {
                enemies.Add(enemy as Enemy);
                totalDmg += (enemy as Enemy).Damage(this, time, eff.TotalDamage, false);
            });

            var players = new List<Player>();
            this.AOE(eff.Radius, true, player =>
            {
                if (!player.HasConditionEffect(ConditionEffects.Sick) || !player.HasConditionEffect(ConditionEffects.Corrupted))
                {
                    players.Add(player as Player);
                    ActivateHealHp(player as Player, totalDmg, pkts);
                }
            });

            if (enemies.Count > 0)
            {
                var rand = new Random();
                for (var i = 0; i < 5; i++)
                {
                    var a = enemies[rand.Next(0, enemies.Count)];
                    var b = players[rand.Next(0, players.Count)];
                    pkts.Add(new ShowEffect()
                    {
                        EffectType = EffectType.Flow,
                        TargetObjectId = b.Id,
                        Pos1 = new Position() { X = a.X, Y = a.Y },
                        Color = new ARGB(0xffffffff)
                    });
                }
            }

            BroadcastSync(pkts, p => this.DistSqr(p) < RadiusSqr);
        }

        private void AETeleport(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            TeleportPosition(time, target, true);
        }

        private void AEMagicNova(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var pkts = new List<Packet>();
            this.AOE(eff.Range, true, player =>
            {
                if (!player.HasConditionEffect(ConditionEffects.Corrupted))
                    ActivateHealMp(player as Player, eff.Amount + (RestorationHeal() / 4), pkts);
            });
            pkts.Add(new ShowEffect()
            {
                EffectType = EffectType.AreaBlast,
                TargetObjectId = Id,
                Color = new ARGB(0xffffffff),
                Pos1 = new Position() { X = eff.Range }
            });
            BroadcastSync(pkts, p => this.DistSqr(p) < RadiusSqr);
        }

        private void AEMagic(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var pkts = new List<Packet>();
            if (!HasConditionEffect(ConditionEffects.Corrupted))
            {
                ActivateHealMp(this, eff.Amount + (RestorationHeal() / 4), pkts);
            }
            BroadcastSync(pkts, p => this.DistSqr(p) < RadiusSqr);
        }
        private void AEMagicNoRest(RealmTime time, Item item, Position target, int amount)
        {
            var pkts = new List<Packet>();
            if (!HasConditionEffect(ConditionEffects.Corrupted))
            {
                ActivateHealMp(this, amount, pkts);
            }
            BroadcastSync(pkts, p => this.DistSqr(p) < RadiusSqr);
        }
        private void AEHealNoRest(RealmTime time, Item item, Position target, int amount)
        {
            var pkts = new List<Packet>();
            if (!HasConditionEffect(ConditionEffects.Corrupted))
            {
                ActivateHealHp(this, amount, pkts);
            }
            BroadcastSync(pkts, p => this.DistSqr(p) < RadiusSqr);
        }
        private void AEHealNova(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var amount = eff.Amount;
            var range = eff.Range;
            if (eff.UseWisMod)
            {
                amount = (int)UseWisMod(eff.Amount, 0);
                range = UseWisMod(eff.Range);
            }

            var pkts = new List<Packet>();
            this.AOE(range, true, player =>
                {
                    if (!player.HasConditionEffect(ConditionEffects.Sick) || !player.HasConditionEffect(ConditionEffects.Corrupted))
                        ActivateHealHp(player as Player, amount + (RestorationHeal() / 4), pkts);
                });
            pkts.Add(new ShowEffect()
            {
                EffectType = EffectType.AreaBlast,
                TargetObjectId = Id,
                Color = new ARGB(0xffffffff),
                Pos1 = new Position() { X = range }
            });
            BroadcastSync(pkts, p => this.DistSqr(p) < RadiusSqr);
        }

        private void AEHeal(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            if (!HasConditionEffect(ConditionEffects.Sick) || !HasConditionEffect(ConditionEffects.Corrupted))
            {
                var pkts = new List<Packet>();
                ActivateHealHp(this, eff.Amount + (RestorationHeal() / 4), pkts);
                BroadcastSync(pkts, p => this.DistSqr(p) < RadiusSqr);
            }
        }
        private void AEHeal2(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            if (!HasConditionEffect(ConditionEffects.Sick) || !HasConditionEffect(ConditionEffects.Corrupted))
            {
                var pkts = new List<Packet>();
                ActivateHealHp(this, RestorationHeal(), pkts);
                BroadcastSync(pkts, p => this.DistSqr(p) < RadiusSqr);
            }
        }
        private void AEMagic2(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var pkts = new List<Packet>();
            if (!HasConditionEffect(ConditionEffects.Corrupted))
            {
                ActivateHealMp(this, RestorationHeal(), pkts);
            }
            BroadcastSync(pkts, p => this.DistSqr(p) < RadiusSqr);
        }
        private void AEDiceActivate(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            Random rnd = new Random();
            int ability = rnd.Next(1, 7);
            switch (ability)
            {
                case 1:
                    ApplyConditionEffect(ConditionEffectIndex.Bravery, eff.DurationMS);
                    break;
                case 2:
                    ApplyConditionEffect(ConditionEffectIndex.ArmorBroken, eff.DurationMS);
                    break;
                case 3:
                    ApplyConditionEffect(ConditionEffectIndex.Berserk, eff.DurationMS);
                    break;
                case 4:
                    ApplyConditionEffect(ConditionEffectIndex.Speedy, eff.DurationMS);
                    break;
                case 5:
                    ApplyConditionEffect(ConditionEffectIndex.Healing, eff.DurationMS);
                    break;
                case 6:
                    ApplyConditionEffect(ConditionEffectIndex.Damaging, eff.DurationMS);
                    break;
            }
        }
    
        private void AEUnlockSkin(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var acc = Client.Account;
            var ownedSkins = acc.Skins.ToList();
            if (!ownedSkins.Contains(eff.SkinType))
            {
                ownedSkins.Add(eff.SkinType);
                acc.Skins = ownedSkins.ToArray();

                acc.FlushAsync();
                SendInfo("You've unlocked a new skin! Check your Wardrobe in the vault!");
            }
            else
            {
                SendError("You already have this skin!");
            }

        }
        private void AEConditionEffectAura(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var duration = eff.DurationMS;
            var range = eff.Range;
            if (eff.UseWisMod)
            {
                duration = (int)(UseWisMod(eff.DurationSec) * 1000);
                range = UseWisMod(eff.Range);
            }

            this.AOE(range, true, player =>
            {
                player.ApplyConditionEffect(new ConditionEffect()
                {
                    Effect = eff.ConditionEffect.Value,
                    DurationMS = duration
                });
            });
            var color = 0xffffffff;
            if (eff.ConditionEffect.Value == ConditionEffectIndex.Damaging)
                color = 0xffff0000;
            if (eff.ConditionEffect.Value == ConditionEffectIndex.Surged)
                color = 0xFFFF00;
            BroadcastSync(new ShowEffect()
            {
                EffectType = EffectType.AreaBlast,
                TargetObjectId = Id,
                Color = new ARGB(color),
                Pos1 = new Position() { X = range }
            }, p => this.DistSqr(p) < RadiusSqr);
        }


        private void BurstFire(RealmTime time, Item item, Position target)
        {
            this.AOE(3, false, enemy => BurnEnemy(Owner, enemy as Enemy, 3000));
            BroadcastSync(new ShowEffect()
            {
                EffectType = EffectType.AreaBlast,
                TargetObjectId = Id,
                Color = new ARGB(0xf26e2c),
                Pos1 = new Position() { X = 3 }
            }, p => this.DistSqr(p) < RadiusSqr);
        }

        private void AEBurstInferno(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            this.AOE(4, false, enemy => BurnEnemy2(Owner, enemy as Enemy, 8000));
            BroadcastSync(new ShowEffect()
            {
                EffectType = EffectType.AreaBlast,
                TargetObjectId = Id,
                Color = new ARGB(0xf26e2c),
                Pos1 = new Position() { X = 4 }
            }, p => this.DistSqr(p) < RadiusSqr);
        }

        private void WeakBlast(RealmTime time, Item item, Position target)
        {
            this.AOE(4, false, enemy =>
            {
                enemy.ApplyConditionEffect(new ConditionEffect()
                {
                    Effect = ConditionEffectIndex.Weak,
                    DurationMS = 2500
                });
            });
            BroadcastSync(new ShowEffect()
            {
                EffectType = EffectType.AreaBlast,
                TargetObjectId = Id,
                Color = new ARGB(0x000000),
                Pos1 = new Position() { X = 4 }
            }, p => this.DistSqr(p) < RadiusSqr);
        }

        private void AEClearConditionEffectAura(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            this.AOE(eff.Range, true, player =>
                {
                    var condition = eff.CheckExistingEffect;
                    ConditionEffects conditions = 0;
                    conditions |= (ConditionEffects)(1 << (Byte)condition.Value);
                    if (!condition.HasValue || player.HasConditionEffect(conditions))
                    {
                        player.ApplyConditionEffect(new ConditionEffect()
                        {
                            Effect = eff.ConditionEffect.Value,
                            DurationMS = 0
                        });
                    }
                });
        }

        private void AEConditionEffectSelf(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var duration = eff.DurationMS;
            if (eff.UseWisMod)
                duration = (int)(UseWisMod(eff.DurationSec) * 1000);

            ApplyConditionEffect(new ConditionEffect()
            {
                Effect = eff.ConditionEffect.Value,
                DurationMS = duration
            });
            BroadcastSync(new ShowEffect()
            {
                EffectType = EffectType.AreaBlast,
                TargetObjectId = Id,
                Color = new ARGB(0xffffffff),
                Pos1 = new Position() { X = 1 }
            }, p => this.DistSqr(p) < RadiusSqr);
        }

        private void AEStatBoostAura(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var idx = StatsManager.GetStatIndex((StatsType)eff.Stats);
            var amount = eff.Amount;
            var duration = eff.DurationMS;
            var range = eff.Range;
            if (eff.UseWisMod)
            {
                amount = (int)UseWisMod(eff.Amount, 0);
                duration = (int)(UseWisMod(eff.DurationSec) * 1000);
                range = UseWisMod(eff.Range);
            }

            this.AOE(range, true, player =>
            {
                ((Player)player).Stats.Boost.ActivateBoost[idx].Push(amount, eff.NoStack);
                ((Player)player).Stats.ReCalculateValues();


                // hack job to allow instant heal of nostack boosts
                if (eff.NoStack && amount > 0 && idx == 0)
                {
                    ((Player)player).HP = Math.Min(((Player)player).Stats[0], ((Player)player).HP + amount);
                }


                Owner.Timers.Add(new WorldTimer(duration, (world, t) =>
                {
                    ((Player)player).Stats.Boost.ActivateBoost[idx].Pop(amount, eff.NoStack);
                    ((Player)player).Stats.ReCalculateValues();
                }));
            });

            if (!eff.NoStack)
                BroadcastSync(new ShowEffect()
                {
                    EffectType = EffectType.AreaBlast,
                    TargetObjectId = Id,
                    Color = new ARGB(0xffffffff),
                    Pos1 = new Position() { X = range }
                }, p => this.DistSqr(p) < RadiusSqr);
        }

        private void AEStatBoostSelf(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var idx = StatsManager.GetStatIndex((StatsType)eff.Stats);
            var s = eff.Amount;
            Stats.Boost.ActivateBoost[idx].Push(s, eff.NoStack);
            Stats.ReCalculateValues();
            Owner.Timers.Add(new WorldTimer(eff.DurationMS, (world, t) =>
            {
                Stats.Boost.ActivateBoost[idx].Pop(s, eff.NoStack);
                Stats.ReCalculateValues();
            }));
            BroadcastSync(new ShowEffect()
            {
                EffectType = EffectType.Potion,
                TargetObjectId = Id,
                Color = new ARGB(0xffffffff)
            }, p => this.DistSqr(p) < RadiusSqr);
        }

        private void AEShoot(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var arcGap = item.ArcGap * Math.PI / 180;
            var startAngle = Math.Atan2(target.Y - Y, target.X - X) - (item.NumProjectiles - 1) / 2 * arcGap;
            var prjDesc = item.Projectiles[0]; //Assume only one

            var sPkts = new Packet[item.NumProjectiles];
            for (var i = 0; i < item.NumProjectiles; i++)
            {
                var proj = CreateProjectile(prjDesc, item.ObjectType,
                    (int)Stats.GetAttackDamage(prjDesc.MinDamage, prjDesc.MaxDamage, true),
                    time.TotalElapsedMs, new Position() { X = X, Y = Y }, (float)(startAngle + arcGap * i));
                Owner.EnterWorld(proj);
                sPkts[i] = new AllyShoot()
                {
                    OwnerId = Id,
                    Angle = proj.Angle,
                    ContainerType = item.ObjectType,
                    BulletId = proj.ProjectileId
                };
                FameCounter.Shoot(proj);
            }
            BroadcastSync(sPkts, p => p != this && this.DistSqr(p) < RadiusSqr);
        }

        private void AEBulletNova(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var prjs = new Projectile[20];
            var prjDesc = item.Projectiles[0]; //Assume only one
            var batch = new Packet[21];
            for (var i = 0; i < 20; i++)
            {
                var proj = CreateProjectile(prjDesc, item.ObjectType,
                    Random.Next(prjDesc.MinDamage, prjDesc.MaxDamage),
                    time.TotalElapsedMs, target, (float)(i * (Math.PI * 2) / 20));
                Owner.EnterWorld(proj);
                FameCounter.Shoot(proj);
                batch[i] = new ServerPlayerShoot()
                {
                    BulletId = proj.ProjectileId,
                    OwnerId = Id,
                    ContainerType = item.ObjectType,
                    StartingPos = target,
                    Angle = proj.Angle,
                    Damage = (short)proj.Damage
                };
                prjs[i] = proj;
            }
            batch[20] = new ShowEffect()
            {
                EffectType = EffectType.Trail,
                Pos1 = target,
                TargetObjectId = Id,
                Color = new ARGB(0xFFFF00AA)
            };

            foreach (var plr in Owner.Players.Values
                        .Where(p => p.DistSqr(this) < RadiusSqr))
            {
                plr.Client.SendPackets(batch);
            }
        }

        private void AEGenericActivate(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            var targetPlayer = eff.Target.Equals("player");
            var centerPlayer = eff.Center.Equals("player");
            var duration = (eff.UseWisMod) ?
                (int)(UseWisMod(eff.DurationSec) * 1000) :
                eff.DurationMS;
            var range = (eff.UseWisMod)
                ? UseWisMod(eff.Range)
                : eff.Range;

            if (eff.ConditionEffect != null)
                Owner.AOE((eff.Center.Equals("mouse")) ? target : new Position { X = X, Y = Y }, range, targetPlayer, entity =>
                {
                    if(!entity.HasConditionEffect(ConditionEffects.Stasis) &&
                       !entity.HasConditionEffect(ConditionEffects.Invincible))
                    {
                        entity.ApplyConditionEffect(new ConditionEffect()
                        {
                            Effect = eff.ConditionEffect.Value,
                            DurationMS = duration
                        });
                    }
                });

            BroadcastSync(new ShowEffect()
            {
                EffectType = (EffectType)eff.VisualEffect,
                TargetObjectId = Id,
                Color = new ARGB(eff.Color),
                Pos1 = (centerPlayer) ? new Position() { X = range } : target,
                Pos2 = new Position() { X = target.X - range, Y = target.Y }
            }, p => this.DistSqr(p) < RadiusSqr);
        }

        private void AEHealingGrenade(RealmTime time, Item item, Position target, ActivateEffect eff)
        {
            BroadcastSync(new ShowEffect()
            {
                EffectType = EffectType.Throw,
                Color = new ARGB(0xffddff00),
                TargetObjectId = Id,
                Pos1 = target
            }, p => this.DistSqr(p) < RadiusSqr);

            var x = new Placeholder(Manager, 1500);
            x.Move(target.X, target.Y);
            Owner.EnterWorld(x);
            Owner.Timers.Add(new WorldTimer(1500, (world, t) =>
            {
                world.BroadcastPacketNearby(new ShowEffect()
                {
                    EffectType = EffectType.AreaBlast,
                    Color = new ARGB(0xffddff00),
                    TargetObjectId = x.Id,
                    Pos1 = new Position() { X = eff.Radius }
                }, x, null, PacketPriority.Low);

                world.AOE(target, eff.Radius, true,
                    player => HealingPlayersPoison(world, player as Player, eff));
            }));
        }

        static void ActivateHealHp(Player player, int amount, List<Packet> pkts)
        {
            if (player.HasConditionEffect(ConditionEffects.DrakzixCharging))
            return;

            if (player.HasConditionEffect(ConditionEffects.Corrupted))
            return;

            var maxHp = player.Stats[0];
            var newHp = Math.Min(maxHp, player.HP + amount);
            if (newHp == player.HP)
                return;

            pkts.Add(new ShowEffect()
            {
                EffectType = EffectType.Potion,
                TargetObjectId = player.Id,
                Color = new ARGB(0xffffffff)
            });
            pkts.Add(new Notification()
            {
                Color = new ARGB(0xff00ff00),
                ObjectId = player.Id,
                Message = "{\"key\":\"blank\",\"tokens\":{\"data\":\"+" + (newHp - player.HP) + "\"}}"
                //"+" + (newHp - player.HP)
            });

            player.HP = newHp;
        }

        static void ActivateHealMp(Player player, int amount, List<Packet> pkts)
        {
            if (player.HasConditionEffect(ConditionEffects.DrakzixCharging))
                return;

            if (player.HasConditionEffect(ConditionEffects.Corrupted))
                return;
            var maxMp = player.Stats[1];
            var newMp = Math.Min(maxMp, player.MP + amount);
            if (newMp == player.MP) 
                return;
            
            pkts.Add(new ShowEffect()
            {
                EffectType = EffectType.Potion,
                TargetObjectId = player.Id,
                Color = new ARGB(0x6084e0)
            });
            pkts.Add(new Notification()
            {
                Color = new ARGB(0x6084e0),
                ObjectId = player.Id,
                Message = "+" + (newMp - player.MP)
            });

            player.MP = newMp;
        }

        void PoisonEnemy(World world, Enemy enemy, ActivateEffect eff)
        {
            var remainingDmg = (int)StatsManager.GetDefenseDamage(enemy, eff.TotalDamage, enemy.ObjectDesc.Defense);
            var perDmg = remainingDmg * 1000 / eff.DurationMS;

            WorldTimer tmr = null;
            var x = 0;

            Func<World, RealmTime, bool> poisonTick = (w, t) =>
            {
                if (enemy.Owner == null || w == null)
                    return true;

                w.BroadcastPacketConditional(new ShowEffect()
                {
                    EffectType = EffectType.Dead,
                    TargetObjectId = enemy.Id,
                    Color = new ARGB(0xffddff00)
                }, p => enemy.DistSqr(p) < RadiusSqr);

                if (x % 4 == 0) // make sure to change this if timer delay is changed
                {
                    var thisDmg = perDmg;
                    if (remainingDmg < thisDmg)
                        thisDmg = remainingDmg;

                    enemy.Damage(this, t, thisDmg, true);
                    remainingDmg -= thisDmg;
                    if (remainingDmg <= 0)
                        return true;
                }
                x++;

                tmr.Reset();
                return false;
            };

            tmr = new WorldTimer(250, poisonTick);
            world.Timers.Add(tmr);
        }
        void BurnEnemy(World world, Enemy enemy, int damage)
        {
            var remainingDmg = (int)StatsManager.GetDefenseDamage(enemy, damage, enemy.ObjectDesc.Defense);
            var perDmg = remainingDmg * 1000 / 7000;

            WorldTimer tmr = null;
            var x = 0;

            Func<World, RealmTime, bool> burnTick = (w, t) =>
            {
                if (enemy.Owner == null || w == null)
                    return true;

                w.BroadcastPacketConditional(new ShowEffect()
                {
                    EffectType = EffectType.Dead,
                    TargetObjectId = enemy.Id,
                    Color = new ARGB(0xbd460a)
                }, p => enemy.DistSqr(p) < RadiusSqr);

                if (x % 4 == 0) // make sure to change this if timer delay is changed
                {
                    var thisDmg = perDmg;
                    if (remainingDmg < thisDmg)
                        thisDmg = remainingDmg;

                    enemy.Damage(this, t, thisDmg, true);
                    remainingDmg -= thisDmg;
                    if (remainingDmg <= 0)
                        return true;
                }
                x++;

                tmr.Reset();
                return false;
            };

            tmr = new WorldTimer(250, burnTick);
            world.Timers.Add(tmr);
        }
        void BurnEnemy2(World world, Enemy enemy, int damage)
        {
            var remainingDmg = (int)StatsManager.GetDefenseDamage(enemy, damage, enemy.ObjectDesc.Defense);
            var perDmg = remainingDmg * 1000 / 8000;

            WorldTimer tmr = null;
            var x = 0;

            Func<World, RealmTime, bool> burnTick = (w, t) =>
            {
                if (enemy.Owner == null || w == null)
                    return true;

                w.BroadcastPacketConditional(new ShowEffect()
                {
                    EffectType = EffectType.Dead,
                    TargetObjectId = enemy.Id,
                    Color = new ARGB(0xbd460a)
                }, p => enemy.DistSqr(p) < RadiusSqr);

                if (x % 4 == 0) // make sure to change this if timer delay is changed
                {
                    var thisDmg = perDmg;
                    if (remainingDmg < thisDmg)
                        thisDmg = remainingDmg;

                    enemy.Damage(this, t, thisDmg, true);
                    remainingDmg -= thisDmg;
                    if (remainingDmg <= 0)
                        return true;
                }
                x++;

                tmr.Reset();
                return false;
            };

            tmr = new WorldTimer(250, burnTick);
            world.Timers.Add(tmr);
        }
        void HealingPlayersPoison(World world, Player player, ActivateEffect eff)
        {
            var remainingHeal = eff.TotalDamage;
            var perHeal = eff.TotalDamage * 1000 / eff.DurationMS;

            WorldTimer tmr = null;
            var x = 0;

            Func<World, RealmTime, bool> healTick = (w, t) =>
            {
                if (player.Owner == null || w == null)
                    return true;

                if (x % 4 == 0) // make sure to change this if timer delay is changed
                {
                    var thisHeal = perHeal;
                    if (remainingHeal < thisHeal)
                        thisHeal = remainingHeal;

                    List<Packet> pkts = new List<Packet>();

                    Player.ActivateHealHp(player, thisHeal, pkts);
                    w.BroadcastPackets(pkts, null, PacketPriority.Low);
                    remainingHeal -= thisHeal;
                    if (remainingHeal <= 0)
                        return true;
                }
                x++;

                tmr.Reset();
                return false;
            };

            tmr = new WorldTimer(250, healTick);
            world.Timers.Add(tmr);
        }

        private float UseWisMod(float value, int offset = 1)
        {
            double totalWisdom = Stats.Base[7] + Stats.Boost[7];

            if (totalWisdom < 30)
                return value;

            double m = (value < 0) ? -1 : 1;
            double n = (value * totalWisdom / 150) + (value * m);
            n = Math.Floor(n * Math.Pow(10, offset)) / Math.Pow(10, offset);
            if (n - (int)n * m >= 1 / Math.Pow(10, offset) * m)
            {
                return ((int)(n * 10)) / 10.0f;
            }

            return (int)n;
        }
    }
}
