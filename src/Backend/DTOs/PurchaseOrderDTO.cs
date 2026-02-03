using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.DTOs
{
    public class PurchaseOrderCreateDTO
    {
        [Required]
        public int SupplierId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public DateTime ExpectedDeliveryDate { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        [Required]
        public List<PurchaseOrderItemCreateDTO> Items { get; set; }
    }

    public class PurchaseOrderUpdateDTO
    {
        [Required]
        public int SupplierId { get; set; }

        public DateTime ExpectedDeliveryDate { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public int Status { get; set; } // 1=Pending, 2=Confirmed, 3=PartiallyReceived, 4=Completed, 5=Cancelled
    }

    public class PurchaseOrderResponseDTO
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Notes { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
        public int CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<PurchaseOrderItemResponseDTO> Items { get; set; }
    }

    public class PurchaseOrderItemCreateDTO
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal QuantityOrdered { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }

    public class PurchaseOrderItemUpdateDTO
    {
        [Required]
        public decimal QuantityOrdered { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }

    public class PurchaseOrderItemResponseDTO
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSKU { get; set; }
        public decimal QuantityOrdered { get; set; }
        public decimal QuantityReceived { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public string Notes { get; set; }
    }
}