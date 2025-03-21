﻿// <auto-generated />
using System;
using FashionFlows.Services.Account.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PersonalScheduling.Services.Account.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250116163903_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PersonalScheduling.Services.Account.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("RefreshTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RefreshTokenID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RefreshTokenId"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ExpireAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserID");

                    b.HasKey("RefreshTokenId");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken", (string)null);
                });

            modelBuilder.Entity("PersonalScheduling.Services.Account.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserID");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FullName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("PersonalScheduling.Services.Account.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("PersonalScheduling.Services.Account.Domain.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_RefreshToken_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PersonalScheduling.Services.Account.Domain.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
