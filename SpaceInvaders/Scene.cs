using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    class Scene
    {
        private static Scene scene;

        public List<GameObject> swarm;

        public List<GameObject> ground;

        public List<GameObject> playerShipMissile;

        public GameObject playerShip;

        GameSettings gameSettings;

        private Scene() { }

        private Scene(GameSettings gameSettings) 
        {
            this.gameSettings = gameSettings;
            swarm = new AlienShipFactory(this.gameSettings).GetSwarm();
            ground = new GraundFactory(this.gameSettings).GetGraund();
            playerShip = new PlayerShipFactory(this.gameSettings).GetGameObject();
            playerShipMissile = new List<GameObject>();
        }

        public static Scene GetScene(GameSettings gameSettings)
        {
            if (scene == null)
            {
                scene = new Scene(gameSettings);
            }
            return scene;
        }
    }
}