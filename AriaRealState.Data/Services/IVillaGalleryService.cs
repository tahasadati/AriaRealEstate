using AriaRealState.Data.Context;
using AriaRealState.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AriaRealState.Data.Services;

public interface IVillaGalleryService
{
    Task<bool> RemoveAsync(VillaGallery gallery, CancellationToken ct = default);
}


public class VillaGalleryService : IVillaGalleryService
{
    private readonly AppDbContext _db;
	public VillaGalleryService(AppDbContext db)
	{
		_db = db;
	}

    public async Task<bool> RemoveAsync(VillaGallery gallery, CancellationToken ct = default)
    {
        try
        {
            _db.VillaGalleries.Remove(gallery);
            await _db.SaveChangesAsync(ct);
            return true;
        }
        catch
        {
            return false;
        }
    }
}   