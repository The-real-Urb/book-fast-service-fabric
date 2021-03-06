﻿// <auto-generated />
using BookFast.Facility.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BookFast.Facility.Data.Migrations
{
    [DbContext(typeof(BookFastContext))]
    partial class BookFastContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookFast.Facility.Data.Models.Accommodation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid>("FacilityId");

                    b.Property<string>("Images");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(320);

                    b.Property<int>("RoomCount");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("BookFast.Facility.Data.Models.Facility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccommodationCount");

                    b.Property<string>("Description");

                    b.Property<string>("Images");

                    b.Property<double?>("Latitude");

                    b.Property<double?>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(320);

                    b.Property<string>("Owner");

                    b.Property<string>("StreetAddress");

                    b.HasKey("Id");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("BookFast.Facility.Data.Models.Accommodation", b =>
                {
                    b.HasOne("BookFast.Facility.Data.Models.Facility", "Facility")
                        .WithMany("Accommodations")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
