using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class Icons : OnScreenObject
    {
        static string[] SunIcon = new string[3] { " \\^/ ", "< O >", " /v\\ " };   //9X4

        //" \\^/ ",
        //"< O >",
        //" /v\\ "

        static string[] SunFlowerIcon = new string[4] {"3 o oE   ", "3____E   ", "  ||     ", " mmmm  50"};

        //"3 o oE   ",
        //"3____E   ",
        //"  ||  ___",
        //" mmmm |50",

        static string[] PeaShooterIcon = new string[4]{ "\\/ oo\\/\\ ", " \\___/\\/ ", "  ||     ", " mmmm 100" }; 

        //"\\/ oo\\/\\ ",
        //" \\___/\\/ ",
        //"  || ____",
        //" mmmm|100",

        static string[] CherryBombIcon = new string[4] {"    /\\__ ", " __/ /oo\\", "/oo\\ \\--/", "\\--/  150" };

        //"    /\\__ ",
        //" __/ /oo\\",
        //"/oo\\ \\--/",
        //"\\--/ |150",

        static string[] WallNutIcon = new string[4] { " //    \\ ", "||  O O |", "||   -  |", " \\____50" };

        //" //    \\ ",
        //"||  O O |",
        //"||   -__|",
        //" \\___|50",

        static string[] PotatoMineIcon = new string[4] { "   (  )  ", " ___||__ ", "/  O  O_\\", "OoOoOO|25" };
        
        //"   (  )  ",
        //" ___||__ ",
        //"/  O  O_\\",
        //"OoOoOO|25",
           
        static string[] GatlingPeaIcon = new string[4] {"/ _/oo\\/=", "|/\\__/\\=", "   ||____", " mmmm|250"};

        //"/ _/oo\\/=",
        //"|/\\__/\\=", 
        //"   ||____", 
        //" mmmm|250"

        static string[] JalapenoIcon = new string[4] {"__r__   ", "| O o   ", " \\  \\___", "   \\|125"};
        
        //"__r__   ",
        //"| O o   ",
        //" \\  \\___",
        //"   \\|125",
        

    //Getters
    public static string[] GetPeaShooterIcon()
        {
            return PeaShooterIcon;
        }
        public static string[] GetSunIcon()
        {
            return SunIcon;
        }
        public static string[] GetSunFlowerIcon()
        {
            return SunFlowerIcon;
        }
        public static string[] GetCherryBombIcon()
        {
            return CherryBombIcon;
        }
        public static string[] GetWallNutIcon()
        {
            return WallNutIcon;
        }
        public static string[] GetPotatoMineIcon()
        {
            return PotatoMineIcon;
        }
        public static string[] GetGatlingPeaIcon()
        {
            return GatlingPeaIcon;
        }
        public static string[] GetJalapenoIcon()
        {
            return JalapenoIcon;
        }
    }
}
