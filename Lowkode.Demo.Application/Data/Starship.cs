using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lowkode.Demo.Application.Data
{
    public class Starship
    {
        [Required]
        [StringLength(16, ErrorMessage = "Identifier too long (16 character limit).")]        
        public string Identifier { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Primary Classification")]    
        public string Classification { get; set; }

        [Range(1, 100000, ErrorMessage = "Accommodation invalid (1-100000).")]
        public int MaximumAccommodation { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "This form disallows unapproved ships.")]
        [DisplayName("Engineering Approval")]    
        public bool IsValidatedDesign { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }
    }
}
