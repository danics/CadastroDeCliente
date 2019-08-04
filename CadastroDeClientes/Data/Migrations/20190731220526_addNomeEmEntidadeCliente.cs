using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroDeClientes.Data.Migrations
{
    public partial class addNomeEmEntidadeCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "Clientes",
                newName: "Nome_Sobrenome");

            migrationBuilder.RenameColumn(
                name: "PrimeiroNome",
                table: "Clientes",
                newName: "Nome_PrimeiroNome");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome_Sobrenome",
                table: "Clientes",
                newName: "Sobrenome");

            migrationBuilder.RenameColumn(
                name: "Nome_PrimeiroNome",
                table: "Clientes",
                newName: "PrimeiroNome");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
