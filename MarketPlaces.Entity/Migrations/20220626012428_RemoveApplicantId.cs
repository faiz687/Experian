using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketPlaces.Entity.Migrations
{
    public partial class RemoveApplicantId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_ApplicantDetails_ApplicantDetailId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_ApplicantDetailId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ApplicantDetailId",
                table: "Cards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicantDetailId",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ApplicantDetailId",
                table: "Cards",
                column: "ApplicantDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_ApplicantDetails_ApplicantDetailId",
                table: "Cards",
                column: "ApplicantDetailId",
                principalTable: "ApplicantDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
