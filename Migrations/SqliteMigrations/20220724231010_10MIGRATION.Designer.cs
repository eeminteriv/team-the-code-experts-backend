﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Helpers;

#nullable disable

namespace WebApi.Migrations.SqliteMigrations
{
    [DbContext(typeof(SqliteDataContext))]
    [Migration("20220724231010_10MIGRATION")]
    partial class _10MIGRATION
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("Broadcast_JWT.Models.Flag", b =>
                {
                    b.Property<int>("FlagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MessageId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReasonId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ResponseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FlagId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("MessageId");

                    b.HasIndex("ResponseId");

                    b.ToTable("Flags");
                });

            modelBuilder.Entity("Broadcast_JWT.Models.FlagType", b =>
                {
                    b.Property<int>("FlagTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.HasKey("FlagTypeId");

                    b.ToTable("FlagTypes");
                });

            modelBuilder.Entity("Broadcast_JWT.Models.FollowingUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FollowingUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("FollowingUsers");
                });

            modelBuilder.Entity("Broadcast_JWT.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("MessageBody")
                        .HasColumnType("TEXT");

                    b.Property<string>("MessageTitle")
                        .HasColumnType("TEXT");

                    b.Property<int>("VoteSummary")
                        .HasColumnType("INTEGER");

                    b.HasKey("MessageId");

                    b.HasIndex("AppUserId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Broadcast_JWT.Models.Response", b =>
                {
                    b.Property<int>("ResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateStamp")
                        .HasColumnType("TEXT");

                    b.Property<int>("MessageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ResponseBody")
                        .HasColumnType("TEXT");

                    b.Property<int>("VoteSummary")
                        .HasColumnType("INTEGER");

                    b.HasKey("ResponseId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("MessageId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("Broadcast_JWT.Models.Vote", b =>
                {
                    b.Property<int>("VoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MessageId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ResponseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("VoteId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("MessageId");

                    b.HasIndex("ResponseId");

                    b.ToTable("Vote");
                });

            modelBuilder.Entity("WebApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Broadcast_JWT.Models.Flag", b =>
                {
                    b.HasOne("WebApi.Entities.User", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.HasOne("Broadcast_JWT.Models.Message", null)
                        .WithMany("Flags")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Broadcast_JWT.Models.Response", null)
                        .WithMany("Flags")
                        .HasForeignKey("ResponseId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Broadcast_JWT.Models.FollowingUser", b =>
                {
                    b.HasOne("WebApi.Entities.User", "AppUser")
                        .WithMany("FollowingUsers")
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Broadcast_JWT.Models.Message", b =>
                {
                    b.HasOne("WebApi.Entities.User", "AppUser")
                        .WithMany("Messages")
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Broadcast_JWT.Models.Response", b =>
                {
                    b.HasOne("WebApi.Entities.User", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.HasOne("Broadcast_JWT.Models.Message", null)
                        .WithMany("Responses")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Broadcast_JWT.Models.Vote", b =>
                {
                    b.HasOne("WebApi.Entities.User", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.HasOne("Broadcast_JWT.Models.Message", null)
                        .WithMany("Votes")
                        .HasForeignKey("MessageId");

                    b.HasOne("Broadcast_JWT.Models.Response", null)
                        .WithMany("Votes")
                        .HasForeignKey("ResponseId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Broadcast_JWT.Models.Message", b =>
                {
                    b.Navigation("Flags");

                    b.Navigation("Responses");

                    b.Navigation("Votes");
                });

            modelBuilder.Entity("Broadcast_JWT.Models.Response", b =>
                {
                    b.Navigation("Flags");

                    b.Navigation("Votes");
                });

            modelBuilder.Entity("WebApi.Entities.User", b =>
                {
                    b.Navigation("FollowingUsers");

                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
