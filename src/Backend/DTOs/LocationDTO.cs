using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.DTOs
{
    public class LocationCreateDTO
    {
        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public int WarehouseId { get; set; }

        [Required]
        public int LocationTypeId { get; set; }
    }

    public class LocationUpdateDTO
    {
        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public int LocationTypeId { get; set; }

        public bool IsActive { get; set; }
    }

    public class LocationResponseDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public int LocationTypeId { get; set; }
        public string LocationTypeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}