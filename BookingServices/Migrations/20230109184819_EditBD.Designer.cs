﻿// <auto-generated />
using System;
using BookingServices.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookingServices.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230109184819_EditBD")]
    partial class EditBD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("BookingServices.Model.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ServicesId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ServicesId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("BookingServices.Model.ServicesObject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ServicesObject");
                });

            modelBuilder.Entity("BookingServices.Model.Booking", b =>
                {
                    b.HasOne("BookingServices.Model.ServicesObject", "servicesObject")
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("servicesObject");
                });
#pragma warning restore 612, 618
        }
    }
}
