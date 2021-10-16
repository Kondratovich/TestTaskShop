using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Store
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(20)]
        public string OperatingMode { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
