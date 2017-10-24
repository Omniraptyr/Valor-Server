using common;

namespace wServer.networking.packets.outgoing
{
    public class SorForge : OutgoingMessage
    {
        public bool IsForge { get; set; }

        public override PacketId ID => PacketId.SORFORGE;
        public override Packet CreateInstance() { return new SorForge(); }

        protected override void Read(NReader rdr)
        {
            IsForge = rdr.ReadBoolean();
        }

        protected override void Write(NWriter wtr)
        {
            wtr.Write(IsForge);
        }
    }
}
