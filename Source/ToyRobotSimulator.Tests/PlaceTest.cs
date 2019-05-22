using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobotSimulator.Tests
{
    [TestClass]
    public class PlaceTest
    {
        Robot robot = new Robot();

        [TestMethod]
        public void Place_Upper_Right()
        {
            Assert.IsFalse(robot.Command("PLACE 0,0,NORTH").HasErrors);
        }

        [TestMethod]
        public void Place_Lower_Right()
        {
            Assert.IsFalse(robot.Command("place 0,0,north").HasErrors);
        }

        [TestMethod]
        public void Place_SpaceStartEnd_Right()
        {
            Assert.IsFalse(robot.Command(" place 0,0,north ").HasErrors);
        }

        [TestMethod]
        public void Place_SpacesBefore_Wrong()
        {
            Assert.IsTrue(robot.Command("place 0 ,0,north").HasErrors);
        }

        [TestMethod]
        public void Place_SpacesAfter_Wrong()
        {
            Assert.IsTrue(robot.Command("place 0, 0,north").HasErrors);
        }

        [TestMethod]
        public void Place_SpacesBoth_Wrong()
        {
            Assert.IsTrue(robot.Command("place 0 , 0,n").HasErrors);
        }

        [TestMethod]
        public void Place_OutOfX_Wrong()
        {
            Assert.IsTrue(robot.Command("place 6,0,n").HasErrors);
        }

        [TestMethod]
        public void Place_OutOfY_Wrong()
        {
            Assert.IsTrue(robot.Command("place 0,6,n").HasErrors);
        }

        [TestMethod]
        public void Place_NotFirst_Wrong()
        {
            Assert.IsTrue(robot.Command("MOVE").HasErrors);
        }

        [TestMethod]
        public void Place_WrongPlaceAfterRightPlace()
        {
            robot.Command("PLACE 0,0,NORTH");
            robot.Command("PLACE 6,6,NORTH");
            Assert.AreEqual("0,0,NORTH", robot.Command("REPORT").Message);
        }
    }
}
