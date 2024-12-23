using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_Virtual.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBancodeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Livro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Editora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Emprestado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Curso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quant_Livros_Posse = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosLivros",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    Livro_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosLivros", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "UsuariosLivros");
        }
    }
}
