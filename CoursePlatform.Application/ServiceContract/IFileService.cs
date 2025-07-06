



namespace CoursePlatform.Core.ServiceContract
{
    public interface IFileService
    {
        Task<string?> CreateFile(IFormFile file);
        Task<string?> Updatefile(IFormFile newfile, string? CurrentFile);

        Task DeleteFile(string? ImageUrl);
    }
      
}
