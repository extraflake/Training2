using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticketing_System.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_employee",
                columns: table => new
                {
                    IdEmployee = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_employee", x => x.IdEmployee);
                });

            migrationBuilder.CreateTable(
                name: "tb_role",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRole = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_role", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "tb_account",
                columns: table => new
                {
                    IdEmployee = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_account", x => x.IdEmployee);
                    table.ForeignKey(
                        name: "FK_tb_account_tb_employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "tb_employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_technical_support",
                columns: table => new
                {
                    IdEmployee = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdTicket = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_technical_support", x => x.IdEmployee);
                    table.ForeignKey(
                        name: "FK_tb_technical_support_tb_employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "tb_employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_account_has_role",
                columns: table => new
                {
                    IdEmployee = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_account_has_role", x => new { x.IdEmployee, x.IdRole });
                    table.ForeignKey(
                        name: "FK_tb_account_has_role_tb_account_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "tb_account",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_account_has_role_tb_role_IdRole",
                        column: x => x.IdRole,
                        principalTable: "tb_role",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_kategori",
                columns: table => new
                {
                    IdKategori = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaKategori = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEmployee = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_kategori", x => x.IdKategori);
                    table.ForeignKey(
                        name: "FK_tb_kategori_tb_technical_support_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "tb_technical_support",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_ticket",
                columns: table => new
                {
                    IdTicket = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusTicket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRequest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Obtacles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEmployee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdKategori = table.Column<int>(type: "int", nullable: false),
                    IdHistoryChat = table.Column<int>(type: "int", nullable: false),
                    EmployeeIdEmployee = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KategoriIdKategori = table.Column<int>(type: "int", nullable: true),
                    TechnicalSupportIdEmployee = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ticket", x => x.IdTicket);
                    table.ForeignKey(
                        name: "FK_tb_ticket_tb_employee_EmployeeIdEmployee",
                        column: x => x.EmployeeIdEmployee,
                        principalTable: "tb_employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_ticket_tb_kategori_KategoriIdKategori",
                        column: x => x.KategoriIdKategori,
                        principalTable: "tb_kategori",
                        principalColumn: "IdKategori",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_ticket_tb_technical_support_TechnicalSupportIdEmployee",
                        column: x => x.TechnicalSupportIdEmployee,
                        principalTable: "tb_technical_support",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_history_chat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateHistory = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdReply = table.Column<int>(type: "int", nullable: false),
                    IdMessage = table.Column<int>(type: "int", nullable: false),
                    TicketIdTicket = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_history_chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_history_chat_tb_ticket_TicketIdTicket",
                        column: x => x.TicketIdTicket,
                        principalTable: "tb_ticket",
                        principalColumn: "IdTicket",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_report",
                columns: table => new
                {
                    IdReport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTicket = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_report", x => x.IdReport);
                    table.ForeignKey(
                        name: "FK_tb_report_tb_ticket_IdTicket",
                        column: x => x.IdTicket,
                        principalTable: "tb_ticket",
                        principalColumn: "IdTicket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_tracking",
                columns: table => new
                {
                    IdTicket = table.Column<int>(type: "int", nullable: false),
                    DateProcess = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSloved = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEmployee = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tracking", x => x.IdTicket);
                    table.ForeignKey(
                        name: "FK_tb_tracking_tb_technical_support_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "tb_technical_support",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_tracking_tb_ticket_IdTicket",
                        column: x => x.IdTicket,
                        principalTable: "tb_ticket",
                        principalColumn: "IdTicket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_message",
                columns: table => new
                {
                    IdMessage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Messages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoryChatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_message", x => x.IdMessage);
                    table.ForeignKey(
                        name: "FK_tb_message_tb_history_chat_HistoryChatId",
                        column: x => x.HistoryChatId,
                        principalTable: "tb_history_chat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_reply",
                columns: table => new
                {
                    IdReply = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Replys = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoryChatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_reply", x => x.IdReply);
                    table.ForeignKey(
                        name: "FK_tb_reply_tb_history_chat_HistoryChatId",
                        column: x => x.HistoryChatId,
                        principalTable: "tb_history_chat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_account_has_role_IdRole",
                table: "tb_account_has_role",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_tb_history_chat_TicketIdTicket",
                table: "tb_history_chat",
                column: "TicketIdTicket");

            migrationBuilder.CreateIndex(
                name: "IX_tb_kategori_IdEmployee",
                table: "tb_kategori",
                column: "IdEmployee",
                unique: true,
                filter: "[IdEmployee] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tb_message_HistoryChatId",
                table: "tb_message",
                column: "HistoryChatId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_reply_HistoryChatId",
                table: "tb_reply",
                column: "HistoryChatId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_report_IdTicket",
                table: "tb_report",
                column: "IdTicket",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_ticket_EmployeeIdEmployee",
                table: "tb_ticket",
                column: "EmployeeIdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ticket_KategoriIdKategori",
                table: "tb_ticket",
                column: "KategoriIdKategori");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ticket_TechnicalSupportIdEmployee",
                table: "tb_ticket",
                column: "TechnicalSupportIdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tracking_IdEmployee",
                table: "tb_tracking",
                column: "IdEmployee",
                unique: true,
                filter: "[IdEmployee] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_account_has_role");

            migrationBuilder.DropTable(
                name: "tb_message");

            migrationBuilder.DropTable(
                name: "tb_reply");

            migrationBuilder.DropTable(
                name: "tb_report");

            migrationBuilder.DropTable(
                name: "tb_tracking");

            migrationBuilder.DropTable(
                name: "tb_account");

            migrationBuilder.DropTable(
                name: "tb_role");

            migrationBuilder.DropTable(
                name: "tb_history_chat");

            migrationBuilder.DropTable(
                name: "tb_ticket");

            migrationBuilder.DropTable(
                name: "tb_kategori");

            migrationBuilder.DropTable(
                name: "tb_technical_support");

            migrationBuilder.DropTable(
                name: "tb_employee");
        }
    }
}
