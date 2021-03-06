using System;
using System.Threading;

namespace SpaceInvaders
{
    class Program
    {
        static GameEngine gameEngine;
        static GameSettings gameSettings;
        static UIController uIController;
        static MusicController musicController;

        static void Main()
        {
            Initialize();
            gameEngine.Run();
        }

        public static void Initialize()
        {
            gameSettings = new GameSettings();
            gameEngine = GameEngine.GetGameEngine(gameSettings);
            uIController = new UIController();
            uIController.OnAPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipLeft();
            uIController.OnDPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipRight();
            uIController.OnSpacePressed += (obj, arg) => gameEngine.Shot();
            Thread uIthread = new Thread(uIController.StartListning);
            uIthread.Start();
            musicController = new MusicController();
            Thread musicThread = new Thread(musicController.PlayBackgroundMusic);
            musicThread.Start();
            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
        }
    }
}