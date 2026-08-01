using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BuySellBeater.api.Models
{
    public class Make
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = null!;
        public ICollection<Model> Models { get; set; } = null!;

        public Make()
        {
            Models = new Collection<Model>();
        }
    }
}