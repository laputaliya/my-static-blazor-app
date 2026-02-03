using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class InventoryTransaction
    {
        [Key]
        public int Id { get; set; }
        
        public int ProductId { get; set; }
        
        public virtual Product Product { get; set; }
        
        public int LocationId { get; set; }
        
        public virtual Location Location { get; set; }
        
        public int WarehouseId { get; set; }
        
        public virtual Warehouse Warehouse { get; set; }
        
        public int TransactionTypeId { get; set; } // 1=Receipt, 2=Pick, 3=Transfer, 4=Adjustment, 5=Scrap
        
        public decimal QuantityChange { get; set; }
        
        public decimal QuantityBefore { get; set; }
        
        public decimal QuantityAfter { get; set; }
        
        public string ReferenceDocument { get; set; } // PO Number, SO Number, etc.
        
        public int UserId { get; set; }
        
        public virtual User User { get; set; }
        
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        
        [StringLength(500)]
        public string Notes { get; set; }
    }
}