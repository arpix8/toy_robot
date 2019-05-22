using System;
using System.Collections.Generic;
using System.Linq;

namespace ToyRobotSimulator
{
    public class Robot
    {
        // input
        private string[] commands;
        private List<string> baseCommands = new List<string>()
        {
            Constants.CMD_PLACE,
            Constants.CMD_MOVE,
            Constants.CMD_LEFT,
            Constants.CMD_RIGHT,
            Constants.CMD_REPORT
        };
        private List<string> faceCommands = new List<string>()
        {
            Constants.CMD_FACE_NORTH,
            Constants.CMD_FACE_SOUTH,
            Constants.CMD_FACE_WEST,
            Constants.CMD_FACE_EAST
        };

        // robot properties
        public bool isPlaced = false;
        public int posX, posY;
        public string posFace;
            
        public OperationResult Command(string input)
        {
            try
            {
                if (TryParse(input) == false)
                    return new OperationResult()
                    {
                        HasErrors = true,
                        Message = Constants.MSG_INPUT_ERROR
                    };

                string result = String.Empty;

                switch (commands[0])
                {
                    case Constants.CMD_PLACE:
                        Place(Int32.Parse(commands[1]), Int32.Parse(commands[2]), commands[3]);
                        result = Constants.MSG_SUCCESS;
                        break;
                    case Constants.CMD_MOVE:
                        if (!isPlaced) throw new Exception(Constants.MSG_ROBOT_NOT_PLACED);
                        Move();
                        result = Constants.MSG_SUCCESS;
                        break;
                    case Constants.CMD_LEFT:
                        if (!isPlaced) throw new Exception(Constants.MSG_ROBOT_NOT_PLACED);
                        Turn(Constants.CMD_LEFT);
                        result = Constants.MSG_SUCCESS;
                        break;
                    case Constants.CMD_RIGHT:
                        if (!isPlaced) throw new Exception(Constants.MSG_ROBOT_NOT_PLACED);
                        Turn(Constants.CMD_RIGHT);
                        result = Constants.MSG_SUCCESS;
                        break;
                    case Constants.CMD_REPORT:
                        if (!isPlaced) throw new Exception(Constants.MSG_ROBOT_NOT_PLACED);
                        result = String.Format("{0},{1},{2}", posX, posY, posFace);
                        break;
                }

                return new OperationResult()
                {
                    HasErrors = false,
                    Message = result
                };
            }
            catch (Exception ex)
            {
                return new OperationResult()
                {
                    HasErrors = true,
                    Message = ex.Message
                };
            }
        }

        /// <summary>
        /// Validate and parse the input.
        /// </summary>
        /// <returns>True if input is valid.</returns>
        private bool TryParse(string input)
        {
            var tempCommands = input.Trim().ToUpper().Split(new char[] { ',', ' ' });
            var firstCommand = tempCommands[0];

            // validation
            if (String.IsNullOrEmpty(firstCommand) || String.IsNullOrWhiteSpace(firstCommand))
                return false;

            if (baseCommands.Any(x => x == firstCommand) == false)
                return false;

            if (firstCommand == Constants.CMD_PLACE)
            {
                if (tempCommands.Length != 4 ||
                    Int32.TryParse(tempCommands[1], out int x) == false ||
                    Int32.TryParse(tempCommands[2], out int y) == false ||
                    faceCommands.Any(cmd => cmd == tempCommands[3]) == false)
                    return false;
            }

            // parse
            commands = tempCommands;
            return true;
        }

        /// <summary>
        /// Place robot on table by user input
        /// </summary>
        public void Place(int placeX, int placeY, string face)
        {
            if (placeX < Constants.TABLE_MIN_X || placeX > Constants.TABLE_MAX_X || 
                placeY < Constants.TABLE_MIN_Y || placeY > Constants.TABLE_MAX_Y)
                throw new Exception(Constants.MSG_ROBOT_OUTSIDE);

            if (faceCommands.Any(x => x == face) == false)
                throw new Exception(Constants.MSG_INPUT_ERROR);
            
            // set coordinators
            posX = placeX;
            posY = placeY;
            posFace = face;
            isPlaced = true;   
        }

        /// <summary>
        /// Turn left or right the robot
        /// </summary>
        public void Turn(string side)
        {
            // side must be left or right
            bool sideRight = side == Constants.CMD_RIGHT ? true : false;

            switch (posFace)
            {
                case Constants.CMD_FACE_NORTH:
                    posFace = sideRight ? Constants.CMD_FACE_EAST : Constants.CMD_FACE_WEST;
                    break;
                case Constants.CMD_FACE_SOUTH:
                    posFace = sideRight ? Constants.CMD_FACE_WEST : Constants.CMD_FACE_EAST;
                    break;
                case Constants.CMD_FACE_WEST:
                    posFace = sideRight ? Constants.CMD_FACE_NORTH : Constants.CMD_FACE_SOUTH;
                    break;
                case Constants.CMD_FACE_EAST:
                    posFace = sideRight ? Constants.CMD_FACE_SOUTH : Constants.CMD_FACE_NORTH;
                    break;
            }
        }

        /// <summary>
        /// Move robot
        /// </summary>
        public void Move()
        {
            switch (posFace)
            {
                case Constants.CMD_FACE_NORTH:
                    if (posY + 1 > Constants.TABLE_MAX_Y)
                        throw new Exception(Constants.MSG_ROBOT_OUTSIDE);
                    posY++;
                    break;
                case Constants.CMD_FACE_SOUTH:
                    if (posY - 1 < Constants.TABLE_MIN_Y)
                        throw new Exception(Constants.MSG_ROBOT_OUTSIDE);
                    posY--;
                    break;
                case Constants.CMD_FACE_WEST:
                    if (posX - 1 < Constants.TABLE_MIN_X)
                        throw new Exception(Constants.MSG_ROBOT_OUTSIDE);
                    posX--;
                    break;
                case Constants.CMD_FACE_EAST:
                    if (posX + 1 > Constants.TABLE_MAX_X)
                        throw new Exception(Constants.MSG_ROBOT_OUTSIDE);
                    posX++;
                    break;
            }
        }
    }
}
