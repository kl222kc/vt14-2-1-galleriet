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
            List<string> temp = new List<string>();
            return temp;
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

            image.Save(Path.Combine(PhysicalUploadImagePath, fileName));

            return fileName;
        }
    }
}