using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetCoreWebApi.Data;

namespace NetCoreWebApi.Migrations
{
    [DbContext(typeof(HeroesContext))]
    [Migration("20170803031634_AddedIdenityAttToModels")]
    partial class AddedIdenityAttToModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetCoreWebApi.Models.Hero", b =>
                {
                    b.Property<int>("HeroId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<int?>("WeaponId");

                    b.HasKey("HeroId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("NetCoreWebApi.Models.Weapon", b =>
                {
                    b.Property<int>("WeaponId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Damage");

                    b.Property<string>("Name");

                    b.HasKey("WeaponId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("NetCoreWebApi.Models.Hero", b =>
                {
                    b.HasOne("NetCoreWebApi.Models.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId");
                });
        }
    }
}
