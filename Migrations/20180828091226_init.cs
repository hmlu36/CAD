using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CAD.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Created_Time = table.Column<DateTime>(nullable: false),
                    Modified_Time = table.Column<DateTime>(nullable: false),
                    Created_User = table.Column<string>(maxLength: 10, nullable: false),
                    Modified_User = table.Column<string>(maxLength: 10, nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identity_Role",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Created_Time = table.Column<DateTime>(nullable: false),
                    Modified_Time = table.Column<DateTime>(nullable: false),
                    Created_User = table.Column<string>(maxLength: 10, nullable: false),
                    Modified_User = table.Column<string>(maxLength: 10, nullable: false),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identity_User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Created_Time = table.Column<DateTime>(nullable: false),
                    Modified_Time = table.Column<DateTime>(nullable: false),
                    Created_User = table.Column<string>(maxLength: 10, nullable: false),
                    Modified_User = table.Column<string>(maxLength: 10, nullable: false),
                    Account = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(maxLength: 30, nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Identity_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Identity_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Identity_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Identity_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Identity_Role",
                columns: new[] { "Id", "Code", "Created_Time", "Created_User", "Description", "Modified_Time", "Modified_User" },
                values: new object[] { "67db9b4c-ad92-405f-b42b-016712b20dd3", "User", new DateTime(2018, 8, 28, 17, 12, 26, 373, DateTimeKind.Local), "DBO", "一般使用者", new DateTime(2018, 8, 28, 17, 12, 26, 373, DateTimeKind.Local), "DBO" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Identity_Role",
                columns: new[] { "Id", "Code", "Created_Time", "Created_User", "Description", "Modified_Time", "Modified_User" },
                values: new object[] { "75f3dca5-609b-4780-8f2c-517e3beff555", "Admin", new DateTime(2018, 8, 28, 17, 12, 26, 374, DateTimeKind.Local), "DBO", "系統管理員", new DateTime(2018, 8, 28, 17, 12, 26, 374, DateTimeKind.Local), "DBO" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Identity_User",
                columns: new[] { "Id", "Account", "Created_Time", "Created_User", "Email", "FirstName", "LastName", "Modified_Time", "Modified_User", "Name", "Password", "PasswordHash", "Status" },
                values: new object[] { "784fc512-e2c6-4217-a5eb-fcb977d3782e", "admin", new DateTime(2018, 8, 28, 17, 12, 26, 394, DateTimeKind.Local), "DBO", null, null, null, new DateTime(2018, 8, 28, 17, 12, 26, 394, DateTimeKind.Local), "DBO", "系統管理員", "123456", "AFvkjVazVBa0dxMw+/mO4kyWwHPa3tgyxDeyZFJiwgOn+ubt1iAegh/4QJWT5JIWZw==", "A" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Identity_User",
                columns: new[] { "Id", "Account", "Created_Time", "Created_User", "Email", "FirstName", "LastName", "Modified_Time", "Modified_User", "Name", "Password", "PasswordHash", "Status" },
                values: new object[] { "c757a82e-58da-4e37-8080-c8789da00a9e", "user", new DateTime(2018, 8, 28, 17, 12, 26, 405, DateTimeKind.Local), "DBO", null, null, null, new DateTime(2018, 8, 28, 17, 12, 26, 405, DateTimeKind.Local), "DBO", "測試帳號", "123456", "AKauHrBMNdyXiyk/OU78pTo0iliWhwMU0CXWvtByQqvQaUzheGqB5SugFfKDdR7prQ==", "A" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { "e9eec1d9-c823-41a0-8b8c-195f497a9d72", "67db9b4c-ad92-405f-b42b-016712b20dd3", "784fc512-e2c6-4217-a5eb-fcb977d3782e" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { "f3d5d57c-0582-4e3c-ba5f-54c7e277b56e", "67db9b4c-ad92-405f-b42b-016712b20dd3", "c757a82e-58da-4e37-8080-c8789da00a9e" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "dbo",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                schema: "dbo",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Identity_Role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Identity_User",
                schema: "dbo");
        }
    }
}
