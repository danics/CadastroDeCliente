using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroDeClientes.Data.Migrations
{
    public partial class AddValueObjectEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "Clientes",
                newName: "Endereco_Cidade");

            migrationBuilder.RenameColumn(
                name: "Cep",
                table: "Clientes",
                newName: "Endereco_Cep");

            migrationBuilder.RenameColumn(
                name: "Bairro",
                table: "Clientes",
                newName: "Endereco_Bairro");

            migrationBuilder.RenameColumn(
                name: "EnderecoNumero",
                table: "Clientes",
                newName: "Endereco_Rua");

            migrationBuilder.AddColumn<int>(
                name: "Endereco_Numero",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco_Numero",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Endereco_Cidade",
                table: "Clientes",
                newName: "Cidade");

            migrationBuilder.RenameColumn(
                name: "Endereco_Cep",
                table: "Clientes",
                newName: "Cep");

            migrationBuilder.RenameColumn(
                name: "Endereco_Bairro",
                table: "Clientes",
                newName: "Bairro");

            migrationBuilder.RenameColumn(
                name: "Endereco_Rua",
                table: "Clientes",
                newName: "EnderecoNumero");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Clientes",
                nullable: true);
        }
    }
}
