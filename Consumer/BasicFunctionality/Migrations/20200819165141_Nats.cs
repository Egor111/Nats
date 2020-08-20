using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BasicFunctionality.Migrations
{
    public partial class Nats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipientNats",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numbet = table.Column<int>(nullable: false),
                    RecipientTime = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    HashCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipientNats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipientNats");
        }
    }
}
