using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkForceManagement.Web.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    profile_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    profile_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.profile_id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    skillid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    skillname = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.skillid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    username = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    password = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    role = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    manager = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    wfm_manager = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "varchar", nullable: false),
                    lockstatus = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    experience = table.Column<decimal>(type: "decimal(5,0)", nullable: false),
                    profile_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_Employees_Profiles_profile_id",
                        column: x => x.profile_id,
                        principalTable: "Profiles",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skillmap",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    skillid = table.Column<int>(type: "int", nullable: false),
                    SkillmapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skillmap", x => new { x.employee_id, x.skillid });
                    table.ForeignKey(
                        name: "FK_Skillmap_Employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skillmap_Skills_skillid",
                        column: x => x.skillid,
                        principalTable: "Skills",
                        principalColumn: "skillid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Softlock",
                columns: table => new
                {
                    lockid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    manager = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    reqdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    lastupdated = table.Column<DateTime>(type: "datetime", nullable: false),
                    requestmessage = table.Column<string>(type: "varchar", nullable: false),
                    wfmremark = table.Column<string>(type: "varchar", nullable: false),
                    managerstatus = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, defaultValue: "awaiting_approval"),
                    mgrstatuscomment = table.Column<string>(type: "varchar", nullable: false),
                    mgrlastupdate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softlock", x => x.lockid);
                    table.ForeignKey(
                        name: "FK_Softlock_Employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_profile_id",
                table: "Employees",
                column: "profile_id");

            migrationBuilder.CreateIndex(
                name: "IX_Skillmap_skillid",
                table: "Skillmap",
                column: "skillid");

            migrationBuilder.CreateIndex(
                name: "IX_Softlock_employee_id",
                table: "Softlock",
                column: "employee_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skillmap");

            migrationBuilder.DropTable(
                name: "Softlock");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
