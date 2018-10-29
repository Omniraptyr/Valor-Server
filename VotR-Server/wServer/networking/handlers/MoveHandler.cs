using System;
using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.realm;
using common.resources;

namespace wServer.networking.handlers
{
    internal class MoveHandler : PacketHandlerBase<Move>
    {
        public override PacketId ID => PacketId.MOVE;

        protected override void HandlePacket(Client client, Move packet)
        {
            client.Manager.Logic.AddPendingAction(t => Handle(client.Player, t, packet));
        }

        private static void Handle(Player player, RealmTime time, Move packet) {
            if (player?.Owner == null)
                return;

            var newX = packet.NewPosition.X;
            var newY = packet.NewPosition.Y;

            /*if (Math.Abs(MathsUtils.DistSqr(newX, newY, player.X, player.Y))
                > player.Stats.GetTilesPerSecSqr() * 1.05) {
                player.Client.Disconnect("Moving too fast");
                return;
            }*/

            if (newX != -1 && newX != player.X ||
                  newY != -1 && newY != player.Y) {
                player.Move(newX, newY);
            }

            CheckLabConditions(player, packet);
            player.MoveReceived(time, packet);
        }

        private static void CheckLabConditions(Entity player, Move packet)
        {
            var tile = player.Owner.Map[(int)packet.NewPosition.X, (int)packet.NewPosition.Y];
            switch (tile.TileId)
            {
                //Green water
                case 0xa9:
                case 0x82:
                    if (tile.ObjId != 0)
                        return;
                    if (!player.HasConditionEffect(ConditionEffects.Hexed) ||
                        !player.HasConditionEffect(ConditionEffects.Stunned) ||
                        !player.HasConditionEffect(ConditionEffects.Speedy))
                    {
                        player.ApplyConditionEffect(ConditionEffectIndex.Hexed);
                        player.ApplyConditionEffect(ConditionEffectIndex.Stunned);
                        player.ApplyConditionEffect(ConditionEffectIndex.Speedy);
                    }
                    break;
                //Blue water
                case 0xa7:
                case 0x83:
                    if (tile.ObjId != 0)
                        return;
                    if (player.HasConditionEffect(ConditionEffects.Hexed) ||
                        player.HasConditionEffect(ConditionEffects.Stunned) ||
                        player.HasConditionEffect(ConditionEffects.Speedy))
                    {
                        player.ApplyConditionEffect(ConditionEffectIndex.Hexed, 0);
                        player.ApplyConditionEffect(ConditionEffectIndex.Stunned, 0);
                        player.ApplyConditionEffect(ConditionEffectIndex.Speedy, 0);
                    }
                    break;
            }
        }
    }
}
