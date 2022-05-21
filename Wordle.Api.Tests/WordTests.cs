using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests
{
    [TestClass]
    public class WordTests : DatabaseBaseTests
    {
        [TestMethod]
        public void SeedWords()
        {
            // This uses the short Words.csv file in the test project.
            using var context = new TestAppDbContext(Options);
            Word.SeedWords(context, "WordsTest.csv");
            Assert.AreEqual(72,context.Words.Count());
            Assert.AreEqual(23, context.Words.Count(f=>f.Common));
        }

    }
}
