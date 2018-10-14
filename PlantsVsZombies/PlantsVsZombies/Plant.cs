using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class Plant : OnScreenObject
    {
        protected bool enabled;
        protected int health;
        protected int maxHealth;
        protected int gridPosition;
        protected int typeOfPlant;
        protected int plantPrice;
        protected int inRow;
        public virtual void Update()
        {

        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Death();
            }
        }
        protected void Death()
        {
            SetEnabled(false);
            ObjectPooler.GetPlants().Remove(this);
            ClearPreviousRender("               ");
        }
        //Getters
        public bool GetEnabled()
        {
            return enabled;
        }
        public int GetMaxHealth()
        {
            return maxHealth;
        }
        public int GetPlantType()
        {
            return typeOfPlant;
        }
        public int GetPlantPrice()
        {
            return plantPrice;
        }
        public int GetGridPosition()
        {
            return gridPosition;
        }
        //Setters
        public void SetEnabled(bool enable)
        {
            enabled = enable;
        }
        public void SetHealth(int hp = 0)
        {
            health = hp;
        }
        public void SetRow()
        {
            for (int i = 0; i < 6; i++)
            {
                if ((int)yPosition == GameBoard.GetGridPosY()[i])
                {
                    inRow = i;
                    break;
                }
            }
        }
        public void SetGridPosition()
        {
            bool finished = false;
            int counter = 0;

            for (int x = 0; x < 10; x++)
            {
                if (!finished)
                {
                    for (int y = 0; y < 6; y++)
                    {
                        if ((int)xPosition == GameBoard.GetGridPosX()[x * 6] + 2 && (int)yPosition == GameBoard.GetGridPosY()[y])
                        {
                            gridPosition = counter;
                            finished = true;
                            break;
                        }
                        counter++;
                    }
                }
            }
        }
    }
}
