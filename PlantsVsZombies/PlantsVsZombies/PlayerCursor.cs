using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSPG;

namespace PlantsVsZombies
{
    class PlayerCursor : OnScreenObject
    {
        bool collecting;
        bool moving;
        bool dropping;
        int currentPlant;
        int currentPlantsPrice;
        int xMoveDist;
        int yMoveDist;
        int sunPoints;

        public PlayerCursor()
        {
            sunPoints = 100;
            currentPlant = 1;
            xMoveDist = 20;
            yMoveDist = 9;
            xPosition = 19;
            yPosition = 6;
            sprite = new string[8] {"                   ", "                   ", "                   ", "                   ",
                                    "                   ", "                   ", "                   ", "                   ", }; //19X8
        }
        public void Update()
        {
            MoveCursor();
            SelectPlant();
            PlacePlant();
            PickUpSun();
        }
        public override void Render()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;
            base.Render();
            Console.BackgroundColor = ConsoleColor.Black;
        }
        void MoveCursor()
        {
            if (!Utility.GetKeyState(ConsoleKey.J) && !Utility.GetKeyState(ConsoleKey.K) && !Utility.GetKeyState(ConsoleKey.L) && !Utility.GetKeyState(ConsoleKey.I))
                moving = false;
            else
            {
                if (Utility.GetKeyState(ConsoleKey.J) && !moving && xPosition > 38)
                {
                    ClearPreviousRender("                   ");
                    xPosition -= xMoveDist;
                    moving = true;
                }
                if (Utility.GetKeyState(ConsoleKey.L) && !moving && xPosition < 180)
                {
                    ClearPreviousRender("                   ");
                    xPosition += xMoveDist;
                    moving = true;
                }
                if (Utility.GetKeyState(ConsoleKey.I) && !moving && yPosition > 14)
                {
                    ClearPreviousRender("                   ");
                    yPosition -= yMoveDist;
                    moving = true;
                }
                if (Utility.GetKeyState(ConsoleKey.K) && !moving && yPosition < 43)
                {
                    ClearPreviousRender("                   ");
                    yPosition += yMoveDist;
                    moving = true;
                }
            }
        }
        void SelectPlant()
        {
            if (Utility.GetKeyState(ConsoleKey.D1))
                currentPlant = (int)PlantTypes.SunFlower;
            else if (Utility.GetKeyState(ConsoleKey.D2))
                currentPlant = (int)PlantTypes.PeaShooter;
            else if (Utility.GetKeyState(ConsoleKey.D3))
                currentPlant = (int)PlantTypes.CherryBomb;
            else if (Utility.GetKeyState(ConsoleKey.D4))
                currentPlant = (int)PlantTypes.WallNut;
            else if (Utility.GetKeyState(ConsoleKey.D5))
                currentPlant = (int)PlantTypes.PotatoMine;
            else if (Utility.GetKeyState(ConsoleKey.D6))
                currentPlant = (int)PlantTypes.GatlingPea;
            else if (Utility.GetKeyState(ConsoleKey.D7))
                currentPlant = (int)PlantTypes.Jalapeno;
        }
        void PlacePlant()
        {
            if (!Utility.GetKeyState(ConsoleKey.Spacebar))
                dropping = false;
            else if (Utility.GetKeyState(ConsoleKey.Spacebar) && !dropping)
            {
                switch (currentPlant)
                {
                    case (int)PlantTypes.SunFlower:
                        currentPlantsPrice = 50;
                        break;
                    case (int)PlantTypes.PeaShooter:
                        currentPlantsPrice = 100;
                        break;
                    case (int)PlantTypes.CherryBomb:
                        currentPlantsPrice = 150;
                        break;
                    case (int)PlantTypes.WallNut:
                        currentPlantsPrice = 50;
                        break;
                    case (int)PlantTypes.PotatoMine:
                        currentPlantsPrice = 25;
                        break;
                    case (int)PlantTypes.GatlingPea:
                        currentPlantsPrice = 250;
                        break;
                    case (int)PlantTypes.Jalapeno:
                        currentPlantsPrice = 125;
                        break;
                }
                if (sunPoints >= currentPlantsPrice)
                {
                    for (int i = 0; i < GameBoard.GetGrids().Length; i++)
                    {
                        if (GameBoard.GetGrids()[i])
                        {
                            if ((int)xPosition == GameBoard.GetGridPosX()[i] && (int)yPosition == GameBoard.GetGridPosY()[i])
                                return;
                        }
                    }
                    ObjectSpawner.SpawnPlant(xPosition, yPosition, currentPlant);
                    dropping = true;
                }
            }
        }
        void PickUpSun()
        {
            if (!Utility.GetKeyState(ConsoleKey.F))
                collecting = false;
            else if (Utility.GetKeyState(ConsoleKey.F) && !collecting)
            {
                for (int i = 0; i < ObjectPooler.GetSuns().Count; i++)
                {
                    if (ObjectPooler.GetSuns()[i].GetEnabled())
                    {
                        if (((int)ObjectPooler.GetSuns()[i].GetX() > xPosition - 2 && (int)ObjectPooler.GetSuns()[i].GetX() < xPosition + 19) && 
                            ((int)ObjectPooler.GetSuns()[i].GetY() >= yPosition && (int)ObjectPooler.GetSuns()[i].GetY() < yPosition + 8))
                        {
                            AddSunPoints(ObjectPooler.GetSuns()[i].GetSunPoints());
                            ObjectPooler.GetSuns()[i].SetEnabled(false);
                            ObjectPooler.GetSuns()[i].ClearPreviousRender("     ");
                            ObjectPooler.GetSuns().Remove(ObjectPooler.GetSuns()[i]);
                        }
                    }
                }
                collecting = true;
            }
        }
        void AddSunPoints(int points)
        {
            sunPoints += points;
        }

        //Others
        public void DeductSunPoints(int points)
        {
            sunPoints -= points;
        }

        //Getters
        public int GetSunPoints()
        {
            return sunPoints;
        }
    }
}
