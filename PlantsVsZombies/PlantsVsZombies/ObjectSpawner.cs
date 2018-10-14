using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    static class ObjectSpawner
    {
        static int[] ySpawnPositions;
        public static void InitSpawner()
        {
            ySpawnPositions = new int[6]{ 6, 15, 24, 33, 42, 51 };
            SpawnMowers();
        }
        public static void SpawnZombie()
        {
            foreach (var zombie in ObjectPooler.GetZombies())
            {
                if (!zombie.GetEnabled())
                {
                    zombie.SetEnabled(true);
                    zombie.SetPosition(239, ySpawnPositions[Program.GetRandomNumber().Next() % ySpawnPositions.Length]);
                    zombie.SetWalk(true);
                    zombie.SetHealth(zombie.GetMaxHealth());
                    break;
                }
            }
        }
        static void SpawnMowers()
        {
            for (int i = 0; i < ObjectPooler.GetMowers().Count; i++)
            {
                ObjectPooler.GetMowers()[i].SetPosition(1, ySpawnPositions[i]);
                ObjectPooler.GetMowers()[i].Render();
            }
        }
        public static void SpawnPlant(float xPos, float yPos, int plantType)
        {
            Plant plant = null;

            switch (plantType)
            {
                case 1:
                    plant = new SunFlower();
                    break;
                case 2:
                    plant = new PeaShooter();
                    break;
                case 3:
                    plant = new CherryBomb();
                    break;
                case 4:
                    plant = new WallNut();
                    break;
                case 5:
                    plant = new PotatoMine();
                    break;
                case 6:
                    plant = new GatlingPea();
                    break;
                case 7:
                    plant = new Jalapeno();
                    break;
            }


            plant.SetEnabled(true);
            if (plant.GetPlantType() != (int)PlantTypes.GatlingPea)
                plant.SetPosition(xPos + 2, yPos);
            else
                plant.SetPosition(xPos, yPos);
            plant.SetRow();
            plant.SetGridPosition();
            plant.SetHealth(plant.GetMaxHealth());
            ObjectPooler.GetPlants().Add(plant);
            Program.GetPlayer().DeductSunPoints(plant.GetPlantPrice());
        }
        public static void SpawnProjectile(float xPos, float yPos)
        {
            foreach (var projectile in ObjectPooler.GetProjectiles())
            {
                if (!projectile.GetEnabled())
                {
                    projectile.SetEnabled(true);
                    projectile.SetPosition(xPos + 11, yPos + 2);
                    break;
                }
            }
        }
        public static void SpawnSun(float xPos, float yPos)
        {
            SunObj sun = new SunObj();
            sun.SetEnabled(true);
            sun.SetPosition(xPos, yPos);
            ObjectPooler.GetSuns().Add(sun);
            sun.SetCurrentClockForTravel((int)Program.GetGameClock().ElapsedMilliseconds);
        }
    }
}
