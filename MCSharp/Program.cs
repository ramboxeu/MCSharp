using System;
using MCSharp.Source;
using System.IO;

namespace MCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Add argument parser

            // Find source files
            SourceFiles.GatherSourceFiles(Directory.GetCurrentDirectory());

            foreach (SourceFile file in SourceFiles.GetSourceFiles()) {
                Console.WriteLine(file.Name);
            }

            Console.ReadKey();
        }
    }
}
