using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceApp_Accounts.Data.Migrations
{
    public partial class Events : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Event",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EventDate",
                table: "Clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventSubject",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Event",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "EventSubject",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "Clients");
        }
    }
}
