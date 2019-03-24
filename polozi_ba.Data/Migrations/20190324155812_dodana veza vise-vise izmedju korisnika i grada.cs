using Microsoft.EntityFrameworkCore.Migrations;

namespace polozi_ba.Data.Migrations
{
    public partial class dodanavezaviseviseizmedjukorisnikaigrada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrojGradova",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "KorisnikGrad",
                columns: table => new
                {
                    KorisnikId = table.Column<string>(nullable: false),
                    GradId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikGrad", x => new { x.KorisnikId, x.GradId });
                    table.ForeignKey(
                        name: "FK_KorisnikGrad_Gradovi_GradId",
                        column: x => x.GradId,
                        principalTable: "Gradovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisnikGrad_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikGrad_GradId",
                table: "KorisnikGrad",
                column: "GradId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisnikGrad");

            migrationBuilder.DropColumn(
                name: "BrojGradova",
                table: "AspNetUsers");
        }
    }
}
