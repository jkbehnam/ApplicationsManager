﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApplicationsManager.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxUsers = table.Column<int>(type: "int", nullable: true),
                    Days = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    ApplicationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    planId = table.Column<long>(type: "bigint", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_ApplicationTypes_ApplicationTypeId",
                        column: x => x.ApplicationTypeId,
                        principalTable: "ApplicationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_SubscriptionPlan_planId",
                        column: x => x.planId,
                        principalTable: "SubscriptionPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionActivity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionId = table.Column<long>(type: "bigint", nullable: false),
                    VersionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUseTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionActivity_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationTypes",
                columns: new[] { "Id", "CreatedDate", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 5, 13, 14, 24, 19, 147, DateTimeKind.Local).AddTicks(5151), null, "صندوقک" },
                    { 2L, new DateTime(2023, 5, 13, 14, 24, 19, 147, DateTimeKind.Local).AddTicks(5156), null, "ویژیتو" },
                    { 3L, new DateTime(2023, 5, 13, 14, 24, 19, 147, DateTimeKind.Local).AddTicks(5157), null, "سفارشگیر" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDate", "Mobile", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 5, 13, 14, 24, 19, 147, DateTimeKind.Local).AddTicks(5012), "09364142953", "احمدی", "123456", "ahmadi" },
                    { 2L, new DateTime(2023, 5, 13, 14, 24, 19, 147, DateTimeKind.Local).AddTicks(5027), "09364142953", "اکبری", "123456", "akbari" },
                    { 3L, new DateTime(2023, 5, 13, 14, 24, 19, 147, DateTimeKind.Local).AddTicks(5029), "09364142953", "حسینی", "123456", "hosseini" }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionPlan",
                columns: new[] { "Id", "Days", "Description", "MaxUsers", "Name" },
                values: new object[,]
                {
                    { 1L, 10, null, 5, "ده روزه" },
                    { 2L, 30, null, 5, "یکماهه" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "ApplicationTypeId", "CreatedDate", "CustomerId", "EndTime", "IsActive", "StartTime", "planId" },
                values: new object[] { 1L, 1L, new DateTime(2023, 5, 13, 14, 24, 19, 147, DateTimeKind.Local).AddTicks(5178), 1L, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionActivity_SubscriptionId",
                table: "SubscriptionActivity",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ApplicationTypeId",
                table: "Subscriptions",
                column: "ApplicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CustomerId",
                table: "Subscriptions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_planId",
                table: "Subscriptions",
                column: "planId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriptionActivity");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "ApplicationTypes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "SubscriptionPlan");
        }
    }
}
