using System.ComponentModel.DataAnnotations;

namespace BuySellBeater.api.Models
{
        public class Model
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = null!;
        public Make Make { get; set; } = null!;
        public int MakeId { get; set; }
    }
}