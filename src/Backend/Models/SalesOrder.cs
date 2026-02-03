using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class SalesOrder
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; }
        
        public int CustomerId { get; set; }
        
        public virtual Customer Customer { get; set; }
        
        public DateTime OrderDate { get; set; }
        
        public DateTime RequiredDate { get; set; }
        
        public decimal TotalAmount { get; set; }
        
        [StringLength(500)]
        public string Notes { get; set; }
        
        public int Status { get; set; } // 1=Pending, 2=Confirmed, 3=Picking, 4=Picked, 5=Packed, 6=Shipped, 7=Delivered, 8=Cancelled
        
        public int CreatedById { get; set; }
        
        public virtual User CreatedBy { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        public virtual ICollection<SalesOrderItem> Items { get; set; }
        
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}