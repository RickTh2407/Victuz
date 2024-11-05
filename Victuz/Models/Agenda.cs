using System.ComponentModel.DataAnnotations;

namespace Victuz.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<Activity> Activities { get; set; }

    }
}
