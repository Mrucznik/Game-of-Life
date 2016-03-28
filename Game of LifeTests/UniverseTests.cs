using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game_of_Life;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life.Tests
{
    [TestClass()]
    public class UniverseTests
    {
        Universe universe;
        public UniverseTests()
        {
            universe = new Universe();
        }
    }
}