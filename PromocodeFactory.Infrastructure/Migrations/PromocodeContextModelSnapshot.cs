﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PromocodeFactory.Infrastructure;

#nullable disable

namespace PromocodeFactory.Infrastructure.Migrations
{
    [DbContext(typeof(PromocodeContext))]
    partial class PromocodeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PromocodeFactory.Domain.Administaration.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AppliedPromocodesCount")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("EmployeeId");

                    b.HasIndex("RoleId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("PromocodeFactory.Domain.Administaration.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("RoleId");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("PromocodeFactory.Domain.PromocodeManagement.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("PromocodeFactory.Domain.PromocodeManagement.CustomerPreference", b =>
                {
                    b.Property<Guid>("PreferenceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.HasKey("PreferenceId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerPreference", (string)null);
                });

            modelBuilder.Entity("PromocodeFactory.Domain.PromocodeManagement.Partner", b =>
                {
                    b.Property<Guid>("PartnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("NumberIssuedPromoCode")
                        .HasColumnType("integer");

                    b.HasKey("PartnerId");

                    b.ToTable("Partner", (string)null);
                });

            modelBuilder.Entity("PromocodeFactory.Domain.PromocodeManagement.PartnerPromoCodeLimit", b =>
                {
                    b.Property<Guid>("PartnerPromoCodeLimitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CancelDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Limit")
                        .HasColumnType("integer");

                    b.Property<Guid>("PartnerId")
                        .HasColumnType("uuid");

                    b.HasKey("PartnerPromoCodeLimitId");

                    b.HasIndex("PartnerId");

                    b.ToTable("PartnerPromoCodeLimit", (string)null);
                });

            modelBuilder.Entity("PromocodeFactory.Domain.PromocodeManagement.Preference", b =>
                {
                    b.Property<Guid>("PreferenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("PreferenceId");

                    b.ToTable("Preference", (string)null);
                });

            modelBuilder.Entity("PromocodeFactory.Domain.PromocodeManagement.PromoCode", b =>
                {
                    b.Property<Guid>("PromoCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PartnerName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<Guid>("PreferenceId")
                        .HasColumnType("uuid");

                    b.Property<string>("ServiceInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PromoCodeId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PreferenceId");

                    b.ToTable("PromoCode", (string)null);
                });

            modelBuilder.Entity("PromocodeFactory.Domain.Administaration.Employee", b =>
                {
                    b.HasOne("PromocodeFactory.Domain.Administaration.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PromocodeFactory.Domain.PromocodeManagement.CustomerPreference", b =>
                {
                    b.HasOne("PromocodeFactory.Domain.PromocodeManagement.Customer", "Customer")
                        .WithMany("CustomerPreferences")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PromocodeFactory.Domain.PromocodeManagement.Preference", "Preference")
                        .WithMany("CustomerPreferences")
                        .HasForeignKey("PreferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Preference");
                });

            modelBuilder.Entity("PromocodeFactory.Domain.PromocodeManagement.PartnerPromoCodeLimit", b =>
                {
                    b.HasOne("PromocodeFactory.Domain.PromocodeManagement.Partner", "Partner")
                        .WithMany("PartnerLimits")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("PromocodeFactory.Domain.PromocodeManagement.PromoCode", b =>
                {
                    b.HasOne("PromocodeFactory.Domain.PromocodeManagement.Customer", "Customer")
                        .WithMany("PromoCodes")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PromocodeFactory.Domain.PromocodeManagement.Preference", "Preference")
                        .WithMany("PromoCodes")
                        .HasForeignKey("PreferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Preference");
                });

            modelBuilder.Entity("PromocodeFactory.Domain.Administaration.Role", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("PromocodeFactory.Domain.PromocodeManagement.Customer", b =>
                {
                    b.Navigation("CustomerPreferences");

                    b.Navigation("PromoCodes");
                });

            modelBuilder.Entity("PromocodeFactory.Domain.PromocodeManagement.Partner", b =>
                {
                    b.Navigation("PartnerLimits");
                });

            modelBuilder.Entity("PromocodeFactory.Domain.PromocodeManagement.Preference", b =>
                {
                    b.Navigation("CustomerPreferences");

                    b.Navigation("PromoCodes");
                });
#pragma warning restore 612, 618
        }
    }
}
