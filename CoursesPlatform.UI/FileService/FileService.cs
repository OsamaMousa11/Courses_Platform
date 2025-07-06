namespace CoursesPlatform.UI.Service
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string?> CreateFile(IFormFile file)
           
        {

            string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string newPath = Path.Combine(_environment.WebRootPath, "Upload", newFileName);
            

            using (var stream = new FileStream(newPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return "/Upload/"+newFileName;
        }

        public async  Task DeleteFile(string? ImageUrl)
        {

            if(string.IsNullOrEmpty(ImageUrl)) return;

            // Remove "/Upload/" from beginning if it exists
            string fileName = ImageUrl.Replace("/Upload/", "").TrimStart('/');

            string filePath = Path.Combine(_environment.WebRootPath, "Upload", fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

        }

        public async Task<string?> Updatefile(IFormFile newfile, string? CurrentFile)
        {    
            if (string.IsNullOrEmpty(CurrentFile))
            {
                return await CreateFile(newfile);
            }

            await DeleteFile(CurrentFile);
            return  await CreateFile(newfile);
        }
    }
}
