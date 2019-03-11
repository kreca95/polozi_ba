using Microsoft.EntityFrameworkCore.Migrations;

namespace polozi_ba.Data.Migrations
{
    public partial class dodanaklasainstrukcijeispravka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Predmet_AspNetUsers_KorisnikId",
                table: "Predmet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Predmet",
                table: "Predmet");

            migrationBuilder.RenameTable(
                name: "Predmet",
                newName: "Predmeti");

            migrationBuilder.RenameIndex(
                name: "IX_Predmet_KorisnikId",
                table: "Predmeti",
                newName: "IX_Predmeti_KorisnikId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Predmeti",
                table: "Predmeti",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Predmeti_AspNetUsers_KorisnikId",
                table: "Predmeti",
                column: "KorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Predmeti_AspNetUsers_KorisnikId",
                table: "Predmeti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Predmeti",
                table: "Predmeti");

            migrationBuilder.RenameTable(
                name: "Predmeti",
                newName: "Predmet");

            migrationBuilder.RenameIndex(
                name: "IX_Predmeti_KorisnikId",
                table: "Predmet",
                newName: "IX_Predmet_KorisnikId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Predmet",
                table: "Predmet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Predmet_AspNetUsers_KorisnikId",
                table: "Predmet",
                column: "KorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
