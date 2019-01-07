﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PicoBeer.Dal;

namespace PicoBeer.Migrations
{
    [DbContext(typeof(PicoBeerContext))]
    [Migration("20190107180751_Recipe-Description")]
    partial class RecipeDescription
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PicoBeer.Domain.Hop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Alpha");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Hop");
                });

            modelBuilder.Entity("PicoBeer.Domain.Malt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<double>("Ebc");

                    b.Property<int>("ExtractFactor");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Malt");
                });

            modelBuilder.Entity("PicoBeer.Domain.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<double>("Volume");

                    b.HasKey("Id");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("PicoBeer.Domain.RecipeHop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoilingTime");

                    b.Property<int?>("IngredientId");

                    b.Property<double>("Quantity");

                    b.Property<int?>("RecipeId");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeHop");
                });

            modelBuilder.Entity("PicoBeer.Domain.RecipeMalt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("IngredientId");

                    b.Property<double>("Quantity");

                    b.Property<int?>("RecipeId");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeMalt");
                });

            modelBuilder.Entity("PicoBeer.Domain.RecipeYeast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("IngredientId");

                    b.Property<double>("Quantity");

                    b.Property<int?>("RecipeId");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeYeast");
                });

            modelBuilder.Entity("PicoBeer.Domain.Yeast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Attenuation");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Yeast");
                });

            modelBuilder.Entity("PicoBeer.Domain.RecipeHop", b =>
                {
                    b.HasOne("PicoBeer.Domain.Hop", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId");

                    b.HasOne("PicoBeer.Domain.Recipe", "Recipe")
                        .WithMany("ListHop")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("PicoBeer.Domain.RecipeMalt", b =>
                {
                    b.HasOne("PicoBeer.Domain.Malt", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId");

                    b.HasOne("PicoBeer.Domain.Recipe", "Recipe")
                        .WithMany("ListMalt")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("PicoBeer.Domain.RecipeYeast", b =>
                {
                    b.HasOne("PicoBeer.Domain.Yeast", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId");

                    b.HasOne("PicoBeer.Domain.Recipe", "Recipe")
                        .WithMany("ListYeast")
                        .HasForeignKey("RecipeId");
                });
#pragma warning restore 612, 618
        }
    }
}
