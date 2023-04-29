using System.ComponentModel.DataAnnotations;

namespace P2_2018UP601.Models
{
    public class CovidCase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int ReportedCases { get; set; }

        [Required]
        public int RecoveredCases { get; set; }

        [Required]
        public int ActiveCases { get; set; }
    }
}