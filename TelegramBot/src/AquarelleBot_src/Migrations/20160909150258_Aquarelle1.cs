using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AquarelleBot.Migrations
{
    public partial class Aquarelle1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RootobjectPhoneItems",
                columns: table => new
                {
                    RootobjectPhoneItemsId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Birthday = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Organization = table.Column<string>(nullable: true),
                    PhoneHandheld = table.Column<int>(nullable: true),
                    PhoneMobile = table.Column<string>(nullable: true),
                    PhoneStationary = table.Column<string>(nullable: true),
                    Service = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootobjectPhoneItems", x => x.RootobjectPhoneItemsId);
                });

            migrationBuilder.CreateTable(
                name: "StateModel",
                columns: table => new
                {
                    StateModelId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ChatId = table.Column<long>(nullable: false),
                    TextButon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateModel", x => x.StateModelId);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    PositionId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "TypeCompany",
                columns: table => new
                {
                    TypeCompanyId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCompany", x => x.TypeCompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Avatar = table.Column<byte>(nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FirsName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PositionId = table.Column<long>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Name = table.Column<string>(nullable: true),
                    TypeCompanyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Company_TypeCompany_TypeCompanyId",
                        column: x => x.TypeCompanyId,
                        principalTable: "TypeCompany",
                        principalColumn: "TypeCompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_TypeCompanyId",
                table: "Company",
                column: "TypeCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PositionId",
                table: "Person",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RootobjectPhoneItems");

            migrationBuilder.DropTable(
                name: "StateModel");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "TypeCompany");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
