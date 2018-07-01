using common;

namespace wServer.networking.packets.incoming
{
    public class MarkRequest : IncomingMessage
    {
        public int MarkId { get; set; }

        public override PacketId ID => PacketId.MARKREQUEST;
        public override Packet CreateInstance() { return new MarkRequest(); }

        protected override void Read(NReader rdr)
        {
            MarkId = rdr.ReadInt32();
        }
        protected override void Write(NWriter wtr)
        {
        }
    }
}
