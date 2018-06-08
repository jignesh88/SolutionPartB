using System;
using System.ComponentModel.DataAnnotations;
namespace SolutionPartB.Models
{
    public class GlossaryTermViewModel
    {
        
        public Guid GlossaryTermId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string Term { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(3000)]
        public string Defination { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
