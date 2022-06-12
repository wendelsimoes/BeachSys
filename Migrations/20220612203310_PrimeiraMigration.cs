using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeachSys.Migrations
{
    public partial class PrimeiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    CPF = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Armarios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    PontoX = table.Column<int>(nullable: false),
                    PontoY = table.Column<int>(nullable: false),
                    CompartimentosDisponiveis = table.Column<int>(nullable: true),
                    AdminID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armarios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Armarios_Usuarios_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compartimentos",
                columns: table => new
                {
                    Numero = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Comprimento = table.Column<int>(nullable: false),
                    Largura = table.Column<int>(nullable: false),
                    Disponivel = table.Column<bool>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: true),
                    ArmarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compartimentos", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_Compartimentos_Armarios_ArmarioID",
                        column: x => x.ArmarioID,
                        principalTable: "Armarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compartimentos_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "ID", "CPF", "Discriminator", "Email", "Nome" },
                values: new object[] { 1, "admin", "Admin", "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Armarios_AdminID",
                table: "Armarios",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Compartimentos_ArmarioID",
                table: "Compartimentos",
                column: "ArmarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Compartimentos_UsuarioID",
                table: "Compartimentos",
                column: "UsuarioID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compartimentos");

            migrationBuilder.DropTable(
                name: "Armarios");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
