using common;

namespace wServer.networking.packets.outgoing
{
    public class GambleStart : OutgoingMessage
    {
        public int Amount { get; set; }
        public string Name { get; set; }

        public override PacketId ID => PacketId.GAMBLE_START;
        public override Packet CreateInstance() { return new GambleStart(); }

        protected override void Read(NReader rdr)
        {
            Amount = rdr.ReadInt32();
            Name = rdr.ReadUTF();
        }

        protected override void Write(NWriter wtr)
        {
            wtr.Write(Amount);
            wtr.WriteUTF(Name);
        }
    }
}
