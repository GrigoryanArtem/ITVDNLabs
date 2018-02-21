using System;
using System.IO;
using System.Text.RegularExpressions;

namespace LAB4_PART2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string pattern = @"(?<![_\d\p{L}])(?:это|как|так|и|в|над|к|до|не|на|но|за|то|с|ли|а|во|от|со|для|о|же|ну|вы|бы|что|кто|он|она)(?![_\d\p{L}])";
            string filename = Console.ReadLine();

            try
            {
                using (var file = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
                {
                    using (var reader = new StreamReader(file))
                    {
                        using (var writer = new StreamWriter(file))
                        {
                            string result = Regex.Replace(reader.ReadToEnd(), pattern, @"ГАВ!");
                            file.Position = 0;
                            writer.Write(result);
                        }
                    }
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine($"File {filename} not found.");
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
