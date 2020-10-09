using NexusForever.Shared.Network;
using NexusForever.Shared.Network.Message;
using NexusForever.WorldServer.Game.Support.Static;
using NexusForever.WorldServer.Network.Message.Model.Shared;

namespace NexusForever.WorldServer.Network.Message.Model
{
    [Message(GameMessageOpcode.ClientPlayerReport)]
    public class ClientPlayerReport : IReadable
    {
        public TargetPlayerIdentity ReportedCharacter { get; private set; }
        public ReportReason Reason { get; private set; }
        public ReportSource Source { get; private set; }
        public string ReportedName { get; private set; }
        public ulong ReportedUnitID { get; private set; }
        public uint Unk6 { get; private set; }
        public bool Ignore { get; private set; }

        public void Read(GamePacketReader reader)
        {
            ReportedCharacter = new TargetPlayerIdentity();

            // Target only
            ReportedCharacter.Read(reader);

            Reason = reader.ReadEnum<ReportReason>(3u);
            Source = reader.ReadEnum<ReportSource>(4u);

            // Custom only
            ReportedName = reader.ReadWideString();

            // Target only
            ReportedUnitID = reader.ReadULong();

            // Packed timestamp?
            Unk6 = reader.ReadUInt();

            // Add player to ignore list
            Ignore = reader.ReadBit();
        }
    }
}
