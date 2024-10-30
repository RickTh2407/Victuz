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
        public bool Board { get; set; }
    }
}
