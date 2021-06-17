using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmDB.Migrations
{
    public partial class AddingActorAndGenreModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Films");

            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "Films",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Films",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActorModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_ActorId",
                table: "Films",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_GenreId",
                table: "Films",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_ActorModel_ActorId",
                table: "Films",
                column: "ActorId",
                principalTable: "ActorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_GenreModel_GenreId",
                table: "Films",
                column: "GenreId",
                principalTable: "GenreModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_ActorModel_ActorId",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Films_GenreModel_GenreId",
                table: "Films");

            migrationBuilder.DropTable(
                name: "ActorModel");

            migrationBuilder.DropTable(
                name: "GenreModel");

            migrationBuilder.DropIndex(
                name: "IX_Films_ActorId",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_GenreId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Films");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
