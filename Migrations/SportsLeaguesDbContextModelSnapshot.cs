using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SportLeague.Models;

namespace SportLeague.Migrations
{
    [DbContext(typeof(SportsLeaguesDbContext))]
    partial class SportsLeaguesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("SportLeague.Models.Division", b =>
                {
                    b.Property<int>("DivisionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("LeagueId");

                    b.Property<string>("Name");

                    b.HasKey("DivisionId");

                    b.HasIndex("LeagueId");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("SportLeague.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Score");

                    b.Property<string>("Versus");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("SportLeague.Models.League", b =>
                {
                    b.Property<int>("LeagueId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("GameId");

                    b.Property<string>("Name");

                    b.Property<int>("SportId");

                    b.HasKey("LeagueId");

                    b.HasIndex("GameId");

                    b.HasIndex("SportId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("SportLeague.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Stats");

                    b.Property<int>("TeamId");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("SportLeague.Models.Sport", b =>
                {
                    b.Property<int>("SportId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("SportId");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("SportLeague.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("DivisionId");

                    b.Property<string>("Name");

                    b.HasKey("TeamId");

                    b.HasIndex("DivisionId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SportLeague.Models.Division", b =>
                {
                    b.HasOne("SportLeague.Models.League", "League")
                        .WithMany("Divisions")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportLeague.Models.League", b =>
                {
                    b.HasOne("SportLeague.Models.Game")
                        .WithMany("Leagues")
                        .HasForeignKey("GameId");

                    b.HasOne("SportLeague.Models.Sport", "Sport")
                        .WithMany("Leagues")
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportLeague.Models.Player", b =>
                {
                    b.HasOne("SportLeague.Models.Team", "Team")
                        .WithMany("players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportLeague.Models.Team", b =>
                {
                    b.HasOne("SportLeague.Models.Division", "Division")
                        .WithMany("Teams")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
