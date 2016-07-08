using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace br.com.engsoft.Data.Migrations
{
    public partial class _05072016 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidade_Cidade_Cidadecodigo_cidade",
                table: "Cidade");

            migrationBuilder.DropForeignKey(
                name: "FK_Frete_Cidade_codigo_cidade1",
                table: "Frete");

            migrationBuilder.DropForeignKey(
                name: "FK_Frete_Cliente_codigo_cliente1",
                table: "Frete");

            migrationBuilder.DropIndex(
                name: "IX_Frete_codigo_cidade1",
                table: "Frete");

            migrationBuilder.DropIndex(
                name: "IX_Frete_codigo_cliente1",
                table: "Frete");

            migrationBuilder.DropIndex(
                name: "IX_Cidade_Cidadecodigo_cidade",
                table: "Cidade");

            migrationBuilder.DropColumn(
                name: "codigo_cidade1",
                table: "Frete");

            migrationBuilder.DropColumn(
                name: "codigo_cliente1",
                table: "Frete");

            migrationBuilder.DropColumn(
                name: "Cidadecodigo_cidade",
                table: "Cidade");

            migrationBuilder.AddColumn<int>(
                name: "Cidadecodigo_cidade",
                table: "Frete",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Clientecodigo_cliente",
                table: "Frete",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Frete_Cidadecodigo_cidade",
                table: "Frete",
                column: "Cidadecodigo_cidade");

            migrationBuilder.CreateIndex(
                name: "IX_Frete_Clientecodigo_cliente",
                table: "Frete",
                column: "Clientecodigo_cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Frete_Cidade_Cidadecodigo_cidade",
                table: "Frete",
                column: "Cidadecodigo_cidade",
                principalTable: "Cidade",
                principalColumn: "codigo_cidade",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Frete_Cliente_Clientecodigo_cliente",
                table: "Frete",
                column: "Clientecodigo_cliente",
                principalTable: "Cliente",
                principalColumn: "codigo_cliente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Frete_Cidade_Cidadecodigo_cidade",
                table: "Frete");

            migrationBuilder.DropForeignKey(
                name: "FK_Frete_Cliente_Clientecodigo_cliente",
                table: "Frete");

            migrationBuilder.DropIndex(
                name: "IX_Frete_Cidadecodigo_cidade",
                table: "Frete");

            migrationBuilder.DropIndex(
                name: "IX_Frete_Clientecodigo_cliente",
                table: "Frete");

            migrationBuilder.DropColumn(
                name: "Cidadecodigo_cidade",
                table: "Frete");

            migrationBuilder.DropColumn(
                name: "Clientecodigo_cliente",
                table: "Frete");

            migrationBuilder.AddColumn<int>(
                name: "codigo_cidade1",
                table: "Frete",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "codigo_cliente1",
                table: "Frete",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Frete_codigo_cidade1",
                table: "Frete",
                column: "codigo_cidade1");

            migrationBuilder.CreateIndex(
                name: "IX_Frete_codigo_cliente1",
                table: "Frete",
                column: "codigo_cliente1");

            migrationBuilder.AddColumn<int>(
                name: "Cidadecodigo_cidade",
                table: "Cidade",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_Cidadecodigo_cidade",
                table: "Cidade",
                column: "Cidadecodigo_cidade");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidade_Cidade_Cidadecodigo_cidade",
                table: "Cidade",
                column: "Cidadecodigo_cidade",
                principalTable: "Cidade",
                principalColumn: "codigo_cidade",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Frete_Cidade_codigo_cidade1",
                table: "Frete",
                column: "codigo_cidade1",
                principalTable: "Cidade",
                principalColumn: "codigo_cidade",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Frete_Cliente_codigo_cliente1",
                table: "Frete",
                column: "codigo_cliente1",
                principalTable: "Cliente",
                principalColumn: "codigo_cliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
