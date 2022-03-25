using Microsoft.EntityFrameworkCore.Migrations;

namespace ELaw.Migrations.EDb
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catchword_Lv1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Lv1 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catchword_Lv1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catchword_Lv2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Lv2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Catch1_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catchword_Lv2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catchword_Lv3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Lv3 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Catch2_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catchword_Lv3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catchword_Lv4",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Lv4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Catch3_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catchword_Lv4", x => x.Id);
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
                    Court_TypesId = table.Column<int>(type: "int", nullable: true),
                    JUDGE_NAME = table.Column<int>(type: "int", nullable: true),
                    Judge_NamesId = table.Column<int>(type: "int", nullable: true),
                    JUDGMENT_COUNTRY = table.Column<int>(type: "int", nullable: true),
                    Judgment_CountriesId = table.Column<int>(type: "int", nullable: true),
                    STATE = table.Column<int>(type: "int", nullable: true),
                    StatesId = table.Column<int>(type: "int", nullable: true),
                    JUDGMENT_LANGUAGE = table.Column<int>(type: "int", nullable: true),
                    Judgment_LanguagesId = table.Column<int>(type: "int", nullable: true),
                    CATCHWORD_LV1 = table.Column<int>(type: "int", nullable: true),
                    Catchword_Lv1Id = table.Column<int>(type: "int", nullable: true),
                    CATCHWORD_LV2 = table.Column<int>(type: "int", nullable: true),
                    Catchword_Lv2Id = table.Column<int>(type: "int", nullable: true),
                    CATCHWORD_LV3 = table.Column<int>(type: "int", nullable: true),
                    Catchword_Lv3Id = table.Column<int>(type: "int", nullable: true),
                    CATCHWORD_LV4 = table.Column<int>(type: "int", nullable: true),
                    Catchword_Lv4Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawReviews", x => x.LAWREVIEW_ID);
                    table.ForeignKey(
                        name: "FK_LawReviews_Catchword_Lv1_Catchword_Lv1Id",
                        column: x => x.Catchword_Lv1Id,
                        principalTable: "Catchword_Lv1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawReviews_Catchword_Lv2_Catchword_Lv2Id",
                        column: x => x.Catchword_Lv2Id,
                        principalTable: "Catchword_Lv2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawReviews_Catchword_Lv3_Catchword_Lv3Id",
                        column: x => x.Catchword_Lv3Id,
                        principalTable: "Catchword_Lv3",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawReviews_Catchword_Lv4_Catchword_Lv4Id",
                        column: x => x.Catchword_Lv4Id,
                        principalTable: "Catchword_Lv4",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawReviews_Court_Types_Court_TypesId",
                        column: x => x.Court_TypesId,
                        principalTable: "Court_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawReviews_Judge_Names_Judge_NamesId",
                        column: x => x.Judge_NamesId,
                        principalTable: "Judge_Names",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawReviews_Judgment_Countries_Judgment_CountriesId",
                        column: x => x.Judgment_CountriesId,
                        principalTable: "Judgment_Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawReviews_Judgment_Languages_Judgment_LanguagesId",
                        column: x => x.Judgment_LanguagesId,
                        principalTable: "Judgment_Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawReviews_States_StatesId",
                        column: x => x.StatesId,
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
                name: "IX_LawReviews_Catchword_Lv1Id",
                table: "LawReviews",
                column: "Catchword_Lv1Id");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_Catchword_Lv2Id",
                table: "LawReviews",
                column: "Catchword_Lv2Id");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_Catchword_Lv3Id",
                table: "LawReviews",
                column: "Catchword_Lv3Id");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_Catchword_Lv4Id",
                table: "LawReviews",
                column: "Catchword_Lv4Id");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_Court_TypesId",
                table: "LawReviews",
                column: "Court_TypesId");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_Judge_NamesId",
                table: "LawReviews",
                column: "Judge_NamesId");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_Judgment_CountriesId",
                table: "LawReviews",
                column: "Judgment_CountriesId");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_Judgment_LanguagesId",
                table: "LawReviews",
                column: "Judgment_LanguagesId");

            migrationBuilder.CreateIndex(
                name: "IX_LawReviews_StatesId",
                table: "LawReviews",
                column: "StatesId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferredCases_LAWREVIEW_ID",
                table: "ReferredCases",
                column: "LAWREVIEW_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ReferredLegislations_LAWREVIEW_ID",
                table: "ReferredLegislations",
                column: "LAWREVIEW_ID");
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
                name: "Catchword_Lv1");

            migrationBuilder.DropTable(
                name: "Catchword_Lv2");

            migrationBuilder.DropTable(
                name: "Catchword_Lv3");

            migrationBuilder.DropTable(
                name: "Catchword_Lv4");

            migrationBuilder.DropTable(
                name: "Court_Types");

            migrationBuilder.DropTable(
                name: "Judge_Names");

            migrationBuilder.DropTable(
                name: "Judgment_Countries");

            migrationBuilder.DropTable(
                name: "Judgment_Languages");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
