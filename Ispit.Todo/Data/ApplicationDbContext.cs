using Ispit.Todo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Todo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TodoList> TodoList { get; set; }
        public DbSet<Tasks> Task { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TodoList>().HasData(
                new TodoList() { Id = 1, Title = "User1", UserId = "956969da-f85d-4a33-a4d1-001404c074a6" }
                );

            builder.Entity<Tasks>().HasData(
                new Tasks() { Id = 1, Title = "Sastanak s kupcima", Description = "Upoznavanje s našim proizvodnim programom, sklapanje novih poslova", IsCompleted = true }
                );

            base.OnModelCreating(builder);
        }
    }
}