using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Victuz.Models
{
    public class Proposition
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string MemberName { get; set; }
        public virtual Status Statuses { get; set; }
        public virtual Member Members { get; set; }

        [Required]
        public string StatusDisplay { get; set; } = "In behandeling";

        public void ChangeStatus()
        {

        }
    }
}
