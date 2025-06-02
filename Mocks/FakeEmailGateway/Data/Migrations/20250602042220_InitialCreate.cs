using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FakeEmailGateway.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inboxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inboxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inboxes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outboxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outboxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outboxes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderOutboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReceiverInboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_Inboxes_ReceiverInboxId",
                        column: x => x.ReceiverInboxId,
                        principalTable: "Inboxes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Emails_Outboxes_SenderOutboxId",
                        column: x => x.SenderOutboxId,
                        principalTable: "Outboxes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Email_Subject",
                table: "Emails",
                column: "Subject");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ReceiverInboxId",
                table: "Emails",
                column: "ReceiverInboxId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_SenderOutboxId",
                table: "Emails",
                column: "SenderOutboxId");

            migrationBuilder.CreateIndex(
                name: "IX_Inboxes_UserId",
                table: "Inboxes",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Outboxes_UserId",
                table: "Outboxes",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmailAddress",
                table: "Users",
                column: "EmailAddress",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Inboxes");

            migrationBuilder.DropTable(
                name: "Outboxes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
