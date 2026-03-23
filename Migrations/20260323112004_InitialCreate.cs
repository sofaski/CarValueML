using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarValueML.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Predictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Buying = table.Column<string>(type: "TEXT", nullable: false),
                    Maint = table.Column<string>(type: "TEXT", nullable: false),
                    Doors = table.Column<string>(type: "TEXT", nullable: false),
                    Persons = table.Column<string>(type: "TEXT", nullable: false),
                    LugBoot = table.Column<string>(type: "TEXT", nullable: false),
                    Safety = table.Column<string>(type: "TEXT", nullable: false),
                    EstimatedPriceCategory = table.Column<string>(type: "TEXT", nullable: false),
                    PredictedClass = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predictions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Predictions");
        }
    }
}
