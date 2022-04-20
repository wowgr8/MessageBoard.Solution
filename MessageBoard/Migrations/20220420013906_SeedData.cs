using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    To = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    From = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Pages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "From", "Pages", "Title", "To" },
                values: new object[,]
                {
                    { 1, "Filipe", 7, "Weekend Trip", "Woolly Mammoth" },
                    { 2, "Dan", 10, "Airbnb", "You" },
                    { 3, "Kimi", 2, "Class Schedule", "Shteve" },
                    { 4, "Stan", 4, "Pipes", "Shark" },
                    { 5, "Foolio", 22, "Binge Drinking 101", "Dinosaur" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
