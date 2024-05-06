using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacultyStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacultyStudents_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
				
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Son', 'Duong Hoang', '1999-01-28 00:00:00.0000000')");
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Duong', 'Hoang Van', '1999-01-28 00:00:00.0000000')");
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Quan', 'Le Hong', '1999-01-28 00:00:00.0000000')");
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Trang', 'Doan Thi Thu', '1999-01-28 00:00:00.0000000')");
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Huong', 'Nguyen Quang', '1999-01-28 00:00:00.0000000')");
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Tram', 'Mai Ngoc', '1999-01-28 00:00:00.0000000')");
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Lien', 'Le Thi', '1999-01-28 00:00:00.0000000')");
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Mai', 'Ta Thi Thanh', '1999-01-28 00:00:00.0000000')");
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Dung', 'Hoang Thi', '1999-01-28 00:00:00.0000000')");
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Anh', 'Tran Phuong', '1999-01-28 00:00:00.0000000')");
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Thiem', 'Le Van', '1999-01-28 00:00:00.0000000')");
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Hoang', 'Nguyen Tu', '1999-01-28 00:00:00.0000000')");
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Chung', 'Le Thi', '1999-01-28 00:00:00.0000000')");
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Dat', 'Khuat Tien', '1999-01-28 00:00:00.0000000')");
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Trung', 'Luu Viet', '1999-01-28 00:00:00.0000000')");
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Vuong', 'Dinh Van', '1999-01-28 00:00:00.0000000')");
			migrationBuilder.Sql(@"insert into Students (FirstName, LastName, BornDate) values ('Thu', 'Nguyen Van', '1999-01-28 00:00:00.0000000')");
			
			migrationBuilder.Sql(@"insert into Faculties (Name, Abbreviation) values ('Khoa Toan-Tin', 'FAMI')");
			migrationBuilder.Sql(@"insert into Faculties (Name, Abbreviation) values ('Khoa CNTT&TT', 'SoICT')");
			migrationBuilder.Sql(@"insert into Faculties (Name, Abbreviation) values ('Khoa Dien-Dien tu', 'SET')");
			
			migrationBuilder.Sql(@"insert into FacultyStudents (FacultyId, StudentId) values (1, 1)");
			migrationBuilder.Sql(@"insert into FacultyStudents (FacultyId, StudentId) values (1, 2)");
			migrationBuilder.Sql(@"insert into FacultyStudents (FacultyId, StudentId) values (1, 3)");
			migrationBuilder.Sql(@"insert into FacultyStudents (FacultyId, StudentId) values (1, 4)");
			migrationBuilder.Sql(@"insert into FacultyStudents (FacultyId, StudentId) values (1, 5)");
			migrationBuilder.Sql(@"insert into FacultyStudents (FacultyId, StudentId) values (2, 6)");
			migrationBuilder.Sql(@"insert into FacultyStudents (FacultyId, StudentId) values (2, 7)");
			migrationBuilder.Sql(@"insert into FacultyStudents (FacultyId, StudentId) values (2, 8)");
			migrationBuilder.Sql(@"insert into FacultyStudents (FacultyId, StudentId) values (2, 9)");
			migrationBuilder.Sql(@"insert into FacultyStudents (FacultyId, StudentId) values (2, 10)");
			migrationBuilder.Sql(@"insert into FacultyStudents (FacultyId, StudentId) values (3, 11)");
			migrationBuilder.Sql(@"insert into FacultyStudents (FacultyId, StudentId) values (3, 12)");
			migrationBuilder.Sql(@"insert into FacultyStudents (FacultyId, StudentId) values (3, 13)");
			migrationBuilder.Sql(@"insert into FacultyStudents (FacultyId, StudentId) values (3, 14)");
			migrationBuilder.Sql(@"insert into FacultyStudents (FacultyId, StudentId) values (3, 15)");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyStudents_FacultyId",
                table: "FacultyStudents",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyStudents_StudentId",
                table: "FacultyStudents",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacultyStudents");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
