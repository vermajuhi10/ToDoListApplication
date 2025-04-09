using Microsoft.EntityFrameworkCore;

namespace ToDoListApplication.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        public DbSet<ToDo> ToDoItems { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().HasKey(t => t.Id);
            modelBuilder.Entity<ToDo>().Property(t => t.Title).IsRequired();
            modelBuilder.Entity<ToDo>().Property(t => t.Description).IsRequired(false);
            modelBuilder.Entity<ToDo>().Property(t => t.DueDate).IsRequired(false);
            modelBuilder.Entity<ToDo>().Property(t => t.IsCompleted);
        }

    }
}
