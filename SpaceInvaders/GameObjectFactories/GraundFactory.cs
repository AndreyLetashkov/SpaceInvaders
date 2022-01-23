using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    class GraundFactory : GameObjectFactory
    {
        public GraundFactory(GameSettings gameSettings) : base(gameSettings) { }

        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            return new GroundObject { Figuer = GameSettings.Ground, GameObjectPlace = objectPlace, GameObjectType = GameObjectType.GroundObject };
        }

        public List<GameObject> GetGraund()
        {
            List<GameObject> graund = new List<GameObject>();

            int startX = GameSettings.GroundStartXCoordinate;
            int startY = GameSettings.GroundStartYCoordinate;
            for (int y = 0; y < GameSettings.NumberOfGroundRows; y++)
            {
                for (int x = 0; x < GameSettings.NumberOfGroundColls; x++)
                {
                    GameObjectPlace objectPlace = new GameObjectPlace() { XCoordinate = startX + x, YCoordinate = startY + y };
                    GameObject graundObj = GetGameObject(objectPlace);
                    graund.Add(graundObj);
                }
            }
            return graund;
        }
    }
}