using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceUp.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mouth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: true),
                    Returns = table.Column<float>(type: "real", nullable: true),
                    OtherEarnings = table.Column<float>(type: "real", nullable: true),
                    FoodExpense = table.Column<float>(type: "real", nullable: true),
                    ExpenseTransport = table.Column<float>(type: "real", nullable: true),
                    HousingExpense = table.Column<float>(type: "real", nullable: true),
                    HealthEducationExpenses = table.Column<float>(type: "real", nullable: true),
                    Investments = table.Column<float>(type: "real", nullable: true),
                    Taxes = table.Column<float>(type: "real", nullable: true),
                    LeisureExpenses = table.Column<float>(type: "real", nullable: true),
                    OtherExpenses = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => new { x.UserId, x.Mouth });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
