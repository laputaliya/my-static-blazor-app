using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; }
        
        public int SupplierId { get; set; }
        
        public virtual Supplier Supplier { get; set; }
        
        public DateTime OrderDate { get; set; }
        
        public DateTime ExpectedDeliveryDate { get; set; }
        
        public decimal TotalAmount { get; set; }
        
        [StringLength(500)]
        public string Notes { get; set; }
        
        public int Status { get; set; } // 1=Pending, 2=Confirmed, 3=PartiallyReceived, 4=Completed, 5=Cancelled
        
        public int CreatedById { get; set; }
        
        public virtual User CreatedBy { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        public virtual ICollection<PurchaseOrderItem> Items { get; set; }
        
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}