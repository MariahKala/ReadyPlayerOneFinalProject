using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyPlayerOne.Models
{
    public class Player
    {
        public int PlayerID { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string PlayerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please choose a class.")]
        public string Class { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Health score.")]
        public string Health { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Strength score.")]
        public string Strength { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the player's intelligence.")]
        public string Intelligence { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the player's Stamina.")]
        public string Stamina { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the player's Stealth.")]
        public string Stealth { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Luck score.")]
        public string Luck { get; set; } = string.Empty;

        // PlayerImage is its own class so I can pull the images easier.
        [ForeignKey("PlayerImage")]
        public string PlayerImageID { get; set; } = string.Empty;
        public PlayerImage? PlayerImage { get; set; }

        // Alignment as its own class for filtering and favorites.
        [ForeignKey("Alignment")]
        public string AlignmentID { get; set; } = string.Empty;
        public Alignment? Alignment { get; set; }
    }
}
