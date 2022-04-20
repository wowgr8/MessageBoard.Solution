﻿// <auto-generated />
using MessageBoard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MessageBoard.Migrations
{
    [DbContext(typeof(MessageBoardContext))]
    partial class MessageBoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MessageBoard.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("From")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("To")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessageId = 1,
                            From = "Filipe",
                            Pages = 7,
                            Title = "Weekend Trip",
                            To = "Woolly Mammoth"
                        },
                        new
                        {
                            MessageId = 2,
                            From = "Dan",
                            Pages = 10,
                            Title = "Airbnb",
                            To = "You"
                        },
                        new
                        {
                            MessageId = 3,
                            From = "Kimi",
                            Pages = 2,
                            Title = "Class Schedule",
                            To = "Shteve"
                        },
                        new
                        {
                            MessageId = 4,
                            From = "Stan",
                            Pages = 4,
                            Title = "Pipes",
                            To = "Shark"
                        },
                        new
                        {
                            MessageId = 5,
                            From = "Foolio",
                            Pages = 22,
                            Title = "Binge Drinking 101",
                            To = "Dinosaur"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
