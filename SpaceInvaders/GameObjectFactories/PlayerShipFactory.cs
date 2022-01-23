using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    class PlayerShipFactory : GameObjectFactory
    {
        public PlayerShipFactory(GameSettings gameSettings) : base(gameSettings) { }


        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {

            GameObject gameObject = new PlayerShip() { Figuer = GameSettings.PlayerShip, GameObjectPlace = objectPlace, GameObjectType = GameObjectType.PlayerShip };
            return gameObject;
        }

        public GameObject GetGameObject()
        {
            GameObjectPlace gameObjectPlace = new GameObjectPlace() { XCoordinate = GameSettings.PlayerShipStartXCoordinate, YCoordinate = GameSettings.PlayerShipStartYCoordinate };
            return GetGameObject(gameObjectPlace);
        }
    }
}