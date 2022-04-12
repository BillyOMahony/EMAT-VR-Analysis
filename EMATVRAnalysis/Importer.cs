using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMATVRAnalysis
{
    public static class Importer
    {
        public static string[] GetFolderContents(string path)
        {
            string[] result = null;
            try
            {
                result = Directory.GetFiles(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }

        public static string[] GetCSVFilesFromArray(string[] files)
        {
            List<string> output = new List<string>();

            foreach (var t in files)
            {
                FileInfo fi = new FileInfo(t);
                if (fi.Extension.Equals(".csv"))
                {
                    Console.WriteLine(fi.Extension);
                    output.Add(t);
                }
            }

            return output.ToArray();
        }


    }
}
