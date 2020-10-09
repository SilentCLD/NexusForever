using System;

namespace NexusForever.Database.Character.Model
{
    public class BugReportModel
    {
        public ulong Id { get; set; }
        public ulong PlayerId { get; set; }
        public byte Category { get; set; }
        public uint EntityId { get; set; }
        public ushort QuestId { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }
        public string Comment { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastModifiedTime { get; set; }

        public CharacterModel Player { get; set; }
    }
}
