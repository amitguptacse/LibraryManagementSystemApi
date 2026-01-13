using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystemApi.Migrations
{
    /// <inheritdoc />
    public partial class AddReturnRemark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Remark",
                table: "BookTransactions",
                newName: "ReturnRemark");

            migrationBuilder.AddColumn<string>(
                name: "IssueRemark",
                table: "BookTransactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueRemark",
                table: "BookTransactions");

            migrationBuilder.RenameColumn(
                name: "ReturnRemark",
                table: "BookTransactions",
                newName: "Remark");
        }
    }
}
