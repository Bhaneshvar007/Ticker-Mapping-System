using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cash_Future_MappingSystem
{
    /// <summary>
    /// Summary description for fileupload
    /// </summary>
    public class fileupload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    string fname = context.Server.MapPath("~/UploadFiles/ClientMaster/" + file.FileName);
                    file.SaveAs(fname);
                }
                context.Response.ContentType = "text/plain";
                context.Response.Write("File Uploaded Successfully!");
            }

        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}