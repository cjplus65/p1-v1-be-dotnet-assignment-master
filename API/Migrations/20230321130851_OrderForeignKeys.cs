using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class OrderForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FlightRateId",
                table: "Orders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FlightId",
                table: "Orders",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FlightRateId",
                table: "Orders",
                column: "FlightRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Flights_FlightId",
                table: "Orders",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FlightRates_FlightRateId",
                table: "Orders",
                column: "FlightRateId",
                principalTable: "FlightRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Flights_FlightId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FlightRates_FlightRateId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FlightId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FlightRateId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FlightRateId",
                table: "Orders");
        }
    }
}
