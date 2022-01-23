using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    class SceneRender
    {
        int screenWhith;
        int screenHight;

        char[,] screenMatrix;

        public SceneRender(GameSettings gameSettings)
        {
            screenWhith = gameSettings.ConsoleWidth;
            screenHight = gameSettings.ConsoleHight;
            screenMatrix = new char[gameSettings.ConsoleHight, gameSettings.ConsoleWidth];

            Console.WindowHeight = gameSettings.ConsoleHight;
            Console.WindowWidth = gameSettings.ConsoleWidth;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        public void Render(Scene scene)
        {
            ClearScreen();           
            Console.SetCursorPosition(0, 0);
            AddListForRendering(scene.swarm);
            AddListForRendering(scene.ground);
            AddListForRendering(scene.playerShipMissile);

            AddGameObjectForRendering(scene.playerShip);

            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < screenHight; y++)
            {
                for (int x = 0; x < screenWhith; x++)
                {
                    stringBuilder.Append(screenMatrix[y, x]);
                }
                stringBuilder.Append(Environment.NewLine);
            }

            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);
        }

        public void AddGameObjectForRendering(GameObject gameObject)
        {
            if (gameObject.GameObjectPlace.YCoordinate < screenMatrix.GetLength(0) &&
                gameObject.GameObjectPlace.XCoordinate < screenMatrix.GetLength(1))
            {
                screenMatrix[gameObject.GameObjectPlace.YCoordinate, gameObject.GameObjectPlace.XCoordinate] = gameObject.Figuer;
            }
        }

        public void AddListForRendering(List<GameObject> gameObjects)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                AddGameObjectForRendering(gameObject);
            }
        }

        public void ClearScreen()
        {
            for (int y = 0; y < screenHight; y++)
            {
                for (int x = 0; x < screenWhith; x++)
                {
                    screenMatrix[y, x] = ' ';
                }
            }
            Console.SetCursorPosition(0, 0);
        }

        public void RenderGameOwer()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Game Ower!!!!!");
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}