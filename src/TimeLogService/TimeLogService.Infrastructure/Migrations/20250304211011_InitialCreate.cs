﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeLogService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PublicAlias = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CoreRevision = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    Revision = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_User", x => x.Id);
                    _ = table.UniqueConstraint("AK_User_UserId", x => x.UserId);
                });

            _ = migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountUri = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    IsAionTimeApproved = table.Column<bool>(type: "bit", nullable: false),
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Organization", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FKUserOrganization",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "AionTimeSubscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubsecriptionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AionTimeSubscription", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FKOrganizationSubscription",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    State = table.Column<int>(type: "int", nullable: true),
                    Visibility = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Url = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Project", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FKOrganisationProject",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "AionTimeSubscriptionHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionDate = table.Column<DateTime>(type: "date", nullable: false),
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AionTimeSubscriptionHistory", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FKSubscriptionSubscriptionHistory",
                        column: x => x.SubscriptionId,
                        principalTable: "AionTimeSubscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "WorkItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discription = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_WorkItem", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FKProjectTicket",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "WorkItemHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    History = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    WorkItemId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_WorkItemHistory", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FKTicketHistory",
                        column: x => x.WorkItemId,
                        principalTable: "WorkItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "WorkItemTimeLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Time = table.Column<DateTime>(type: "datetime", nullable: true),
                    WorkItemId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_WorkItemTimeLog", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FKProjectTicketLog",
                        column: x => x.WorkItemId,
                        principalTable: "WorkItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_AionTimeSubscription_OrganizationId",
                table: "AionTimeSubscription",
                column: "OrganizationId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_AionTimeSubscriptionHistory_SubscriptionId",
                table: "AionTimeSubscriptionHistory",
                column: "SubscriptionId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Organization_AccountId",
                table: "Organization",
                column: "AccountId",
                unique: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_Organization_Name_Unique",
                table: "Organization",
                column: "Name",
                unique: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_Organization_UserId",
                table: "Organization",
                column: "UserId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Project_OrganizationId",
                table: "Project",
                column: "OrganizationId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectId",
                table: "Project",
                column: "ProjectId",
                unique: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_User_UserId",
                table: "User",
                column: "UserId",
                unique: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_WorkItem_ProjectId",
                table: "WorkItem",
                column: "ProjectId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_WorkItemHistory_WorkItemId",
                table: "WorkItemHistory",
                column: "WorkItemId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_WorkItemTimeLog_WorkItemId",
                table: "WorkItemTimeLog",
                column: "WorkItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "AionTimeSubscriptionHistory");

            _ = migrationBuilder.DropTable(
                name: "WorkItemHistory");

            _ = migrationBuilder.DropTable(
                name: "WorkItemTimeLog");

            _ = migrationBuilder.DropTable(
                name: "AionTimeSubscription");

            _ = migrationBuilder.DropTable(
                name: "WorkItem");

            _ = migrationBuilder.DropTable(
                name: "Project");

            _ = migrationBuilder.DropTable(
                name: "Organization");

            _ = migrationBuilder.DropTable(
                name: "User");
        }
    }
}