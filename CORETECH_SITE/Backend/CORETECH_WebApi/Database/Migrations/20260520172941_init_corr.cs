using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class init_corr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpecsModalSerialized",
                table: "CatalogDatas",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Сериализованное модальное окно",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FpsModalSerialized",
                table: "CatalogDatas",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Сериализованное FPS модальное окно",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Flag_Del",
                table: "CatalogDatas",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Флаг удалено");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Flag_Del",
                table: "CatalogDatas");

            migrationBuilder.AlterColumn<string>(
                name: "SpecsModalSerialized",
                table: "CatalogDatas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Сериализованное модальное окно");

            migrationBuilder.AlterColumn<string>(
                name: "FpsModalSerialized",
                table: "CatalogDatas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Сериализованное FPS модальное окно");
        }
    }
}
