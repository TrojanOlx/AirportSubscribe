using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportSubscribe.Migrations
{
    public partial class updateUrlModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateTime",
                table: "UrlModels",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "UrlModels",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastUpdateTime",
                table: "UrlModels",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastUpdateUser",
                table: "UrlModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "UrlModels");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "UrlModels");

            migrationBuilder.DropColumn(
                name: "LastUpdateTime",
                table: "UrlModels");

            migrationBuilder.DropColumn(
                name: "LastUpdateUser",
                table: "UrlModels");
        }
    }
}
