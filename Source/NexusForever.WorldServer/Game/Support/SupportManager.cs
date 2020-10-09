using NexusForever.Database.Character.Model;
using NexusForever.Shared;
using NexusForever.Shared.Database;
using NexusForever.Shared.Game.Events;
using NexusForever.WorldServer.Game.CharacterCache;
using NexusForever.WorldServer.Game.Entity;
using NexusForever.WorldServer.Network;
using NexusForever.WorldServer.Network.Message.Model;
using NLog;

namespace NexusForever.WorldServer.Game.Support
{
    public class SupportManager : Singleton<SupportManager>
    {
        private static readonly ILogger log = LogManager.GetCurrentClassLogger();

        private SupportManager() { }

        public void Initialise() { /* Empty for now, might be needed in the future */ }

        public void HandleClientSupportTicket(WorldSession session, ClientSupportTicket ticket)
        {
            session.EnqueueEvent(new TaskEvent(DatabaseManager.Instance.CharacterDatabase.Save(context =>
            {
                context.Add(new SupportTicketModel
                {
                    Id = AssetManager.Instance.NextSupportTicketId,
                    PlayerId = session.Player.CharacterId,
                    Category = (byte)ticket.Category,
                    SubCategory = (byte)ticket.SubCategory,
                    Subject = ticket.Subject,
                    Description = ticket.Description,
                    WorldId = (ushort)session.Player.Map.Entry.Id,
                    PosX = ticket.Position.Vector.X,
                    PosY = ticket.Position.Vector.Y,
                    PosZ = ticket.Position.Vector.Z
                });
            }), () =>
            {
                session.EnqueueMessageEncrypted(new ServerSupportTicketResult { Success = true });

                // TODO: Notify online GM's of new ticket.
            }));
        }

        public void HandleClientBugReport(WorldSession session, ClientBugReport report)
        {
            // TODO: Need to handle this differently for Players and dynamic spawns
            var entityId = report.EntityGuid > 0 ? session.Player.Map.GetEntity<WorldEntity>(report.EntityGuid).EntityId : 0;

            session.EnqueueEvent(new TaskEvent(DatabaseManager.Instance.CharacterDatabase.Save(context =>
            {
                context.Add(new BugReportModel
                {
                    Id = AssetManager.Instance.NextBugReportId,
                    PlayerId = session.Player.CharacterId,
                    Category = (byte)report.Category,
                    EntityId = entityId,
                    QuestId = (ushort)report.QuestId,
                    Description = report.Description
                });
            }), () =>
            {
                session.EnqueueMessageEncrypted(new ServerSupportTicketResult { Success = true });

                // TODO: Notify online GM's of new bug report.
            }));
        }

        public void HandleClientPlayerReport(WorldSession session, ClientPlayerReport report)
        {
            ulong reportedPlayerId = report.ReportedCharacter.CharacterId;
            string reportedPlayerName = report.ReportedName;

            if (reportedPlayerId == 0)
                reportedPlayerId = CharacterManager.Instance.GetCharacterIdByName(report.ReportedName);
            else
                reportedPlayerName = CharacterManager.Instance.GetCharacterInfo(reportedPlayerId).Name;

            session.EnqueueEvent(new TaskEvent(DatabaseManager.Instance.CharacterDatabase.Save(context =>
            {
                context.Add(new PlayerReportModel
                {
                    Id = AssetManager.Instance.NextPlayerReportId,
                    ReportedById = session.Player.CharacterId,
                    ReportedPlayerId = reportedPlayerId,
                    ReportedPlayerName = reportedPlayerName,
                    Reason = (byte)report.Reason,
                    Source = (byte)report.Source
                });
            }), () =>
            {
                // TODO: Add reported player to ignore list if report.Ignore.

                // TODO: Notify online GM's of new report.
            }));
        }
    }
}
