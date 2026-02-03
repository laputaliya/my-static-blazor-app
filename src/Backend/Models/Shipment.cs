using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class Shipment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string ShipmentNumber { get; set; }
        
        public int SalesOrderId { get; set; }
        
        public virtual SalesOrder SalesOrder { get; set; }
        
        public DateTime ShipmentDate { get; set; }
        
        public int ShippedById { get; set; }
        
        public virtual User ShippedBy { get; set; }
        
        public decimal TotalAmount { get; set; }
        
        public int Status { get; set; } // 1=Packing, 2=ReadyToShip, 3=Shipped, 4=Delivered, 5=Cancelled
        
        [StringLength(500)]
        public string Notes { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        public virtual ICollection<ShipmentItem> ShipmentItems { get; set; }
    }
}