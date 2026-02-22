namespace AriaRealState.Web.Assistance.Services;

public interface IStaticFileService
{
    /// <summary>
    /// Saves the uploaded file into wwwroot/{folderName} and returns its relative path (e.g. "/images/abc.jpg")
    /// </summary>
    Task<string?> SaveFileAsync(IFormFile file, string folderName);

    /// <summary>
    /// Deletes a file (if exists) from wwwroot
    /// </summary>
    void DeleteFile(string relativePath);
}

public class StaticFileService : IStaticFileService
{
    private readonly IWebHostEnvironment _env;

    public StaticFileService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task<string?> SaveFileAsync(IFormFile file, string folderName)
    {
        if (file == null || file.Length == 0)
            return null;

        // مسیر فولدر در wwwroot
        var uploadPath = Path.Combine(_env.WebRootPath, folderName);

        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        // نام فایل یکتا
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploadPath, fileName);

        // ذخیره در سرور
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // مسیر نسبی برای ذخیره در دیتابیس
        return $"/{folderName}/{fileName}";
    }

    public void DeleteFile(string relativePath)
    {
        if (string.IsNullOrWhiteSpace(relativePath))
            return;

        var physicalPath = Path.Combine(_env.WebRootPath, relativePath.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));

        if (File.Exists(physicalPath))
        {
            File.Delete(physicalPath);
        }
    }
}
