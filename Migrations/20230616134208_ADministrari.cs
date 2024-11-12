using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AOA.Migrations
{
    /// <inheritdoc />
    public partial class ADministrari : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_TypesOffer_TypeId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Events",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Events_TypeId",
                table: "Events",
                newName: "IX_Events_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_TypesOffer_CategoryID",
                table: "Events",
                column: "CategoryID",
                principalTable: "TypesOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_TypesOffer_CategoryID",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Events",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_CategoryID",
                table: "Events",
                newName: "IX_Events_TypeId");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_TypesOffer_TypeId",
                table: "Events",
                column: "TypeId",
                principalTable: "TypesOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
