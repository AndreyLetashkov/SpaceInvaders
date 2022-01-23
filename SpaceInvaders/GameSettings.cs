using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    class GameSettings
    {
        public int ConsoleWidth { get; set; } = 80;

        public int ConsoleHight { get; set; } = 30;


        public int NumberOfSwarnRows { get; set; } = 2;

        public int NumberOfSwarnColls { get; set; } = 60;

        public int NumberOfGroundRows { get; set; } = 1;

        public int NumberOfGroundColls { get; set; } = 80;


        public char Ground { get; set; } = 'п';

        public char PlayerShip { get; set; } = '^';

        public char AlienShip { get; set; } = 'o';

        public char PlayerMissile { get; set; } = '|';


        public int SwarnStartXCoordinate { get; set; } = 10;

        public int SwarnStartYCoordinate { get; set; } = 2;

        public int PlayerShipStartXCoordinate { get; set; } = 40;

        public int PlayerShipStartYCoordinate { get; set; } = 19;

        public int GroundStartXCoordinate { get; set; } = 1;

        public int GroundStartYCoordinate { get; set; } = 20;


        public int SwarmSpeed { get; set; } = 20;

        public int PlayerMissileSpeed { get; set; } = 5;

        public int GameSpeed { get; set; } = 100;
    }
}