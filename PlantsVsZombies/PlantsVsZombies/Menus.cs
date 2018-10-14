using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    static class Menus
    {
        public static void Welcome()
        {
            string[] text = { "Welcome to my version of Zombies Vs Plants!", "Press ENTER to continue" };
            Tools.MenuWriter(text);
            Console.ReadLine();
        }
        public static void MainMenu()
        {
            int playerDecision;
            string[] text = { "1. Start Game", "2. Game Options", "3. Exit Game", "Press corresponding number, then press ENTER to continue" };

            do
            {
                playerDecision = Tools.ErrorCheckedMenu(1, 3, text);

                switch (playerDecision)
                {
                    case 1:
                        Program.SetPlayGame(true);
                        break;
                    case 2:
                        Options();
                        break;
                    case 3:
                        Program.SetQuitGame(true);
                        break;
                }
            } while (!Program.GetQuitGame() && !Program.GetPlayGame());

            Console.Clear();
        }
        static void Options()
        {
            string[] text = { "Use this later", "Press ENTER to continue" };
            Tools.MenuWriter(text);
            Console.ReadLine();
        }
        public static void Pause()
        {

        }
        public static void GameOver()
        {
            string[] text = { "The zombies ate your brains!", "Press ENTER to continue" };
            Tools.MenuWriter(text);
            Console.ReadLine();
        }
        public static void Exit()
        {
            string[] text = { "You're now exiting my Zombies Vs. Plants game!", "Press ENTER to continue" };
            Tools.MenuWriter(text);
            Console.ReadLine();
        }
    }
}
