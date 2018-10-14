using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    static class Tools
    {
        public static int ErrorCheckedMenu(int min, int max, string[] text)
        {
            bool invalid;
            int playerDecision = 0;
            string[] invalidText = { "Invalid Option", "Press ENTER to try again" };

            do
            {
                try
                {
                    Console.Clear();
                    MenuWriter(text);
                    playerDecision = int.Parse(Console.ReadLine());
                    if (playerDecision < min || playerDecision > max)
                        throw new Exception();
                    invalid = false;
                }
                catch
                {
                    Console.Clear();
                    MenuWriter(invalidText);
                    invalid = true;
                    Console.ReadLine();
                }
            } while (invalid);

            

            return playerDecision;
        }
        public static void EasyWriter(int xPos, int yPos, string text)
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(text);
        }
        public static void MenuWriter(string[] text)
        {
            Console.Clear();
            for (int i = 0; i < text.Length; i++)
            {
                if (i < text.Length - 1)
                    EasyWriter(Console.WindowWidth / 2 - text[i].Length / 2, Console.WindowHeight / text.Length * (i + 1), text[i]);
                else
                    EasyWriter(Console.WindowWidth / 2 - text[i].Length / 2, Console.WindowHeight - 1, text[i]);
            }
        }
    }
}
