using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventario.Migrations
{
    /// <inheritdoc />
    public partial class Add_relation_with_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WeatherForecasts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_UserId",
                table: "WeatherForecasts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherForecasts_Usuarios_UserId",
                table: "WeatherForecasts",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherForecasts_Usuarios_UserId",
                table: "WeatherForecasts");

            migrationBuilder.DropIndex(
                name: "IX_WeatherForecasts_UserId",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WeatherForecasts");
        }
    }
}
