using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.networking.packets.outgoing;

namespace wServer.networking.handlers
{
    class QuestFetchHandler : PacketHandlerBase<QuestFetch>
    {
        public override PacketId ID => PacketId.QUEST_FETCH_ASK;

        protected override void HandlePacket(Client client, QuestFetch packet)
        {
            //we don't use quests
        }
    }
}
