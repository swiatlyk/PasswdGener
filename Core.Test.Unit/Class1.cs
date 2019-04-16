using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Core.Services;
using Xunit;

namespace Core.Test.Unit
{
    public class Class1
    {
        [Fact]
        public void ConsoleService()
        {
            //arrange
            var cs = new MockedConsoleService();
            var sit = new AskQuestionService(cs);
            var expected = "szyna kolejowa";

            //act
            sit.AskQuestion(expected);

            //assert
            Assert.Equal(expected, cs.DisplayText);
        }
    }

    public class AskQuestionService
    {
        private IConsoleService cs;

        public AskQuestionService(IConsoleService cs)
        {
            this.cs = cs;
        }

        public void AskQuestion(string tekst)
        {
            cs.ConsoleWriteLine(tekst);
            //cs.ConsoleWriteLine("szyna kolejowa2");

        }
    }

    public class MockedConsoleService : IConsoleService
    {
        public string DisplayText { get; set; }
        public void ConsoleWriteLine(string tekst)
        {
            DisplayText = tekst;
        }
    }
}
