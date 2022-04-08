using System;

namespace EMATVRAnalysis // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Importer import = new Importer();

            string[] files = import.GetFolderContents("data");
            Console.WriteLine(files.Length + " files have been found:");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine(files[i]);
            }

            Console.ReadKey();
        }
    }
}