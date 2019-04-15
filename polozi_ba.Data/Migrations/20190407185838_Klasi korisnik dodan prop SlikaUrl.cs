using Microsoft.EntityFrameworkCore.Migrations;

namespace polozi_ba.Data.Migrations
{
    public partial class KlasikorisnikdodanpropSlikaUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SlikaUrl",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlikaUrl",
                table: "AspNetUsers");
        }
    }
}
