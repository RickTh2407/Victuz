using System.ComponentModel.DataAnnotations;

namespace Victuz.Models
{
    public class Status
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
