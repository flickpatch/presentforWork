using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AOA.Migrations
{
    /// <inheritdoc />
    public partial class NewMIgration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_News_NewsId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_NewsId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "NewsId",
                table: "News");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewsId",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_NewsId",
                table: "News",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_News_NewsId",
                table: "News",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");
        }
    }
}
