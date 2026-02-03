using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.DTOs
{
    public class InventoryCreateDTO
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public int WarehouseId { get; set; }

        [Required]
        public decimal QuantityOnHand { get; set; }

        public decimal MinimumStockLevel { get; set; }

        public decimal MaximumStockLevel { get; set; }
    }

    public class InventoryUpdateDTO
    {
        [Required]
        public decimal QuantityOnHand { get; set; }

        public decimal MinimumStockLevel { get; set; }

        public decimal MaximumStockLevel { get; set; }
    }

    public class InventoryResponseDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int LocationId { get; set; }
        public string LocationCode { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public decimal QuantityOnHand { get; set; }
        public decimal QuantityAvailable { get; set; }
        public decimal QuantityReserved { get; set; }
        public decimal QuantityInTransit { get; set; }
        public decimal MinimumStockLevel { get; set; }
        public decimal MaximumStockLevel { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}