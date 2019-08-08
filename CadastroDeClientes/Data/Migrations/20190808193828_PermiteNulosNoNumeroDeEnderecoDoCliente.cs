using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroDeClientes.Data.Migrations
{
    public partial class PermiteNulosNoNumeroDeEnderecoDoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Endereco_Numero",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Endereco_Numero",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
