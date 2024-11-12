using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AOA.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TypesOffer",
                type: "varchar(54)",
                maxLength: 54,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TypesOffer",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(54)",
                oldMaxLength: 54)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
