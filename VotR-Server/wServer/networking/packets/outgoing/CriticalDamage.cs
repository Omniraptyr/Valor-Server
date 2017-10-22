using common;

namespace wServer.networking.packets.outgoing
{
    public class CriticalDamage : OutgoingMessage
    {
        public bool IsCritical { get; set; }
        public float CriticalHit { get; set; }

        public override PacketId ID => PacketId.CRITICALDAMAGE;
        public override Packet CreateInstance() { return new CriticalDamage(); }

        protected override void Read(NReader rdr)
        {
            IsCritical = rdr.ReadBoolean();
            CriticalHit = rdr.ReadSingle();
        }

        protected override void Write(NWriter wtr)
        {
            wtr.Write(IsCritical);
            wtr.Write(CriticalHit);
        }
    }
}
