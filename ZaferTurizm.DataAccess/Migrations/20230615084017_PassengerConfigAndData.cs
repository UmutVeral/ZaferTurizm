using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaferTurizm.DataAccess.Migrations
{
    public partial class PassengerConfigAndData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passenger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "varchar(15)", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Passenger",
                columns: new[] { "Id", "FirstName", "Gender", "IdentityNumber", "LastName" },
                values: new object[] { 1, "Tsubasa", (byte)2, "12345667874", "Ozora" });

            migrationBuilder.InsertData(
                table: "Passenger",
                columns: new[] { "Id", "FirstName", "Gender", "IdentityNumber", "LastName" },
                values: new object[] { 2, "Sanae", (byte)1, "8764873564", "Ozora" });

            migrationBuilder.InsertData(
                table: "Passenger",
                columns: new[] { "Id", "FirstName", "Gender", "IdentityNumber", "LastName" },
                values: new object[] { 3, "Taro", (byte)2, "3486384743", "Misaki" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passenger");
        }
    }
}
