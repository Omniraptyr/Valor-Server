using common;

namespace wServer.networking.packets.incoming
{
    public class AlertNotice : IncomingMessage
    {
        public bool alert { get; set; }

        public override PacketId ID => PacketId.ALERTNOTICE;
        public override Packet CreateInstance() { return new AlertNotice(); }

        protected override void Read(NReader rdr)
        {
            alert = rdr.ReadBoolean();
        }
        protected override void Write(NWriter wtr)
        {
        }
    }
}
