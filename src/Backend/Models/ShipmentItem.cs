using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class ShipmentItem
    {
        [Key]
        public int Id { get; set; }
        
        public int ShipmentId { get; set; }
        
        public virtual Shipment Shipment { get; set; }
        
        public int SalesOrderItemId { get; set; }
        
        public virtual SalesOrderItem SalesOrderItem { get; set; }
        
        public int ProductId { get; set; }
        
        public virtual Product Product { get; set; }
        
        public int LocationId { get; set; }
        
        public virtual Location Location { get; set; }
        
        public decimal QuantityShipped { get; set; }
        
        [StringLength(500)]
        public string Notes { get; set; }
    }
}