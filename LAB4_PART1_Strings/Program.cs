using LAB4_PART1_Strings.Model;
using System;
using System.IO;

namespace LAB4_PART1_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var hpp = new HTMLPageParser(@"http://onu.edu.ua/ru/");

            using (var writer = File.CreateText("report.txt"))
            {
                writer.WriteLine(@"- Links -");
                writer.WriteLine(String.Join(writer.NewLine, hpp.GetAllLinks()));

                writer.WriteLine(@"- Phones -");
                writer.WriteLine(String.Join(writer.NewLine, hpp.GetAllPhones()));

                writer.WriteLine(@"- Addresses -");
                writer.WriteLine(String.Join(writer.NewLine, hpp.GetAllAddresses()));
            }
        }
    }
}
