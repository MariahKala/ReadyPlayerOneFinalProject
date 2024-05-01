using ReadyPlayerOne.Migrations;
using ReadyPlayerOne.Models;

namespace ReadyPlayerOne.Models
{
    public class PlayerViewModel
    {

        public string ActiveAlign { get; set; } = "all";
        public Player Player { get; set; } = new Player();
        public List<Player> Players { get; set; } = new List<Player>();
        public List<PlayerImage> PlayerImages { get; set; } = new List<PlayerImage>();
        public List<Alignment> Alignments { get; set; } = new List<Alignment>();

        // Add properties for individual parts of Player
        public int PlayerID { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string Health { get; set; } = string.Empty;
        public string Strength { get; set; } = string.Empty;
        public string Intelligence { get; set; } = string.Empty;
        public string Stamina { get; set; } = string.Empty;
        public string Stealth { get; set; } = string.Empty;
        public string Luck { get; set; } = string.Empty;

        // Add properties for individual parts of PlayerImage
        public string PlayerImageID { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        // Add any other properties you want from PlayerImage

        // Add properties for individual parts of Alignment
        public string AlignmentID { get; set; } = string.Empty;
        public string AlignmentType { get; set; } = string.Empty;

        // methods to help view determine active link
        public string CheckActiveAlign(string a) =>
            a.ToLower() == ActiveAlign.ToLower() ? "active" : "";

    }
}