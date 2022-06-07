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
        public void GetDailyGame_SamePlayer_NewContext()
        {
        }

    [TestMethod]
    public void GetDailyGame_DifferentPlayers_NewContext()
    {
    }

    [TestMethod]
    public void GetDailyGameNoDateFails()
    {
    }

    [TestMethod]
    [Ignore("Passes when running alone, fails when running with other tests")]
    public void GetDailyGameThatIsFinished()
    {
    }


}
