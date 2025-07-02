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
            return newFileName;
        }

    }
}
