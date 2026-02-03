using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class Delivery
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string DeliveryNumber { get; set; }
        
        public int SalesOrderId { get; set; }
        
        public virtual SalesOrder SalesOrder { get; set; }
        
        public DateTime DeliveryDate { get; set; }
        
        public int DeliveredById { get; set; }
        
        public virtual User DeliveredBy { get; set; }
        
        public int DriverId { get; set; }
        
        public virtual User Driver { get; set; }
        
        public int VehicleId { get; set; }
        
        public virtual Vehicle Vehicle { get; set; }
        
        public decimal TotalAmount { get; set; }
        
        public int Status { get; set; } // 1=Assigned, 2=In Transit, 3=Delivered, 4=Failed, 5=Cancelled
        
        [StringLength(500)]
        public string Notes { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        public virtual ICollection<DeliveryItem> DeliveryItems { get; set; }
    }
}