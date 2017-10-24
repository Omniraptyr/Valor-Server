using common;
using System;

namespace wServer.networking.packets.incoming
{
    public class SorForgeRequest : IncomingMessage
    {
        public bool isForge { get; set; }

        public override PacketId ID => PacketId.SORFORGEREQUEST;
        public override Packet CreateInstance() { return new SorForgeRequest(); }

        protected override void Read(NReader rdr)
        {
            isForge = rdr.ReadBoolean();
        }
        protected override void Write(NWriter wtr)
        {
            throw new InvalidOperationException("Nope, no write client packetzzzz :D");
        }
    }
}
