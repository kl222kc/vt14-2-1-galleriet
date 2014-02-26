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
            PhysicalUploadImagePath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content/Images");
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
            return true;
        }

        public bool IsValidImage(Image image)
        {
            return true;
        }

        public string SaveImage(Stream stream, string fileName)
        {
            var image = System.Drawing.Image.FromStream(stream);
            var thumbnail = image.GetThumbnailImage(60, 45, null, System.IntPtr.Zero);

            image.Save(Path.Combine(PhysicalUploadImagePath, fileName));
            thumbnail.Save(Path.Combine(PhysicalUploadImagePath + "/Thumbnails", fileName));

            return fileName;
        }
    }
}