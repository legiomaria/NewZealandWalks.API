﻿using NewZealandWalks.API.Models.Domain;

namespace NewZealandWalks.API.Interfaces
{
    public interface IRegionsService
    {
        Task<List<Region>> GetAllAsync();

        Task<Region?> GetByIdAsync(Guid id);

        Task<Region> CreateAsync(Region region);

        Task<Region?> UpdateAsync(Guid id, Region region);

        Task<Region> DeleteAsync(Guid id);
    }
}
