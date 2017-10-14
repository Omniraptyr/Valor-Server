using common;
using System;

namespace wServer.networking.packets.incoming
{
    public class LaunchRaid : IncomingMessage
    {
        public int RaidId { get; set; }
        public bool Ultra { get; set; }

        public override PacketId ID => PacketId.LAUNCH_RAID;
        public override Packet CreateInstance() { return new LaunchRaid(); }

        protected override void Read(NReader rdr)
        {
            RaidId = rdr.ReadInt32();
            Ultra = rdr.ReadBoolean();
        }
        protected override void Write(NWriter wtr)
        {
            throw new InvalidOperationException("Nope, no write client packetzzzz :D");
        }
    }
}
