using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; }
        
        public int? ParentCategoryId { get; set; }
        
        public virtual ProductCategory ParentCategory { get; set; }
        
        public virtual ICollection<ProductCategory> SubCategories { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}