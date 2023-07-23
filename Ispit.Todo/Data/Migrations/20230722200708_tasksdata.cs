using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispit.Todo.Data.Migrations
{
    public partial class tasksdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "Description", "IsCompleted", "Title", "TodoId", "TodoListId" },
                values: new object[] { 1, "Upoznavanje s našim proizvodnim programom, sklapanje novih poslova", true, "Sastanak s kupcima", 0, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
