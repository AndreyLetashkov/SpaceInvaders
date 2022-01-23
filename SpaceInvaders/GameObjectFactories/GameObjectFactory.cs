using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    abstract class GameObjectFactory
    {
        public GameSettings GameSettings { get; set;}

        public abstract GameObject GetGameObject(GameObjectPlace objectPlace);

        public GameObjectFactory(GameSettings gameSettings)
        {
            GameSettings = gameSettings;
        }
    }
}
