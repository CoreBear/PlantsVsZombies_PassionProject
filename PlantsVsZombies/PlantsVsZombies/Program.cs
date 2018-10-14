using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSPG;
using System.Diagnostics;

namespace PlantsVsZombies
{
    enum PlantTypes { SunFlower = 1, PeaShooter, CherryBomb, WallNut, PotatoMine, GatlingPea, Jalapeno };

    static class Program
    {
        static bool endGame;
        static bool quitGame;
        static bool playGame;
        static PlayerCursor player;
        static Stopwatch gameClock;
        static Random randomNumber;

        static void Main(string[] args)
        {
            SetupWindow();
            RunGame();
        }
        static void SetupWindow()
        {
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.CursorVisible = false;
            Utility.EOLWrap(false);
        }
        static void RunGame()
        {
            do
            {
                endGame = false;
                Phase.PreGame();

                while (!quitGame && playGame && !endGame)
                {
                    Phase.InitGame();
                    Phase.DuringGame();
                    Phase.PostGame();
                }

            } while (!quitGame);

            Phase.ExitGame();
        }
        //Getters
        public static bool GetEndGame()
        {
            return endGame;
        }
        public static bool GetQuitGame()
        {
            return quitGame;
        }
        public static bool GetPlayGame()
        {
            return playGame;
        }
        public static PlayerCursor GetPlayer()
        {
            return player;
        }
        public static Stopwatch GetGameClock()
        {
            return gameClock;
        }
        public static Random GetRandomNumber()
        {
            return randomNumber;
        }

        //Setters
        public static void SetEndGame(bool end)
        {
            endGame = end;
        }
        public static void SetQuitGame(bool quit)
        {
            quitGame = quit;
        }
        public static void SetPlayGame(bool play)
        {
            playGame = play;
        }
        public static void InitPlayer(PlayerCursor playerCursor)
        {
            player = playerCursor;
        }
        public static void InitGameClock(Stopwatch clock)
        {
            gameClock = clock;
        }
        public static void InitRandomNumber(Random random)
        {
            randomNumber = random;
        }
    }
}
