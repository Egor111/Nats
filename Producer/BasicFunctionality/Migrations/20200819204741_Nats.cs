using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BasicFunctionality.Migrations
{
    public partial class Nats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SendNats",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    SendTime = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    HashCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendNats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SendNats");
        }
    }
}
