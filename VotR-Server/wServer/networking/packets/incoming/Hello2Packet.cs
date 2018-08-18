using common;

namespace wServer.networking.packets.incoming
{
    public class Hello2Packet : IncomingMessage
    {
        public byte BulletId { get; set; }
        public int ObjectId { get; set; }

        public override PacketId ID => PacketId.HELLO2PACKET;
        public override Packet CreateInstance() { return new Hello2Packet(); }

        protected override void Read(NReader rdr)
        {
            BulletId = rdr.ReadByte();
            ObjectId = rdr.ReadInt32();
        }
        protected override void Write(NWriter wtr)
        {
            wtr.Write(BulletId);
            wtr.Write(ObjectId);
        }
    }
}
