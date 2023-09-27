using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddforignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSubjects_Departments_DID",
                table: "DepartmentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSubjects_Subjects_SubID",
                table: "DepartmentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_InsSubjects_Instructors_InsId",
                table: "InsSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_InsSubjects_Subjects_SubId",
                table: "InsSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudID",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Subjects_SubID",
                table: "StudentSubjects");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSubjects_Departments_DID",
                table: "DepartmentSubjects",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSubjects_Subjects_SubID",
                table: "DepartmentSubjects",
                column: "SubID",
                principalTable: "Subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsSubjects_Instructors_InsId",
                table: "InsSubjects",
                column: "InsId",
                principalTable: "Instructors",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsSubjects_Subjects_SubId",
                table: "InsSubjects",
                column: "SubId",
                principalTable: "Subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudID",
                table: "StudentSubjects",
                column: "StudID",
                principalTable: "Students",
                principalColumn: "StudID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Subjects_SubID",
                table: "StudentSubjects",
                column: "SubID",
                principalTable: "Subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSubjects_Departments_DID",
                table: "DepartmentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSubjects_Subjects_SubID",
                table: "DepartmentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_InsSubjects_Instructors_InsId",
                table: "InsSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_InsSubjects_Subjects_SubId",
                table: "InsSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudID",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Subjects_SubID",
                table: "StudentSubjects");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSubjects_Departments_DID",
                table: "DepartmentSubjects",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSubjects_Subjects_SubID",
                table: "DepartmentSubjects",
                column: "SubID",
                principalTable: "Subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsSubjects_Instructors_InsId",
                table: "InsSubjects",
                column: "InsId",
                principalTable: "Instructors",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsSubjects_Subjects_SubId",
                table: "InsSubjects",
                column: "SubId",
                principalTable: "Subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudID",
                table: "StudentSubjects",
                column: "StudID",
                principalTable: "Students",
                principalColumn: "StudID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Subjects_SubID",
                table: "StudentSubjects",
                column: "SubID",
                principalTable: "Subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
