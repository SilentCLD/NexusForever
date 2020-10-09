using System;

namespace NexusForever.Database.Character.Model
{
    public class SupportTicketModel
    {
        public ulong Id { get; set; }
        public ulong PlayerId { get; set; }
        public ushort Category { get; set; }
        public ushort SubCategory { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public ushort WorldId { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public ulong AssignedToId { get; set; }
        public ulong ClosedById { get; set; }
        public byte Status { get; set; }
        public string Comment { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastModifiedTime { get; set; }

        public CharacterModel Player { get; set; }
    }
}
