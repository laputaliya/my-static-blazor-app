using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class PickList
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string PickListNumber { get; set; }
        
        public int SalesOrderId { get; set; }
        
        public virtual SalesOrder SalesOrder { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public int PickedById { get; set; }
        
        public virtual User PickedBy { get; set; }
        
        public int Status { get; set; } // 1=Created, 2=Assigned, 3=In Progress, 4=Completed, 5=Cancelled
        
        [StringLength(500)]
        public string Notes { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        public virtual ICollection<PickListItem> PickListItems { get; set; }
    }
}