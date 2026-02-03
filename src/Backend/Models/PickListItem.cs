using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class PickListItem
    {
        [Key]
        public int Id { get; set; }
        
        public int PickListId { get; set; }
        
        public virtual PickList PickList { get; set; }
        
        public int SalesOrderItemId { get; set; }
        
        public virtual SalesOrderItem SalesOrderItem { get; set; }
        
        public int ProductId { get; set; }
        
        public virtual Product Product { get; set; }
        
        public int LocationId { get; set; }
        
        public virtual Location Location { get; set; }
        
        public decimal QuantityToPick { get; set; }
        
        public decimal QuantityPicked { get; set; }
        
        public int Status { get; set; } // 1=Not Started, 2=In Progress, 3=Completed, 4=Shortage
        
        [StringLength(500)]
        public string Notes { get; set; }
    }
}