using LAB1_UserCollections.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1_UserCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            CitizenCollection cc = new CitizenCollection { new Student(1), new Pensioner(2), new Worker(3), new Worker(4), new Pensioner(5)};

            Console.WriteLine($"Count: {cc.Count}");
            Console.WriteLine($"Elements: {cc}");
            Console.WriteLine(cc.Contains(new Student(1)));
            Console.WriteLine($"Last: {cc.Last()}");
            cc.Remove(new Worker(3)); cc.Remove();
            Console.WriteLine($"Elements: {cc}");
            cc.Remove(); cc.Remove();
            Console.WriteLine($"Elements: {cc}");
            cc.Clear();
            Console.WriteLine($"Elements: {cc}");
        }
    }
}
