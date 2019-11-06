using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreArchitecture.Database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.CreateTable(
                name: "CatogryItems",
                columns: table => new
                {
                    CatogryId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatogryItems", x => x.CatogryId);
                });

            migrationBuilder.CreateTable(
                name: "InventoryTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ItemName = table.Column<string>(nullable: false),
                    ItemDescription = table.Column<string>(nullable: true),
                    MaxNum = table.Column<int>(nullable: false),
                    MinNum = table.Column<int>(nullable: false),
                    IsExist = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "User",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Surname = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(maxLength: 300, nullable: true),
                    Login = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 500, nullable: true),
                    Salt = table.Column<string>(maxLength: 500, nullable: true),
                    Roles = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ItemInventory",
                schema: "User",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(nullable: false),
                    ItemName = table.Column<string>(nullable: false),
                    CreateDate = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    IsExist = table.Column<bool>(nullable: false),
                    MaxNum = table.Column<string>(nullable: false),
                    MinNum = table.Column<string>(nullable: false),
                    CatogryId = table.Column<string>(nullable: true),
                    CatogriesCatogryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInventory", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ItemInventory_CatogryItems_CatogriesCatogryId",
                        column: x => x.CatogriesCatogryId,
                        principalTable: "CatogryItems",
                        principalColumn: "CatogryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatogriesTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ItemsInventoryTableId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatogriesTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatogriesTable_InventoryTable_ItemsInventoryTableId",
                        column: x => x.ItemsInventoryTableId,
                        principalTable: "InventoryTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersLogs",
                schema: "User",
                columns: table => new
                {
                    UserLogId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    LogType = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLogs", x => x.UserLogId);
                    table.ForeignKey(
                        name: "FK_UsersLogs_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Users",
                columns: new[] { "UserId", "Roles", "Status", "Email", "Name", "Surname", "Login", "Password", "Salt" },
                values: new object[] { 1L, 3, 1, "administrator@administrator.com", "Administrator", "Administrator", "admin", "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=", "79005744-e69a-4b09-996b-08fe0b70cbb9" });

            migrationBuilder.CreateIndex(
                name: "IX_CatogriesTable_ItemsInventoryTableId",
                table: "CatogriesTable",
                column: "ItemsInventoryTableId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInventory_CatogriesCatogryId",
                schema: "User",
                table: "ItemInventory",
                column: "CatogriesCatogryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "User",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                schema: "User",
                table: "Users",
                column: "Login",
                unique: true,
                filter: "[Login] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLogs_UserId",
                schema: "User",
                table: "UsersLogs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatogriesTable");

            migrationBuilder.DropTable(
                name: "ItemInventory",
                schema: "User");

            migrationBuilder.DropTable(
                name: "UsersLogs",
                schema: "User");

            migrationBuilder.DropTable(
                name: "InventoryTable");

            migrationBuilder.DropTable(
                name: "CatogryItems");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "User");
        }
    }
}
