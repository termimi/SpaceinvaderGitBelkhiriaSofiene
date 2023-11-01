using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Tests
{
    [TestClass()]
    public class AlienTests
    {
        [TestMethod()]
        public void MoveRightTest()
        {
            // arange
            int x = 5;
            int y = 10;
            const int xBase = 5;
            Alien alain = new Alien(x,y);
            //act
            alain.MoveRight();
            //Assert
            Assert.IsTrue(x == xBase +1);
        }
    }
}