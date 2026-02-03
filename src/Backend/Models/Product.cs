using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; }
        
        [StringLength(50)]
        public string SKU { get; set; }
        
        [StringLength(50)]
        public string Barcode { get; set; }
        
        public decimal Price { get; set; }
        
        public decimal Cost { get; set; }
        
        public int CategoryId { get; set; }
        
        public virtual ProductCategory Category { get; set; }
        
        public int UnitOfMeasureId { get; set; }
        
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}