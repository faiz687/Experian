// <auto-generated />
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
    [Migration("20220626013458_AddedApplicantCard")]
    partial class AddedApplicantCard
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MarketPlaces.Entity.Models.ApplicantCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ApplicantDetailId")
                        .HasColumnType("int");

                    b.Property<int?>("ApplicantId")
                        .HasColumnType("int");

                    b.Property<int?>("CardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantDetailId");

                    b.HasIndex("CardId");

                    b.ToTable("ApplicantCard");
                });

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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PromotionalMessage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("MarketPlaces.Entity.Models.ApplicantCard", b =>
                {
                    b.HasOne("MarketPlaces.Entity.Models.ApplicantDetail", "ApplicantDetail")
                        .WithMany("MyProperty")
                        .HasForeignKey("ApplicantDetailId");

                    b.HasOne("MarketPlaces.Entity.Models.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId");

                    b.Navigation("ApplicantDetail");

                    b.Navigation("Card");
                });

            modelBuilder.Entity("MarketPlaces.Entity.Models.ApplicantDetail", b =>
                {
                    b.Navigation("MyProperty");
                });
#pragma warning restore 612, 618
        }
    }
}
