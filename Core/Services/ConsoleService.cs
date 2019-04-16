using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ConsoleService : IConsoleService

    {
        public void ConsoleWriteLine(string tekst)
        {
            Console.WriteLine(tekst);
        }
    }
}
