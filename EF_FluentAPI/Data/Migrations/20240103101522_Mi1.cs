using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_FluentAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mi1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID_ONE = table.Column<int>(type: "int", nullable: false),
                    ID_TWO = table.Column<int>(type: "int", nullable: false),
                    STUDENT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForeignToSchool = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => new { x.ID_ONE, x.ID_TWO });
                    table.ForeignKey(
                        name: "FK_Students_Schools_ForeignToSchool",
                        column: x => x.ForeignToSchool,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ForeignToSchool",
                table: "Students",
                column: "ForeignToSchool");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
