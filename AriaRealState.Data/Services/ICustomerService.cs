using AriaRealState.Data.Context;
using AriaRealState.Data.Entities;
using AriaRealState.Data.Helps.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Services;

public interface ICustomerService
{
    Task<long> CreateAsync(Customer entity, CancellationToken ct = default);
    Task<bool> UpdateAsync(Customer entity, CancellationToken ct = default);
    Task<Customer?> GetByIdAsync(long id, CancellationToken ct = default);
    Task<PaginatedList<Customer>> GetPaginatedAsync(int page, int pageSize, CancellationToken ct = default);
    Task<List<Customer>> GetAllAsync(CancellationToken ct = default);
}
public class CustomerService : ICustomerService
{
    private readonly AppDbContext _db;
    public CustomerService(AppDbContext db)
    {
        _db = db;
    }


    public async Task<long> CreateAsync(Customer entity, CancellationToken ct = default)
    {
        try
        {
            await _db.Customers.AddAsync(entity);
            await _db.SaveChangesAsync(ct);
            return entity.Id;
        }
        catch
        {
            return 0;
        }

    }

    public async Task<bool> UpdateAsync(Customer entity, CancellationToken ct = default)
    {
        try
        {
            _db.Customers.Update(entity);
            await _db.SaveChangesAsync(ct);
            return true;
        }
        catch
        {
            return false;
        }

    }

    public async Task<Customer?> GetByIdAsync(long id, CancellationToken ct = default)
    {
        return await _db.Customers.FirstOrDefaultAsync(o => o.Id == id, ct);
    }

    public async Task<PaginatedList<Customer>> GetPaginatedAsync(int page, int pageSize, CancellationToken ct = default)
    {
        var query = _db.Customers.AsNoTracking()
           .OrderByDescending(u => u.Id);
        return await PaginatedList<Customer>.CreateAsync(query, page, pageSize);
    }


    public async Task<List<Customer>> GetAllAsync(CancellationToken ct = default)
    {
        return await _db.Customers
            .AsNoTracking()
            .ToListAsync(ct);
    }
}