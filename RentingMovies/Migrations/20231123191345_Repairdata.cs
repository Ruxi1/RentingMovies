using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingMovies.Migrations
{
    public partial class Repairdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentings_Clients_IdClientNavigationIdClient",
                table: "Rentings");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentings_Movies_IdMovieNavigationIdMovie",
                table: "Rentings");

            migrationBuilder.DropIndex(
                name: "IX_Rentings_IdClientNavigationIdClient",
                table: "Rentings");

            migrationBuilder.DropIndex(
                name: "IX_Rentings_IdMovieNavigationIdMovie",
                table: "Rentings");

            migrationBuilder.DropColumn(
                name: "IdClientNavigationIdClient",
                table: "Rentings");

            migrationBuilder.DropColumn(
                name: "IdMovieNavigationIdMovie",
                table: "Rentings");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientIdClient",
                table: "Rentings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MovieIdMovie",
                table: "Rentings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentings_ClientIdClient",
                table: "Rentings",
                column: "ClientIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Rentings_MovieIdMovie",
                table: "Rentings",
                column: "MovieIdMovie");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentings_Clients_ClientIdClient",
                table: "Rentings",
                column: "ClientIdClient",
                principalTable: "Clients",
                principalColumn: "IdClient");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentings_Movies_MovieIdMovie",
                table: "Rentings",
                column: "MovieIdMovie",
                principalTable: "Movies",
                principalColumn: "IdMovie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentings_Clients_ClientIdClient",
                table: "Rentings");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentings_Movies_MovieIdMovie",
                table: "Rentings");

            migrationBuilder.DropIndex(
                name: "IX_Rentings_ClientIdClient",
                table: "Rentings");

            migrationBuilder.DropIndex(
                name: "IX_Rentings_MovieIdMovie",
                table: "Rentings");

            migrationBuilder.DropColumn(
                name: "ClientIdClient",
                table: "Rentings");

            migrationBuilder.DropColumn(
                name: "MovieIdMovie",
                table: "Rentings");

            migrationBuilder.AddColumn<Guid>(
                name: "IdClientNavigationIdClient",
                table: "Rentings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdMovieNavigationIdMovie",
                table: "Rentings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Rentings_IdClientNavigationIdClient",
                table: "Rentings",
                column: "IdClientNavigationIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Rentings_IdMovieNavigationIdMovie",
                table: "Rentings",
                column: "IdMovieNavigationIdMovie");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentings_Clients_IdClientNavigationIdClient",
                table: "Rentings",
                column: "IdClientNavigationIdClient",
                principalTable: "Clients",
                principalColumn: "IdClient",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentings_Movies_IdMovieNavigationIdMovie",
                table: "Rentings",
                column: "IdMovieNavigationIdMovie",
                principalTable: "Movies",
                principalColumn: "IdMovie",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
