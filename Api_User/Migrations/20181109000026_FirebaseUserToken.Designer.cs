﻿// <auto-generated />
using System;
using Api_User.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api_User.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20181109000026_FirebaseUserToken")]
    partial class FirebaseUserToken
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api_User.Models.FirebaseUserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreation");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FirebaseUserTokens");
                });

            modelBuilder.Entity("Api_User.Models.PersonalDancer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PersonalDancer");
                });

            modelBuilder.Entity("Api_User.Models.PersonalDanceStyle", b =>
                {
                    b.Property<int>("PersonalDancerId");

                    b.Property<int>("StyleId");

                    b.HasKey("PersonalDancerId", "StyleId");

                    b.HasIndex("StyleId");

                    b.ToTable("PersonalDanceStyle");
                });

            modelBuilder.Entity("Api_User.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("PersonalDancerId");

                    b.Property<byte>("Rating");

                    b.HasKey("Id");

                    b.HasIndex("PersonalDancerId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Api_User.Models.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Style");
                });

            modelBuilder.Entity("Api_User.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Api_User.Models.FirebaseUserToken", b =>
                {
                    b.HasOne("Api_User.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api_User.Models.PersonalDancer", b =>
                {
                    b.HasOne("Api_User.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Api_User.Models.PersonalDanceStyle", b =>
                {
                    b.HasOne("Api_User.Models.PersonalDancer", "PersonalDancer")
                        .WithMany("Style")
                        .HasForeignKey("PersonalDancerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api_User.Models.Style", "Style")
                        .WithMany("PersonalDancer")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api_User.Models.Review", b =>
                {
                    b.HasOne("Api_User.Models.PersonalDancer", "PersonalDancer")
                        .WithMany()
                        .HasForeignKey("PersonalDancerId");
                });
#pragma warning restore 612, 618
        }
    }
}
