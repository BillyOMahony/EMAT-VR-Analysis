using System;
using System.Diagnostics;

namespace EMATVRAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Get a list of names of all files in the data folder
            string[] files = Importer.GetFolderContents("data");
            Console.WriteLine(files.Length + " files have been found");
            
            // Get a list of CSV files in the data folder
            files = Importer.GetCSVFilesFromArray(files);

            Console.WriteLine(files.Length + " csv files have been found");

            // Pre-Process each file and add the EmatVrParticipant to the list
            List<EmatVrParticipant> participants = new List<EmatVrParticipant>();

            foreach (var f in files)
            {
                participants.Add(Processor.ProcessFile(f));
            }

            foreach (var p in participants)
            {
                p.PrintData();
                Console.WriteLine("====================================");
            }

            Console.ReadKey();
        }
    }
}