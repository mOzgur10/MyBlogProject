using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MyBlog.Application.Utilities.Helpers
{
    public static class ImageHelper
    {
        public static async Task<string> SaveImageWithThumbnailAsync(IFormFile imageFile, string folderName, int thumbWidth = 300, int thumbHeight = 300)
        {
            if (imageFile == null || imageFile.Length == 0)
                return null;

            var fileExtension = Path.GetExtension(imageFile.FileName);
            var baseFileName = $"{Guid.NewGuid()}{fileExtension}";

            var mainImageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", folderName);
            var thumbnailFolder = Path.Combine(mainImageFolder, "thumbnails");

            Directory.CreateDirectory(mainImageFolder);
            Directory.CreateDirectory(thumbnailFolder);

            var originalPath = Path.Combine(mainImageFolder, baseFileName);
            var thumbnailPath = Path.Combine(thumbnailFolder, baseFileName);

            // Save original
            using (var stream = new FileStream(originalPath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            // Create thumbnail
            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var image = await Image.LoadAsync(memoryStream))
                {
                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Size = new Size(thumbWidth, thumbHeight),
                        Mode = ResizeMode.Max,
                        Position = AnchorPositionMode.Center
                    }));

                    await image.SaveAsync(thumbnailPath, new JpegEncoder());
                }
            }

            return $"/images/{folderName}/{baseFileName}";
        }

        public static string GetThumbnailUrl(string originalUrl)
        {
            if (string.IsNullOrEmpty(originalUrl))
                return "/images/default.jpg";

            // Örn: /images/articles/photo.jpg -> /images/articles/thumbnails/photo.jpg
            return originalUrl.Replace("/images/", "/images/").Replace($"{Path.GetFileName(originalUrl)}", $"thumbnails/{Path.GetFileName(originalUrl)}");
        }
    }
}
