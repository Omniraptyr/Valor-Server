using System.Collections.Generic;
using System.Linq;
using common;
using common.resources;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.networking.packets.outgoing;
using wServer.networking.packets.outgoing.pets;
using wServer.realm.entities;
using wServer.realm.worlds.logic;
using PetYard = wServer.networking.packets.outgoing.PetYard;

namespace wServer.networking.handlers
{
    class PetUpgradeRequestHandler : PacketHandlerBase<PetUpgradeRequest>
    {
        public override PacketId ID => PacketId.PETUPGRADEREQUEST;

        protected override void HandlePacket(Client client, PetUpgradeRequest packet)
        {
           //temp disable
        }    
    }
}
