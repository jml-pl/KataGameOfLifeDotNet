using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace GameOfLifeTests
{
    [TestClass]
    public class UnitTest1
    {

        private string Expected = String.Join(
           Environment.NewLine,
                "5 5",
                ".....",
                ".....",
                ".***.",
                ".....",
                ".....");

        [TestMethod]
        public void TestMethod1()
        {

            string boardFile = String.Join(
                Environment.NewLine,
                "5 5",
                ".....",
                "..*..",
                "..*..",
                "..*..",
                ".....");

            string[] boardsLines = boardFile.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                GameOfLife.Program.PrintBoard(GameOfLife.Program.Tick(boardsLines));

                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected, result);
            }
        }
    }
}
