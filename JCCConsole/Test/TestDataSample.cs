using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCCConsole.Test
{
    public class TestDataSample
    {
        const string samplePath = "..\\..\\..\\Data\\";
        public static string GetPdfPath(string filename)
        {
            return GetFilePath(filename, "PDF");
        }
        public static string GetWordPath(string filename)
        {
            return GetFilePath(filename, "Word");
        }


        public static string GetExcelPath(string filename)
        {
            return GetFilePath(filename, "Excel");
        }
    
        public static string GetFilePath(string filename, string subFolder)
        {
            string path = samplePath.Replace('\\', Path.DirectorySeparatorChar);
            if (!path.EndsWith(string.Empty + Path.DirectorySeparatorChar))
            {
                path += Path.DirectorySeparatorChar;
            }
            if (subFolder == null)
                return path + filename;
            else
                return path + subFolder + Path.DirectorySeparatorChar + filename;
        }
    }
}
