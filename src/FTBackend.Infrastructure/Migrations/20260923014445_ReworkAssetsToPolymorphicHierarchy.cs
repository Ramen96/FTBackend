using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReworkAssetsToPolymorphicHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Assets",
                newName: "StockQuantity");

            migrationBuilder.AlterColumn<decimal>(
                name: "StockQuantity",
                table: "Assets",
                type: "numeric(18,4)",
                precision: 18,
                scale: 4,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ApyPercent",
                table: "Assets",
                type: "numeric(9,4)",
                precision: 9,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetType",
                table: "Assets",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CryptoCostBasis",
                table: "Assets",
                type: "numeric(18,8)",
                precision: 18,
                scale: 8,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CryptoLastPrice",
                table: "Assets",
                type: "numeric(18,8)",
                precision: 18,
                scale: 8,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CryptoPriceUpdatedAt",
                table: "Assets",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CryptoPurchaseDate",
                table: "Assets",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CryptoQuantity",
                table: "Assets",
                type: "numeric(18,8)",
                precision: 18,
                scale: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CryptoSymbol",
                table: "Assets",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CustomCostBasis",
                table: "Assets",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomTypeLabel",
                table: "Assets",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DividendYieldPercent",
                table: "Assets",
                type: "numeric(9,4)",
                precision: 9,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyDistribution",
                table: "Assets",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyIncomeOverride",
                table: "Assets",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NetMonthlyRent",
                table: "Assets",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PurchasePrice",
                table: "Assets",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RealEstatePurchaseDate",
                table: "Assets",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "StockCostBasis",
                table: "Assets",
                type: "numeric(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "StockLastPrice",
                table: "Assets",
                type: "numeric(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StockPriceUpdatedAt",
                table: "Assets",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StockPurchaseDate",
                table: "Assets",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockSymbol",
                table: "Assets",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YieldPercent",
                table: "Assets",
                type: "numeric(9,4)",
                precision: 9,
                scale: 4,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UserId",
                table: "Assets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Assets_UserId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "ApyPercent",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "AssetType",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "CryptoCostBasis",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "CryptoLastPrice",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "CryptoPriceUpdatedAt",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "CryptoPurchaseDate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "CryptoQuantity",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "CryptoSymbol",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "CustomCostBasis",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "CustomTypeLabel",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "DividendYieldPercent",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "MonthlyDistribution",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "MonthlyIncomeOverride",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "NetMonthlyRent",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "RealEstatePurchaseDate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "StockCostBasis",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "StockLastPrice",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "StockPriceUpdatedAt",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "StockPurchaseDate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "StockSymbol",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "YieldPercent",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "StockQuantity",
                table: "Assets",
                newName: "Quantity");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Assets",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,4)",
                oldPrecision: 18,
                oldScale: 4,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Assets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "Assets",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
