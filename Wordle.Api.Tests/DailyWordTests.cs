using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Controllers;
using Wordle.Api.Data;

namespace Wordle.Api.Tests;
[TestClass]
public class DailyWordTests : DatabaseBaseTests
{
    [TestMethod]
    public void GetDailyWord()
    {
        using var context = new TestAppDbContext(Options);
        Word.SeedWords(context);

        DateWordController sut = new(context, new Services.GameService(context));

        string? word = sut.GetDailyWord(new DateTime(2020, 1, 1));
        Assert.IsNotNull(word);
        Assert.AreEqual<int>(5, word.Length);
        string? word2 = sut.GetDailyWord(new DateTime(2020, 1, 1));
        Assert.AreEqual<string?>(word, word2);
    }
}
