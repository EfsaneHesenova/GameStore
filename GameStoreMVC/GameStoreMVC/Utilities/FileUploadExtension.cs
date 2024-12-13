using Microsoft.AspNetCore.Http.HttpResults;

namespace GameStoreMVC.Utilities
{
    public static class FileUploadExtension
    {
        public static string Upload(this IFormFile file, string rootPath)
        {
            string path = Path.Combine(rootPath, "Uploads");
            string newFileName = file.FileName.ChangeName();
            using (FileStream fileStream = new FileStream(Path.Combine(path, newFileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return newFileName;
        }

        public static string ChangeName(this string fileName)
        {
            string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
            return newFileName;
        }
        public static bool CheckType(this IFormFile formFile) => formFile.ContentType.Contains("image");

        public static bool CheckSize(this IFormFile formFile, int size)
        {
            if (formFile.Length > size * 1024 * 1024)
            {
                return false;
            }
            return true;
        }
        public static void DeleteFile(this string fileName, string rootPath)
        {
            string path = Path.Combine(rootPath, "Uploads", fileName);
            File.Delete(path);
        }
    }
}
