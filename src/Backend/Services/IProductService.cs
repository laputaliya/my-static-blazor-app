using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagement.DTOs;

namespace WarehouseManagement.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDTO>> GetAllProductsAsync();
        Task<ProductResponseDTO> GetProductByIdAsync(int id);
        Task<ProductResponseDTO> CreateProductAsync(ProductCreateDTO productDto);
        Task<ProductResponseDTO> UpdateProductAsync(int id, ProductUpdateDTO productDto);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<ProductResponseDTO>> SearchProductsAsync(string searchTerm);
    }
}