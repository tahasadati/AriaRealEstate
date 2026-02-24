using AriaRealState.Data.Context;
using AriaRealState.Data.Entities;
using AriaRealState.Data.Enums;
using AriaRealState.Data.Enums.Land;
using AriaRealState.Data.Enums.Villa;
using AriaRealState.Data.Helps.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AriaRealState.Data.Services;

public interface ILandService
{
    Task<long> CreateAsync(Land entity, CancellationToken ct = default);
    Task<bool> UpdateAsync(Land entity, CancellationToken ct = default);
    Task<Land?> GetByIdAsync(long id, CancellationToken ct = default);
    Task<PaginatedList<Land>> GetPaginatedAsync(int page, int pageSize, CancellationToken ct = default);
    Task<List<Land>> GetAllAsync(CancellationToken ct = default);
    Task<bool> RemoveAsync(Land land, CancellationToken ct = default);
    Task<List<Land>> GetUserList(
    string? searchTerm,
    List<AbilityEnum> selectedAbilities,
    List<LandOrientationEnum> selectedLandOrientations,
    List<LandUseType> selectedLandUseTypes,
    List<PropertyLocationType> selectedPropertyLocationTypes,
    int size = 45,
    CancellationToken ct = default);
}

public class LandService : ILandService
{
    private readonly AppDbContext _db;
    public LandService(AppDbContext db)
    {
        _db = db;
    }


    public async Task<long> CreateAsync(Land entity, CancellationToken ct = default)
    {
        try
        {
            await _db.Lands.AddAsync(entity);
            await _db.SaveChangesAsync(ct);
            return entity.Id;
        }
        catch
        {
            return 0;
        }

    }

    public async Task<bool> UpdateAsync(Land entity, CancellationToken ct = default)
    {
        try
        {
            _db.Lands.Update(entity);
            await _db.SaveChangesAsync(ct);
            return true;
        }
        catch
        {
            return false;
        }

    }

    public async Task<Land?> GetByIdAsync(long id, CancellationToken ct = default)
    {
        return await _db.Lands.FirstOrDefaultAsync(o => o.Id == id, ct);
    }

    public async Task<PaginatedList<Land>> GetPaginatedAsync(int page, int pageSize, CancellationToken ct = default)
    {
        var query = _db.Lands.AsNoTracking()
           .OrderByDescending(u => u.Id);
        return await PaginatedList<Land>.CreateAsync(query, page, pageSize);
    }


    public async Task<List<Land>> GetAllAsync(CancellationToken ct = default)
    {
        return await _db.Lands
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task<bool> RemoveAsync(Land land, CancellationToken ct = default)
    {
        try
        {
            _db.Lands.Remove(land);
            await _db.SaveChangesAsync(ct);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<Land>> GetUserList(
    string? searchTerm,
    List<AbilityEnum> selectedAbilities,
    List<LandOrientationEnum> selectedLandOrientations,
    List<LandUseType> selectedLandUseTypes,
    List<PropertyLocationType> selectedPropertyLocationTypes,
    int size = 45,
    CancellationToken ct = default)
    {
        selectedAbilities ??= new();
        selectedLandOrientations ??= new();
        selectedLandUseTypes ??= new();
        selectedPropertyLocationTypes ??= new();

        // شروع با query اولیه
        var query = _db.Lands.Where(v => v.IsShow)
            .AsNoTracking()
            .AsQueryable();

        // فیلتر بر اساس کلمه جستجو
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(v => v.Code.Contains(searchTerm) || v.Title.Contains(searchTerm));
        }

        // فیلتر بر اساس نوع معماری
        if (selectedLandOrientations.Any())
        {
            query = query.Where(v => selectedLandOrientations.Contains(v.LandOrientation));
        }

        // فیلتر بر اساس موقعیت
        if (selectedLandUseTypes.Any())
        {
            query = query.Where(v => selectedLandUseTypes.Contains(v.UseType));
        }

        // فیلتر بر اساس وضعیت اشغال
        if (selectedPropertyLocationTypes.Any())
        {
            query = query.Where(v => selectedPropertyLocationTypes.Contains(v.LocationType));
        }

        return await query
         .OrderByDescending(l => l.Id)
         .Take(size)
         .ToListAsync(ct);
    }

}
