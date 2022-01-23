using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    class PlayerShipMissileFactory : GameObjectFactory
    {
        public PlayerShipMissileFactory(GameSettings gameSettings) : base(gameSettings) {}

        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObjectPlace missilePlase = new GameObjectPlace() { XCoordinate = objectPlace.XCoordinate, YCoordinate = objectPlace.YCoordinate - 1 };
            return new PlayerShipMissle() { Figuer = GameSettings.PlayerMissile, GameObjectPlace = missilePlase, GameObjectType = GameObjectType.PlaerShipMissile };
        }
    }
}