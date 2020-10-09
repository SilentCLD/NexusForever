using NexusForever.Shared.Network;
using NexusForever.Shared.Network.Message;

namespace NexusForever.WorldServer.Network.Message.Model
{
    [Message(GameMessageOpcode.ServerSupportTicketResult)]
    public class ServerSupportTicketResult : IWritable
    {
        public bool Success { get; set; }

        public void Write(GamePacketWriter writer)
        {
            writer.Write(Success);
        }
    }
}
