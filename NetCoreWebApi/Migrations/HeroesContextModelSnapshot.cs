using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetCoreWebApi.Data;

namespace NetCoreWebApi.Migrations
{
    [DbContext(typeof(HeroesContext))]
    partial class HeroesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasKey("HeroId");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("NetCoreWebApi.Models.Weapon", b =>
                {
                    b.Property<int>("WeaponId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Damage");

                    b.Property<int?>("HeroId");

                    b.Property<string>("Name");

                    b.HasKey("WeaponId");

                    b.HasIndex("HeroId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("NetCoreWebApi.Models.Weapon", b =>
                {
                    b.HasOne("NetCoreWebApi.Models.Hero")
                        .WithMany("Weapon")
                        .HasForeignKey("HeroId");
                });
        }
    }
}
