using Microsoft.EntityFrameworkCore.Migrations;

namespace UserProject.Data.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Companyname = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Suite = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    CatchPhrase = table.Column<string>(nullable: true),
                    BS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BS", "CatchPhrase", "City", "Companyname", "Email", "Latitude", "Longitude", "Name", "Password", "Phone", "Street", "Suite", "Username", "Website", "Zipcode" },
                values: new object[] { 1, "harness real-time e-markets", "Multi - layered client - server neural - net", "Gwenborough", "Romaguera-Crona", "Sincere@april.biz", "-37.3159", "81.1496", "Leanne Graham", "AQAAAAEAACcQAAAAEPp1r39mlMNrBouxYUXqOXLaihJ0NVJaDMiG1NrlTK4oXz6I6Ar4M6slhf8ChxCeUg==", "1-770-736-8031 x56442", "Kulas Light", "Apt. 556", "Bret", "hildegard.org", "92998-3874" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
