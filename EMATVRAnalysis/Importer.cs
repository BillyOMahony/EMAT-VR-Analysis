using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMATVRAnalysis
{
    public class Importer
    {
        public Importer()
        {

        }

        public string[] GetFolderContents(string path)
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

        public bool IsAGreaterThanB(int a, int b)
        {
            return a > b;
        }
    }
}
