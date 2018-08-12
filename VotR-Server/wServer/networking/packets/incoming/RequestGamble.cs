using common;

namespace wServer.networking.packets.incoming
{
    public class RequestGamble : IncomingMessage
    {
        public string Name { get; set; }
        public int Amount { get; set; }

        public override PacketId ID => PacketId.REQUESTGAMBLE;
        public override Packet CreateInstance() { return new RequestGamble(); }

        protected override void Read(NReader rdr)
        {
            Name = rdr.ReadUTF();
            Amount = rdr.ReadInt32();
        }

        protected override void Write(NWriter wtr)
        {
            wtr.WriteUTF(Name);
            wtr.Write(Amount);
        }
    }
}
