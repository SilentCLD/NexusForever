using NexusForever.Shared.Network;
using NexusForever.Shared.Network.Message;
using NexusForever.WorldServer.Game.Entity;
using NexusForever.WorldServer.Game.Support.Static;

namespace NexusForever.WorldServer.Network.Message.Model
{
    [Message(GameMessageOpcode.ClientSupportTicket)]
    public class ClientSupportTicket : IReadable
    {
        public TicketCategory Category { get; private set; }
        public TicketSubCategory SubCategory { get; private set; }
        public Position Position { get; private set; }
        public string Subject { get; private set; }
        public string Description { get; private set; }
        public uint Unk { get; private set; }

        public void Read(GamePacketReader reader)
        {
            Position = new Position();

            Category = reader.ReadEnum<TicketCategory>(16);
            SubCategory = reader.ReadEnum<TicketSubCategory>(16);
            Position.Read(reader);
            Subject = reader.ReadWideString();
            Description = reader.ReadWideString();
            Unk = reader.ReadUInt();
        }
    }
}
