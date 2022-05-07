using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaoHongAcademy.Infrastructure.Data.Migrations
{
    public partial class AddCourseDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseDescription",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Course",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Course",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CourseDetail",
                columns: table => new
                {
                    CourseDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HtmlContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDetail", x => x.CourseDetailId);
                    table.ForeignKey(
                        name: "FK_CourseDetail_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetail_CourseId",
                table: "CourseDetail",
                column: "CourseId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDetail");

            migrationBuilder.DropColumn(
                name: "CourseDescription",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Course");
        }
    }
}
