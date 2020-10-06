﻿// <auto-generated />
using LibraryApp.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryApp.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200825101552_Location_photopath")]
    partial class Location_photopath
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-preview.7.20365.15");

            modelBuilder.Entity("LibraryDataBase.Book", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("locationId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("locationId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Author = "PFirstBook",
                            Category = 0,
                            Name = "FirstBook",
                            PhotoPath = "images/1.jpg",
                            Price = 100,
                            locationId = 1
                        },
                        new
                        {
                            id = 2,
                            Author = "PSecondBook",
                            Category = 0,
                            Name = "SecondBook",
                            PhotoPath = "images/2.jpg",
                            Price = 120,
                            locationId = 1
                        },
                        new
                        {
                            id = 3,
                            Author = "PThirdBook",
                            Category = 1,
                            Name = "ThirdBook",
                            PhotoPath = "images/3.jpg",
                            Price = 300,
                            locationId = 2
                        },
                        new
                        {
                            id = 4,
                            Author = "PFourthBook",
                            Category = 2,
                            Name = "FourthBook",
                            PhotoPath = "images/4.jpg",
                            Price = 210,
                            locationId = 2
                        });
                });

            modelBuilder.Entity("LibraryDataBase.Location", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LibraryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CityName = "Tanta",
                            LibraryName = "TantaLibrary",
                            PhotoPath = "images/lib1.jpg"
                        },
                        new
                        {
                            id = 2,
                            CityName = "Mansoura",
                            LibraryName = "MansouraLibrary",
                            PhotoPath = "images/lib2.jpg"
                        });
                });

            modelBuilder.Entity("LibraryDataBase.Book", b =>
                {
                    b.HasOne("LibraryDataBase.Location", "Location")
                        .WithMany()
                        .HasForeignKey("locationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
