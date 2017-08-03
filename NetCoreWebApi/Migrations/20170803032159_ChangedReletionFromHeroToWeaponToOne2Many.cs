using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreWebApi.Migrations
{
    public partial class ChangedReletionFromHeroToWeaponToOne2Many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Weapons_WeaponId",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_WeaponId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "WeaponId",
                table: "Heroes");

            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "Weapons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_HeroId",
                table: "Weapons",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Heroes_HeroId",
                table: "Weapons",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "HeroId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Heroes_HeroId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_HeroId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Weapons");

            migrationBuilder.AddColumn<int>(
                name: "WeaponId",
                table: "Heroes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_WeaponId",
                table: "Heroes",
                column: "WeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Weapons_WeaponId",
                table: "Heroes",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "WeaponId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
