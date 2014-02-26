using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

namespace Galleriet.Model
{
    public class Gallery
    {   
        private static readonly Regex ApprovedExenstions;
        private static string PhysicalUploadImagePath;
        private static readonly Regex SantizePath;

        static Gallery()
        {   
            ApprovedExenstions = new Regex("^.*\.(gif|jpg|png)$");
            PhysicalUploadImagePath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content/Images");
            var invalidChars = new string(Path.GetInvalidFileNameChars());
            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));
        }

        public IEnumerable<string> GetImageNames()
        {
            string[] filesindirectory = Directory.GetFiles(PhysicalUploadImagePath);
            List<String> images = new List<string>(filesindirectory.Count());

            foreach (string item in filesindirectory)
            {
                images.Add(String.Format(Path.GetFileName(item)));
            }

            return images.AsEnumerable();
        }

        public bool ImageExists(string name)
        {
            return File.Exists(Path.Combine(PhysicalUploadImagePath, name));
        }

        public bool IsValidImage(Image image)
        {
            if (image.RawFormat.Guid == ImageFormat.Gif.Guid || image.RawFormat.Guid == ImageFormat.Jpeg.Guid || image.RawFormat.Guid == ImageFormat.Png.Guid)
	        {
		        return true;
	        }

            return false;
        }

        public string SaveImage(Stream stream, string fileName)
        {
            var image = System.Drawing.Image.FromStream(stream);
            var thumbnail = image.GetThumbnailImage(90, 90, null, System.IntPtr.Zero);

            if (!IsValidImage(image))
            {
                throw new ArgumentException("Bilden är inte giltlig");
            }

            if (ImageExists(fileName))
            {
                int count = 1;
                string fileNameNoExt = Path.GetFileNameWithoutExtension(fileName);
                string extension = Path.GetExtension(fileName);

                while (ImageExists(fileName))
                {
                    fileName = string.Format("{0}({1}){2}", fileNameNoExt, count++, extension);
                }
            }

            SantizePath.Replace(fileName,"_");

            if (fileName != ApprovedExenstions.Match(fileName).ToString())
            {
                throw new ArgumentException("Bilden har inte en giltlig filändelse");
            }

            image.Save(Path.Combine(PhysicalUploadImagePath, fileName));
            thumbnail.Save(Path.Combine(PhysicalUploadImagePath + "/Thumbnails", fileName));

            return fileName;
        }
    }
}