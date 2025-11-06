namespace bmiCalculator.Data;

using Microsoft.EntityFrameworkCore;
using bmiCalculator.Models;

public class BmiDbContext : DbContext
{
    public BmiDbContext(DbContextOptions<BmiDbContext> options) : base(options)
    {
    }

    public DbSet<BmiResult> BmiResults { get; set; }
    public DbSet<LocalizationString> LocalizationStrings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure table names to match your database schema
        modelBuilder.Entity<BmiResult>().ToTable("bmi_results");
        modelBuilder.Entity<LocalizationString>().ToTable("localization_strings");

        // Configure column names to match snake_case
        modelBuilder.Entity<BmiResult>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
        });

        // Seed localization data
        SeedLocalizationData(modelBuilder);
    }

    private void SeedLocalizationData(ModelBuilder modelBuilder)
    {
        var localizationData = new List<LocalizationString>
        {
            // English
            new() { Id = 1, Key = "title", Value = "BMI Calculator", Language = "en" },
            new() { Id = 2, Key = "weight_label", Value = "Weight (kg)", Language = "en" },
            new() { Id = 3, Key = "height_label", Value = "Height (cm)", Language = "en" },
            new() { Id = 4, Key = "calculate_button", Value = "Calculate BMI", Language = "en" },
            new() { Id = 5, Key = "result_title", Value = "Your BMI Result", Language = "en" },
            new() { Id = 6, Key = "category_label", Value = "Category", Language = "en" },
            new() { Id = 7, Key = "underweight", Value = "Underweight", Language = "en" },
            new() { Id = 8, Key = "normal_weight", Value = "Normal weight", Language = "en" },
            new() { Id = 9, Key = "overweight", Value = "Overweight", Language = "en" },
            new() { Id = 10, Key = "obese", Value = "Obese", Language = "en" },
            new() { Id = 11, Key = "weight_placeholder", Value = "Enter your weight in kilograms", Language = "en" },
            new() { Id = 12, Key = "height_placeholder", Value = "Enter your height in centimeters", Language = "en" },

            // Finnish
            new() { Id = 13, Key = "title", Value = "BMI Laskin", Language = "fi" },
            new() { Id = 14, Key = "weight_label", Value = "Paino (kg)", Language = "fi" },
            new() { Id = 15, Key = "height_label", Value = "Pituus (cm)", Language = "fi" },
            new() { Id = 16, Key = "calculate_button", Value = "Laske BMI", Language = "fi" },
            new() { Id = 17, Key = "result_title", Value = "BMI Tuloksesi", Language = "fi" },
            new() { Id = 18, Key = "category_label", Value = "Kategoria", Language = "fi" },
            new() { Id = 19, Key = "underweight", Value = "Alipaino", Language = "fi" },
            new() { Id = 20, Key = "normal_weight", Value = "Normaali paino", Language = "fi" },
            new() { Id = 21, Key = "overweight", Value = "Ylipaino", Language = "fi" },
            new() { Id = 22, Key = "obese", Value = "Lihava", Language = "fi" },
            new() { Id = 23, Key = "weight_placeholder", Value = "Syötä painosi kilogrammoina", Language = "fi" },
            new() { Id = 24, Key = "height_placeholder", Value = "Syötä pituutesi senttimetreinä", Language = "fi" },

            // Persian/Farsi
            new() { Id = 25, Key = "title", Value = "محاسبه BMI", Language = "fa" },
            new() { Id = 26, Key = "weight_label", Value = "وزن (کیلوگرم)", Language = "fa" },
            new() { Id = 27, Key = "height_label", Value = "قد (سانتی‌متر)", Language = "fa" },
            new() { Id = 28, Key = "calculate_button", Value = "محاسبه BMI", Language = "fa" },
            new() { Id = 29, Key = "result_title", Value = "نتیجه BMI شما", Language = "fa" },
            new() { Id = 30, Key = "category_label", Value = "دسته‌بندی", Language = "fa" },
            new() { Id = 31, Key = "underweight", Value = "کم وزن", Language = "fa" },
            new() { Id = 32, Key = "normal_weight", Value = "وزن طبیعی", Language = "fa" },
            new() { Id = 33, Key = "overweight", Value = "اضافه وزن", Language = "fa" },
            new() { Id = 34, Key = "obese", Value = "چاق", Language = "fa" },
            new() { Id = 35, Key = "weight_placeholder", Value = "وزن خود را به کیلوگرم وارد کنید", Language = "fa" },
            new() { Id = 36, Key = "height_placeholder", Value = "قد خود را به سانتی‌متر وارد کنید", Language = "fa" }
        };

        modelBuilder.Entity<LocalizationString>().HasData(localizationData);
    }
}