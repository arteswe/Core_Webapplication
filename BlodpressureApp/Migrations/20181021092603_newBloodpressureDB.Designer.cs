﻿// <auto-generated />
using System;
using BloodpressureApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BloodpressureApp.Migrations
{
    [DbContext(typeof(BloodPressureInfoContext))]
    [Migration("20181021092603_newBloodpressureDB")]
    partial class newBloodpressureDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BloodpressureApp.Entities.Bloodpressure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Diastolic");

                    b.Property<int>("Heartrate");

                    b.Property<string>("Personnummer")
                        .HasMaxLength(10);

                    b.Property<int>("Systolic");

                    b.Property<string>("Time");

                    b.HasKey("Id");

                    b.HasIndex("Personnummer");

                    b.ToTable("Bloodpressures");
                });

            modelBuilder.Entity("BloodpressureApp.Entities.Person", b =>
                {
                    b.Property<string>("Personnummer")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Personnummer");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("BloodpressureApp.Entities.Weight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Personnummer");

                    b.Property<double>("Weigth");

                    b.HasKey("Id");

                    b.HasIndex("Personnummer");

                    b.ToTable("Weight");
                });

            modelBuilder.Entity("BloodpressureApp.Entities.Bloodpressure", b =>
                {
                    b.HasOne("BloodpressureApp.Entities.Person", "Person")
                        .WithMany("PressureList")
                        .HasForeignKey("Personnummer");
                });

            modelBuilder.Entity("BloodpressureApp.Entities.Weight", b =>
                {
                    b.HasOne("BloodpressureApp.Entities.Person", "Person")
                        .WithMany("Weight")
                        .HasForeignKey("Personnummer");
                });
#pragma warning restore 612, 618
        }
    }
}
