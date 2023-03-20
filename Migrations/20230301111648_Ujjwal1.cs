using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Migrations
{
    /// <inheritdoc />
    public partial class Ujjwal1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "UserInfo",
                type: "varchar(64)",
                unicode: false,
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "UserInfo",
                type: "VARCHAR(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldUnicode: false,
                oldMaxLength: 64,
                oldNullable: true);
        }
    }
}
