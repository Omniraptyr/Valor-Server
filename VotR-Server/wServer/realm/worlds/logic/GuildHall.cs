using common.resources;
using wServer.networking;

namespace wServer.realm.worlds.logic
{
    public class GuildHall : World
    {
        public int GuildId { get; }

        public GuildHall(ProtoWorld proto, Client client = null) : base(proto)
        {
            if (client == null)
                return;

            GuildId = client.Account.GuildId;
        }

        public override bool AllowedAccess(Client client)
        {
            return base.AllowedAccess(client) && client.Account.GuildId == GuildId;
        }

        protected override void Init()
        {
            switch (Level())
            {
                case 0:
                    LoadMap("wServer.realm.worlds.maps.GuildHall0.wmap");
                    break;
                case 1:
                    LoadMap("wServer.realm.worlds.maps.GuildHall1.wmap");
                    break;
                case 2:
                    LoadMap("wServer.realm.worlds.maps.GuildHall2.wmap");
                    break;
                case 3:
                    LoadMap("wServer.realm.worlds.maps.GuildHall3.wmap");
                    break;
            }
        }

        private int Level()
        {
            var guild = Manager.Database.GetGuild(GuildId);
            return guild?.Level ?? 0;
        }

        public override World GetInstance(Client client)
        {
            var manager = client.Manager;
            var plrGuildId = client.Account.GuildId;

            // join existing if possible
            foreach (var world in manager.Worlds.Values)
            {
                if (!(world is GuildHall) || (world as GuildHall).GuildId != plrGuildId)
                    continue;

                if (world.Players.Count > 0)
                    return world;

                world.Delete();
                break; // if empty guild hall, reset by making new one
            }

            // create new instance of guild hall
            var gWorld = new GuildHall(manager.Resources.Worlds[Name], client) {IsLimbo = false};
            return Manager.AddWorld(gWorld);
        }
    }
}
