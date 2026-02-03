using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.DTOs
{
    public class ProductCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(50)]
        public string SKU { get; set; }

        [StringLength(50)]
        public string Barcode { get; set; }

        public decimal Price { get; set; }

        public decimal Cost { get; set; }

        public int CategoryId { get; set; }

        public int UnitOfMeasureId { get; set; }
    }

    public class ProductUpdateDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(50)]
        public string SKU { get; set; }

        [StringLength(50)]
        public string Barcode { get; set; }

        public decimal Price { get; set; }

        public decimal Cost { get; set; }

        public int CategoryId { get; set; }

        public int UnitOfMeasureId { get; set; }

        public bool IsActive { get; set; }
    }

    public class ProductResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int UnitOfMeasureId { get; set; }
        public string UnitOfMeasureName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}