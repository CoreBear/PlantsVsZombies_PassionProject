using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PlantsVsZombies
{
    static class Phase
    {
        static bool gameOver;

        public static void PreGame()
        {
            Menus.Welcome();
            Menus.MainMenu();
        }
        public static void InitGame()
        {
            Program.InitGameClock(new Stopwatch());
            ObjectPooler.InitPooler();
            ObjectSpawner.InitSpawner();
            Program.InitRandomNumber(new Random());
            Program.InitPlayer(new PlayerCursor());
            WaveController.InitWaveCont();
            //Loop.SpriteTestor();
            GameBoard.InitGameBoard();
        }
        public static void DuringGame()
        {
            gameOver = false;
            Program.GetGameClock().Start();

            do
            {
                Loop.Update();
                Loop.Render();
                Loop.TimeStep();
            } while (!gameOver);
        }
        public static void PostGame()
        {
            Menus.GameOver();
        }
        public static void ExitGame()
        {
            Menus.Exit();
        }

        //Setters
        public static void SetGameOver(bool gOver)
        {
            gameOver = gOver;
        }
    }
}
