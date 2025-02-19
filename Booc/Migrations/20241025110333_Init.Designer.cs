﻿// <auto-generated />
using System;
using Booc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Booc.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241025110333_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Booc.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Booc.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("authors");
                });

            modelBuilder.Entity("Booc.Models.Bookstore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost_price")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameBook")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number_of_pages")
                        .HasColumnType("int");

                    b.Property<int>("Price_for_sale")
                        .HasColumnType("int");

                    b.Property<int?>("TrilogiesId")
                        .HasColumnType("int");

                    b.Property<int>("authorId")
                        .HasColumnType("int");

                    b.Property<int>("genreId")
                        .HasColumnType("int");

                    b.Property<int>("publishersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrilogiesId");

                    b.HasIndex("authorId");

                    b.HasIndex("genreId");

                    b.HasIndex("publishersId");

                    b.ToTable("bookstore");
                });

            modelBuilder.Entity("Booc.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("genres");
                });

            modelBuilder.Entity("Booc.Models.Publishers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("publishers");
                });

            modelBuilder.Entity("Booc.Models.Trilogies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("trilogies");
                });

            modelBuilder.Entity("Booc.Models.Bookstore", b =>
                {
                    b.HasOne("Booc.Models.Trilogies", "trilogies")
                        .WithMany("bookstores")
                        .HasForeignKey("TrilogiesId");

                    b.HasOne("Booc.Models.Author", "author")
                        .WithMany("Bookstore")
                        .HasForeignKey("authorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booc.Models.Genre", "genre")
                        .WithMany("Bookstore")
                        .HasForeignKey("genreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booc.Models.Publishers", "publishers")
                        .WithMany("Bookstore")
                        .HasForeignKey("publishersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("genre");

                    b.Navigation("publishers");

                    b.Navigation("trilogies");
                });

            modelBuilder.Entity("Booc.Models.Author", b =>
                {
                    b.Navigation("Bookstore");
                });

            modelBuilder.Entity("Booc.Models.Genre", b =>
                {
                    b.Navigation("Bookstore");
                });

            modelBuilder.Entity("Booc.Models.Publishers", b =>
                {
                    b.Navigation("Bookstore");
                });

            modelBuilder.Entity("Booc.Models.Trilogies", b =>
                {
                    b.Navigation("bookstores");
                });
#pragma warning restore 612, 618
        }
    }
}
