using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaferTurizm.DataAccess.Migrations
{
    public partial class CityAndRouteMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureCityId = table.Column<int>(type: "int", nullable: false),
                    ArrivalCityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Route_City_ArrivalCityId",
                        column: x => x.ArrivalCityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Route_City_DepartureCityId",
                        column: x => x.DepartureCityId,
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adana" },
                    { 6, "Ankara" },
                    { 7, "Antalya" },
                    { 16, "Bursa" },
                    { 34, "İstanbul" },
                    { 35, "İzmir" }
                });

            migrationBuilder.InsertData(
                table: "Route",
                columns: new[] { "Id", "ArrivalCityId", "DepartureCityId" },
                values: new object[,]
                {
                    { 1, 34, 35 },
                    { 2, 6, 34 },
                    { 3, 7, 34 },
                    { 4, 35, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Route_ArrivalCityId",
                table: "Route",
                column: "ArrivalCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_DepartureCityId",
                table: "Route",
                column: "DepartureCityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
