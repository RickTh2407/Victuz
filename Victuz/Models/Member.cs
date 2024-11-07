using System.ComponentModel.DataAnnotations;

namespace Victuz.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ScreenName { get; set; }
        public string Password { get; set; }
        public bool Board { get; set; }
        public bool Validated { get; set; }
        public virtual ICollection<Proposition> Propositions { get; set; }  
        public virtual ICollection<Activity> Activitys { get; set; }


    }
}
