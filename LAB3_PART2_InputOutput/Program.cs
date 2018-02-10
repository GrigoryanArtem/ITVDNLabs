using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace LAB3_PART2_InputOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = Console.ReadLine();

            var rootDirectory = new DirectoryInfo(".");
            var files = rootDirectory.GetFiles(fileName, SearchOption.TopDirectoryOnly);

            if(files.Count() == 0)
            {
                Console.WriteLine("file not exist");
            }
            else if(files.Count() > 1)
            {
                Console.WriteLine($"finded files:");

                foreach(var file in files)
                    Console.WriteLine(file.Name);
            }
            else
            {
                var file = files.First();

                Console.WriteLine(file.Name);

                using (var reader = file.OpenText())
                {
                    Console.WriteLine(reader.ReadToEnd());
                }

                using (var reader = file.OpenRead())
                {
                    using (GZipStream cmps = new GZipStream(File.Open($"{file.FullName}.zip", FileMode.OpenOrCreate,
                        FileAccess.Write, FileShare.Read), CompressionMode.Compress))
                    {
                        reader.CopyTo(cmps);
                    }
                }
            }
        }
    }
}
