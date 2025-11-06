# BMI Calculator

A multilingual BMI calculator built with ASP.NET Core Razor Pages, featuring localization support for English, Finnish, and Persian/Farsi languages with MariaDB database storage.

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [MariaDB](https://mariadb.org/download/) or MySQL
- [Entity Framework Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) (for database migrations)

## Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/ravend3v/otp2-tasks.git
cd otp2-tasks/bmiCalculator
```

### 2. Install EF Core Tools

```bash
dotnet tool install --global dotnet-ef
```

### 3. Setup MariaDB Database

#### Install MariaDB

- Download and install MariaDB from [official website](https://mariadb.org/download/)
- Set a root password during installation

#### Create Database and User

```sql
-- Connect to MariaDB as root
mysql -u root -p

-- Create database
CREATE DATABASE IF NOT EXISTS bmi_localization CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Create user
CREATE USER IF NOT EXISTS 'bmi_user'@'localhost' IDENTIFIED BY 'bmitest1235';

-- Grant privileges
GRANT ALL PRIVILEGES ON bmi_localization.* TO 'bmi_user'@'localhost';
FLUSH PRIVILEGES;

-- Exit
EXIT;
```

### 4. Configure Connection String

Update `appsettings.json` with your database credentials:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=bmi_localization;User=bmi_user;Password=bmitest1235;Port=3306;"
  }
}
```

### 5. Install Dependencies

```bash
dotnet restore
```

### 6. Run Database Migrations

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

This takes time.

## Running the Application

```bash
dotnet run
```

The application will be available at:

- HTTP: `http://localhost:5015`
- HTTPS: `https://localhost:7119`

## Usage

1. **Select Language**: Use the language buttons at the top (English/Suomi/فارسی)
2. **Enter Weight**: Input your weight in kilograms (1-1000 kg)
3. **Enter Height**: Input your height in centimeters (50-300 cm)
4. **Calculate**: Click the "Calculate BMI" button
5. **View Results**: See your BMI value and category classification

### BMI Categories

- **Underweight**: BMI < 18.5
- **Normal weight**: BMI 18.5-24.9
- **Overweight**: BMI 25-29.9
- **Obese**: BMI ≥ 30

## Database Schema

### Tables

- `bmi_results`: Stores BMI calculation results
- `localization_strings`: Stores UI text translations
- `__efmigrationshistory`: Entity Framework migration history

### Example Queries

```sql
-- View recent BMI calculations
SELECT * FROM bmi_results ORDER BY created_at DESC LIMIT 10;

-- Count calculations by language
SELECT language, COUNT(*) as count FROM bmi_results GROUP BY language;

-- View localization strings for a specific language
SELECT * FROM localization_strings WHERE language = 'en';
```

## Project Structure

```
bmiCalculator/
├── Data/
│   └── BmiDbContext.cs          # Entity Framework DbContext
├── Models/
│   ├── BmiResult.cs             # BMI calculation result model
│   └── LocalizationString.cs    # Localization text model
├── Pages/
│   ├── Index.cshtml             # Main calculator page view
│   ├── Index.cshtml.cs          # Main calculator page logic
│   └── Shared/
│       └── _Layout.cshtml       # Layout template
├── Services/
│   ├── ILocalizationService.cs  # Localization service interface
│   └── LocalizationService.cs   # Localization service implementation
├── wwwroot/css/
│   └── site.css                 # Custom styles
├── appsettings.json             # Configuration file
└── Program.cs                   # Application entry point
```
