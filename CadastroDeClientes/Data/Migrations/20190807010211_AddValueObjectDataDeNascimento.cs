using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroDeClientes.Data.Migrations
{
    public partial class AddValueObjectDataDeNascimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDeNascimento",
                table: "Clientes",
                newName: "DataDeNascimento_DataNascimento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDeNascimento_DataNascimento",
                table: "Clientes",
                newName: "DataDeNascimento");
        }
    }
}
