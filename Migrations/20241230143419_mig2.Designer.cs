﻿// <auto-generated />
using AgateProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgateProject.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241230143419_mig2")]
    partial class mig2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgateProject.Data.Models.Campaign", b =>
                {
                    b.Property<int>("CampaignID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampaignID"));

                    b.Property<string>("CampaignDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CampaignName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("CampaingBudget")
                        .HasColumnType("float");

                    b.HasKey("CampaignID");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("AgateProject.Data.Models.CampaignManager", b =>
                {
                    b.Property<int>("CampaignManagerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampaignManagerID"));

                    b.Property<int?>("CampaignID")
                        .HasColumnType("int");

                    b.Property<string>("CampaignManagerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CampaignManagerPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CampaignManagerID");

                    b.HasIndex("CampaignID");

                    b.ToTable("CampaignManagers");
                });

            modelBuilder.Entity("AgateProject.Data.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<int>("CampaignID")
                        .HasColumnType("int");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Payment")
                        .HasColumnType("float");

                    b.HasKey("ClientID");

                    b.HasIndex("CampaignID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AgateProject.Data.Models.ClientContact", b =>
                {
                    b.Property<int>("ClientContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientContactID"));

                    b.Property<string>("ClientContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.HasKey("ClientContactID");

                    b.ToTable("ClientContacts");
                });

            modelBuilder.Entity("AgateProject.Data.Models.Staff", b =>
                {
                    b.Property<int>("StaffID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffID"));

                    b.Property<int>("CampaignID")
                        .HasColumnType("int");

                    b.Property<string>("StaffName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StaffID");

                    b.HasIndex("CampaignID");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("AgateProject.Data.Models.StaffContact", b =>
                {
                    b.Property<int>("StaffContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffContactID"));

                    b.Property<int>("CampaignID")
                        .HasColumnType("int");

                    b.Property<string>("StaffContactName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StaffContactID");

                    b.HasIndex("CampaignID");

                    b.ToTable("StaffContacts");
                });

            modelBuilder.Entity("AgateProject.Data.Models.CampaignManager", b =>
                {
                    b.HasOne("AgateProject.Data.Models.Campaign", null)
                        .WithMany("CampaignManagers")
                        .HasForeignKey("CampaignID");
                });

            modelBuilder.Entity("AgateProject.Data.Models.Client", b =>
                {
                    b.HasOne("AgateProject.Data.Models.Campaign", null)
                        .WithMany("Clients")
                        .HasForeignKey("CampaignID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgateProject.Data.Models.Staff", b =>
                {
                    b.HasOne("AgateProject.Data.Models.Campaign", null)
                        .WithMany("Staffs")
                        .HasForeignKey("CampaignID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgateProject.Data.Models.StaffContact", b =>
                {
                    b.HasOne("AgateProject.Data.Models.Campaign", null)
                        .WithMany("Contacts")
                        .HasForeignKey("CampaignID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgateProject.Data.Models.Campaign", b =>
                {
                    b.Navigation("CampaignManagers");

                    b.Navigation("Clients");

                    b.Navigation("Contacts");

                    b.Navigation("Staffs");
                });
#pragma warning restore 612, 618
        }
    }
}
