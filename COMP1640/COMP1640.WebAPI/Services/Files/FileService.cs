using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace COMP1640.WebAPI.Services.Files
{
    public class FileService(IWebHostEnvironment environment, ILogger<FileService> logger) : IFileService
    {
        private readonly ILogger<FileService> _logger = logger;
        private readonly IWebHostEnvironment _environment = environment;
        private const string UploadsFolderName = "uploads"; // Folder to store images

        private static readonly HashSet<string> AllowedImageExtensions = [".jpg", ".jpeg", ".png", ".gif"];
        private static readonly HashSet<string> AllowedImageMimeTypes = ["image/jpeg", "image/png", "image/gif"];

        public async Task<string> SaveImageAsync(IFormFile image, int maxWidth, int maxHeight)
        {
            try
            {
                var uploadsFolder = EnsureUploadsFolderExists();
                var originalFileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(uploadsFolder, originalFileName);

                // Check if the file already exists
                if (File.Exists(filePath))
                {
                    return originalFileName;
                }

                var uniqueFileName = GenerateUniqueFileName(originalFileName);
                filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using var stream = image.OpenReadStream();
                using var img = Image.Load(stream);

                // Resize the image
                var resizedImg = ResizeImage(img, maxWidth, maxHeight);

                // Save the resized image to the file system
                await SaveImageToFileAsync(resizedImg, filePath);

                return uniqueFileName;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the image.");
                throw;
            }
        }

        public async Task<IEnumerable<string>> SaveImagesAsync(IEnumerable<IFormFile> images, int maxWidth, int maxHeight)
        {
            var imagePaths = new List<string>();

            foreach (var image in images)
            {
                try
                {
                    var fileName = await SaveImageAsync(image, maxWidth, maxHeight);
                    imagePaths.Add(fileName);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while saving the image {FileName}.", image.FileName);
                }
            }

            return imagePaths;
        }

        public void DeleteImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                return;
            }
            var filePath = Path.Combine(_environment.WebRootPath, UploadsFolderName, imagePath);
            if (File.Exists(filePath))
            {
                try
                {
                    _logger.LogInformation("Deleting image {ImagePath}", imagePath);
                    File.Delete(filePath);
                }
                catch (Exception)
                {
                    _logger.LogWarning("Failed to delete image {ImagePath}", imagePath);
                    var directory = Path.GetDirectoryName(filePath);
                    var newFileName = "image.delete" + Path.GetExtension(filePath);
                    var newFilePath = Path.Combine(directory, newFileName);

                    // Rename the file
                    File.Move(filePath, newFilePath);
                }
            }
        }

        public void DeleteImages(IEnumerable<string> imagePaths)
        {
            foreach (var imagePath in imagePaths)
            {
                DeleteImage(imagePath);
            }
        }

        public bool IsImageFile(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!AllowedImageExtensions.Contains(extension))
            {
                return false;
            }

            if (!AllowedImageMimeTypes.Contains(file.ContentType))
            {
                return false;
            }

            return true;
        }

        #region SubMethods for SaveImageAsync

        private string EnsureUploadsFolderExists()
        {
            if (string.IsNullOrEmpty(_environment?.WebRootPath))
            {
                throw new InvalidOperationException("WebRootPath is not set or is null.");
            }

            if (string.IsNullOrEmpty(UploadsFolderName))
            {
                throw new ArgumentNullException(nameof(UploadsFolderName), "Uploads folder name cannot be null or empty.");
            }

            var uploadsFolder = Path.Combine(_environment.WebRootPath, UploadsFolderName);
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            return uploadsFolder;
        }

        private static string GenerateUniqueFileName(string originalFileName)
        {
            return Guid.NewGuid().ToString() + "-" + originalFileName;
        }

        private static Image ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            var originalWidth = image.Width;
            var originalHeight = image.Height;
            var aspectRatio = (double)originalWidth / originalHeight;

            int newWidth = originalWidth > maxWidth ? maxWidth : originalWidth;
            int newHeight = (int)(newWidth / aspectRatio);

            if (newHeight > maxHeight)
            {
                newHeight = maxHeight;
                newWidth = (int)(newHeight * aspectRatio);
            }

            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Size = new Size(newWidth, newHeight),
                Mode = ResizeMode.Max,
                Sampler = KnownResamplers.Lanczos3 // High-quality resampling
            }));

            return image;
        }

        private async Task SaveImageToFileAsync(Image image, string filePath)
        {
            await image.SaveAsync(filePath, new SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder
            {
                Quality = 100
            });
        }

        #endregion
    }
}
