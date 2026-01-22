using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EBOS.Audit.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MetadataJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrelationId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditChanges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CorrelationId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditChanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DomainEventLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PayloadJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OccurredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TriggeredBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CorrelationId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainEventLogs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_CorrelationId",
                table: "ActivityLogs",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_SystemName",
                table: "ActivityLogs",
                column: "SystemName");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_Timestamp",
                table: "ActivityLogs",
                column: "Timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_User",
                table: "ActivityLogs",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_AuditChange_User",
                table: "ActivityLogs",
                columns: new[] { "User", "Timestamp" });

            migrationBuilder.CreateIndex(
                name: "IX_AuditChange_ChangedAt",
                table: "AuditChanges",
                column: "ChangedAt");

            migrationBuilder.CreateIndex(
                name: "IX_AuditChange_Entity",
                table: "AuditChanges",
                columns: new[] { "SystemName", "EntityName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_AuditChange_EntityName_EntityId_ChangedAt",
                table: "AuditChanges",
                columns: new[] { "EntityName", "EntityId", "ChangedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_AuditChanges_CorrelationId",
                table: "AuditChanges",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditChanges_EntityId",
                table: "AuditChanges",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditChanges_EntityName",
                table: "AuditChanges",
                column: "EntityName");

            migrationBuilder.CreateIndex(
                name: "IX_AuditChanges_SystemName",
                table: "AuditChanges",
                column: "SystemName");

            migrationBuilder.CreateIndex(
                name: "IX_AuditChange_Event",
                table: "DomainEventLogs",
                columns: new[] { "EventType", "OccurredAt" });

            migrationBuilder.CreateIndex(
                name: "IX_DomainEventLogs_CorrelationId",
                table: "DomainEventLogs",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEventLogs_EntityId",
                table: "DomainEventLogs",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEventLogs_EntityName",
                table: "DomainEventLogs",
                column: "EntityName");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEventLogs_EventType",
                table: "DomainEventLogs",
                column: "EventType");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEventLogs_OccurredAt",
                table: "DomainEventLogs",
                column: "OccurredAt");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEventLogs_SystemName",
                table: "DomainEventLogs",
                column: "SystemName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.DropTable(
                name: "AuditChanges");

            migrationBuilder.DropTable(
                name: "DomainEventLogs");
        }
    }
}
