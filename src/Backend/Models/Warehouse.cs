using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; }
        
        [StringLength(500)]
        public string Address { get; set; }
        
        [StringLength(100)]
        public string City { get; set; }
        
        [StringLength(20)]
        public string PostalCode { get; set; }
        
        [StringLength(100)]
        public string Country { get; set; }
        
        [StringLength(20)]
        public string Phone { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        public virtual ICollection<Location> Locations { get; set; }
        
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}