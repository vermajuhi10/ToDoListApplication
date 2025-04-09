using System.ComponentModel.DataAnnotations;

namespace ToDoListApplication.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(30, ErrorMessage = "Title cannot be longer than 30 characters.")]
        public string? Title { get; set; }

        [StringLength(200, ErrorMessage = "Description cannot be longer than 200 characters.")]
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
