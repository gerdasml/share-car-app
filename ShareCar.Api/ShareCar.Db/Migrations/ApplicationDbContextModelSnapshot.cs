﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ShareCar.Db;
using System;

namespace ShareCar.Db.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ShareCar.Db.Entities.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longtitude");

                    b.Property<string>("Number");

                    b.Property<string>("Street");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ShareCar.Db.Entities.Passenger", b =>
                {
                    b.Property<string>("Email");

                    b.Property<int>("RideId");

                    b.Property<bool>("Completed");

                    b.Property<bool>("PassengerResponded");

                    b.Property<int>("PassengerId");

                    b.HasKey("Email", "RideId");

                    b.HasAlternateKey("PassengerId");

                    b.HasIndex("RideId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("ShareCar.Db.Entities.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<string>("DriverEmail");

                    b.Property<string>("PassengerEmail");

                    b.Property<int>("RideId");

                    b.Property<bool>("SeenByDriver");

                    b.Property<bool>("SeenByPassenger");

                    b.Property<int>("Status");

                    b.HasKey("RequestId");

                    b.HasIndex("AddressId");

                    b.HasIndex("DriverEmail");

                    b.HasIndex("PassengerEmail");

                    b.HasIndex("RideId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("ShareCar.Db.Entities.Ride", b =>
                {
                    b.Property<int>("RideId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DriverEmail");

                    b.Property<int>("NumberOfSeats")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(4);

                    b.Property<DateTime>("RideDateTime");

                    b.Property<int>("RouteId");

                    b.Property<bool>("isActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.HasKey("RideId");

                    b.HasIndex("RouteId");

                    b.ToTable("Rides");
                });

            modelBuilder.Entity("ShareCar.Db.Entities.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FromId");

                    b.Property<string>("Geometry");

                    b.Property<int>("ToId");

                    b.HasKey("RouteId");

                    b.HasIndex("FromId");

                    b.HasIndex("Geometry")
                        .IsUnique()
                        .HasFilter("[Geometry] IS NOT NULL");

                    b.HasIndex("ToId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("ShareCar.Db.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<long?>("FacebookId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("LicensePlate");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Phone");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PictureUrl");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ShareCar.Db.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ShareCar.Db.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShareCar.Db.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ShareCar.Db.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShareCar.Db.Entities.Passenger", b =>
                {
                    b.HasOne("ShareCar.Db.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("Email")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShareCar.Db.Entities.Ride", "Ride")
                        .WithMany("Passengers")
                        .HasForeignKey("RideId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShareCar.Db.Entities.Request", b =>
                {
                    b.HasOne("ShareCar.Db.Entities.Address", "RequestAddress")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShareCar.Db.Entities.User", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverEmail");

                    b.HasOne("ShareCar.Db.Entities.User", "Passenger")
                        .WithMany()
                        .HasForeignKey("PassengerEmail");

                    b.HasOne("ShareCar.Db.Entities.Ride", "RequestedRide")
                        .WithMany("Requests")
                        .HasForeignKey("RideId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShareCar.Db.Entities.Ride", b =>
                {
                    b.HasOne("ShareCar.Db.Entities.Route", "Route")
                        .WithMany("Rides")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShareCar.Db.Entities.Route", b =>
                {
                    b.HasOne("ShareCar.Db.Entities.Address", "AromAddress")
                        .WithMany()
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShareCar.Db.Entities.Address", "ToAddress")
                        .WithMany()
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
