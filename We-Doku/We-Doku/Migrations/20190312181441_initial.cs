using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace We_Doku.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameBoards",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Placed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameBoards", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GameSpaces",
                columns: table => new
                {
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    GameBoardID = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    Masked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSpaces", x => new { x.GameBoardID, x.X, x.Y });
                    table.ForeignKey(
                        name: "FK_GameSpaces_GameBoards_GameBoardID",
                        column: x => x.GameBoardID,
                        principalTable: "GameBoards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GameBoards",
                columns: new[] { "ID", "Placed" },
                values: new object[] { 1, 30 });

            migrationBuilder.InsertData(
                table: "GameSpaces",
                columns: new[] { "GameBoardID", "X", "Y", "Masked", "Value" },
                values: new object[,]
                {
                    { 1, 0, 0, false, 5 },
                    { 1, 3, 6, true, 5 },
                    { 1, 2, 6, true, 1 },
                    { 1, 1, 6, false, 6 },
                    { 1, 0, 6, true, 9 },
                    { 1, 8, 5, false, 6 },
                    { 1, 7, 5, true, 5 },
                    { 1, 6, 5, true, 8 },
                    { 1, 4, 6, true, 3 },
                    { 1, 5, 5, true, 4 },
                    { 1, 3, 5, true, 9 },
                    { 1, 2, 5, true, 3 },
                    { 1, 1, 5, true, 1 },
                    { 1, 0, 5, false, 7 },
                    { 1, 8, 4, false, 1 },
                    { 1, 7, 4, true, 9 },
                    { 1, 6, 4, true, 7 },
                    { 1, 4, 5, false, 2 },
                    { 1, 5, 6, true, 7 },
                    { 1, 6, 6, false, 2 },
                    { 1, 7, 6, false, 8 },
                    { 1, 6, 8, true, 1 },
                    { 1, 5, 8, true, 6 },
                    { 1, 4, 8, false, 8 },
                    { 1, 3, 8, true, 2 },
                    { 1, 2, 8, true, 5 },
                    { 1, 1, 8, true, 4 },
                    { 1, 0, 8, true, 3 },
                    { 1, 8, 7, false, 5 },
                    { 1, 7, 7, true, 3 },
                    { 1, 6, 7, true, 6 },
                    { 1, 5, 7, false, 9 },
                    { 1, 4, 7, false, 1 },
                    { 1, 3, 7, false, 4 },
                    { 1, 2, 7, true, 7 },
                    { 1, 1, 7, true, 8 },
                    { 1, 0, 7, true, 2 },
                    { 1, 8, 6, true, 4 },
                    { 1, 5, 4, false, 3 },
                    { 1, 7, 8, false, 7 },
                    { 1, 4, 4, true, 5 },
                    { 1, 2, 4, true, 6 },
                    { 1, 7, 1, true, 4 },
                    { 1, 6, 1, true, 3 },
                    { 1, 5, 1, false, 5 },
                    { 1, 4, 1, false, 9 },
                    { 1, 3, 1, false, 1 },
                    { 1, 2, 1, true, 2 },
                    { 1, 1, 1, true, 7 },
                    { 1, 8, 1, true, 8 },
                    { 1, 0, 1, false, 6 },
                    { 1, 7, 0, true, 1 },
                    { 1, 6, 0, true, 9 },
                    { 1, 5, 0, true, 8 },
                    { 1, 4, 0, false, 7 },
                    { 1, 3, 0, true, 6 },
                    { 1, 2, 0, true, 4 },
                    { 1, 1, 0, false, 3 },
                    { 1, 8, 0, true, 2 },
                    { 1, 0, 2, true, 1 },
                    { 1, 1, 2, false, 9 },
                    { 1, 2, 2, false, 8 },
                    { 1, 1, 4, true, 2 },
                    { 1, 0, 4, false, 4 },
                    { 1, 8, 3, false, 3 },
                    { 1, 7, 3, true, 2 },
                    { 1, 6, 3, true, 4 },
                    { 1, 5, 3, true, 1 },
                    { 1, 4, 3, false, 6 },
                    { 1, 3, 3, true, 7 },
                    { 1, 2, 3, true, 9 },
                    { 1, 1, 3, true, 5 },
                    { 1, 0, 3, false, 8 },
                    { 1, 8, 2, true, 7 },
                    { 1, 7, 2, false, 6 },
                    { 1, 6, 2, true, 5 },
                    { 1, 5, 2, true, 2 },
                    { 1, 4, 2, true, 4 },
                    { 1, 3, 2, true, 3 },
                    { 1, 3, 4, false, 8 },
                    { 1, 8, 8, false, 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameSpaces");

            migrationBuilder.DropTable(
                name: "GameBoards");
        }
    }
}
