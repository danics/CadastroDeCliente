using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroDeClientes.Data.Migrations
{
    public partial class AddValueObjectTelefone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelefoneNumero",
                table: "Clientes",
                newName: "Telefone_TelefoneNumero");

            migrationBuilder.RenameColumn(
                name: "TelefoneDDD",
                table: "Clientes",
                newName: "Telefone_DDD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone_TelefoneNumero",
                table: "Clientes",
                newName: "TelefoneNumero");

            migrationBuilder.RenameColumn(
                name: "Telefone_DDD",
                table: "Clientes",
                newName: "TelefoneDDD");
        }
    }
}
