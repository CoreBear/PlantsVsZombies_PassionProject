using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class BasicWalker : Zombie
    {
        public BasicWalker()
        {
            maxHealth = 100;
            timeBetweenCheckForPlant = 250;
            eatDamage = 2; //about 7ish seconds to eat a plant
            speed = 0.25f;
            sprite = new string[8]{ " |___/   ", "\\/   \\/  ", "|o O /   ", " \\m_/|\\  ", " || || \\ ", " ||\\||_/|", " w__w__||", "(___(___)" };

            //" |___/   ",
            //"\\/   \\/  ",
            //"|o O /   ",
            //" \\m_/|\\  ",
            //" || || \\ ",
            //" ||\\||_/|",
            //" w__w__||",
            //"(___(___)"
        }
    }
}
