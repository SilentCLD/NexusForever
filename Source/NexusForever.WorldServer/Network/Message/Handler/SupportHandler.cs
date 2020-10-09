using NexusForever.Shared.Network.Message;
using NexusForever.WorldServer.Game.Support;
using NexusForever.WorldServer.Network.Message.Model;

namespace NexusForever.WorldServer.Network.Message.Handler
{
    public static class SupportHandler
    {
        [MessageHandler(GameMessageOpcode.ClientSupportTicket)]
        public static void HandleSupportTicket(WorldSession session, ClientSupportTicket ticket)
        {
            SupportManager.Instance.HandleClientSupportTicket(session, ticket);
        }

        [MessageHandler(GameMessageOpcode.ClientBugReport)]
        public static void HandleBugReport(WorldSession session, ClientBugReport report)
        {
            SupportManager.Instance.HandleClientBugReport(session, report);
        }

        [MessageHandler(GameMessageOpcode.ClientPlayerReport)]
        public static void HandleClientPlayerReport(WorldSession session, ClientPlayerReport report)
        {
            SupportManager.Instance.HandleClientPlayerReport(session, report);
        }
    }
}
