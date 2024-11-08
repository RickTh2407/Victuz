using System.ComponentModel.DataAnnotations;

namespace Victuz.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<Member>? Members { get; set; }
    }
}
