using common;

namespace wServer.networking.packets.outgoing
{
    public class UnboxResult : OutgoingMessage
    {
        public ushort[] Items { get; set; }

        public override PacketId ID => PacketId.UNBOXRESULT;
        public override Packet CreateInstance() { return new UnboxResult(); }

        protected override void Read(NReader rdr)
        {
            Items = new ushort[rdr.ReadInt16()];
            for (int i = 0; i < Items.Length; i++)
                Items[i] = (ushort)rdr.ReadInt32();
        }

        protected override void Write(NWriter wtr)
        {
            wtr.Write((short)Items.Length);
            for (int i = 0; i < Items.Length; i++)
                wtr.Write((int)Items[i]);
        }
    }
}