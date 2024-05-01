using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyPlayerOne.Models
{
    public class Alignment
    {
        public string AlignmentID { get; set; } = string.Empty;
        public string AlignmentType { get; set; } = string.Empty;
    }
}
