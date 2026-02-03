using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        
        public int ProductId { get; set; }
        
        public virtual Product Product { get; set; }
        
        public int LocationId { get; set; }
        
        public virtual Location Location { get; set; }
        
        public int WarehouseId { get; set; }
        
        public virtual Warehouse Warehouse { get; set; }
        
        public decimal QuantityOnHand { get; set; }
        
        public decimal QuantityAvailable { get; set; }
        
        public decimal QuantityReserved { get; set; }
        
        public decimal QuantityInTransit { get; set; }
        
        public decimal MinimumStockLevel { get; set; }
        
        public decimal MaximumStockLevel { get; set; }
        
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}