using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagingSystem.Migrations
{
    public partial class fixId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClassId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
