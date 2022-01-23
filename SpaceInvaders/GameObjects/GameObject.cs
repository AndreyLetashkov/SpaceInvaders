using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    abstract class GameObject
    {
        public GameObjectPlace GameObjectPlace { get; set; }

        public char Figuer { get; set; }

        public GameObjectType GameObjectType { get; set; }
    }
}