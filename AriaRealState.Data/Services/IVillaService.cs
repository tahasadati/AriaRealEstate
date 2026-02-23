using AriaRealState.Data.Context;
using AriaRealState.Data.Entities;
using AriaRealState.Data.Enums.Villa;
using AriaRealState.Data.Helps.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Services;

public interface IVillaService
{
    Task<long> CreateAsync(Villa entity, CancellationToken ct = default);
    Task<bool> UpdateAsync(Villa entity, CancellationToken ct = default );
    Task<Villa?> GetByIdAsync(long id, CancellationToken ct = default);
    Task<PaginatedList<Villa>> GetPaginatedAsync(int page, int pageSize, CancellationToken ct = default);
    Task<List<Villa>> GetAllAsync(CancellationToken ct = default);
    Task<List<Villa>> GetUserList(int size, CancellationToken ct = default);
    Task<bool> RemoveAsync(Villa villa, CancellationToken ct = default);
    Task<bool> UpdateAdvanceFacilitiesAsync(long villaId, List<AdvanceFacilityEnum> selected, CancellationToken ct = default);

}

public class VillaService : IVillaService
{
	private readonly AppDbContext _db;
	public VillaService(AppDbContext db)
	{
		_db = db;
	}

	public async Task<long> CreateAsync(Villa entity, CancellationToken ct = default)
	{
		try
		{
            await _db.Villas.AddAsync(entity);
            await _db.SaveChangesAsync(ct);
            return entity.Id;
        }
		catch
		{
			return 0;
		}
		
	}

    public async Task<bool> UpdateAsync(Villa entity, CancellationToken ct = default)
    {
        try
        {
            _db.Villas.Update(entity);
            await _db.SaveChangesAsync(ct);
            return true;
        }
        catch
        {
            return false;
        }

    }

    public async Task<Villa?> GetByIdAsync(long id, CancellationToken ct = default)
    {
        return await _db.Villas
            .Include(o => o.VillaAdvanceFacilities)
            .Include(o => o.VillaGalleries)
            .FirstOrDefaultAsync(o => o.Id == id, ct);
    }

    public async Task<PaginatedList<Villa>> GetPaginatedAsync(int page, int pageSize, CancellationToken ct = default)
    {
        var query = _db.Villas.AsNoTracking()
           .OrderByDescending(u => u.Id);
        return await PaginatedList<Villa>.CreateAsync(query, page, pageSize);
    }


    public async Task<List<Villa>> GetAllAsync(CancellationToken ct = default)
    {
        return await _db.Villas
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task<List<Villa>> GetUserList(int size, CancellationToken ct = default)
    {
        return await _db.Villas.Where(o => o.IsShow)
            .Take(size)
            .AsNoTracking()
            .ToListAsync(ct);
    }


    public async Task<bool> RemoveAsync(Villa villa, CancellationToken ct = default)
    {
        try
        {
            _db.Villas.Remove(villa);
            await _db.SaveChangesAsync(ct);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateAdvanceFacilitiesAsync(long villaId, List<AdvanceFacilityEnum> selected, CancellationToken ct = default)
    {
        try
        {
            selected ??= new List<AdvanceFacilityEnum>();
            selected = selected.Distinct().ToList();

            // امکانات فعلی
            var current = await _db.VillaAdvanceFacilities
                .Where(x => x.VillaId == villaId)
                .ToListAsync(ct);

            // حذف مواردی که دیگر انتخاب نشده‌اند
            var toRemove = current
                .Where(x => !selected.Contains(x.AdvanceFacility))
                .ToList();

            if (toRemove.Any())
                _db.VillaAdvanceFacilities.RemoveRange(toRemove);

            // اضافه کردن موارد جدید
            var currentEnums = current.Select(x => x.AdvanceFacility).ToHashSet();

            var toAdd = selected
                .Where(x => !currentEnums.Contains(x))
                .Select(x => new VillaAdvanceFacility
                {
                    VillaId = villaId,
                    AdvanceFacility = x
                })
                .ToList();

            if (toAdd.Any())
                await _db.VillaAdvanceFacilities.AddRangeAsync(toAdd, ct);

            await _db.SaveChangesAsync(ct);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
