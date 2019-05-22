namespace ToyRobotSimulator
{
    public class Constants
    {
        // square tabletop size
        public const int TABLE_MAX_X = 5;
        public const int TABLE_MAX_Y = 5;
        public const int TABLE_MIN_X = 0;
        public const int TABLE_MIN_Y = 0;

        // commands
        public const string CMD_PLACE = "PLACE";
        public const string CMD_MOVE = "MOVE";
        public const string CMD_LEFT = "LEFT";
        public const string CMD_RIGHT = "RIGHT";
        public const string CMD_REPORT = "REPORT";

        public const string CMD_FACE_NORTH = "NORTH";
        public const string CMD_FACE_SOUTH = "SOUTH";
        public const string CMD_FACE_WEST = "WEST";
        public const string CMD_FACE_EAST = "EAST";

        // messages
        public const string MSG_INPUT_ERROR = "Invalid syntax. Please retry.";
        public const string MSG_ROBOT_NOT_PLACED = "Invalid. The robot has not yet been placed.";
        public const string MSG_ROBOT_OUTSIDE = "Ignored. Robot cannot goes outside the table.";
        public const string MSG_SUCCESS = "Success!";
    }
}
