using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class PurchaseOrderItem
    {
        [Key]
        public int Id { get; set; }
        
        public int PurchaseOrderId { get; set; }
        
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        
        public int ProductId { get; set; }
        
        public virtual Product Product { get; set; }
        
        public decimal QuantityOrdered { get; set; }
        
        public decimal QuantityReceived { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        public decimal LineTotal { get; set; }
        
        [StringLength(500)]
        public string Notes { get; set; }
    }
}