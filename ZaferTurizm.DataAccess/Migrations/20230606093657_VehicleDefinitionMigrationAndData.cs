using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaferTurizm.DataAccess.Migrations
{
    public partial class VehicleDefinitionMigrationAndData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    SeatCount = table.Column<int>(type: "int", nullable: false),
                    HasToilet = table.Column<bool>(type: "bit", nullable: false),
                    HasWifi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleDefinition_VehicleModel_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModel",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "VehicleDefinition",
                columns: new[] { "Id", "HasToilet", "HasWifi", "SeatCount", "VehicleModelId", "Year" },
                values: new object[] { 1, false, true, 48, 1, 2020 });

            migrationBuilder.InsertData(
                table: "VehicleDefinition",
                columns: new[] { "Id", "HasToilet", "HasWifi", "SeatCount", "VehicleModelId", "Year" },
                values: new object[] { 2, false, true, 48, 1, 2021 });

            migrationBuilder.InsertData(
                table: "VehicleDefinition",
                columns: new[] { "Id", "HasToilet", "HasWifi", "SeatCount", "VehicleModelId", "Year" },
                values: new object[] { 3, false, false, 52, 5, 2019 });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDefinition_VehicleModelId",
                table: "VehicleDefinition",
                column: "VehicleModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleDefinition");
        }
    }
}
