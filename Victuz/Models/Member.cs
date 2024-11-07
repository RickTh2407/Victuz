using System.ComponentModel.DataAnnotations;

namespace Victuz.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Voornaam is verplicht.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Achternaam is verplicht.")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email is verplicht.")]
        [EmailAddress(ErrorMessage = "Alstublieft, gebruik een geldig email adres.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Wachtwoord is verplicht.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Gebruikersnaam is verplicht.")]
        public string ScreenName { get; set; }

        [Required]
        public bool Validated { get; set; } = false;

        [Required]
        public bool Board { get; set; } = false;

        public virtual ICollection<>
    }
}
