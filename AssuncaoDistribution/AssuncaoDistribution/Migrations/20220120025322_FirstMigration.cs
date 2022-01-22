using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssuncaoDistribution.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ContactCli = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Cep = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Uf = table.Column<string>(nullable: true),
                    CnpjOrCpf = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameProd = table.Column<string>(nullable: true),
                    Measures = table.Column<int>(nullable: false),
                    AmountProd = table.Column<int>(nullable: false),
                    PriceProd = table.Column<double>(nullable: false),
                    MeasuresId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CorporateName = table.Column<string>(nullable: true),
                    FantasyName = table.Column<string>(nullable: true),
                    CnpjOrCpfProv = table.Column<long>(nullable: false),
                    AddresProv = table.Column<string>(nullable: true),
                    DistrictProv = table.Column<string>(nullable: true),
                    CepProv = table.Column<int>(nullable: false),
                    CityProv = table.Column<string>(nullable: true),
                    PhoneProv = table.Column<int>(nullable: false),
                    Fax = table.Column<int>(nullable: false),
                    EmailProv = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Portage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOrder = table.Column<DateTime>(nullable: false),
                    PriceSale = table.Column<double>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PurchDate = table.Column<DateTime>(nullable: false),
                    PriceOrder = table.Column<double>(nullable: false),
                    ProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsOrderSales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AmountOrder = table.Column<int>(nullable: false),
                    PriceOrder = table.Column<double>(nullable: false),
                    ProdId = table.Column<int>(nullable: false),
                    SalesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsOrderSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsOrderSales_Products_ProdId",
                        column: x => x.ProdId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsOrderSales_SalesOrders_SalesId",
                        column: x => x.SalesId,
                        principalTable: "SalesOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    PriceItems = table.Column<double>(nullable: false),
                    PurchOrderId = table.Column<int>(nullable: false),
                    ProdId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_Products_ProdId",
                        column: x => x.ProdId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_PurchaseOrders_PurchOrderId",
                        column: x => x.PurchOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsOrderSales_ProdId",
                table: "ItemsOrderSales",
                column: "ProdId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsOrderSales_SalesId",
                table: "ItemsOrderSales",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_ProdId",
                table: "PurchaseOrderItems",
                column: "ProdId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_PurchOrderId",
                table: "PurchaseOrderItems",
                column: "PurchOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_ProviderId",
                table: "PurchaseOrders",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_ClientId",
                table: "SalesOrders",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsOrderSales");

            migrationBuilder.DropTable(
                name: "PurchaseOrderItems");

            migrationBuilder.DropTable(
                name: "SalesOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
