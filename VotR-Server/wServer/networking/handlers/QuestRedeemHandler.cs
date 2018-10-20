#define NO_TINKER_QUESTS //remove this line to enable tinkering

using wServer.networking.packets;
using wServer.networking.packets.incoming.arena;
using wServer.networking.packets.outgoing;

namespace wServer.networking.handlers
{
    class QuestRedeemHandler : PacketHandlerBase<QuestRedeem>
    {
        public override PacketId ID => PacketId.QUEST_REDEEM;

        protected override void HandlePacket(Client client, QuestRedeem redeem)
        {
            //we don't use quests
        }
    }
}
