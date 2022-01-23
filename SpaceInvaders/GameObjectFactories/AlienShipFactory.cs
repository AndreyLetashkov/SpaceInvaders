using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    class AlienShipFactory : GameObjectFactory
    {
        public AlienShipFactory(GameSettings gameSettings) : base(gameSettings) { }

        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            return new AllianShip { Figuer = GameSettings.AlienShip, GameObjectPlace = objectPlace, GameObjectType = GameObjectType.AlianShip };
        }

        public List<GameObject> GetSwarm()
        {
            List<GameObject> swarm = new List<GameObject>();

            int startX = GameSettings.SwarnStartXCoordinate;
            int startY = GameSettings.SwarnStartYCoordinate;
            for (int y = 0; y < GameSettings.NumberOfSwarnRows; y++)
            {
                for (int x = 0; x < GameSettings.NumberOfSwarnColls; x++)
                {
                    GameObjectPlace objectPlace = new GameObjectPlace() { XCoordinate = startX + x, YCoordinate = startY + y };
                    GameObject alienShip = GetGameObject(objectPlace);
                    swarm.Add(alienShip);
                }
            }
            return swarm;
        }
    }
}