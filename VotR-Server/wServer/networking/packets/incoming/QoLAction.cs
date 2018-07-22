using common;

namespace wServer.networking.packets.incoming
{
    public class QoLAction : IncomingMessage
    {
        public int ActionId { get; set; }

        public override PacketId ID => PacketId.QOLACTION;
        public override Packet CreateInstance() { return new QoLAction(); }

        protected override void Read(NReader rdr)
        {
            ActionId = rdr.ReadInt32();
        }
        protected override void Write(NWriter wtr)
        {
        }
    }
}
