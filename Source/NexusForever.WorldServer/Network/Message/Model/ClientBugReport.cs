using NexusForever.Shared.Network;
using NexusForever.Shared.Network.Message;
using NexusForever.WorldServer.Game.Support.Static;

namespace NexusForever.WorldServer.Network.Message.Model
{
    [Message(GameMessageOpcode.ClientBugReport)]
    public class ClientBugReport : IReadable
    {
        public BugSubCategory Category { get; private set; }
        public uint EntityGuid { get; private set; }
        public uint QuestId { get; private set; }
        public string Description { get; private set; }

        public void Read(GamePacketReader reader)
        {
            Category = reader.ReadEnum<BugSubCategory>(16u);
            EntityGuid = reader.ReadUInt();
            QuestId = reader.ReadUInt();
            Description = reader.ReadWideString();
        }
    }
}
