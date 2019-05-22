using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobotSimulator.Tests
{
    [TestClass]
    public class MoveTest
    {
        Robot robot = new Robot();

        [TestMethod]
        public void Move_OutsideWest_Wrong()
        {
            robot.Command("PLACE 0,0,NORTH");
            robot.Command("LEFT");
            Assert.IsTrue(robot.Command("MOVE").HasErrors);
        }

        [TestMethod]
        public void Move_FiveNorth_Right()
        {
            robot.Command("PLACE 0,0,NORTH");
            robot.Command("MOVE");
            robot.Command("MOVE");
            robot.Command("MOVE");
            robot.Command("MOVE");
            robot.Command("MOVE");
            Assert.AreEqual("0,5,NORTH", robot.Command("REPORT").Message);
        }

        [TestMethod]
        public void Move_OutsidSouth_Wrong()
        {
            robot.Command("PLACE 0,2,NORTH");
            robot.Command("LEFT");
            robot.Command("LEFT");
            robot.Command("MOVE");
            robot.Command("MOVE");
            Assert.IsTrue(robot.Command("MOVE").HasErrors);
        }

        [TestMethod]
        public void Move_Path1_Right()
        {
            robot.Command("PLACE 1,2,EAST");
            robot.Command("MOVE");
            robot.Command("MOVE");
            robot.Command("LEFT");
            robot.Command("MOVE");
            robot.Command("REPORT");
            Assert.AreEqual("3,3,NORTH", robot.Command("REPORT").Message);
        }
    }
}
