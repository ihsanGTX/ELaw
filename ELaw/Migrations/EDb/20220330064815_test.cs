using Microsoft.EntityFrameworkCore.Migrations;

namespace ELaw.Migrations.EDb
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catchword_Lv1s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catchword_Lv1s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Court_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Court_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Judge_Names",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judge_Names", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Judgment_Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judgment_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Judgment_Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judgment_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catchword_Lv2s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Catch1_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catchword_Lv2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catchword_Lv2s_Catchword_Lv1s_Catch1_Id",
                        column: x => x.Catch1_Id,
                        principalTable: "Catchword_Lv1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Judgment_Country_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Judgment_Countries_Judgment_Country_Id",
                        column: x => x.Judgment_Country_Id,
                        principalTable: "Judgment_Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catchword_Lv3s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Catch2_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catchword_Lv3s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catchword_Lv3s_Catchword_Lv2s_Catch2_Id",
                        column: x => x.Catch2_Id,
                        principalTable: "Catchword_Lv2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catchword_Lv4s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Catch3_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catchword_Lv4s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catchword_Lv4s_Catchword_Lv3s_Catch3_Id",
                        column: x => x.Catch3_Id,
                        principalTable: "Catchword_Lv3s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LawReviews",
                columns: table => new
                {
                    LAWREVIEW_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JUDGMENT_NAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    JUDGMENT_NAME_VERSUS = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    JUDGMENT_NAME_ADDITIONAL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    JUDGMENT_NUMBER = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    JUDGMENT_DATE = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    HEADNOTE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VERDICT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COURT_TYPE = table.Column<int>(type: "int", nullable: true),
                    JUDGE_NAME = table.Column<int>(type: "int", nullable: true),
                    JUDGMENT_COUNTRY = table.Column<int>(type: "int", nullable: true),
                    STATE = table.Column<int>(type: "int", nullable: true),
                    JUDGMENT_LANGUAGE = table.Column<int>(type: "int", nullable: true),
                    CATCHWORD_LV1 = table.Column<int>(type: "int", nullable: true),
                    CATCHWORD_LV2 = table.Column<int>(type: "int", nullable: true),
                    CATCHWORD_LV3 = table.Column<int>(type: "int", nullable: true),
                    CATCHWORD_LV4 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawReviews", x => x.LAWREVIEW_ID);
                    table.ForeignKey(
                        name: "FK_LawReviews_Catchword_Lv1s_CATCHWORD_LV1",
                        column: x => x.CATCHWORD_LV1,
                        principalTable: "Catchword_Lv1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawReviews_Catchword_Lv2s_CATCHWORD_LV2",
                        column: x => x.CATCHWORD_LV2,
                        principalTable: "Catchword_Lv2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawReviews_Catchword_Lv3s_CATCHWORD_LV3",
                        column: x => x.CATCHWORD_LV3,
                        principalTable: "Catchword_Lv3s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawReviews_Catchword_Lv4s_CATCHWORD_LV4",
                        column: x => x.CATCHWORD_LV4,
                        principalTable: "Catchword_Lv4s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawReviews_Court_Types_COURT_TYPE",
                        column: x => x.COURT_TYPE,
                        principalTable: "Court_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawReviews_Judge_Names_JUDGE_NAME",
                        column: x => x.JUDGE_NAME,
                        principalTable: "Judge_Names",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawReviews_Judgment_Countries_JUDGMENT_COUNTRY",
                        column: x => x.JUDGMENT_COUNTRY,
                        principalTable: "Judgment_Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawReviews_Judgment_Languages_JUDGMENT_LANGUAGE",
                        column: x => x.JUDGMENT_LANGUAGE,
                        principalTable: "Judgment_Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawReviews_States_STATE",
                        column: x => x.STATE,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReferredCases",
                columns: table => new
                {
                    REFERRED_CASES_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LAWREVIEW_ID = table.Column<int>(type: "int", nullable: false),
                    REFERRED_CASES = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferredCases", x => x.REFERRED_CASES_ID);
                    table.ForeignKey(
                        name: "FK_ReferredCases_LawReviews_LAWREVIEW_ID",
                        column: x => x.LAWREVIEW_ID,
                        principalTable: "LawReviews",
                        principalColumn: "LAWREVIEW_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferredLegislations",
                columns: table => new
                {
                    REFERRED_LEGISLATION_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LAWREVIEW_ID = table.Column<int>(type: "int", nullable: false),
                    REFERRED_LEGISLATIONS = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferredLegislations", x => x.REFERRED_LEGISLATION_ID);
                    table.ForeignKey(
                        name: "FK_ReferredLegislations_LawReviews_LAWREVIEW_ID",
                        column: x => x.LAWREVIEW_ID,
                        principalTable: "LawReviews",
                        principalColumn: "LAWREVIEW_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catchword_Lv2s_Catch1_Id",
                table: "Catchword_Lv2s",
                column: "Catch1_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Catchword_Lv3s_Catch2_Id",
                table: "Catchword_Lv3s",
                column: "Catch2_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Catchword_Lv4s_Catch3_Id",
                table: "Catchword_Lv4s",
                column: "Catch3_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_CATCHWORD_LV1",
                table: "LawReviews",
                column: "CATCHWORD_LV1");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_CATCHWORD_LV2",
                table: "LawReviews",
                column: "CATCHWORD_LV2");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_CATCHWORD_LV3",
                table: "LawReviews",
                column: "CATCHWORD_LV3");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_CATCHWORD_LV4",
                table: "LawReviews",
                column: "CATCHWORD_LV4");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_COURT_TYPE",
                table: "LawReviews",
                column: "COURT_TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_JUDGE_NAME",
                table: "LawReviews",
                column: "JUDGE_NAME");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_JUDGMENT_COUNTRY",
                table: "LawReviews",
                column: "JUDGMENT_COUNTRY");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_JUDGMENT_LANGUAGE",
                table: "LawReviews",
                column: "JUDGMENT_LANGUAGE");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_STATE",
                table: "LawReviews",
                column: "STATE");

            migrationBuilder.CreateIndex(
                name: "IX_ReferredCases_LAWREVIEW_ID",
                table: "ReferredCases",
                column: "LAWREVIEW_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ReferredLegislations_LAWREVIEW_ID",
                table: "ReferredLegislations",
                column: "LAWREVIEW_ID");

            migrationBuilder.CreateIndex(
                name: "IX_States_Judgment_Country_Id",
                table: "States",
                column: "Judgment_Country_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReferredCases");

            migrationBuilder.DropTable(
                name: "ReferredLegislations");

            migrationBuilder.DropTable(
                name: "LawReviews");

            migrationBuilder.DropTable(
                name: "Catchword_Lv4s");

            migrationBuilder.DropTable(
                name: "Court_Types");

            migrationBuilder.DropTable(
                name: "Judge_Names");

            migrationBuilder.DropTable(
                name: "Judgment_Languages");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Catchword_Lv3s");

            migrationBuilder.DropTable(
                name: "Judgment_Countries");

            migrationBuilder.DropTable(
                name: "Catchword_Lv2s");

            migrationBuilder.DropTable(
                name: "Catchword_Lv1s");
        }
    }
}
