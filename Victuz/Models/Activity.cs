using System.ComponentModel.DataAnnotations;

namespace Victuz.Models
{
    public class Activity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public List<Member> Members { get; set; }

        public void AddToPlanner()
        {

        }
    } 
}
