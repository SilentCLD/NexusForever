using System;

namespace NexusForever.Database.Character.Model
{
    public class PlayerReportModel
    {
        public ulong Id { get; set; }
        public ulong ReportedById { get; set; }
        public ulong ReportedPlayerId { get; set; }
        public string ReportedPlayerName { get; set; }
        public byte Reason { get; set; }
        public byte Source { get; set; }
        public DateTime CreateTime { get; set; }

        public CharacterModel ReportedByPlayer { get; set; }
    }
}
