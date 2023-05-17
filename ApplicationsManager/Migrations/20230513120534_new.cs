using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationsManager.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionActivity_Subscriptions_SubscriptionId",
                table: "SubscriptionActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_SubscriptionPlan_planId",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionPlan",
                table: "SubscriptionPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionActivity",
                table: "SubscriptionActivity");

            migrationBuilder.RenameTable(
                name: "SubscriptionPlan",
                newName: "SubscriptionPlans");

            migrationBuilder.RenameTable(
                name: "SubscriptionActivity",
                newName: "SubscriptionActivities");

            migrationBuilder.RenameIndex(
                name: "IX_SubscriptionActivity_SubscriptionId",
                table: "SubscriptionActivities",
                newName: "IX_SubscriptionActivities_SubscriptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionPlans",
                table: "SubscriptionPlans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionActivities",
                table: "SubscriptionActivities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApplicationVersions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationTypeId = table.Column<long>(type: "bigint", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<int>(type: "int", nullable: false),
                    IsCritical = table.Column<bool>(type: "bit", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationVersions_ApplicationTypes_ApplicationTypeId",
                        column: x => x.ApplicationTypeId,
                        principalTable: "ApplicationTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "ApplicationTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 13, 15, 35, 34, 84, DateTimeKind.Local).AddTicks(5131));

            migrationBuilder.UpdateData(
                table: "ApplicationTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 13, 15, 35, 34, 84, DateTimeKind.Local).AddTicks(5137));

            migrationBuilder.UpdateData(
                table: "ApplicationTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 13, 15, 35, 34, 84, DateTimeKind.Local).AddTicks(5139));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 13, 15, 35, 34, 84, DateTimeKind.Local).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 13, 15, 35, 34, 84, DateTimeKind.Local).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 13, 15, 35, 34, 84, DateTimeKind.Local).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 13, 15, 35, 34, 84, DateTimeKind.Local).AddTicks(5170));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationVersions_ApplicationTypeId",
                table: "ApplicationVersions",
                column: "ApplicationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionActivities_Subscriptions_SubscriptionId",
                table: "SubscriptionActivities",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_SubscriptionPlans_planId",
                table: "Subscriptions",
                column: "planId",
                principalTable: "SubscriptionPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionActivities_Subscriptions_SubscriptionId",
                table: "SubscriptionActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_SubscriptionPlans_planId",
                table: "Subscriptions");

            migrationBuilder.DropTable(
                name: "ApplicationVersions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionPlans",
                table: "SubscriptionPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionActivities",
                table: "SubscriptionActivities");

            migrationBuilder.RenameTable(
                name: "SubscriptionPlans",
                newName: "SubscriptionPlan");

            migrationBuilder.RenameTable(
                name: "SubscriptionActivities",
                newName: "SubscriptionActivity");

            migrationBuilder.RenameIndex(
                name: "IX_SubscriptionActivities_SubscriptionId",
                table: "SubscriptionActivity",
                newName: "IX_SubscriptionActivity_SubscriptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionPlan",
                table: "SubscriptionPlan",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionActivity",
                table: "SubscriptionActivity",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ApplicationTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 13, 14, 24, 19, 147, DateTimeKind.Local).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "ApplicationTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 13, 14, 24, 19, 147, DateTimeKind.Local).AddTicks(5156));

            migrationBuilder.UpdateData(
                table: "ApplicationTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 13, 14, 24, 19, 147, DateTimeKind.Local).AddTicks(5157));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 13, 14, 24, 19, 147, DateTimeKind.Local).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 13, 14, 24, 19, 147, DateTimeKind.Local).AddTicks(5027));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 13, 14, 24, 19, 147, DateTimeKind.Local).AddTicks(5029));

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 13, 14, 24, 19, 147, DateTimeKind.Local).AddTicks(5178));

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionActivity_Subscriptions_SubscriptionId",
                table: "SubscriptionActivity",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_SubscriptionPlan_planId",
                table: "Subscriptions",
                column: "planId",
                principalTable: "SubscriptionPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
