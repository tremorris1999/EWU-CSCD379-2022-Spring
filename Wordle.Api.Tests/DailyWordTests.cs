using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Controllers;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests;
[TestClass]
public class DailyWordTests : DatabaseBaseTests
{
    [TestMethod]
    public void GetDailyWord()
    {
    }

    [TestMethod]
    public void GetDailyGame()
    {
    }

    [TestMethod]
    public void GetDailyGameNoDateFails()
    {

    }

    [Ignore("Needs a bit more work to get the same game to come back.")]
    [TestMethod]
    public void GetDailyGameThatIsFinished()
    {
    }


}
