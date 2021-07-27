﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Travelers.persistance;

namespace Travelers.Persistence.Migrations
{
    [DbContext(typeof(TravelersContext))]
    [Migration("20210726195705_Changes4")]
    partial class Changes4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Travelers.entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Content");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateAndTime");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberOfLikes")
                        .HasColumnType("int")
                        .HasColumnName("NumberOfLikes");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdPosts");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.HasIndex("PostId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Travelers.entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Content");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdPosts");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.HasIndex("PostId")
                        .IsUnique();

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("Travelers.entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Content");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateAndTime");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberOfLikes")
                        .HasColumnType("int")
                        .HasColumnName("NumberOfLikes");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Travelers.entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Content");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberOfLikes")
                        .HasColumnType("int")
                        .HasColumnName("numberOfLikes");

                    b.Property<int>("NumberOfStars")
                        .HasColumnType("int")
                        .HasColumnName("NumberOfStars");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdPosts");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.HasIndex("PostId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Travelers.entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Email");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("PasswordHash");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Type");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Travelers.entities.Comment", b =>
                {
                    b.HasOne("Travelers.entities.User", "Users")
                        .WithMany("Comments")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travelers.entities.Post", "Posts")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Posts");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Travelers.entities.Notification", b =>
                {
                    b.HasOne("Travelers.entities.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travelers.entities.Post", "Post")
                        .WithOne("Notification")
                        .HasForeignKey("Travelers.entities.Notification", "PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Travelers.entities.Post", b =>
                {
                    b.HasOne("Travelers.entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Travelers.entities.Review", b =>
                {
                    b.HasOne("Travelers.entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travelers.entities.Post", "Post")
                        .WithMany("Reviews")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Travelers.entities.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Notification");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Travelers.entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Notifications");

                    b.Navigation("Posts");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
