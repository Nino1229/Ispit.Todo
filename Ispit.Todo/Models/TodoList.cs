namespace Ispit.Todo.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? UserId { get; set; }
        public List <Tasks>? Tasks { get; set; }
    }
}
