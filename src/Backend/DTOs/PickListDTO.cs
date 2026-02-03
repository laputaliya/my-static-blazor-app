using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.DTOs
{
    public class PickListCreateDTO
    {
        [Required]
        public int SalesOrderId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [StringLength(500)]
        public string Notes { get; set; }
    }

    public class PickListUpdateDTO
    {
        public int PickedById { get; set; }

        public int Status { get; set; } // 1=Created, 2=Assigned, 3=In Progress, 4=Completed, 5=Cancelled
    }

    public class PickListResponseDTO
    {
        public int Id { get; set; }
        public string PickListNumber { get; set; }
        public int SalesOrderId { get; set; }
        public string SalesOrderNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PickedById { get; set; }
        public string PickedByName { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<PickListItemResponseDTO> Items { get; set; }
    }

    public class PickListItemCreateDTO
    {
        [Required]
        public int PickListId { get; set; }

        [Required]
        public int SalesOrderItemId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public decimal QuantityToPick { get; set; }
    }

    public class PickListItemUpdateDTO
    {
        [Required]
        public decimal QuantityPicked { get; set; }

        public int Status { get; set; } // 1=Not Started, 2=In Progress, 3=Completed, 4=Shortage
    }

    public class PickListItemResponseDTO
    {
        public int Id { get; set; }
        public int PickListId { get; set; }
        public int SalesOrderItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSKU { get; set; }
        public int LocationId { get; set; }
        public string LocationCode { get; set; }
        public decimal QuantityToPick { get; set; }
        public decimal QuantityPicked { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
        public string Notes { get; set; }
    }
}