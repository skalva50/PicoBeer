using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PicoBeer.Migrations
{
    public partial class Recipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Volume = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeHop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    RecipeId = table.Column<int>(nullable: true),
                    IngredientId = table.Column<int>(nullable: true),
                    Quantity = table.Column<double>(nullable: false),
                    BoilingTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeHop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeHop_Hop_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Hop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeHop_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeMalt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    RecipeId = table.Column<int>(nullable: true),
                    IngredientId = table.Column<int>(nullable: true),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeMalt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeMalt_Malt_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Malt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeMalt_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeYeast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    RecipeId = table.Column<int>(nullable: true),
                    IngredientId = table.Column<int>(nullable: true),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeYeast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeYeast_Yeast_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Yeast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeYeast_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeHop_IngredientId",
                table: "RecipeHop",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeHop_RecipeId",
                table: "RecipeHop",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeMalt_IngredientId",
                table: "RecipeMalt",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeMalt_RecipeId",
                table: "RecipeMalt",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeYeast_IngredientId",
                table: "RecipeYeast",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeYeast_RecipeId",
                table: "RecipeYeast",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeHop");

            migrationBuilder.DropTable(
                name: "RecipeMalt");

            migrationBuilder.DropTable(
                name: "RecipeYeast");

            migrationBuilder.DropTable(
                name: "Recipe");
        }
    }
}
