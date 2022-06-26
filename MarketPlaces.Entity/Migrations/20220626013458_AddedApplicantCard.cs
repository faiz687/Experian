using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketPlaces.Entity.Migrations
{
    public partial class AddedApplicantCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: true),
                    ApplicantDetailId = table.Column<int>(type: "int", nullable: true),
                    CardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantCard_ApplicantDetails_ApplicantDetailId",
                        column: x => x.ApplicantDetailId,
                        principalTable: "ApplicantDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicantCard_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantCard_ApplicantDetailId",
                table: "ApplicantCard",
                column: "ApplicantDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantCard_CardId",
                table: "ApplicantCard",
                column: "CardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantCard");
        }
    }
}
