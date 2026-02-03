using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }
        
        [StringLength(100)]
        public string ContactPerson { get; set; }
        
        [StringLength(20)]
        public string Phone { get; set; }
        
        [StringLength(100)]
        public string Email { get; set; }
        
        [StringLength(500)]
        public string Address { get; set; }
        
        [StringLength(100)]
        public string City { get; set; }
        
        [StringLength(20)]
        public string PostalCode { get; set; }
        
        [StringLength(100)]
        public string Country { get; set; }
        
        public decimal CreditLimit { get; set; }
        
        public int CreditRating { get; set; } // 1-5 scale
        
        public int PaymentTermDays { get; set; }
        
        [StringLength(500)]
        public string Notes { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
    }
}