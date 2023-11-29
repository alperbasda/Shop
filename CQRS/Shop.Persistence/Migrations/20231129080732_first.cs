using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "shop");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                schema: "shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiscountUsageType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "shop",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCriteria",
                schema: "shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountAssignType = table.Column<int>(type: "int", nullable: false),
                    FilterOperator = table.Column<int>(type: "int", nullable: false),
                    Criterion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCriteria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountCriteria_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalSchema: "shop",
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerRoleRelations",
                schema: "shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastValidTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRoleRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerRoleRelations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "shop",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerRoleRelations_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "shop",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "shop",
                table: "Categories",
                columns: new[] { "Id", "CreatedTime", "DeletedTime", "Name", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("3139afc7-9ce9-4b2d-b44d-87b89c981e38"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2147), null, "Meat & Fish", null },
                    { new Guid("3574425b-a905-4591-ba8c-f5551a3c6efd"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2144), null, "Grocery", null },
                    { new Guid("36d0d944-3478-446b-8032-06bb6166599f"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2145), null, "Fruits & Vegatables", null }
                });

            migrationBuilder.InsertData(
                schema: "shop",
                table: "Customers",
                columns: new[] { "Id", "CreatedTime", "DeletedTime", "FirstName", "LastName", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("89379877-68fc-49a5-8655-d2a038262138"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2241), null, "Affiliate", "Affiliate", null },
                    { new Guid("ca49622e-c788-4bc1-89f3-52e620c1f220"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2240), null, "Employee", "Employee", null },
                    { new Guid("d9aa2403-1442-4622-b31d-45cf53c5746e"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2243), null, "StardardAccount", "StardardAccount", null }
                });

            migrationBuilder.InsertData(
                schema: "shop",
                table: "Discounts",
                columns: new[] { "Id", "CreatedTime", "DeletedTime", "DiscountUsageType", "Name", "Priority", "UpdatedTime", "Value" },
                values: new object[,]
                {
                    { new Guid("5b21fdd1-3d87-461f-b1e4-8643e6dbd09b"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2118), null, 10, "30% Discount", 1, null, 30m },
                    { new Guid("6688e075-61c3-4532-8861-4a848f7b3ce9"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2127), null, 20, "$5 Discount For every $100", 4, null, 5m },
                    { new Guid("76d0c4af-2ae4-46da-97df-6e0db3b22fba"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2125), null, 10, "5% Discount If Over 2 Year", 3, null, 5m },
                    { new Guid("d567b4dd-03fd-450e-bb95-84f0c8902368"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2123), null, 10, "10% Discount", 2, null, 10m }
                });

            migrationBuilder.InsertData(
                schema: "shop",
                table: "Roles",
                columns: new[] { "Id", "CreatedTime", "DeletedTime", "Name", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("16038a01-51b7-40a6-a8d3-f76c767bf240"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(1975), null, "Employee", null },
                    { new Guid("2abc20da-3e33-4e06-9e68-ea86247ddf7d"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(1986), null, "Affiliate", null },
                    { new Guid("feebd82d-e26c-40f8-b00d-70574b23a288"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(1988), null, "StardardAccount", null }
                });

            migrationBuilder.InsertData(
                schema: "shop",
                table: "CustomerRoleRelations",
                columns: new[] { "Id", "CreatedTime", "CustomerId", "DeletedTime", "LastValidTime", "RoleId", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("073c5288-2fd0-48dd-86c8-7b45dd8cb57a"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2257), new Guid("89379877-68fc-49a5-8655-d2a038262138"), null, null, new Guid("2abc20da-3e33-4e06-9e68-ea86247ddf7d"), null },
                    { new Guid("249241ad-91b6-4490-b65b-1f5654bcec13"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2259), new Guid("d9aa2403-1442-4622-b31d-45cf53c5746e"), null, null, new Guid("feebd82d-e26c-40f8-b00d-70574b23a288"), null },
                    { new Guid("a2f76b49-063f-4e61-8687-ec19e30e3d02"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2255), new Guid("ca49622e-c788-4bc1-89f3-52e620c1f220"), null, null, new Guid("16038a01-51b7-40a6-a8d3-f76c767bf240"), null }
                });

            migrationBuilder.InsertData(
                schema: "shop",
                table: "DiscountCriteria",
                columns: new[] { "Id", "CreatedTime", "Criterion", "DeletedTime", "DiscountAssignType", "DiscountId", "FilterOperator", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("33df01ec-8c26-46e3-a5d1-0d5576ca1497"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2185), "3574425b-a905-4591-ba8c-f5551a3c6efd", null, 40, new Guid("76d0c4af-2ae4-46da-97df-6e0db3b22fba"), 2, null },
                    { new Guid("4784ee61-8833-4488-9c16-d5c46a33134e"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2159), "16038a01-51b7-40a6-a8d3-f76c767bf240", null, 10, new Guid("5b21fdd1-3d87-461f-b1e4-8643e6dbd09b"), 1, null },
                    { new Guid("8f77bce9-4337-4fbe-8f3b-faa63c4f2d87"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2182), "100", null, 30, new Guid("6688e075-61c3-4532-8861-4a848f7b3ce9"), 4, null },
                    { new Guid("96336178-25f9-4f67-b3c3-35f6bde4e4ba"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2189), "3574425b-a905-4591-ba8c-f5551a3c6efd", null, 40, new Guid("d567b4dd-03fd-450e-bb95-84f0c8902368"), 2, null },
                    { new Guid("cd937daa-21f1-4e33-bed7-127524c3a9f2"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2178), "2", null, 20, new Guid("76d0c4af-2ae4-46da-97df-6e0db3b22fba"), 6, null },
                    { new Guid("d966e27e-cea0-47df-bcaa-4bad8b532dd2"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2192), "3574425b-a905-4591-ba8c-f5551a3c6efd", null, 40, new Guid("5b21fdd1-3d87-461f-b1e4-8643e6dbd09b"), 2, null },
                    { new Guid("e9169085-5ca1-451b-8ee1-efdcd8f94c08"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2174), "2abc20da-3e33-4e06-9e68-ea86247ddf7d", null, 10, new Guid("d567b4dd-03fd-450e-bb95-84f0c8902368"), 1, null }
                });

            migrationBuilder.InsertData(
                schema: "shop",
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedTime", "DeletedTime", "Name", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("1f1437a8-0c02-4be5-85f3-7fe5011a663d"), new Guid("36d0d944-3478-446b-8032-06bb6166599f"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2272), null, "Banana", null },
                    { new Guid("75d9dea7-a81b-4775-803a-ab29b88a2527"), new Guid("3574425b-a905-4591-ba8c-f5551a3c6efd"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2274), null, "Cigarette", null },
                    { new Guid("feb5afd5-861a-42fa-8784-dc62d63f9a52"), new Guid("3139afc7-9ce9-4b2d-b44d-87b89c981e38"), new DateTime(2023, 11, 29, 11, 7, 28, 657, DateTimeKind.Local).AddTicks(2270), null, "Beef", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRoleRelations_CustomerId",
                schema: "shop",
                table: "CustomerRoleRelations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRoleRelations_RoleId",
                schema: "shop",
                table: "CustomerRoleRelations",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCriteria_DiscountId",
                schema: "shop",
                table: "DiscountCriteria",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "shop",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerRoleRelations",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "DiscountCriteria",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "Discounts",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "shop");
        }
    }
}
