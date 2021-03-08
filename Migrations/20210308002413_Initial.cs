using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    password = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    firstName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    lastname = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    userPKID = table.Column<int>(type: "int", nullable: false),
                    checkingNumber = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    balance = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__accounts__userPK__3C69FB99",
                        column: x => x.userPKID,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_userPKID",
                table: "accounts",
                column: "userPKID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
