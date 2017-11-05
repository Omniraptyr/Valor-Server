using common;
using System;

namespace wServer.networking.packets.incoming
{
    public class UnboxRequest : IncomingMessage
    {
        public int lootboxType { get; set; }

        public override PacketId ID => PacketId.UNBOXREQUEST;
        public override Packet CreateInstance() { return new UnboxRequest(); }

        protected override void Read(NReader rdr)
        {
            lootboxType = rdr.ReadInt32(); 
        }
        protected override void Write(NWriter wtr)
        {
            throw new InvalidOperationException("Nope, no write client packetzzzz :D");
        }
    }
}
