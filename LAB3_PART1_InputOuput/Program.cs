using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LAB3_PART1_InputOuput
{
    class Program
    {
        private static Random rnd = new Random();

        static void Main(string[] args)
        {
            using (StreamWriter stream = new StreamWriter(File.OpenWrite("temp.txt")))
            {
                stream.Write(GenerateSomeText(100));
            }

            using (var reader = File.OpenText("temp.txt"))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }

        static string GenerateSomeText(int length)
        {
            using (StringWriter sw = new StringWriter())
            {
                for (int i = 0; i < length; i++)
                    sw.Write(GenerateLetter());

                return sw.ToString();
            }
        }

        static char GenerateLetter()
        {
            return (char)rnd.Next('a', 'z');
        }
    }
}
