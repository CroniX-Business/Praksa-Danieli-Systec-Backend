using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class timestampDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "User",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Restaurants",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "OrderItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "OrderItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "OrderItem",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Order",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Item",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Item",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Item",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Item",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Category",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Category");
        }
    }
}
