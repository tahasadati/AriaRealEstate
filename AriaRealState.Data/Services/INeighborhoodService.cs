using AriaRealState.Data.Context;
using AriaRealState.Data.Entities;
using AriaRealState.Data.Helps.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Services;

public interface INeighborhoodService
{
    Task<long> CreateAsync(Neighborhood entity, CancellationToken ct = default);
    Task<bool> UpdateAsync(Neighborhood entity, CancellationToken ct = default);
    Task<Neighborhood?> GetByIdAsync(long id, CancellationToken ct = default);
    Task<PaginatedList<Neighborhood>> GetPaginatedAsync(int page, int pageSize, CancellationToken ct = default);
    Task<List<Neighborhood>> GetAllAsync(CancellationToken ct = default);
}

public class NeighborhoodService : INeighborhoodService
{
    private readonly AppDbContext _db;
    public NeighborhoodService(AppDbContext db)
    {
        _db = db;
    }


    public async Task<long> CreateAsync(Neighborhood entity, CancellationToken ct = default)
    {
        try
        {
            await _db.Neighborhoods.AddAsync(entity);
            await _db.SaveChangesAsync(ct);
            return entity.Id;
        }
        catch
        {
            return 0;
        }

    }

    public async Task<bool> UpdateAsync(Neighborhood entity, CancellationToken ct = default)
    {
        try
        {
            _db.Neighborhoods.Update(entity);
            await _db.SaveChangesAsync(ct);
            return true;
        }
        catch
        {
            return false;
        }

    }

    public async Task<Neighborhood?> GetByIdAsync(long id, CancellationToken ct = default)
    {
        return await _db.Neighborhoods.FirstOrDefaultAsync(o => o.Id == id, ct);
    }

    public async Task<PaginatedList<Neighborhood>> GetPaginatedAsync(int page, int pageSize, CancellationToken ct = default)
    {
        var query = _db.Neighborhoods.AsNoTracking()
           .OrderByDescending(u => u.Id);
        return await PaginatedList<Neighborhood>.CreateAsync(query, page, pageSize);
    }


    public async Task<List<Neighborhood>> GetAllAsync(CancellationToken ct = default)
    {
        return await _db.Neighborhoods
            .AsNoTracking()
            .ToListAsync(ct);
    }
}
