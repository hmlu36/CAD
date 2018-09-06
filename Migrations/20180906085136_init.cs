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
                name: "Lesson",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Created_Time = table.Column<DateTime>(nullable: false),
                    Modified_Time = table.Column<DateTime>(nullable: false),
                    Created_User = table.Column<string>(maxLength: 10, nullable: false),
                    Modified_User = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teaching_Aid",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Created_Time = table.Column<DateTime>(nullable: false),
                    Modified_Time = table.Column<DateTime>(nullable: false),
                    Created_User = table.Column<string>(maxLength: 10, nullable: false),
                    Modified_User = table.Column<string>(maxLength: 10, nullable: false),
                    Seq = table.Column<string>(maxLength: 5, nullable: true),
                    Description = table.Column<string>(maxLength: 20, nullable: true),
                    FileName = table.Column<string>(maxLength: 30, nullable: false),
                    LessonId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teaching_Aid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teaching_Aid_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "dbo",
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teaching_Aid_LessonId",
                schema: "dbo",
                table: "Teaching_Aid",
                column: "LessonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teaching_Aid",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Lesson",
                schema: "dbo");
        }
    }
}
