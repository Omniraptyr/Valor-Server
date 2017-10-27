using common;

namespace wServer.networking.packets.incoming
{
    public class ForgeItem : IncomingMessage
    {
        public ObjectSlot SorSlot { get; set; }
        public ObjectSlot ShardSlot { get; set; }

        public override PacketId ID => PacketId.FORGEITEM;
        public override Packet CreateInstance() { return new ForgeItem(); }

        protected override void Read(NReader rdr)
        {
            SorSlot = ObjectSlot.Read(rdr);
            ShardSlot = ObjectSlot.Read(rdr);
        }

        protected override void Write(NWriter wtr)
        {
            SorSlot.Write(wtr);
            ShardSlot.Write(wtr);
        }
    }
}
