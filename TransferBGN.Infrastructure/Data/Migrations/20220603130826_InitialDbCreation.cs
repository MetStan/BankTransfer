using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransferBGN.Infrastructure.Data.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountHolders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHolders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    BIC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeeTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentSystems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ibans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    IbanN = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: false),
                    AccountHolderId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    BankId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CurrencyId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ibans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ibans_AccountHolders_AccountHolderId",
                        column: x => x.AccountHolderId,
                        principalTable: "AccountHolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ibans_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ibans_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentOrders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    OrderingBankId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,3)", maxLength: 13, precision: 10, scale: 3, nullable: false),
                    ReasonForPayment = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    AdditionalComment = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    OrderingAccountHolderId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    OrderingAccountId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    BeneficiaryAccountHolderId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    BeneficiaryAccountId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    BeneficiaryBankId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    DateOfPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfSubmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentSystemId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    FeeTypeId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CurrencyId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentOrders_AccountHolders_BeneficiaryAccountHolderId",
                        column: x => x.BeneficiaryAccountHolderId,
                        principalTable: "AccountHolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentOrders_AccountHolders_OrderingAccountHolderId",
                        column: x => x.OrderingAccountHolderId,
                        principalTable: "AccountHolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentOrders_Banks_BeneficiaryBankId",
                        column: x => x.BeneficiaryBankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentOrders_Banks_OrderingBankId",
                        column: x => x.OrderingBankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentOrders_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentOrders_FeeTypes_FeeTypeId",
                        column: x => x.FeeTypeId,
                        principalTable: "FeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentOrders_Ibans_BeneficiaryAccountId",
                        column: x => x.BeneficiaryAccountId,
                        principalTable: "Ibans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentOrders_Ibans_OrderingAccountId",
                        column: x => x.OrderingAccountId,
                        principalTable: "Ibans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentOrders_PaymentSystems_PaymentSystemId",
                        column: x => x.PaymentSystemId,
                        principalTable: "PaymentSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ibans_AccountHolderId",
                table: "Ibans",
                column: "AccountHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Ibans_BankId",
                table: "Ibans",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Ibans_CurrencyId",
                table: "Ibans",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrders_BeneficiaryAccountHolderId",
                table: "PaymentOrders",
                column: "BeneficiaryAccountHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrders_BeneficiaryAccountId",
                table: "PaymentOrders",
                column: "BeneficiaryAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrders_BeneficiaryBankId",
                table: "PaymentOrders",
                column: "BeneficiaryBankId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrders_CurrencyId",
                table: "PaymentOrders",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrders_FeeTypeId",
                table: "PaymentOrders",
                column: "FeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrders_OrderingAccountHolderId",
                table: "PaymentOrders",
                column: "OrderingAccountHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrders_OrderingAccountId",
                table: "PaymentOrders",
                column: "OrderingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrders_OrderingBankId",
                table: "PaymentOrders",
                column: "OrderingBankId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrders_PaymentSystemId",
                table: "PaymentOrders",
                column: "PaymentSystemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentOrders");

            migrationBuilder.DropTable(
                name: "FeeTypes");

            migrationBuilder.DropTable(
                name: "Ibans");

            migrationBuilder.DropTable(
                name: "PaymentSystems");

            migrationBuilder.DropTable(
                name: "AccountHolders");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
