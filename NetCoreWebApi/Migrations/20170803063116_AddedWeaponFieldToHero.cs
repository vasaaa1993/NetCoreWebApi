using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreWebApi.Migrations
{
    public partial class AddedWeaponFieldToHero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeroId1",
                table: "Weapons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_HeroId1",
                table: "Weapons",
                column: "HeroId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Heroes_HeroId1",
                table: "Weapons",
                column: "HeroId1",
                principalTable: "Heroes",
                principalColumn: "HeroId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Heroes_HeroId1",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_HeroId1",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "HeroId1",
                table: "Weapons");
        }
    }
}
