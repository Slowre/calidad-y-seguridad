using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventario.Migrations
{
    /// <inheritdoc />
    public partial class fix_user_weather : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherForecasts_Usuarios_UserId",
                table: "WeatherForecasts");

            migrationBuilder.DropIndex(
                name: "IX_WeatherForecasts_UserId",
                table: "WeatherForecasts");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "WeatherForecasts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_UsuarioId",
                table: "WeatherForecasts",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherForecasts_Usuarios_UsuarioId",
                table: "WeatherForecasts",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherForecasts_Usuarios_UsuarioId",
                table: "WeatherForecasts");

            migrationBuilder.DropIndex(
                name: "IX_WeatherForecasts_UsuarioId",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "WeatherForecasts");

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
    }
}
