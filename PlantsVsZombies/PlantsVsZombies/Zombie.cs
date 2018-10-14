using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    class Zombie : OnScreenObject
    {
        protected bool walk;
        protected bool enabled;
        protected float speed;
        protected int health;
        protected int maxHealth;
        protected int eatDamage;
        protected int timeBetweenCheckForPlant;
        protected int currentClockForPlantCheck;
        

        public Zombie()
        {
            enabled = false;
            currentClockForPlantCheck = (int)Program.GetGameClock().ElapsedMilliseconds;
        }
        public void Update()
        {
            GameOver();
            CheckForPlant();
            Move();
        }
        public override void Render()
        {
            for (int a = 0; a < sprite.Length; a++)
            {
                for (int b = 0; b < sprite[a].Length; b++)
                {
                    if ((int)xPosition + b < Console.WindowWidth)
                        Tools.EasyWriter((int)xPosition + b, (int)yPosition + a, sprite[a][b].ToString());
                }
            }
        }
        void CheckForPlant()
        {
            if ((int)Program.GetGameClock().ElapsedMilliseconds > currentClockForPlantCheck + timeBetweenCheckForPlant)
            {
                Plant currentThreat = null;

                foreach (var plant in ObjectPooler.GetPlants())
                {
                    if (plant.GetEnabled())
                    {
                        if (((int)xPosition >= (int)plant.GetX() + 16 && (int)xPosition <= (int)plant.GetX() + 17) && (int)yPosition == (int)plant.GetY())
                        {
                            if (plant.GetPlantType() != (int)PlantTypes.PotatoMine && plant.GetPlantType() != (int)PlantTypes.Jalapeno && plant.GetPlantType() != (int)PlantTypes.CherryBomb)
                            { 
                            walk = false;
                            currentThreat = plant;
                            Eat(currentThreat);
                            break;
                            }
                        }
                    }
                }
                if (currentThreat != null && !currentThreat.GetEnabled())
                    walk = true;
            }
        }
        void GameOver()
        {
            if ((int)xPosition < 1)
            {
                Phase.SetGameOver(true);
                Program.SetEndGame(true);
            }
        }
        void Move()
        {
            if (walk)
            {
                ClearPreviousRender("         ");
                xPosition -= speed;
            }
        }
        void Eat(Plant plant)
        {
            plant.TakeDamage(eatDamage);
        }
        public void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                Death();
            }
        }
        public void Death()
        {
            SetEnabled(false);
            ClearPreviousRender("         ");
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

        //Setters
        public void SetEnabled(bool enable)
        {
            enabled = enable;
        }
        public void SetWalk(bool move)
        {
            walk = move;
        }
        public void SetHealth(int hp)
        {
            health = hp;
        }
        
    }
}
