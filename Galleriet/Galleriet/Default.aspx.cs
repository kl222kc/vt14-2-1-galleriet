using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Galleriet.Model;

namespace Galleriet
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string[] filesindirectory = Directory.GetFiles(Server.MapPath("~/Content/Images/Thumbnails"));
            List<String> images = new List<string>(filesindirectory.Count());

            foreach (string item in filesindirectory)
            {
                images.Add(String.Format("~/Content/Images/Thumbnails/{0}", System.IO.Path.GetFileName(item)));
            }

            RepeaterImages.DataSource = images;
            RepeaterImages.DataBind();
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Gallery gallery = new Gallery();
                gallery.SaveImage(FileUpload.FileContent, FileUpload.FileName);
            }
        }
    }
}