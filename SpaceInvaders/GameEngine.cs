using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpaceInvaders
{
    class GameEngine
    {
        private bool isNotOwer;
        private static GameEngine gameEngine;
        private Scene scene;
        private GameEngine() { }
        private SceneRender sceneRender;
        private GameSettings gameSettings;
        private GameEngine(GameSettings gameSettings)
        {
            isNotOwer = true;
            scene = Scene.GetScene(gameSettings);
            sceneRender = new SceneRender(gameSettings);
            this.gameSettings = gameSettings;
        }

        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if (gameEngine == null)
            {
                gameEngine = new GameEngine(gameSettings);
            }
            return gameEngine;
        }

        public void Run()
        {
            int swarmMoveCounter = 0;
            int playerMissileCounter = 0;
            do
            {
                sceneRender.Render(scene);
                Thread.Sleep(gameSettings.GameSpeed);
                sceneRender.ClearScreen();

                if (swarmMoveCounter == gameSettings.SwarmSpeed)
                {
                    CalculateSwarnMove();
                    swarmMoveCounter = 0;
                }
                swarmMoveCounter++;

                if (playerMissileCounter == gameSettings.PlayerMissileSpeed)
                {
                    CalculateMissileMove();
                    playerMissileCounter = 0;
                }
                playerMissileCounter++;
            }
            while (isNotOwer);

            Console.ForegroundColor = ConsoleColor.Red;
            sceneRender.RenderGameOwer();
        }

        public void CalculateMovePlayerShipLeft()
        {
            if (scene.playerShip.GameObjectPlace.XCoordinate > 1)
            {
                scene.playerShip.GameObjectPlace.XCoordinate--;
            }
        }

        public void CalculateMovePlayerShipRight()
        {
            if (scene.playerShip.GameObjectPlace.XCoordinate < gameSettings.ConsoleWidth)
            {
                scene.playerShip.GameObjectPlace.XCoordinate++;
            }
        }

        public void CalculateSwarnMove()
        {
            for (int i = 0; i < scene.swarm.Count; i++)
            {
                GameObject alienShip = scene.swarm[i];

                alienShip.GameObjectPlace.YCoordinate++;

                if (alienShip.GameObjectPlace.YCoordinate == scene.playerShip.GameObjectPlace.YCoordinate)
                {
                    isNotOwer = false;
                }
            }
        }

        public void Shot()
        {
            PlayerShipMissileFactory missileFactory = new PlayerShipMissileFactory(gameSettings);
            GameObject missile = missileFactory.GetGameObject(scene.playerShip.GameObjectPlace);
            scene.playerShipMissile.Add(missile);
            Console.Beep(1000, 200);
        }

        public void CalculateMissileMove()
        {
            if (scene.playerShipMissile.Count == 0)
            {
                return;
            }
            for (int i = 0; i < scene.playerShipMissile.Count; i++)
            {
                GameObject missile = scene.playerShipMissile[i];

                if (missile.GameObjectPlace.YCoordinate == 1)
                {
                    scene.playerShipMissile.RemoveAt(i);
                }

                missile.GameObjectPlace.YCoordinate--;

                for (int j = 0; j < scene.swarm.Count; j++)
                {
                    GameObject alianShip = scene.swarm[j];
                    if (missile.GameObjectPlace.Equals(alianShip.GameObjectPlace))
                    {
                        scene.swarm.RemoveAt(j);
                        scene.playerShipMissile.RemoveAt(i);
                        break;
                    }
                }
            }
        }
    }
} 