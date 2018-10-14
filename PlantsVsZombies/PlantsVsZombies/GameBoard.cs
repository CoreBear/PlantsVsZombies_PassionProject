using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    static class GameBoard
    {
        static char[] mapCharacters;
        static int timeBetweenChecks;
        static int currentCheckTime;
        static bool[] grid;
        enum SquareState { Plant, Zombie, Empty};
        static string[] squareStateHolder;
        static int[] gridPositionsX;
        static int[] gridPositionsY;
        static bool[] rowInUseByZombie;

        public static void InitGameBoard()
        {
            mapCharacters = new char[3]{ '|', '+', '-'};
            timeBetweenChecks = 250;
            currentCheckTime = (int)Program.GetGameClock().ElapsedMilliseconds;
            gridPositionsX = new int[60];
            gridPositionsY = new int[60];
            int intCount = 0;

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    gridPositionsX[intCount] = 19 + (20 * x);
                    gridPositionsY[intCount] = 6 + (9 * y);
                    intCount++;
                }
            }
            grid = new bool[60];
            squareStateHolder = new string[60];
            rowInUseByZombie = new bool[6];
            RenderMap();
        }
        public static void RenderMap()
        {
            for (int x = 0; x < Console.WindowWidth; x++)
            {
                for (int y = 0; y < Console.WindowHeight; y++)
                {
                    PlantIconBoxes(x, y, mapCharacters);
                    TopBoxes(x, y, mapCharacters);
                    Board(x, y, mapCharacters);
                }
            }
        }
        public static void Update()
        {
            if ((int)Program.GetGameClock().ElapsedMilliseconds > currentCheckTime + timeBetweenChecks)
            {
                FireLine();
                WriteSunScore();
                SquaresInUse();
                RowsInUse();
                currentCheckTime = (int)Program.GetGameClock().ElapsedMilliseconds;
            }
        }
        static void FireLine()
        {
            for (int y = 0; y < Console.WindowHeight; y++)
            {
                if (y > 4 && y < Console.WindowHeight - 3)
                {
                    Tools.EasyWriter(218, y, mapCharacters[0].ToString());
                }

            }            
        }
        public static void PlantIconBoxes(int x, int y, char[] character)
        {
            if ((x == 0 || x == 10) && ((y > 8 && y < 13) || (y > 15 && y < 20) || (y > 22 && y < 27) || (y > 29 && y < 34) || (y > 36 && y < 41) || (y > 43 && y < 48) || (y > 50 && y < 55)))
                Tools.EasyWriter(x, y, character[0].ToString());
            if ((x == 0 || x == 10) && (y == 8 || y == 13 || y == 15 || y == 20 || y == 22 || y == 27 || y == 29 || y == 34 || y == 36 || y == 41 || y == 43 || y == 48 || y == 50 || y == 55))
                Tools.EasyWriter(x, y, character[1].ToString());
            if ((x > 0 && x < 10) && (y == 8 || y == 13 || y == 15 || y == 20 || y == 22|| y == 27 || y == 29 || y == 34 || y == 36 || y == 41 || y == 43 || y == 48 || y == 50 || y == 55))
                Tools.EasyWriter(x, y, character[2].ToString());

            if (x == 1 && y == 9)
            {
                for (int i = 0; i < Icons.GetSunFlowerIcon().Length; i++)
                {
                    Tools.EasyWriter(x, y + i, Icons.GetSunFlowerIcon()[i]);
                }
            }
            if (x == 1 && y == 16)
            {
                for (int i = 0; i < Icons.GetPeaShooterIcon().Length; i++)
                {
                    Tools.EasyWriter(x, y + i, Icons.GetPeaShooterIcon()[i]);
                }
            }
            if (x == 1 && y == 23)
            {
                for (int i = 0; i < Icons.GetCherryBombIcon().Length; i++)
                {
                    Tools.EasyWriter(x, y + i, Icons.GetCherryBombIcon()[i]);
                }
            }
            if (x == 1 && y == 30)
            {
                for (int i = 0; i < Icons.GetWallNutIcon().Length; i++)
                {
                    Tools.EasyWriter(x, y + i, Icons.GetWallNutIcon()[i]);
                }
            }
            if (x == 1 && y == 37)
            {
                for (int i = 0; i < Icons.GetPotatoMineIcon().Length; i++)
                {
                    Tools.EasyWriter(x, y + i, Icons.GetPotatoMineIcon()[i]);
                }
            }
            if (x == 1 && y == 44)
            {
                for (int i = 0; i < Icons.GetGatlingPeaIcon().Length; i++)
                {
                    Tools.EasyWriter(x, y + i, Icons.GetGatlingPeaIcon()[i]);
                }
            }
            if (x == 1 && y == 51)
            {
                for (int i = 0; i < Icons.GetJalapenoIcon().Length; i++)
                {
                    Tools.EasyWriter(x, y + i, Icons.GetJalapenoIcon()[i]);
                }
            }
        } //9X4
        static void TopBoxes(int x, int y, char[] character)
        {
            if ((x == 20 || x == 26 || x == 45) && (y > 0 && y < 4))
                Tools.EasyWriter(x, y, character[0].ToString());
            if ((x == 20 || x == 45) && (y == 0 || y == 4))
                Tools.EasyWriter(x, y, character[1].ToString());
            if ((x > 20 && x < 45) && (y == 0 || y == 4))
                Tools.EasyWriter(x, y, character[2].ToString());

            if (x == 21 && y == 1)
            {
                for (int i = 0; i < Icons.GetSunIcon().Length; i++)
                {
                    Tools.EasyWriter(x, y + i, Icons.GetSunIcon()[i]);
                }
            }
        }
        static void Board(int x, int y, char[] character)
        {
            if (x == 18 && (y > 4 && y < Console.WindowHeight - 3))
                Tools.EasyWriter(x, y, character[0].ToString());
            if ((x == 18 || x == 38 || x == 58 || x == 78 || x == 98 || x == 118 || x == 138 || x == 158 || x == 178 || x == 198) && (y == 5 || y == 14 || y == 23 || y == 32 || y == 41 || y == 50 || y == 59))
                Tools.EasyWriter(x, y, character[1].ToString());
            else if (x > 18 && (y == 5 || y == 14 || y == 23 || y == 32 || y == 41 || y == 50 || y == 59))
                Tools.EasyWriter(x, y, character[2].ToString());
        }
        static void WriteSunScore()
        {
            for (int i = 0; i < 4; i++)
            {
                Tools.EasyWriter(28 + i, 2, " ");
            }
            Tools.EasyWriter(28, 2, Program.GetPlayer().GetSunPoints().ToString());
        }
        static void SquaresInUse()
        {
            for (int i = 0; i < 60; i++)
            {
                grid[i] = false;
                squareStateHolder[i] = SquareState.Empty.ToString();
            }
            foreach (var plant in ObjectPooler.GetPlants())
            {
                if (plant.GetEnabled())
                {
                    bool[] gridXPlant = new bool[60];
                    bool[] gridYPlant = new bool[60];

                    for (int gridPos = 0; gridPos < 2; gridPos++)
                    {
                        for (int i = 0; i < 60; i++)
                        {
                            if (gridPos == 0)
                            {
                                if ((int)plant.GetX() == gridPositionsX[i] + 2)
                                {
                                    gridXPlant[i] = true;
                                }
                            }
                            else
                            {
                                if ((int)plant.GetY() == gridPositionsY[i])
                                {
                                    gridYPlant[i] = true;
                                }
                            }
                        }
                    }
                    for (int i = 0; i < 60; i++)
                    {
                        if (gridXPlant[i] == true && gridYPlant[i] == true)
                        {
                            grid[i] = true;
                            squareStateHolder[i] = SquareState.Plant.ToString();
                        }
                    }
                }
            }
            foreach (var zombie in ObjectPooler.GetZombies())
            {
                if (zombie.GetEnabled())
                {
                    bool[] gridXZombie = new bool[60];
                    bool[] gridYZombie = new bool[60];

                    for (int gridPos = 0; gridPos < 2; gridPos++)
                    {
                        for (int i = 0; i < 60; i++)
                        {
                            if (gridPos == 0)
                            {
                                if ((int)zombie.GetX() >= gridPositionsX[i] - 7 && (int)zombie.GetX() < gridPositionsX[i] + 20)
                                {
                                    gridXZombie[i] = true;
                                }
                            }
                            else
                            {
                                if ((int)zombie.GetY() == gridPositionsY[i])
                                {
                                    gridYZombie[i] = true;
                                }
                            }
                        }
                    }
                    for (int i = 0; i < 60; i++)
                    {
                        if (gridXZombie[i] == true && gridYZombie[i] == true)
                        {
                            grid[i] = true;
                            squareStateHolder[i] = SquareState.Zombie.ToString();
                        }
                    }
                }
            }
        }
        static void RowsInUse()
        {
            for (int i = 0; i < 6; i++)
            {
                rowInUseByZombie[i] = false;
            }

            int counter = 0;

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    switch (y)
                    {
                        case 0:
                            if (squareStateHolder[counter].Equals("Zombie"))
                                rowInUseByZombie[y] = true;
                            break;
                        case 1:
                            if (squareStateHolder[counter].Equals("Zombie"))
                                rowInUseByZombie[y] = true;
                            break;
                        case 2:
                            if (squareStateHolder[counter].Equals("Zombie"))
                                rowInUseByZombie[y] = true;
                            break;
                        case 3:
                            if (squareStateHolder[counter].Equals("Zombie"))
                                rowInUseByZombie[y] = true;
                            break;
                        case 4:
                            if (squareStateHolder[counter].Equals("Zombie"))
                                rowInUseByZombie[y] = true;
                            break;
                        case 5:
                            if (squareStateHolder[counter].Equals("Zombie"))
                                rowInUseByZombie[y] = true;
                            break;
                    }
                    counter++;
                }
            }
        }

        //Getters
        public static bool[] GetGrids()
        {
            return grid;
        }
        public static string[] GetSSS()
        {
            return squareStateHolder;
        }
        public static int[] GetGridPosX()
        {
            return gridPositionsX;
        }
        public static int[] GetGridPosY()
        {
            return gridPositionsY;
        }
        public static bool[] GetRowInUseByZombie()
        {
            return rowInUseByZombie;
        }
    }
}
    
