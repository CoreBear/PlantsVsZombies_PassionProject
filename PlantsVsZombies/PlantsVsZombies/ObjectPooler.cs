using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    static class ObjectPooler
    {
        static int numberOfMowersToPool;
        static int numberOfProjectilesToPool;
        static int numberOfZombiesToPool;
        static List<Mower> mowers;
        static List<Plant> plants;
        static List<SunObj> suns;
        static Projectile[] projectiles;
        static Zombie[] zombies;     


        public static void InitPooler()
        {
            numberOfMowersToPool = 6;
            numberOfProjectilesToPool = 100;
            numberOfZombiesToPool = 20;
            mowers = new List<Mower>(numberOfMowersToPool);
            plants = new List<Plant>(1);
            suns = new List<SunObj>(1);
            projectiles = new Projectile[numberOfProjectilesToPool];
            zombies = new Zombie[numberOfZombiesToPool];
            PoolMowers();
            PoolProjectiles();
            PoolZombies();
        }
        static void PoolMowers()
        {
            for (int i = 0; i < mowers.Capacity; i++)
            {
                mowers.Add(new Mower());
            }
        }
        static void PoolProjectiles()
        {
            for (int i = 0; i < projectiles.Length; i++)
            {
                projectiles[i] = new PeaProjectile();
            }
        }
        static void PoolZombies()
        {
            for (int i = 0; i < zombies.Length; i++)
            {
                zombies[i] = new BasicWalker();
            }
        }

        //Getters
        public static List<Plant> GetPlants()
        {
            return plants;
        }
        public static Zombie[] GetZombies()
        {
            return zombies;
        }
        public static List<Mower> GetMowers()
        {
            return mowers;
        }
        public static Projectile[] GetProjectiles()
        {
            return projectiles;
        }
        public static List<SunObj> GetSuns()
        {
            return suns;
        }
    }
}
