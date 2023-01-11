using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingServices.Migrations
{
    /// <inheritdoc />
    public partial class EditBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Booking",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<Guid>(
                name: "ServicesId",
                table: "Booking",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ServicesId",
                table: "Booking",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_ServicesObject_ServicesId",
                table: "Booking",
                column: "ServicesId",
                principalTable: "ServicesObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_ServicesObject_ServicesId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_ServicesId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Booking",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
