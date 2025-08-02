using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using EntityFramework.Data.Models.Domain;
using Microsoft.AspNetCore.Http;
using EntityFramework.Data;

namespace IssueTrackerRepo
{
    public class ImageUploaderRepo : IImageUploaderRepo1
    {
        private readonly IWebHostEnvironment _env;
        private readonly IssueTrackerDbContext _issueTrackerDbContext;

        public ImageUploaderRepo(IWebHostEnvironment env, IssueTrackerDbContext issueTrackerDbContext )
        {
            _issueTrackerDbContext = issueTrackerDbContext;
            _env = env;
        }

        public async Task<Image> UploadImageAsync(IFormFile uploadedImage)
        {
            var uploadPath = Path.Combine(_env.ContentRootPath, "Uploaded");
            if (!Directory.Exists(uploadPath))
            { 
                Directory.CreateDirectory(uploadPath);
            }
            var fileName = Path.GetRandomFileName() + Path.GetExtension(uploadedImage.FileName);
            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await uploadedImage.CopyToAsync(stream);
            }
            var image = new Image
            {
                FileName = fileName,
                ContentType = uploadedImage.ContentType,
                FilePath = filePath,
                Length = uploadedImage.Length,
                UploadedAt = DateTime.UtcNow
            };

            var savedImage = await _issueTrackerDbContext.Images.AddAsync(image);
            await _issueTrackerDbContext.SaveChangesAsync();
            return savedImage.Entity;
        }
    }
}
