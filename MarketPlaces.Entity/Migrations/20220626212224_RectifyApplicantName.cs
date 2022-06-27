using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketPlaces.Entity.Migrations
{
    public partial class RectifyApplicantName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantCard_ApplicantDetails_ApplicantDetailId",
                table: "ApplicantCard");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantCard_Cards_CardId",
                table: "ApplicantCard");

            migrationBuilder.DropTable(
                name: "ApplicantDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantCard",
                table: "ApplicantCard");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantCard_ApplicantDetailId",
                table: "ApplicantCard");

            migrationBuilder.DropColumn(
                name: "ApplicantDetailId",
                table: "ApplicantCard");

            migrationBuilder.RenameTable(
                name: "ApplicantCard",
                newName: "ApplicantCards");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantCard_CardId",
                table: "ApplicantCards",
                newName: "IX_ApplicantCards_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantCards",
                table: "ApplicantCards",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnnualIncome = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantCards_ApplicantId",
                table: "ApplicantCards",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantCards_Applicants_ApplicantId",
                table: "ApplicantCards",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantCards_Cards_CardId",
                table: "ApplicantCards",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantCards_Applicants_ApplicantId",
                table: "ApplicantCards");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantCards_Cards_CardId",
                table: "ApplicantCards");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantCards",
                table: "ApplicantCards");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantCards_ApplicantId",
                table: "ApplicantCards");

            migrationBuilder.RenameTable(
                name: "ApplicantCards",
                newName: "ApplicantCard");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantCards_CardId",
                table: "ApplicantCard",
                newName: "IX_ApplicantCard_CardId");

            migrationBuilder.AddColumn<int>(
                name: "ApplicantDetailId",
                table: "ApplicantCard",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantCard",
                table: "ApplicantCard",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApplicantDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnualIncome = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantCard_ApplicantDetailId",
                table: "ApplicantCard",
                column: "ApplicantDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantCard_ApplicantDetails_ApplicantDetailId",
                table: "ApplicantCard",
                column: "ApplicantDetailId",
                principalTable: "ApplicantDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantCard_Cards_CardId",
                table: "ApplicantCard",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
