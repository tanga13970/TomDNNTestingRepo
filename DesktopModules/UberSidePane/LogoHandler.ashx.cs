using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using Uberistic.Modules.UberSidePane.Data;

namespace Uberistic.Modules.TextModule3
{
    /// <summary>
    /// Summary description for LogoHandler
    /// </summary>
    public class LogoHandler : IHttpHandler
    {
        SqlDataProvider newDataProvider = new SqlDataProvider();
        #pragma warning disable 1591
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/png";

            if (context.Request.QueryString["UBPId"] != null)
            {
                int UBPId = 0;
                DataTable newTable = GetBusinessProfileByUBPID(Convert.ToInt16(context.Request.QueryString["UBPId"]));
                UBPId = Convert.ToInt16(context.Request.QueryString["UBPId"]);
                MemoryStream memoryStream = new MemoryStream((byte[])newTable.Rows[0]["BusinessLogo"], true);
                System.Drawing.Image imgFromGB = System.Drawing.Image.FromStream(memoryStream);
                imgFromGB.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
        
        private DataTable GetBusinessProfileByUBPID(int UBPID)
        {

            DataTable newTb = new DataTable();
            IDataReader newReader = newDataProvider.GetBusinessProfileByUBPID(UBPID);

            newTb.Load(newReader);

            return newTb;
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