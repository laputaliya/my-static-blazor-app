using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class Receipt
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string ReceiptNumber { get; set; }
        
        public int PurchaseOrderId { get; set; }
        
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        
        public DateTime ReceiptDate { get; set; }
        
        public int ReceivedById { get; set; }
        
        public virtual User ReceivedBy { get; set; }
        
        public decimal TotalAmount { get; set; }
        
        public int Status { get; set; } // 1=Partial, 2=Complete, 3=Rejected
        
        [StringLength(500)]
        public string Notes { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        public virtual ICollection<ReceiptItem> ReceiptItems { get; set; }
    }
}