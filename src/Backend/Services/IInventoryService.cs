using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagement.DTOs;

namespace WarehouseManagement.Services
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryResponseDTO>> GetAllInventoriesAsync();
        Task<InventoryResponseDTO> GetInventoryByIdAsync(int id);
        Task<InventoryResponseDTO> GetInventoryByProductAndLocationAsync(int productId, int locationId);
        Task<InventoryResponseDTO> CreateInventoryAsync(InventoryCreateDTO inventoryDto);
        Task<InventoryResponseDTO> UpdateInventoryAsync(int id, InventoryUpdateDTO inventoryDto);
        Task<bool> DeleteInventoryAsync(int id);
        Task<bool> AdjustInventoryAsync(int productId, int locationId, int warehouseId, decimal quantityChange, string adjustmentReason, int userId);
    }
}