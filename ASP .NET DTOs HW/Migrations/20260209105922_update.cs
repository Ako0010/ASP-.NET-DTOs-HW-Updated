using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_.NET_DTOs_HW.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceRow_Invoices_InvoiceId",
                table: "InvoiceRow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceRow",
                table: "InvoiceRow");

            migrationBuilder.RenameTable(
                name: "InvoiceRow",
                newName: "InvoiceRows");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceRow_InvoiceId",
                table: "InvoiceRows",
                newName: "IX_InvoiceRows_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceRows",
                table: "InvoiceRows",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceRows_Invoices_InvoiceId",
                table: "InvoiceRows",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceRows_Invoices_InvoiceId",
                table: "InvoiceRows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceRows",
                table: "InvoiceRows");

            migrationBuilder.RenameTable(
                name: "InvoiceRows",
                newName: "InvoiceRow");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceRows_InvoiceId",
                table: "InvoiceRow",
                newName: "IX_InvoiceRow_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceRow",
                table: "InvoiceRow",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceRow_Invoices_InvoiceId",
                table: "InvoiceRow",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
