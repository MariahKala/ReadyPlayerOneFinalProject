using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReadyPlayerOne.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alignments",
                columns: table => new
                {
                    AlignmentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AlignmentType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alignments", x => x.AlignmentID);
                });

            migrationBuilder.CreateTable(
                name: "PlayerImages",
                columns: table => new
                {
                    PlayerImageID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerImages", x => x.PlayerImageID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Health = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Intelligence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stamina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stealth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Luck = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerImageID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AlignmentID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Players_Alignments_AlignmentID",
                        column: x => x.AlignmentID,
                        principalTable: "Alignments",
                        principalColumn: "AlignmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_PlayerImages_PlayerImageID",
                        column: x => x.PlayerImageID,
                        principalTable: "PlayerImages",
                        principalColumn: "PlayerImageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alignments",
                columns: new[] { "AlignmentID", "AlignmentType" },
                values: new object[,]
                {
                    { "1", "Lawful Good" },
                    { "2", "Neutral Good" },
                    { "3", "Chaotic Good" },
                    { "4", "Lawful Neutral" },
                    { "5", "True Neutral" },
                    { "6", "Chaotic Neutral" },
                    { "7", "Lawful Evil" },
                    { "8", "Neutral Evil" },
                    { "9", "Chaotic Evil" }
                });

            migrationBuilder.InsertData(
                table: "PlayerImages",
                columns: new[] { "PlayerImageID", "Image" },
                values: new object[,]
                {
                    { "1", "BlondeElfMaleWarrior.jpg" },
                    { "10", "GreenFairy.jpg" },
                    { "11", "HumanBoyWithCloak.jpg" },
                    { "12", "HumanFemaleKnight.jpg" },
                    { "13", "HumanGirlWithCloak.jpg" },
                    { "14", "HumanMaleDruid.jpg" },
                    { "15", "MaleSeaCreature.jpg" },
                    { "16", "MaleWarriorInSilverArmor.jpg" },
                    { "17", "MaleWithFlowerCrown.jpg" },
                    { "18", "ManWithSkullArmor.jpg" },
                    { "19", "MermaidWithBlueHair.jpg" },
                    { "2", "BlondeWarlock.jpg" },
                    { "20", "OlderManHuman.jpg" },
                    { "21", "OlderManWarrior.jpg" },
                    { "22", "OldWomanMage.jpg" },
                    { "23", "OldWomanMage.jpg" },
                    { "24", "WomanWithWhiteHair.jpg" },
                    { "25", "YoungRogue.png" },
                    { "3", "BlondeWitch.jpg" },
                    { "4", "DarkHairedPriestess.jpg" },
                    { "5", "ElfFemaleFighter.jpg" },
                    { "6", "FemaleSamuraiWarrior.jpg" },
                    { "7", "FemaleWarriorInSilverArmor.jpg" },
                    { "8", "FemaleWaterCreature.jpg" },
                    { "9", "GoldenArcher.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerID", "AlignmentID", "Class", "Health", "Intelligence", "Luck", "PlayerImageID", "PlayerName", "Stamina", "Stealth", "Strength" },
                values: new object[,]
                {
                    { 1, "3", "Mage", "3", "9", "3", "3", "Esther Ulrick", "3", "6", "3" },
                    { 2, "3", "Warrior", "3", "3", "3", "3", "Rhiordan Tannick", "3", "3", "3" },
                    { 3, "3", "Rogue", "3", "3", "3", "3", "Bevil Starling", "3", "3", "3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_AlignmentID",
                table: "Players",
                column: "AlignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerImageID",
                table: "Players",
                column: "PlayerImageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Alignments");

            migrationBuilder.DropTable(
                name: "PlayerImages");
        }
    }
}
