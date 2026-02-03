using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class GoodsReceiptItem
    {
        [Key]
        public int Id { get; set; }
        
        public int GoodsReceiptId { get; set; }
        
        public virtual GoodsReceipt GoodsReceipt { get; set; }
        
        public int PurchaseOrderItemId { get; set; }
        
        public virtual PurchaseOrderItem PurchaseOrderItem { get; set; }
        
        public int ProductId { get; set; }
        
        public virtual Product Product { get; set; }
        
        public int LocationId { get; set; }
        
        public virtual Location Location { get; set; }
        
        public decimal QuantityReceived { get; set; }
        
        public decimal QuantityAccepted { get; set; }
        
        public decimal QuantityRejected { get; set; }
        
        [StringLength(500)]
        public string Notes { get; set; }
    }
}