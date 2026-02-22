using AriaRealState.Data.Context;
using AriaRealState.Data.Entities;
using AriaRealState.Data.Helps.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AriaRealState.Data.Services;

public interface IUserService
{
    Task<PaginatedList<iUser>> GetPaginatedAsync(int page, int pageSize, string? q = null);
}

public class UserService : IUserService
{
    private readonly AppDbContext _db;
    public UserService(AppDbContext db)
    {
        _db = db;
    }
    public async Task<PaginatedList<iUser>> GetPaginatedAsync(int page, int pageSize, string? q = null)
    {
        var query = _db.Users.AsNoTracking().Where(o => o.UserName != "support@light.com");

        if (!string.IsNullOrWhiteSpace(q))
        {
            q = q.Trim();
            query = query.Where(u =>
                (u.UserName != null && u.UserName.Contains(q)) ||
                (u.PhoneNumber != null && u.PhoneNumber.Contains(q)) ||
                (u.FullName != null && u.FullName.Contains(q)));
            );
        }

        return await PaginatedList<iUser>.CreateAsync(query, page, pageSize);
    }
}
