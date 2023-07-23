using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispit.Todo.Data.Migrations
{
    public partial class tododata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TodoList",
                columns: new[] { "Id", "Title", "UserId" },
                values: new object[] { 1, "User1", "956969da-f85d-4a33-a4d1-001404c074a6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoList",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
