namespace COMP1640.WebAPI.Services.Files
{
    public interface IFileService
    {
        /// <summary>
        /// Save an image to the file system
        /// </summary>
        /// <param name="image"></param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        public Task<string> SaveImageAsync(IFormFile image, int maxWidth, int maxHeight);
        /// <summary>
        /// Save multiple images to the file system
        /// </summary>
        /// <param name="images"></param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        public Task<IEnumerable<string>> SaveImagesAsync(IEnumerable<IFormFile> images, int maxWidth, int maxHeight);
        /// <summary>
        /// Delete an image from the file system
        /// </summary>
        /// <param name="imagePath"></param>
        public void DeleteImage(string imagePath);
        /// <summary>
        /// Delete multiple images from the file system
        /// </summary>
        /// <param name="imagePaths"></param>
        public void DeleteImages(IEnumerable<string> imagePaths);
        /// <summary>
        /// Check if the file is an image file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        bool IsImageFile(IFormFile file);
    }

}
