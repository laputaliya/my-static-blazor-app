using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class SalesOrderItem
    {
        [Key]
        public int Id { get; set; }
        
        public int SalesOrderId { get; set; }
        
        public virtual SalesOrder SalesOrder { get; set; }
        
        public int ProductId { get; set; }
        
        public virtual Product Product { get; set; }
        
        public decimal QuantityOrdered { get; set; }
        
        public decimal QuantityPicked { get; set; }
        
        public decimal QuantityShipped { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        public decimal LineTotal { get; set; }
        
        [StringLength(500)]
        public string Notes { get; set; }
    }
}