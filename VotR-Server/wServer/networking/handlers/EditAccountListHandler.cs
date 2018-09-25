using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;

namespace wServer.networking.handlers
{
    internal class EditAccountListHandler : PacketHandlerBase<EditAccountList>
    {
        private const int LockAction = 0;
        private const int IgnoreAction = 1;

        public override PacketId ID => PacketId.EDITACCOUNTLIST;

        protected override void HandlePacket(Client client, EditAccountList packet)
        {
            Handle(client, packet.AccountListId, packet.ObjectId, packet.Add);
        }

        private void Handle(Client client, int action, int objId, bool add)
        {
            if (client.Player == null || IsTest(client))
                return;

            var targetPlayer = client.Player.Owner.GetEntity(objId) as Player;
            if (targetPlayer?.Client.Account == null)
            {
                client.Player.SendError("Player not found.");
                return;
            }

            switch (action) {
                case LockAction:
                    client.Manager.Database.LockAccount(client.Account, targetPlayer.Client.Account, add);
                    return;
                case IgnoreAction:
                    client.Manager.Database.IgnoreAccount(client.Account, targetPlayer.Client.Account, add);
                    break;
                default:
                    client.Player.SendError("Inproper action ID.");
                    break;
            }
        }
    }
}
