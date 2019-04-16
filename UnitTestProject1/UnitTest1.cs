using System;
using Infrastructure.Interfaces;
using Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Prawda()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void False()
        {
            Assert.IsFalse(false);
        }

        [TestMethod]
        public void ConsoleService()
        {
            //arrange
            var cs = new MockedConsoleService();
            var sit = new AskQuestion(cs);
            var expected = "Szyna kolejowa";

            //act
            sit.AskQuestion(expected);

            //assert
            Assert.Equals(expected);
        }
    }

    public class MockedConsoleService : IConsoleService
}
