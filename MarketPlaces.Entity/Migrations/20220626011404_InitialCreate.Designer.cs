﻿// <auto-generated />
using System;
using MarketPlaces.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MarketPlaces.Entity.Migrations
{
    [DbContext(typeof(MarketPlacesContext))]
    [Migration("20220626011404_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MarketPlaces.Entity.Models.ApplicantDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AnnualIncome")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicantDetails");
                });

            modelBuilder.Entity("MarketPlaces.Entity.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("APR")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ApplicantDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PromotionalMessage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantDetailId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("MarketPlaces.Entity.Models.Card", b =>
                {
                    b.HasOne("MarketPlaces.Entity.Models.ApplicantDetail", null)
                        .WithMany("EligibleCards")
                        .HasForeignKey("ApplicantDetailId");
                });

            modelBuilder.Entity("MarketPlaces.Entity.Models.ApplicantDetail", b =>
                {
                    b.Navigation("EligibleCards");
                });
#pragma warning restore 612, 618
        }
    }
}