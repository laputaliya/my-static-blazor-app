using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string LicensePlate { get; set; }
        
        [StringLength(100)]
        public string Brand { get; set; }
        
        [StringLength(100)]
        public string Model { get; set; }
        
        public int Year { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; }
        
        public decimal Capacity { get; set; } // in cubic meters or kg
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}