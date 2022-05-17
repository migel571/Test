using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromocodeFactory.Infrastructure.Migrations
{
    public partial class Promocode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    PartnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NumberIssuedPromoCode = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.PartnerId);
                });

            migrationBuilder.CreateTable(
                name: "Preference",
                columns: table => new
                {
                    PreferenceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preference", x => x.PreferenceId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleName = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "PartnerPromoCodeLimit",
                columns: table => new
                {
                    PartnerPromoCodeLimitId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CancelDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Limit = table.Column<int>(type: "integer", nullable: false),
                    PartnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerPromoCodeLimit", x => x.PartnerPromoCodeLimitId);
                    table.ForeignKey(
                        name: "FK_PartnerPromoCodeLimit_Partner_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partner",
                        principalColumn: "PartnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPreference",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PreferenceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPreference", x => new { x.PreferenceId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CustomerPreference_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPreference_Preference_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preference",
                        principalColumn: "PreferenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromoCode",
                columns: table => new
                {
                    PromoCodeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ServiceInfo = table.Column<string>(type: "text", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PartnerName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    PreferenceId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCode", x => x.PromoCodeId);
                    table.ForeignKey(
                        name: "FK_PromoCode_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromoCode_Preference_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preference",
                        principalColumn: "PreferenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppliedPromocodesCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPreference_CustomerId",
                table: "CustomerPreference",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RoleId",
                table: "Employee",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerPromoCodeLimit_PartnerId",
                table: "PartnerPromoCodeLimit",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCode_CustomerId",
                table: "PromoCode",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCode_PreferenceId",
                table: "PromoCode",
                column: "PreferenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerPreference");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "PartnerPromoCodeLimit");

            migrationBuilder.DropTable(
                name: "PromoCode");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Preference");
        }
    }
}
