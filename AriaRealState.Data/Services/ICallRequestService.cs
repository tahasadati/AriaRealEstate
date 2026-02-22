using AriaRealState.Data.Context;
using AriaRealState.Data.Entities;
using AriaRealState.Data.Helps.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Services;

public interface ICallRequestService
{
    Task<long> CreateAsync(CallRequest entity, CancellationToken ct = default);
    Task<bool> UpdateAsync(CallRequest entity, CancellationToken ct = default);
    Task<CallRequest?> GetByIdAsync(long id, CancellationToken ct = default);
    Task<PaginatedList<CallRequest>> GetPaginatedAsync(int page, int pageSize, CancellationToken ct = default);
    Task<List<CallRequest>> GetAllAsync(CancellationToken ct = default);
}
public class CallRequestService : ICallRequestService
{
    private readonly AppDbContext _db;
    public CallRequestService(AppDbContext db)
    {
        _db = db;
    }


    public async Task<long> CreateAsync(CallRequest entity, CancellationToken ct = default)
    {
        try
        {
            await _db.CallRequests.AddAsync(entity);
            await _db.SaveChangesAsync(ct);
            return entity.Id;
        }
        catch
        {
            return 0;
        }

    }

    public async Task<bool> UpdateAsync(CallRequest entity, CancellationToken ct = default)
    {
        try
        {
            _db.CallRequests.Update(entity);
            await _db.SaveChangesAsync(ct);
            return true;
        }
        catch
        {
            return false;
        }

    }

    public async Task<CallRequest?> GetByIdAsync(long id, CancellationToken ct = default)
    {
        return await _db.CallRequests.FirstOrDefaultAsync(o => o.Id == id, ct);
    }

    public async Task<PaginatedList<CallRequest>> GetPaginatedAsync(int page, int pageSize, CancellationToken ct = default)
    {
        var query = _db.CallRequests.AsNoTracking()
           .OrderByDescending(u => u.Id);
        return await PaginatedList<CallRequest>.CreateAsync(query, page, pageSize);
    }


    public async Task<List<CallRequest>> GetAllAsync(CancellationToken ct = default)
    {
        return await _db.CallRequests
            .AsNoTracking()
            .ToListAsync(ct);
    }
}