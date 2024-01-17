using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Food_Site
{
    public class Connection
    {
       public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["cs"].ConnectionString; 
        }
    }


    public class Utils
    {
        public static bool IsValidExtention(string filenName)
        {
            bool isValid = false;
            string[] fileExtension = {".jpg",".png",".jpeg" };
            for(int i = 0; i <= fileExtension.Length - 1; i++) {
                if (filenName.Contains(fileExtension[i]))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
         }
    }
}