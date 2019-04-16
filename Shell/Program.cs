using System;
using Core.Services;

namespace Shell
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var rnd = new Random();

            Console.WriteLine("<-------          Password Generator          ------->");
            Console.WriteLine("<-------          Generates password          ------->");
            Console.WriteLine("<-------Generate password from 8 to 128 chars ------->");
            new PassGetService().AskPassword(rnd);
            Console.ReadKey();
        }
    }
}