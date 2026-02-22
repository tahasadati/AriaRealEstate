using AriaRealState.Data.Context;
using AriaRealState.Data.Entities;
using AriaRealState.Data.Enums;
using AriaRealState.Data.Helps.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Services;

public interface IBlogService
{
    Task<PaginatedList<Blog>> GetPaginatedAsync(int page, int pageSize, CancellationToken ct = default);
    Task<Blog?> GetByIdAsync(long id, CancellationToken ct = default);
    Task<long> CreateAsync(Blog blog, CancellationToken ct = default);
    Task<bool> UpdateAsync(Blog blog, CancellationToken ct = default);
    Task<bool> DeleteAsync(Blog blog, CancellationToken ct = default);
    Task<List<Blog>> GetLastAsync(int count = 10);
    Task<PaginatedList<Blog>> GetUserPaginatedAsync(int page, int pageSize, CancellationToken ct = default);
    Task<PaginatedList<Blog>> GetFilteredPaginatedAsync(
    int page, int pageSize,
    long? categoryId,
    BlogSortBy sortBy,
    string? keyword,
    CancellationToken ct = default);
    Task<List<BlogCategory>> GetAllCategoriesAsync(CancellationToken ct = default);
    Task<bool> UpdateRangeAsync(List<Blog> blogs);
}

public class BlogService : IBlogService
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<Blog> _blogRepository;
    public BlogService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _blogRepository = _dbContext.Set<Blog>();
    }

    public async Task<List<Blog>> GetAllAsync(CancellationToken ct = default)
    {
        return await _blogRepository
            .AsNoTracking()
            .ToListAsync(ct);
    }
    public async Task<PaginatedList<Blog>> GetPaginatedAsync(int page, int pageSize, CancellationToken ct = default)
    {
        var query = _blogRepository
            .Include(o => o.BlogCategory)
            .AsNoTracking().OrderByDescending(u => u.Id);
        return await PaginatedList<Blog>.CreateAsync(query, page, pageSize);
    }

    public async Task<PaginatedList<Blog>> GetUserPaginatedAsync(int page, int pageSize, CancellationToken ct = default)
    {
        var query = _blogRepository.Where(o => o.IsReadyShow).AsNoTracking().OrderBy(u => u.Id);
        return await PaginatedList<Blog>.CreateAsync(query, page, pageSize);
    }

    public async Task<Blog?> GetByIdAsync(long id, CancellationToken ct = default)
    {
        return await _blogRepository
            .Include(o => o.BlogCategory)
            .FirstOrDefaultAsync(o => o.Id == id, ct);
    }

    public async Task<long> CreateAsync(Blog blog, CancellationToken ct = default)
    {
        try
        {
            await _blogRepository.AddAsync(blog);
            await _dbContext.SaveChangesAsync(ct);
            return blog.Id;
        }
        catch (Exception ex)
        {
            return 0;
        }

    }

    public async Task<bool> UpdateAsync(Blog blog, CancellationToken ct = default)
    {
        try
        {
            _blogRepository.Update(blog);
            await _dbContext.SaveChangesAsync(ct);
            return true;
        }
        catch
        {
            return false;
        }

    }

    public async Task<bool> DeleteAsync(Blog blog, CancellationToken ct = default)
    {
        try
        {
            _blogRepository.Remove(blog);
            await _dbContext.SaveChangesAsync(ct);
            return true;
        }
        catch
        {
            return false;
        }

    }

    public async Task<List<Blog>> GetLastAsync(int count = 10)
    {
        return await _blogRepository
            .Include(o => o.BlogCategory)
            .Where(o => o.IsReadyShow)
            .OrderByDescending(o => o.CreatedAt)
            .Take(count)
            .AsNoTracking()
            .ToListAsync();
    }


    public async Task<PaginatedList<Blog>> GetFilteredPaginatedAsync(
    int page, int pageSize,
    long? categoryId,
    BlogSortBy sortBy,
    string? keyword,
    CancellationToken ct = default)
    {
        var query = _blogRepository
            .Include(b => b.BlogCategory)
            .AsNoTracking()
            .Where(b => b.IsReadyShow);

        if (categoryId.HasValue)
            query = query.Where(b => b.BlogCategoryId == categoryId.Value);

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            var k = keyword.Trim();
            query = query.Where(b =>
                b.BlogTitle.Contains(k) ||
                b.BlogDescription.Contains(k) ||
                b.Keyword.Contains(k));
        }

        query = sortBy == BlogSortBy.Newest
            ? query.OrderByDescending(b => b.CreatedAt)
            : query.OrderBy(b => b.CreatedAt);

        return await PaginatedList<Blog>.CreateAsync(query, page, pageSize);
    }

    public async Task<List<BlogCategory>> GetAllCategoriesAsync(CancellationToken ct = default)
    {
        return await _dbContext.Set<BlogCategory>()
            .AsNoTracking()
            .OrderBy(c => c.CategoryName)
            .ToListAsync(ct);
    }

    public async Task<bool> UpdateRangeAsync(List<Blog> blogs)
    {
        try
        {
            _blogRepository.UpdateRange(blogs);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}