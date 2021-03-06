﻿using System;
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

            var query = Request.QueryString["img"];

            if (Request.QueryString["img"] != null)
            {
                ImagePlaceholder.ImageUrl = "Content/Images/" + query;
                ImagePlaceholder.Visible = true;
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Gallery gallery = new Gallery();
                gallery.SaveImage(FileUpload.FileContent, FileUpload.FileName);
            }

            UploadSuccess.Visible = true;
        }
        public IEnumerable<System.String> GetImages()
        {
            Gallery gallery = new Gallery();
            return  gallery.GetImageNames();
        }
    }
}