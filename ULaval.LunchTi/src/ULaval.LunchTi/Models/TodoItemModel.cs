using System.ComponentModel.DataAnnotations;

namespace ULaval.LunchTi.Models
{
    public class TodoItemModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public bool IsDone { get; set; }
    }
}
