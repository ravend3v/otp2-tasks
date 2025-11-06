using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bmiCalculator.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bmi_results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Weight = table.Column<double>(type: "double", nullable: false),
                    Height = table.Column<double>(type: "double", nullable: false),
                    Bmi = table.Column<double>(type: "double", nullable: false),
                    Language = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bmi_results", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "localization_strings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Language = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_localization_strings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "localization_strings",
                columns: new[] { "Id", "Key", "Language", "Value" },
                values: new object[,]
                {
                    { 1, "title", "en", "BMI Calculator" },
                    { 2, "weight_label", "en", "Weight (kg)" },
                    { 3, "height_label", "en", "Height (cm)" },
                    { 4, "calculate_button", "en", "Calculate BMI" },
                    { 5, "result_title", "en", "Your BMI Result" },
                    { 6, "category_label", "en", "Category" },
                    { 7, "underweight", "en", "Underweight" },
                    { 8, "normal_weight", "en", "Normal weight" },
                    { 9, "overweight", "en", "Overweight" },
                    { 10, "obese", "en", "Obese" },
                    { 11, "weight_placeholder", "en", "Enter your weight in kilograms" },
                    { 12, "height_placeholder", "en", "Enter your height in centimeters" },
                    { 13, "title", "fi", "BMI Laskin" },
                    { 14, "weight_label", "fi", "Paino (kg)" },
                    { 15, "height_label", "fi", "Pituus (cm)" },
                    { 16, "calculate_button", "fi", "Laske BMI" },
                    { 17, "result_title", "fi", "BMI Tuloksesi" },
                    { 18, "category_label", "fi", "Kategoria" },
                    { 19, "underweight", "fi", "Alipaino" },
                    { 20, "normal_weight", "fi", "Normaali paino" },
                    { 21, "overweight", "fi", "Ylipaino" },
                    { 22, "obese", "fi", "Lihava" },
                    { 23, "weight_placeholder", "fi", "Syötä painosi kilogrammoina" },
                    { 24, "height_placeholder", "fi", "Syötä pituutesi senttimetreinä" },
                    { 25, "title", "fa", "محاسبه BMI" },
                    { 26, "weight_label", "fa", "وزن (کیلوگرم)" },
                    { 27, "height_label", "fa", "قد (سانتی‌متر)" },
                    { 28, "calculate_button", "fa", "محاسبه BMI" },
                    { 29, "result_title", "fa", "نتیجه BMI شما" },
                    { 30, "category_label", "fa", "دسته‌بندی" },
                    { 31, "underweight", "fa", "کم وزن" },
                    { 32, "normal_weight", "fa", "وزن طبیعی" },
                    { 33, "overweight", "fa", "اضافه وزن" },
                    { 34, "obese", "fa", "چاق" },
                    { 35, "weight_placeholder", "fa", "وزن خود را به کیلوگرم وارد کنید" },
                    { 36, "height_placeholder", "fa", "قد خود را به سانتی‌متر وارد کنید" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bmi_results");

            migrationBuilder.DropTable(
                name: "localization_strings");
        }
    }
}
