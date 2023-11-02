using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Model.Tests
{
    [TestClass()]
    public class MissileAlienTests
    {
        [TestMethod()]
        public void MissileUpdateTest()
        {
            // arange
            int x = 5;
            int _y = 10;
            Alien alain = new Alien(x, _y);
            MissileAlien missile = new MissileAlien(alain);
            missile.y = _y;
            //act
            missile.MissileUpdate();
            //Assert
            Assert.IsTrue(missile.y == _y + 1);
        }

        [TestMethod()]
        public void MissileUpdateTest1()
        {
            // arange
            int x = 5;
            int _y = 10;
            Alien alain = new Alien(x, _y);
            MissileAlien missile = new MissileAlien(alain);
            missile.y = _y;
            //act
            while (missile.y < MissileAlien.SCREENHEIGHT)
            {
                missile.MissileUpdate();
            }
            //Assert
            Assert.IsFalse(missile.missileLaunched);
        }
    }
}