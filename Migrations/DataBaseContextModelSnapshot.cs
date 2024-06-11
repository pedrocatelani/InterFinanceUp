﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinanceUp.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Account", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Month")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("ExpenseTransport")
                        .HasColumnType("real");

                    b.Property<float>("FoodExpense")
                        .HasColumnType("real");

                    b.Property<float>("HealthEducationExpenses")
                        .HasColumnType("real");

                    b.Property<float>("HousingExpense")
                        .HasColumnType("real");

                    b.Property<float>("Investments")
                        .HasColumnType("real");

                    b.Property<float>("LeisureExpenses")
                        .HasColumnType("real");

                    b.Property<float>("OtherEarnings")
                        .HasColumnType("real");

                    b.Property<float>("OtherExpenses")
                        .HasColumnType("real");

                    b.Property<float>("Returns")
                        .HasColumnType("real");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.Property<float>("Taxes")
                        .HasColumnType("real");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("UserId", "Month");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Account", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
