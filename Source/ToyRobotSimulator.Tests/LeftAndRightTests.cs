using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobotSimulator.Tests
{
    [TestClass]
    public class LeftAndRightTests
    {
        Robot robot = new Robot();

        [TestMethod]
        public void Right_Right()
        {
            robot.Command("PLACE 0,0,NORTH");
            Assert.IsFalse(robot.Command("RIGHT").HasErrors);
        }

        [TestMethod]
        public void Right_Wrong()
        {
            robot.Command("PLACE 0,0,NORTH");
            Assert.IsTrue(robot.Command("RIGTHT").HasErrors);
        }

        [TestMethod]
        public void Right_TwoTurnFromNorth()
        {
            robot.Command("PLACE 0,0,NORTH");
            robot.Command("RIGHT");
            robot.Command("RIGHT");
            Assert.AreEqual("0,0,SOUTH", robot.Command("REPORT").Message);
        }

        [TestMethod]
        public void Left_Right()
        {
            robot.Command("PLACE 0,0,NORTH");
            Assert.IsFalse(robot.Command(" LEFT  ").HasErrors);
        }

        [TestMethod]
        public void Left_Wrong()
        {
            robot.Command("PLACE 0,0,NORTH");
            Assert.IsTrue(robot.Command("LEFTE").HasErrors);
        }

        [TestMethod]
        public void Left_ThreeTurnFromNorth()
        {
            robot.Command("PLACE 0,0,NORTH");
            robot.Command("left");
            robot.Command("left");
            robot.Command("left");
            Assert.AreEqual("0,0,EAST", robot.Command("REPORT").Message);
        }
    }
}
