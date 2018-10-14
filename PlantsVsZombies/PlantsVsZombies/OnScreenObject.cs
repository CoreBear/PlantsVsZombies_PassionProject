using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class OnScreenObject
    {
        protected float xPosition, yPosition;
        protected string[] sprite;

        public virtual void Render()
        {
            for (int i = 0; i < sprite.Length; i++)
            {
                Tools.EasyWriter((int)xPosition, (int)yPosition + i, sprite[i]);
            }
        }
        public virtual void ClearPreviousRender(string spacesForCovering)

        {
            int prevX = (int)xPosition;
            int prevY = (int)yPosition;
            for (int i = 0; i < sprite.Length; i++)
            {
                Tools.EasyWriter(prevX, prevY + i, spacesForCovering);
            }
        }

        //Getters
        public float GetX()
        {
            return xPosition;
        }
        public float GetY()
        {
            return yPosition;
        }

        //Setters
        public void SetPosition(float xPos, float yPos)
        {
            xPosition = xPos;
            yPosition = yPos;
        }
    }
}
