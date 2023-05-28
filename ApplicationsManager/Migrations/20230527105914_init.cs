using System;
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
                    AppEName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationTypes", x => x.AppEName);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarketName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BarnchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Days = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationVersions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationEName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<int>(type: "int", nullable: false),
                    IsCritical = table.Column<bool>(type: "bit", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationVersions_ApplicationTypes_ApplicationEName",
                        column: x => x.ApplicationEName,
                        principalTable: "ApplicationTypes",
                        principalColumn: "AppEName");
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppEName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlanId = table.Column<long>(type: "bigint", nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_ApplicationTypes_AppEName",
                        column: x => x.AppEName,
                        principalTable: "ApplicationTypes",
                        principalColumn: "AppEName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_SubscriptionPlans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "SubscriptionPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ApplicationTypes",
                columns: new[] { "AppEName", "CreatedDate", "Description", "Id", "Name" },
                values: new object[,]
                {
                    { "41", new DateTime(2023, 5, 27, 14, 29, 14, 661, DateTimeKind.Local).AddTicks(3396), null, 2L, "ویژیتو" },
                    { "47", new DateTime(2023, 5, 27, 14, 29, 14, 661, DateTimeKind.Local).AddTicks(3392), null, 1L, "صندوقک" },
                    { "52", new DateTime(2023, 5, 27, 14, 29, 14, 661, DateTimeKind.Local).AddTicks(3398), null, 3L, "سفارشگیر" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BarnchName", "City", "CreatedDate", "MarketName", "Mobile", "OwnerName", "State" },
                values: new object[,]
                {
                    { new Guid("4c9862c1-6777-45b6-8581-2151898af73e"), "مطهری", "کرمان", new DateTime(2023, 5, 27, 14, 29, 14, 661, DateTimeKind.Local).AddTicks(3250), "سوپرمارکت احد", "09364142953", "اکبری", "کرمان" },
                    { new Guid("519665be-1e28-4d25-8cf3-2ce95695d738"), "مطهری", "تهران", new DateTime(2023, 5, 27, 14, 29, 14, 661, DateTimeKind.Local).AddTicks(3253), "سوپرمارکت صالحی", "09364142953", "صالحی", "تهران" },
                    { new Guid("98be75ba-0227-4f55-affa-18d39c634685"), "مطهری", "کرمان", new DateTime(2023, 5, 27, 14, 29, 14, 661, DateTimeKind.Local).AddTicks(3230), "خوارو بار فروشی احمدی", "09364142953", "احمدی", "کرمان" }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionPlans",
                columns: new[] { "Id", "Days", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, 10, null, "ده روزه" },
                    { 2L, 30, null, "یکماهه" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FName", "LName", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("0178d296-9c94-448e-8ced-9c09d744b510"), "حمید", "اکبری", "123456", 1, "hamid" },
                    { new Guid("dd37fb26-5dcf-43ab-bc34-88d3a0965f40"), "میلاد", "انجم شعاع", "123456", 0, "milad" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationVersions",
                columns: new[] { "Id", "ApplicationEName", "IsCritical", "ReleaseDate", "code", "name" },
                values: new object[,]
                {
                    { 1L, "47", false, new DateTime(2023, 5, 27, 10, 59, 14, 661, DateTimeKind.Utc).AddTicks(3368), 1, "13.2.1" },
                    { 2L, "47", false, new DateTime(2023, 5, 27, 10, 59, 14, 661, DateTimeKind.Utc).AddTicks(3371), 2, "14.2.1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationVersions_ApplicationEName",
                table: "ApplicationVersions",
                column: "ApplicationEName");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_AppEName",
                table: "Subscriptions",
                column: "AppEName");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CustomerId",
                table: "Subscriptions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_PlanId",
                table: "Subscriptions",
                column: "PlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationVersions");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ApplicationTypes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "SubscriptionPlans");
        }
    }
}
