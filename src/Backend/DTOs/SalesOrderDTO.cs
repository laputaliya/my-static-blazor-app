using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.DTOs
{
    public class SalesOrderCreateDTO
    {
        [Required]
        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public DateTime RequiredDate { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        [Required]
        public List<SalesOrderItemCreateDTO> Items { get; set; }
    }

    public class SalesOrderUpdateDTO
    {
        [Required]
        public int CustomerId { get; set; }

        public DateTime RequiredDate { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public int Status { get; set; } // 1=Pending, 2=Confirmed, 3=Picking, 4=Picked, 5=Packed, 6=Shipped, 7=Delivered, 8=Cancelled
    }

    public class SalesOrderResponseDTO
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Notes { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
        public int CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<SalesOrderItemResponseDTO> Items { get; set; }
    }

    public class SalesOrderItemCreateDTO
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal QuantityOrdered { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }

    public class SalesOrderItemUpdateDTO
    {
        [Required]
        public decimal QuantityOrdered { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }

    public class SalesOrderItemResponseDTO
    {
        public int Id { get; set; }
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSKU { get; set; }
        public decimal QuantityOrdered { get; set; }
        public decimal QuantityPicked { get; set; }
        public decimal QuantityShipped { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public string Notes { get; set; }
    }
}