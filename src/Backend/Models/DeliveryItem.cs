using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class DeliveryItem
    {
        [Key]
        public int Id { get; set; }
        
        public int DeliveryId { get; set; }
        
        public virtual Delivery Delivery { get; set; }
        
        public int ShipmentItemId { get; set; }
        
        public virtual ShipmentItem ShipmentItem { get; set; }
        
        public int ProductId { get; set; }
        
        public virtual Product Product { get; set; }
        
        public decimal QuantityDelivered { get; set; }
        
        [StringLength(500)]
        public string Notes { get; set; }
    }
}