using System.Linq;
using common;
using log4net;

namespace server
{
    public class ChatManager
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ChatManager));
        
        private readonly InterServerChannel _interServer;

        public ChatManager(InterServerChannel interServer)
        {
            _interServer = interServer;

            // listen to chat communications
            _interServer.AddHandler<ChatMsg>(Channel.Chat, HandleChat);
        }

        private void HandleChat(object sender, InterServerEventArgs<ChatMsg> e)
        {
        }
    }
}
