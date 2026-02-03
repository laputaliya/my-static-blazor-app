using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarehouseManagement.DTOs;
using WarehouseManagement.Models;

namespace WarehouseManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetAllProductsAsync()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.UnitOfMeasure)
                .Where(p => p.IsActive)
                .Select(p => new ProductResponseDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    SKU = p.SKU,
                    Barcode = p.Barcode,
                    Price = p.Price,
                    Cost = p.Cost,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name,
                    UnitOfMeasureId = p.UnitOfMeasureId,
                    UnitOfMeasureName = p.UnitOfMeasure.Name,
                    IsActive = p.IsActive,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                })
                .ToListAsync();

            return products;
        }

        public async Task<ProductResponseDTO> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.UnitOfMeasure)
                .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);

            if (product == null)
                return null;

            return new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                SKU = product.SKU,
                Barcode = product.Barcode,
                Price = product.Price,
                Cost = product.Cost,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                UnitOfMeasureId = product.UnitOfMeasureId,
                UnitOfMeasureName = product.UnitOfMeasure.Name,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
        }

        public async Task<ProductResponseDTO> CreateProductAsync(ProductCreateDTO productDto)
        {
            // Check if SKU or Barcode already exists
            if (await _context.Products.AnyAsync(p => p.SKU == productDto.SKU))
                throw new ArgumentException("Product with this SKU already exists");

            if (!string.IsNullOrEmpty(productDto.Barcode) && await _context.Products.AnyAsync(p => p.Barcode == productDto.Barcode))
                throw new ArgumentException("Product with this Barcode already exists");

            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                SKU = productDto.SKU,
                Barcode = productDto.Barcode,
                Price = productDto.Price,
                Cost = productDto.Cost,
                CategoryId = productDto.CategoryId,
                UnitOfMeasureId = productDto.UnitOfMeasureId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // Return the created product
            var createdProduct = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.UnitOfMeasure)
                .FirstOrDefaultAsync(p => p.Id == product.Id);

            return new ProductResponseDTO
            {
                Id = createdProduct.Id,
                Name = createdProduct.Name,
                Description = createdProduct.Description,
                SKU = createdProduct.SKU,
                Barcode = createdProduct.Barcode,
                Price = createdProduct.Price,
                Cost = createdProduct.Cost,
                CategoryId = createdProduct.CategoryId,
                CategoryName = createdProduct.Category.Name,
                UnitOfMeasureId = createdProduct.UnitOfMeasureId,
                UnitOfMeasureName = createdProduct.UnitOfMeasure.Name,
                IsActive = createdProduct.IsActive,
                CreatedAt = createdProduct.CreatedAt,
                UpdatedAt = createdProduct.UpdatedAt
            };
        }

        public async Task<ProductResponseDTO> UpdateProductAsync(int id, ProductUpdateDTO productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            
            if (product == null)
                return null;

            // Check if SKU or Barcode already exists for other products
            if (await _context.Products.AnyAsync(p => p.Id != id && p.SKU == productDto.SKU))
                throw new ArgumentException("Product with this SKU already exists");

            if (!string.IsNullOrEmpty(productDto.Barcode) && await _context.Products.AnyAsync(p => p.Id != id && p.Barcode == productDto.Barcode))
                throw new ArgumentException("Product with this Barcode already exists");

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.SKU = productDto.SKU;
            product.Barcode = productDto.Barcode;
            product.Price = productDto.Price;
            product.Cost = productDto.Cost;
            product.CategoryId = productDto.CategoryId;
            product.UnitOfMeasureId = productDto.UnitOfMeasureId;
            product.IsActive = productDto.IsActive;
            product.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Return updated product
            var updatedProduct = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.UnitOfMeasure)
                .FirstOrDefaultAsync(p => p.Id == product.Id);

            return new ProductResponseDTO
            {
                Id = updatedProduct.Id,
                Name = updatedProduct.Name,
                Description = updatedProduct.Description,
                SKU = updatedProduct.SKU,
                Barcode = updatedProduct.Barcode,
                Price = updatedProduct.Price,
                Cost = updatedProduct.Cost,
                CategoryId = updatedProduct.CategoryId,
                CategoryName = updatedProduct.Category.Name,
                UnitOfMeasureId = updatedProduct.UnitOfMeasureId,
                UnitOfMeasureName = updatedProduct.UnitOfMeasure.Name,
                IsActive = updatedProduct.IsActive,
                CreatedAt = updatedProduct.CreatedAt,
                UpdatedAt = updatedProduct.UpdatedAt
            };
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            
            if (product == null)
                return false;

            // Instead of deleting, mark as inactive
            product.IsActive = false;
            product.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductResponseDTO>> SearchProductsAsync(string searchTerm)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.UnitOfMeasure)
                .Where(p => p.IsActive && 
                           (p.Name.Contains(searchTerm) || 
                            p.SKU.Contains(searchTerm) || 
                            p.Barcode.Contains(searchTerm)))
                .Select(p => new ProductResponseDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    SKU = p.SKU,
                    Barcode = p.Barcode,
                    Price = p.Price,
                    Cost = p.Cost,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name,
                    UnitOfMeasureId = p.UnitOfMeasureId,
                    UnitOfMeasureName = p.UnitOfMeasure.Name,
                    IsActive = p.IsActive,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                })
                .ToListAsync();

            return products;
        }
    }
}