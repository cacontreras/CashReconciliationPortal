using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CashReconciliationPortal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "DepositId", "ActualAmount", "DepositDate", "DepositNumber", "ExpectedAmount", "Status", "StoreNumber", "Variance" },
                values: new object[,]
                {
                    { 1, 0m, new DateTime(2026, 11, 5, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8792), "DEP-2026-0001", 1545.50m, "Pending", "STR-002", 0m },
                    { 2, 0m, new DateTime(2026, 11, 4, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8801), "DEP-2026-0002", 1591.00m, "Pending", "STR-003", 0m },
                    { 3, 0m, new DateTime(2026, 11, 3, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8804), "DEP-2026-0003", 1636.50m, "Pending", "STR-004", 0m },
                    { 4, 0m, new DateTime(2026, 11, 2, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8808), "DEP-2026-0004", 1682.00m, "Pending", "STR-005", 0m },
                    { 5, 0m, new DateTime(2026, 11, 1, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8812), "DEP-2026-0005", 1727.50m, "Pending", "STR-001", 0m },
                    { 6, 0m, new DateTime(2026, 10, 31, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8815), "DEP-2026-0006", 1773.00m, "Pending", "STR-002", 0m },
                    { 7, 0m, new DateTime(2026, 10, 30, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8818), "DEP-2026-0007", 1818.50m, "Pending", "STR-003", 0m },
                    { 8, 0m, new DateTime(2026, 10, 29, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8821), "DEP-2026-0008", 1864.00m, "Pending", "STR-004", 0m },
                    { 9, 0m, new DateTime(2026, 10, 28, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8824), "DEP-2026-0009", 1909.50m, "Pending", "STR-005", 0m },
                    { 10, 0m, new DateTime(2026, 10, 27, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8828), "DEP-2026-0010", 1955.00m, "Pending", "STR-001", 0m },
                    { 11, 0m, new DateTime(2026, 10, 26, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8830), "DEP-2026-0011", 2000.50m, "Pending", "STR-002", 0m },
                    { 12, 0m, new DateTime(2026, 10, 25, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8833), "DEP-2026-0012", 2046.00m, "Pending", "STR-003", 0m },
                    { 13, 0m, new DateTime(2026, 10, 24, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8836), "DEP-2026-0013", 2091.50m, "Pending", "STR-004", 0m },
                    { 14, 0m, new DateTime(2026, 10, 23, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8838), "DEP-2026-0014", 2137.00m, "Pending", "STR-005", 0m },
                    { 15, 0m, new DateTime(2026, 10, 22, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8841), "DEP-2026-0015", 2182.50m, "Pending", "STR-001", 0m },
                    { 16, 0m, new DateTime(2026, 10, 21, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8844), "DEP-2026-0016", 2228.00m, "Pending", "STR-002", 0m },
                    { 17, 0m, new DateTime(2026, 10, 20, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8846), "DEP-2026-0017", 2273.50m, "Pending", "STR-003", 0m },
                    { 18, 0m, new DateTime(2026, 10, 19, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8849), "DEP-2026-0018", 2319.00m, "Pending", "STR-004", 0m },
                    { 19, 0m, new DateTime(2026, 10, 18, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8851), "DEP-2026-0019", 2364.50m, "Pending", "STR-005", 0m },
                    { 20, 0m, new DateTime(2026, 10, 17, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8854), "DEP-2026-0020", 2410.00m, "Pending", "STR-001", 0m },
                    { 21, 0m, new DateTime(2026, 10, 16, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8856), "DEP-2026-0021", 2455.50m, "Pending", "STR-002", 0m },
                    { 22, 0m, new DateTime(2026, 10, 15, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8859), "DEP-2026-0022", 2501.00m, "Pending", "STR-003", 0m },
                    { 23, 0m, new DateTime(2026, 10, 14, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8862), "DEP-2026-0023", 2546.50m, "Pending", "STR-004", 0m },
                    { 24, 0m, new DateTime(2026, 10, 13, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8864), "DEP-2026-0024", 2592.00m, "Pending", "STR-005", 0m },
                    { 25, 0m, new DateTime(2026, 10, 12, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8937), "DEP-2026-0025", 2637.50m, "Pending", "STR-001", 0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 25);
        }
    }
}
