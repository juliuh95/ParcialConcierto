using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParcialConcierto.Migrations
{
    public partial class add_nullable_date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Entrances_EntranceId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_Document",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EntranceId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Entrances_Description",
                table: "Entrances");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EntranceId",
                table: "Tickets");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Tickets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Entrances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Entrances_Description_TicketId",
                table: "Entrances",
                columns: new[] { "Description", "TicketId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entrances_TicketId",
                table: "Entrances",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrances_Tickets_TicketId",
                table: "Entrances",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrances_Tickets_TicketId",
                table: "Entrances");

            migrationBuilder.DropIndex(
                name: "IX_Entrances_Description_TicketId",
                table: "Entrances");

            migrationBuilder.DropIndex(
                name: "IX_Entrances_TicketId",
                table: "Entrances");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Entrances");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EntranceId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Document",
                table: "Tickets",
                column: "Document",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EntranceId",
                table: "Tickets",
                column: "EntranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrances_Description",
                table: "Entrances",
                column: "Description",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Entrances_EntranceId",
                table: "Tickets",
                column: "EntranceId",
                principalTable: "Entrances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
