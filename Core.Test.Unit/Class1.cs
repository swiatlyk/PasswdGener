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
        public void AskQuestion_displayMessageOnConsole()
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

        [Theory]
        [InlineData('t', true)]
        [InlineData('T', true)]
        [InlineData('f', false)]
        [InlineData('F', false)]
        public void AskQuestion_returnsProper(char response, bool expected)
        {
            //arrange
            var cs = new MockedConsoleService();
            var sit = new AskQuestionService(cs);
            cs.Response = response;
            

            //act
            var actual = sit.AskQuestion("szyna kolejowa");

            //assert
            Assert.Equal(expected, actual);
        }
    }

    public class AskQuestionService
    {
        private IConsoleService cs;

        public AskQuestionService(IConsoleService cs)
        {
            this.cs = cs;
        }

        public bool AskQuestion(string tekst)
        {            
            cs.ConsoleWriteLine(tekst);
            var response = cs.ConsoleReadKey();
            return response == 't' || response == 'T';
        }
    }

    public class MockedConsoleService : IConsoleService
    {
        public string DisplayText { get; set; }
        public char Response { get; set; }

        public char ConsoleReadKey()
        {
            return Response;
        }

        public void ConsoleWriteLine(string tekst)
        {
            DisplayText = tekst;
        }
    }
}
