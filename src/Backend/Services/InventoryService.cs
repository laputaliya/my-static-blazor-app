using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarehouseManagement.DTOs;
using WarehouseManagement.Models;

namespace WarehouseManagement.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly ApplicationDbContext _context;

        public InventoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InventoryResponseDTO>> GetAllInventoriesAsync()
        {
            var inventories = await _context.Inventories
                .Include(i => i.Product)
                .Include(i => i.Location)
                .Include(i => i.Warehouse)
                .Select(i => new InventoryResponseDTO
                {
                    Id = i.Id,
                    ProductId = i.ProductId,
                    ProductName = i.Product.Name,
                    LocationId = i.LocationId,
                    LocationCode = i.Location.Code,
                    WarehouseId = i.WarehouseId,
                    WarehouseName = i.Warehouse.Name,
                    QuantityOnHand = i.QuantityOnHand,
                    QuantityAvailable = i.QuantityAvailable,
                    QuantityReserved = i.QuantityReserved,
                    QuantityInTransit = i.QuantityInTransit,
                    MinimumStockLevel = i.MinimumStockLevel,
                    MaximumStockLevel = i.MaximumStockLevel,
                    LastUpdated = i.LastUpdated,
                    CreatedAt = i.CreatedAt,
                    UpdatedAt = i.UpdatedAt
                })
                .ToListAsync();

            return inventories;
        }

        public async Task<InventoryResponseDTO> GetInventoryByIdAsync(int id)
        {
            var inventory = await _context.Inventories
                .Include(i => i.Product)
                .Include(i => i.Location)
                .Include(i => i.Warehouse)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (inventory == null)
                return null;

            return new InventoryResponseDTO
            {
                Id = inventory.Id,
                ProductId = inventory.ProductId,
                ProductName = inventory.Product.Name,
                LocationId = inventory.LocationId,
                LocationCode = inventory.Location.Code,
                WarehouseId = inventory.WarehouseId,
                WarehouseName = inventory.Warehouse.Name,
                QuantityOnHand = inventory.QuantityOnHand,
                QuantityAvailable = inventory.QuantityAvailable,
                QuantityReserved = inventory.QuantityReserved,
                QuantityInTransit = inventory.QuantityInTransit,
                MinimumStockLevel = inventory.MinimumStockLevel,
                MaximumStockLevel = inventory.MaximumStockLevel,
                LastUpdated = inventory.LastUpdated,
                CreatedAt = inventory.CreatedAt,
                UpdatedAt = inventory.UpdatedAt
            };
        }

        public async Task<InventoryResponseDTO> GetInventoryByProductAndLocationAsync(int productId, int locationId)
        {
            var inventory = await _context.Inventories
                .Include(i => i.Product)
                .Include(i => i.Location)
                .Include(i => i.Warehouse)
                .FirstOrDefaultAsync(i => i.ProductId == productId && i.LocationId == locationId);

            if (inventory == null)
                return null;

            return new InventoryResponseDTO
            {
                Id = inventory.Id,
                ProductId = inventory.ProductId,
                ProductName = inventory.Product.Name,
                LocationId = inventory.LocationId,
                LocationCode = inventory.Location.Code,
                WarehouseId = inventory.WarehouseId,
                WarehouseName = inventory.Warehouse.Name,
                QuantityOnHand = inventory.QuantityOnHand,
                QuantityAvailable = inventory.QuantityAvailable,
                QuantityReserved = inventory.QuantityReserved,
                QuantityInTransit = inventory.QuantityInTransit,
                MinimumStockLevel = inventory.MinimumStockLevel,
                MaximumStockLevel = inventory.MaximumStockLevel,
                LastUpdated = inventory.LastUpdated,
                CreatedAt = inventory.CreatedAt,
                UpdatedAt = inventory.UpdatedAt
            };
        }

        public async Task<InventoryResponseDTO> CreateInventoryAsync(InventoryCreateDTO inventoryDto)
        {
            // Check if inventory record already exists for this product and location
            var existingInventory = await _context.Inventories
                .FirstOrDefaultAsync(i => i.ProductId == inventoryDto.ProductId && i.LocationId == inventoryDto.LocationId);

            if (existingInventory != null)
                throw new ArgumentException($"Inventory record already exists for product ID {inventoryDto.ProductId} and location ID {inventoryDto.LocationId}");

            var inventory = new Inventory
            {
                ProductId = inventoryDto.ProductId,
                LocationId = inventoryDto.LocationId,
                WarehouseId = inventoryDto.WarehouseId,
                QuantityOnHand = inventoryDto.QuantityOnHand,
                QuantityAvailable = inventoryDto.QuantityOnHand, // Initially available equals on hand
                QuantityReserved = 0,
                QuantityInTransit = 0,
                MinimumStockLevel = inventoryDto.MinimumStockLevel,
                MaximumStockLevel = inventoryDto.MaximumStockLevel,
                LastUpdated = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();

            // Return the created inventory
            var createdInventory = await _context.Inventories
                .Include(i => i.Product)
                .Include(i => i.Location)
                .Include(i => i.Warehouse)
                .FirstOrDefaultAsync(i => i.Id == inventory.Id);

            return new InventoryResponseDTO
            {
                Id = createdInventory.Id,
                ProductId = createdInventory.ProductId,
                ProductName = createdInventory.Product.Name,
                LocationId = createdInventory.LocationId,
                LocationCode = createdInventory.Location.Code,
                WarehouseId = createdInventory.WarehouseId,
                WarehouseName = createdInventory.Warehouse.Name,
                QuantityOnHand = createdInventory.QuantityOnHand,
                QuantityAvailable = createdInventory.QuantityAvailable,
                QuantityReserved = createdInventory.QuantityReserved,
                QuantityInTransit = createdInventory.QuantityInTransit,
                MinimumStockLevel = createdInventory.MinimumStockLevel,
                MaximumStockLevel = createdInventory.MaximumStockLevel,
                LastUpdated = createdInventory.LastUpdated,
                CreatedAt = createdInventory.CreatedAt,
                UpdatedAt = createdInventory.UpdatedAt
            };
        }

        public async Task<InventoryResponseDTO> UpdateInventoryAsync(int id, InventoryUpdateDTO inventoryDto)
        {
            var inventory = await _context.Inventories.FirstOrDefaultAsync(i => i.Id == id);

            if (inventory == null)
                return null;

            // Store old values for transaction logging
            var oldQuantity = inventory.QuantityOnHand;

            inventory.QuantityOnHand = inventoryDto.QuantityOnHand;
            inventory.MinimumStockLevel = inventoryDto.MinimumStockLevel;
            inventory.MaximumStockLevel = inventoryDto.MaximumStockLevel;
            inventory.QuantityAvailable = inventoryDto.QuantityOnHand - inventory.QuantityReserved; // Recalculate available quantity
            inventory.LastUpdated = DateTime.UtcNow;
            inventory.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Return updated inventory
            var updatedInventory = await _context.Inventories
                .Include(i => i.Product)
                .Include(i => i.Location)
                .Include(i => i.Warehouse)
                .FirstOrDefaultAsync(i => i.Id == inventory.Id);

            return new InventoryResponseDTO
            {
                Id = updatedInventory.Id,
                ProductId = updatedInventory.ProductId,
                ProductName = updatedInventory.Product.Name,
                LocationId = updatedInventory.LocationId,
                LocationCode = updatedInventory.Location.Code,
                WarehouseId = updatedInventory.WarehouseId,
                WarehouseName = updatedInventory.Warehouse.Name,
                QuantityOnHand = updatedInventory.QuantityOnHand,
                QuantityAvailable = updatedInventory.QuantityAvailable,
                QuantityReserved = updatedInventory.QuantityReserved,
                QuantityInTransit = updatedInventory.QuantityInTransit,
                MinimumStockLevel = updatedInventory.MinimumStockLevel,
                MaximumStockLevel = updatedInventory.MaximumStockLevel,
                LastUpdated = updatedInventory.LastUpdated,
                CreatedAt = updatedInventory.CreatedAt,
                UpdatedAt = updatedInventory.UpdatedAt
            };
        }

        public async Task<bool> DeleteInventoryAsync(int id)
        {
            var inventory = await _context.Inventories.FirstOrDefaultAsync(i => i.Id == id);

            if (inventory == null)
                return false;

            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AdjustInventoryAsync(int productId, int locationId, int warehouseId, decimal quantityChange, string adjustmentReason, int userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Find the inventory record
                var inventory = await _context.Inventories
                    .FirstOrDefaultAsync(i => i.ProductId == productId && i.LocationId == locationId);

                if (inventory == null)
                {
                    // Create new inventory record if it doesn't exist
                    inventory = new Inventory
                    {
                        ProductId = productId,
                        LocationId = locationId,
                        WarehouseId = warehouseId,
                        QuantityOnHand = 0,
                        QuantityAvailable = 0,
                        QuantityReserved = 0,
                        QuantityInTransit = 0,
                        MinimumStockLevel = 0,
                        MaximumStockLevel = 0,
                        LastUpdated = DateTime.UtcNow,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };
                    _context.Inventories.Add(inventory);
                }

                // Store old values for transaction record
                var oldQuantity = inventory.QuantityOnHand;
                
                // Update quantities
                inventory.QuantityOnHand += quantityChange;
                inventory.QuantityAvailable = inventory.QuantityOnHand - inventory.QuantityReserved;
                inventory.LastUpdated = DateTime.UtcNow;
                inventory.UpdatedAt = DateTime.UtcNow;

                // Create inventory transaction record
                var inventoryTransaction = new InventoryTransaction
                {
                    ProductId = productId,
                    LocationId = locationId,
                    WarehouseId = warehouseId,
                    TransactionTypeId = 4, // Adjustment
                    QuantityChange = quantityChange,
                    QuantityBefore = oldQuantity,
                    QuantityAfter = inventory.QuantityOnHand,
                    ReferenceDocument = $"ADJ-{DateTime.UtcNow:yyyyMMdd-HHmmss}-{adjustmentReason.Substring(0, Math.Min(adjustmentReason.Length, 20)).Replace(" ", "")}",
                    UserId = userId,
                    TransactionDate = DateTime.UtcNow,
                    Notes = adjustmentReason
                };

                _context.InventoryTransactions.Add(inventoryTransaction);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}