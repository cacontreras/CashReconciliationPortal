using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashReconciliationPortal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Rename_UderId_With_UserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UderId",
                table: "DepositAudits",
                newName: "UserId");

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 1,
                column: "DepositDate",
                value: new DateTime(2026, 11, 5, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(988));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 2,
                column: "DepositDate",
                value: new DateTime(2026, 11, 4, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1021));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 3,
                column: "DepositDate",
                value: new DateTime(2026, 11, 3, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1037));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 4,
                column: "DepositDate",
                value: new DateTime(2026, 11, 2, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1242));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 5,
                column: "DepositDate",
                value: new DateTime(2026, 11, 1, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1259));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 6,
                column: "DepositDate",
                value: new DateTime(2026, 10, 31, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1273));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 7,
                column: "DepositDate",
                value: new DateTime(2026, 10, 30, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1288));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 8,
                column: "DepositDate",
                value: new DateTime(2026, 10, 29, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1302));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 9,
                column: "DepositDate",
                value: new DateTime(2026, 10, 28, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1318));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 10,
                column: "DepositDate",
                value: new DateTime(2026, 10, 27, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1332));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 11,
                column: "DepositDate",
                value: new DateTime(2026, 10, 26, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 12,
                column: "DepositDate",
                value: new DateTime(2026, 10, 25, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 13,
                column: "DepositDate",
                value: new DateTime(2026, 10, 24, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1374));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 14,
                column: "DepositDate",
                value: new DateTime(2026, 10, 23, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 15,
                column: "DepositDate",
                value: new DateTime(2026, 10, 22, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 16,
                column: "DepositDate",
                value: new DateTime(2026, 10, 21, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 17,
                column: "DepositDate",
                value: new DateTime(2026, 10, 20, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1428));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 18,
                column: "DepositDate",
                value: new DateTime(2026, 10, 19, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 19,
                column: "DepositDate",
                value: new DateTime(2026, 10, 18, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1458));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 20,
                column: "DepositDate",
                value: new DateTime(2026, 10, 17, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 21,
                column: "DepositDate",
                value: new DateTime(2026, 10, 16, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1485));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 22,
                column: "DepositDate",
                value: new DateTime(2026, 10, 15, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1498));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 23,
                column: "DepositDate",
                value: new DateTime(2026, 10, 14, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1511));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 24,
                column: "DepositDate",
                value: new DateTime(2026, 10, 13, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1526));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 25,
                column: "DepositDate",
                value: new DateTime(2026, 10, 12, 17, 0, 49, 379, DateTimeKind.Utc).AddTicks(1539));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DepositAudits",
                newName: "UderId");

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 1,
                column: "DepositDate",
                value: new DateTime(2026, 11, 5, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8792));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 2,
                column: "DepositDate",
                value: new DateTime(2026, 11, 4, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 3,
                column: "DepositDate",
                value: new DateTime(2026, 11, 3, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8804));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 4,
                column: "DepositDate",
                value: new DateTime(2026, 11, 2, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 5,
                column: "DepositDate",
                value: new DateTime(2026, 11, 1, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 6,
                column: "DepositDate",
                value: new DateTime(2026, 10, 31, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8815));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 7,
                column: "DepositDate",
                value: new DateTime(2026, 10, 30, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8818));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 8,
                column: "DepositDate",
                value: new DateTime(2026, 10, 29, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 9,
                column: "DepositDate",
                value: new DateTime(2026, 10, 28, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 10,
                column: "DepositDate",
                value: new DateTime(2026, 10, 27, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 11,
                column: "DepositDate",
                value: new DateTime(2026, 10, 26, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 12,
                column: "DepositDate",
                value: new DateTime(2026, 10, 25, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8833));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 13,
                column: "DepositDate",
                value: new DateTime(2026, 10, 24, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8836));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 14,
                column: "DepositDate",
                value: new DateTime(2026, 10, 23, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8838));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 15,
                column: "DepositDate",
                value: new DateTime(2026, 10, 22, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8841));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 16,
                column: "DepositDate",
                value: new DateTime(2026, 10, 21, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8844));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 17,
                column: "DepositDate",
                value: new DateTime(2026, 10, 20, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8846));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 18,
                column: "DepositDate",
                value: new DateTime(2026, 10, 19, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8849));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 19,
                column: "DepositDate",
                value: new DateTime(2026, 10, 18, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 20,
                column: "DepositDate",
                value: new DateTime(2026, 10, 17, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8854));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 21,
                column: "DepositDate",
                value: new DateTime(2026, 10, 16, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 22,
                column: "DepositDate",
                value: new DateTime(2026, 10, 15, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8859));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 23,
                column: "DepositDate",
                value: new DateTime(2026, 10, 14, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 24,
                column: "DepositDate",
                value: new DateTime(2026, 10, 13, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8864));

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 25,
                column: "DepositDate",
                value: new DateTime(2026, 10, 12, 6, 31, 14, 271, DateTimeKind.Utc).AddTicks(8937));
        }
    }
}
