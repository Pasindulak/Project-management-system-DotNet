using System.ComponentModel.DataAnnotations;

namespace PMS_Net.Models
{
    public class Project
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

    }
}
