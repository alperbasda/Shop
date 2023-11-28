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
                name: "ExcludedCategoryDiscounts",
                schema: "shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcludedCategoryDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExcludedCategoryDiscounts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "shop",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExcludedCategoryDiscounts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalSchema: "shop",
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "DiscountRoleRelations",
                schema: "shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountRoleRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountRoleRelations_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalSchema: "shop",
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountRoleRelations_Roles_RoleId",
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
                    { new Guid("00dfc4fa-1551-4329-935b-1663783c2eac"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9678), null, "Grocery", null },
                    { new Guid("46ae4dc3-f9d9-4e64-bbcb-8362705f06dd"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9679), null, "Fruits & Vegatables", null },
                    { new Guid("f0a8c780-06db-4634-ae9e-51bb8cc486d1"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9680), null, "Meat & Fish", null }
                });

            migrationBuilder.InsertData(
                schema: "shop",
                table: "Customers",
                columns: new[] { "Id", "CreatedTime", "DeletedTime", "FirstName", "LastName", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("6efe7506-2a76-4eb2-a858-9d3872bcd8ed"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9648), null, "Employee", "Employee", null },
                    { new Guid("8f26e38e-7010-454e-94d7-629387e15303"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9651), null, "StardardAccount", "StardardAccount", null },
                    { new Guid("fd62308d-0b4d-493c-aa7b-d84d9bc41e9d"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9649), null, "Affiliate", "Affiliate", null }
                });

            migrationBuilder.InsertData(
                schema: "shop",
                table: "Discounts",
                columns: new[] { "Id", "CreatedTime", "DeletedTime", "DiscountUsageType", "Name", "UpdatedTime", "Value" },
                values: new object[,]
                {
                    { new Guid("26a9a19b-d72a-4c78-8a1b-2d7a76c96f5b"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9597), null, 20, "$5 Discount For every $100", null, 5m },
                    { new Guid("443cbfd1-86be-4b56-847b-f0828f3a9ff5"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9588), null, 10, "10% Discount", null, 10m },
                    { new Guid("b105e4c0-254c-47a5-abcf-8d0e1d7f0a90"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9590), null, 10, "5% Discount If Over 2 Year", null, 5m },
                    { new Guid("c5146d0b-2bbe-49b7-950f-174d5a89ccf8"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9584), null, 10, "30% Discount", null, 30m }
                });

            migrationBuilder.InsertData(
                schema: "shop",
                table: "Roles",
                columns: new[] { "Id", "CreatedTime", "DeletedTime", "Name", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("0a7d514c-14d4-4e41-b5e8-e5d77fb25e02"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9464), null, "Affiliate", null },
                    { new Guid("b444c280-bc89-4c10-8ba4-902d1b6bf0ee"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9453), null, "Employee", null },
                    { new Guid("b5c811d5-c122-4763-b0d6-4a6c30514c22"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9466), null, "StardardAccount", null }
                });

            migrationBuilder.InsertData(
                schema: "shop",
                table: "CustomerRoleRelations",
                columns: new[] { "Id", "CreatedTime", "CustomerId", "DeletedTime", "LastValidTime", "RoleId", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("1928e268-d8f6-47ba-8625-af88b708c74b"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9665), new Guid("fd62308d-0b4d-493c-aa7b-d84d9bc41e9d"), null, null, new Guid("0a7d514c-14d4-4e41-b5e8-e5d77fb25e02"), null },
                    { new Guid("897c77f7-92c4-43d6-a8aa-fcb0fb89ea6d"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9663), new Guid("6efe7506-2a76-4eb2-a858-9d3872bcd8ed"), null, null, new Guid("b444c280-bc89-4c10-8ba4-902d1b6bf0ee"), null },
                    { new Guid("f01bae81-5af7-4064-823f-2d96ab058c96"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9668), new Guid("8f26e38e-7010-454e-94d7-629387e15303"), null, null, new Guid("b5c811d5-c122-4763-b0d6-4a6c30514c22"), null }
                });

            migrationBuilder.InsertData(
                schema: "shop",
                table: "DiscountRoleRelations",
                columns: new[] { "Id", "CreatedTime", "DeletedTime", "DiscountId", "RoleId", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("8ea6454d-e69f-4cbd-aad6-91223c309381"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9612), null, new Guid("443cbfd1-86be-4b56-847b-f0828f3a9ff5"), new Guid("0a7d514c-14d4-4e41-b5e8-e5d77fb25e02"), null },
                    { new Guid("d3c91649-1f33-4e39-84de-12979cd83a29"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9610), null, new Guid("c5146d0b-2bbe-49b7-950f-174d5a89ccf8"), new Guid("b444c280-bc89-4c10-8ba4-902d1b6bf0ee"), null }
                });

            migrationBuilder.InsertData(
                schema: "shop",
                table: "ExcludedCategoryDiscounts",
                columns: new[] { "Id", "CategoryId", "CreatedTime", "DeletedTime", "DiscountId", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("54c0d4b7-3bd0-43c7-9be2-3b2f62a94f73"), new Guid("00dfc4fa-1551-4329-935b-1663783c2eac"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9841), null, new Guid("443cbfd1-86be-4b56-847b-f0828f3a9ff5"), null },
                    { new Guid("9d76e424-1c20-4c23-9c63-3ed7ce1a60ff"), new Guid("00dfc4fa-1551-4329-935b-1663783c2eac"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9836), null, new Guid("c5146d0b-2bbe-49b7-950f-174d5a89ccf8"), null },
                    { new Guid("a3780644-2238-4b27-a367-8b59183b2d89"), new Guid("00dfc4fa-1551-4329-935b-1663783c2eac"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9842), null, new Guid("b105e4c0-254c-47a5-abcf-8d0e1d7f0a90"), null }
                });

            migrationBuilder.InsertData(
                schema: "shop",
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedTime", "DeletedTime", "Name", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("5fe1dcbb-26cf-4d70-9aee-e5cf207070e1"), new Guid("00dfc4fa-1551-4329-935b-1663783c2eac"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9863), null, "Cigarette", null },
                    { new Guid("b1718dd9-be28-4202-9fe7-27033f1e48d4"), new Guid("46ae4dc3-f9d9-4e64-bbcb-8362705f06dd"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9861), null, "Banana", null },
                    { new Guid("fa3edd53-9d44-436b-af90-646b2dc19edb"), new Guid("f0a8c780-06db-4634-ae9e-51bb8cc486d1"), new DateTime(2023, 11, 28, 22, 51, 3, 30, DateTimeKind.Local).AddTicks(9856), null, "Beef", null }
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
                name: "IX_DiscountRoleRelations_DiscountId",
                schema: "shop",
                table: "DiscountRoleRelations",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountRoleRelations_RoleId",
                schema: "shop",
                table: "DiscountRoleRelations",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcludedCategoryDiscounts_CategoryId",
                schema: "shop",
                table: "ExcludedCategoryDiscounts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcludedCategoryDiscounts_DiscountId",
                schema: "shop",
                table: "ExcludedCategoryDiscounts",
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
                name: "DiscountRoleRelations",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "ExcludedCategoryDiscounts",
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
