using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class SunObj : OnScreenObject
    {
        protected bool landed;
        protected bool enabled;
        protected float xSpeed;
        protected float ySpeed;
        protected int sunPoints;
        protected int currentClockForTravel;
        protected int timeForTravel;

        public SunObj()
        {
            timeForTravel = 4000;
            landed = false;
            xSpeed = 0.20f;
            ySpeed = 0.05f;
            sunPoints = 25;
            enabled = false;
            sprite = new string[3] { " \\^/ ", "< O >", " /v\\ " };

            //" \\^/ ",
            //"< O >",
            //" /v\\ "
        }

        public void Update()
        {
            CheckForLanding();
            Move();
        }
        void CheckForLanding()
        {
            if ((int)Program.GetGameClock().ElapsedMilliseconds > currentClockForTravel + timeForTravel)
            {
                landed = true;
            }
        }
        void Move()
        {
            if (!landed)
            {
                ClearPreviousRender("      ");
                xPosition += xSpeed;
                yPosition += ySpeed;
            }
        }

        //Getters
        public bool GetEnabled()
        {
            return enabled;
        }
        public int GetSunPoints()
        {
            return sunPoints;
        }
        //Setters
        public void SetEnabled(bool enable)
        {
            enabled = enable;
        }
        public void SetCurrentClockForTravel(int clock)
        {
            currentClockForTravel = clock;
        }
    }
}
