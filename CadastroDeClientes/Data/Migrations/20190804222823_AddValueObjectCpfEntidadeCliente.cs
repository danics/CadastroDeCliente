using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroDeClientes.Data.Migrations
{
    public partial class AddValueObjectCpfEntidadeCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Cpf_Numero",
                table: "Clientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf_Numero",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Clientes",
                nullable: false,
                defaultValue: "");
        }
    }
}
