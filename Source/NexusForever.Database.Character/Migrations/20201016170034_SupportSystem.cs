using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NexusForever.Database.Character.Migrations
{
    public partial class SupportSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bug_report",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    playerId = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    category = table.Column<byte>(type: "tinyint(2) unsigned", nullable: false, defaultValue: (byte)0),
                    npcId = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    questId = table.Column<ushort>(type: "smallint(5) unsigned", nullable: false, defaultValue: (ushort)0),
                    description = table.Column<string>(type: "varchar(500)", nullable: true, defaultValue: ""),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false, defaultValue: (byte)0),
                    comment = table.Column<string>(type: "text", nullable: true, defaultValue: ""),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    lastModifiedTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK__bug_report_playerId__character_id",
                        column: x => x.playerId,
                        principalTable: "character",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_report",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    reportedById = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    reportedPlayerId = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    reportedPlayerName = table.Column<string>(type: "varchar(50)", nullable: true, defaultValue: ""),
                    reason = table.Column<byte>(type: "tinyint(2) unsigned", nullable: false, defaultValue: (byte)0),
                    source = table.Column<byte>(type: "tinyint(2) unsigned", nullable: false, defaultValue: (byte)0),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK__player_report_reportedById__character_id",
                        column: x => x.reportedById,
                        principalTable: "character",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "support_ticket",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    playerId = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    category = table.Column<byte>(type: "tinyint(2) unsigned", nullable: false, defaultValue: (byte)0),
                    subCategory = table.Column<byte>(type: "tinyint(2) unsigned", nullable: false, defaultValue: (byte)0),
                    subject = table.Column<string>(type: "varchar(500)", nullable: true, defaultValue: ""),
                    description = table.Column<string>(type: "varchar(500)", nullable: true, defaultValue: ""),
                    worldId = table.Column<short>(type: "smallint(2)", nullable: false, defaultValue: (short)0),
                    posX = table.Column<float>(type: "float", nullable: false, defaultValue: 0f),
                    posY = table.Column<float>(type: "float", nullable: false, defaultValue: 0f),
                    posZ = table.Column<float>(type: "float", nullable: false, defaultValue: 0f),
                    assignedToId = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    closedById = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false, defaultValue: (byte)0),
                    comment = table.Column<string>(type: "text", nullable: true, defaultValue: ""),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    lastModifiedTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK__support_ticket_playerId__character_id",
                        column: x => x.playerId,
                        principalTable: "character",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "FK__bug_report_playerId__character_id",
                table: "bug_report",
                column: "playerId");

            migrationBuilder.CreateIndex(
                name: "FK__player_report_reportedById__character_id",
                table: "player_report",
                column: "reportedById");

            migrationBuilder.CreateIndex(
                name: "IX__player_report_reportedPlayerId",
                table: "player_report",
                column: "reportedPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX__support_ticket_assignedToId",
                table: "support_ticket",
                column: "assignedToId");

            migrationBuilder.CreateIndex(
                name: "IX__support_ticket_closedById",
                table: "support_ticket",
                column: "closedById");

            migrationBuilder.CreateIndex(
                name: "FK__support_ticket_playerId__character_id",
                table: "support_ticket",
                column: "playerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bug_report");

            migrationBuilder.DropTable(
                name: "player_report");

            migrationBuilder.DropTable(
                name: "support_ticket");
        }
    }
}
