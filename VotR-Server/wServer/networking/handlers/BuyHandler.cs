using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.realm.entities.vendors;

namespace wServer.networking.handlers
{
    class BuyHandler : PacketHandlerBase<Buy>
    {
        public override PacketId ID => PacketId.BUY;

        protected override void HandlePacket(Client client, Buy packet)
        {
            client.Manager.Logic.AddPendingAction(t => Handle(client.Player, packet.ObjectId));
            //Handle(client.Player, packet.ObjectId);
        }

        void Handle(Player player, int objId)
        {
            if (player?.Owner == null)
                return;

            if (objId == 0xc6c && player.Rank < 10)
                player.SendInfo("You must a donator to purchase this item!");

            var obj = player.Owner.GetEntity(objId) as SellableObject;
            obj?.Buy(player);
        }
    }
}
