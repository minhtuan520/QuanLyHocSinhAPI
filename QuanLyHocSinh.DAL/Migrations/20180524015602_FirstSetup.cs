using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuanLyHocSinh.DAL.Migrations
{
    public partial class FirstSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GRADELEVEL",
                columns: table => new
                {
                    GRADELEVELID = table.Column<double>(nullable: false),
                    NAME = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRADELEVEL", x => x.GRADELEVELID);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOLYEAR",
                columns: table => new
                {
                    SCHOOLYEARID = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    NAME = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOLYEAR", x => x.SCHOOLYEARID);
                });

            migrationBuilder.CreateTable(
                name: "SEMESTER",
                columns: table => new
                {
                    SEMESTERID = table.Column<double>(nullable: false),
                    COEFFICIENT = table.Column<double>(nullable: true),
                    NAME = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEMESTER", x => x.SEMESTERID);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT",
                columns: table => new
                {
                    MSHOCSINH = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    ADDRESS = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    BIRTHDAY = table.Column<DateTime>(type: "datetime", nullable: true),
                    NAME = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    PHONE = table.Column<string>(type: "char(12)", nullable: true),
                    SEX = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT", x => x.MSHOCSINH);
                });

            migrationBuilder.CreateTable(
                name: "SUBJECT",
                columns: table => new
                {
                    SUBJECTID = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    NAME = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBJECT", x => x.SUBJECTID);
                });

            migrationBuilder.CreateTable(
                name: "TYPEACCOUNT",
                columns: table => new
                {
                    IDTYPE = table.Column<double>(nullable: false),
                    NAME = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TYPEACCOUNT", x => x.IDTYPE);
                });

            migrationBuilder.CreateTable(
                name: "TYPERESULT",
                columns: table => new
                {
                    TYPERESULTID = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    NAME = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TYPERESULT", x => x.TYPERESULTID);
                });

            migrationBuilder.CreateTable(
                name: "CLASS",
                columns: table => new
                {
                    IDCLASS = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    GRADELEVELID = table.Column<double>(nullable: true),
                    NAME = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLASS", x => x.IDCLASS);
                    table.ForeignKey(
                        name: "FK_CLASS_GRADELEVEL",
                        column: x => x.GRADELEVELID,
                        principalTable: "GRADELEVEL",
                        principalColumn: "GRADELEVELID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TESTSCORES",
                columns: table => new
                {
                    SUBJECTID = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    SEMESTERID = table.Column<double>(nullable: false),
                    SCHOOLYEARID = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    MSHOCSINH = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    SCORE_15M = table.Column<double>(nullable: true),
                    SCORE_45M = table.Column<double>(nullable: true),
                    SCORE_5M = table.Column<double>(nullable: true),
                    SCORE_ENDYEAR = table.Column<double>(nullable: true),
                    SCORE_MIDYEAR = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TESTSCORES", x => new { x.SUBJECTID, x.SEMESTERID, x.SCHOOLYEARID, x.MSHOCSINH });
                    table.ForeignKey(
                        name: "FK_TESTSCORES_STUDENT",
                        column: x => x.MSHOCSINH,
                        principalTable: "STUDENT",
                        principalColumn: "MSHOCSINH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TESTSCORES_SCHOOLYEAR",
                        column: x => x.SCHOOLYEARID,
                        principalTable: "SCHOOLYEAR",
                        principalColumn: "SCHOOLYEARID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TESTSCORES_SEMESTER",
                        column: x => x.SEMESTERID,
                        principalTable: "SEMESTER",
                        principalColumn: "SEMESTERID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TESTSCORES_SUBJECT",
                        column: x => x.SUBJECTID,
                        principalTable: "SUBJECT",
                        principalColumn: "SUBJECTID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT",
                columns: table => new
                {
                    USERNAME = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    IDTYPE = table.Column<double>(nullable: true),
                    PASSWORD = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT", x => x.USERNAME);
                    table.ForeignKey(
                        name: "FK_ACCOUNT_TYPEACCOUNT",
                        column: x => x.IDTYPE,
                        principalTable: "TYPEACCOUNT",
                        principalColumn: "IDTYPE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LEARNINGOUTCOMES",
                columns: table => new
                {
                    LEARNINGOUTCOMESID = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    CONDUCT = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    GRADE = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    MEDIUMSCORE = table.Column<double>(nullable: true),
                    MSHOCSINH = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    SCHOOLYEARID = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    TYPERESULTID = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEARNINGOUTCOMES", x => x.LEARNINGOUTCOMESID);
                    table.ForeignKey(
                        name: "FK_LEARNINGOUTCOMES_STUDENT",
                        column: x => x.MSHOCSINH,
                        principalTable: "STUDENT",
                        principalColumn: "MSHOCSINH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LEARNINGOUTCOMES_SCHOOLYEAR",
                        column: x => x.SCHOOLYEARID,
                        principalTable: "SCHOOLYEAR",
                        principalColumn: "SCHOOLYEARID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LEARNINGOUTCOMES_TYPERESULT",
                        column: x => x.TYPERESULTID,
                        principalTable: "TYPERESULT",
                        principalColumn: "TYPERESULTID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STUDENTINCLASS",
                columns: table => new
                {
                    SCHOOLYEARID = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    IDCLASS = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    MSHOCSINH = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENTINCLASS", x => new { x.SCHOOLYEARID, x.IDCLASS, x.MSHOCSINH });
                    table.ForeignKey(
                        name: "FK_STUDENTINCLASS_CLASS",
                        column: x => x.IDCLASS,
                        principalTable: "CLASS",
                        principalColumn: "IDCLASS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__STUDENTIN__MSHOC__5AEE82B9",
                        column: x => x.MSHOCSINH,
                        principalTable: "STUDENT",
                        principalColumn: "MSHOCSINH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STUDENTINCLASS_SCHOOLYEAR",
                        column: x => x.SCHOOLYEARID,
                        principalTable: "SCHOOLYEAR",
                        principalColumn: "SCHOOLYEARID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "FK_TYPEACCOUNT_IN_ACCOUNT_FK",
                table: "ACCOUNT",
                column: "IDTYPE");

            migrationBuilder.CreateIndex(
                name: "FK_CLASS_IN_GRADELEVEL_FK",
                table: "CLASS",
                column: "GRADELEVELID");

            migrationBuilder.CreateIndex(
                name: "RELATIONSHIP_6_FK",
                table: "LEARNINGOUTCOMES",
                column: "MSHOCSINH");

            migrationBuilder.CreateIndex(
                name: "FK_FK",
                table: "LEARNINGOUTCOMES",
                column: "SCHOOLYEARID");

            migrationBuilder.CreateIndex(
                name: "FK_TR_IN_LO",
                table: "LEARNINGOUTCOMES",
                column: "TYPERESULTID");

            migrationBuilder.CreateIndex(
                name: "STUDENTINCLASS2_FK",
                table: "STUDENTINCLASS",
                column: "IDCLASS");

            migrationBuilder.CreateIndex(
                name: "STUDENTINCLASS3_FK",
                table: "STUDENTINCLASS",
                column: "MSHOCSINH");

            migrationBuilder.CreateIndex(
                name: "STUDENTINCLASS_FK",
                table: "STUDENTINCLASS",
                column: "SCHOOLYEARID");

            migrationBuilder.CreateIndex(
                name: "TESTSCORES4_FK",
                table: "TESTSCORES",
                column: "MSHOCSINH");

            migrationBuilder.CreateIndex(
                name: "TESTSCORES3_FK",
                table: "TESTSCORES",
                column: "SCHOOLYEARID");

            migrationBuilder.CreateIndex(
                name: "TESTSCORES2_FK",
                table: "TESTSCORES",
                column: "SEMESTERID");

            migrationBuilder.CreateIndex(
                name: "TESTSCORES_FK",
                table: "TESTSCORES",
                column: "SUBJECTID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACCOUNT");

            migrationBuilder.DropTable(
                name: "LEARNINGOUTCOMES");

            migrationBuilder.DropTable(
                name: "STUDENTINCLASS");

            migrationBuilder.DropTable(
                name: "TESTSCORES");

            migrationBuilder.DropTable(
                name: "TYPEACCOUNT");

            migrationBuilder.DropTable(
                name: "TYPERESULT");

            migrationBuilder.DropTable(
                name: "CLASS");

            migrationBuilder.DropTable(
                name: "STUDENT");

            migrationBuilder.DropTable(
                name: "SCHOOLYEAR");

            migrationBuilder.DropTable(
                name: "SEMESTER");

            migrationBuilder.DropTable(
                name: "SUBJECT");

            migrationBuilder.DropTable(
                name: "GRADELEVEL");
        }
    }
}
