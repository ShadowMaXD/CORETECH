using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogDatas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "Код")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Имя продукта"),
                    IsHit = table.Column<bool>(type: "bit", nullable: false, comment: "IsHit"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Имя продукта"),
                    FpsNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "FPS На главной"),
                    FpsBarWidth = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "FPS прогресс"),
                    FpsModalSerialized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpu = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Процессор"),
                    Gpu = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Графическая карта"),
                    Ram = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Оперативка"),
                    StatusClass = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Статус"),
                    StatusText = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Текст статуса"),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Стоимость"),
                    SpecsModalSerialized = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogDatas", x => x.ID);
                },
                comment: "Продукты каталога");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogDatas");
        }
    }
}
