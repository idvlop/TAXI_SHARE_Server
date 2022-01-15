﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TaxiShare.Infrastructure.Context;

#nullable disable

namespace TaxiShare.Infrastructure.Migrations
{
    [DbContext(typeof(TaxiShareDbContext))]
    [Migration("20220115131826_addClosedDateToTrip")]
    partial class addClosedDateToTrip
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TaxiShare.Domain.Entities.Grade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<long>("HolderId")
                        .HasColumnType("bigint");

                    b.Property<bool>("InExistance")
                        .HasColumnType("boolean");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.Property<long>("TripId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("HolderId");

                    b.HasIndex("TripId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("TaxiShare.Domain.Entities.Messege", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid");

                    b.Property<bool>("InExistance")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSystemMessege")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastChanged")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("TripId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasAlternateKey("Guid");

                    b.HasIndex("CreatorId");

                    b.HasIndex("TripId");

                    b.ToTable("Messeges");
                });

            modelBuilder.Entity("TaxiShare.Domain.Entities.Trip", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ArrivalPointAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Closed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("DeparturePointAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid");

                    b.Property<bool>("InExistance")
                        .HasColumnType("boolean");

                    b.Property<int?>("OverallCost")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserLimit")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasAlternateKey("Guid");

                    b.HasIndex("CreatorId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TaxiShare.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid");

                    b.Property<bool>("InExistance")
                        .HasColumnType("boolean");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PatronymicName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasAlternateKey("Guid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TripUser", b =>
                {
                    b.Property<long>("TripsId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("TripsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("TripUser");
                });

            modelBuilder.Entity("TaxiShare.Domain.Entities.Grade", b =>
                {
                    b.HasOne("TaxiShare.Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaxiShare.Domain.Entities.User", "Holder")
                        .WithMany()
                        .HasForeignKey("HolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaxiShare.Domain.Entities.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Holder");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("TaxiShare.Domain.Entities.Messege", b =>
                {
                    b.HasOne("TaxiShare.Domain.Entities.User", "Creator")
                        .WithMany("Messeges")
                        .HasForeignKey("CreatorId");

                    b.HasOne("TaxiShare.Domain.Entities.Trip", "Trip")
                        .WithMany("Messeges")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("TaxiShare.Domain.Entities.Trip", b =>
                {
                    b.HasOne("TaxiShare.Domain.Entities.User", "Creator")
                        .WithMany("OwnedTrips")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("TripUser", b =>
                {
                    b.HasOne("TaxiShare.Domain.Entities.Trip", null)
                        .WithMany()
                        .HasForeignKey("TripsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaxiShare.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaxiShare.Domain.Entities.Trip", b =>
                {
                    b.Navigation("Messeges");
                });

            modelBuilder.Entity("TaxiShare.Domain.Entities.User", b =>
                {
                    b.Navigation("Messeges");

                    b.Navigation("OwnedTrips");
                });
#pragma warning restore 612, 618
        }
    }
}
