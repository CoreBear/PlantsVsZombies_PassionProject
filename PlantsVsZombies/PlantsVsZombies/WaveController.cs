using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantsVsZombies
{
    static class WaveController
    {
        static bool waveInProgress;
        static int currentClockForSpawn;
        static int currentClockForWave;
        static int timeBeforeWave;
        static int timeBetweenSpawns;

        public static void InitWaveCont()
        {
            waveInProgress = false;
            currentClockForSpawn = (int)Program.GetGameClock().ElapsedMilliseconds;
            currentClockForWave = (int)Program.GetGameClock().ElapsedMilliseconds;
            timeBeforeWave = 10000;
            timeBetweenSpawns = 5000;
        }
        public static void Update()
        {
            if (waveInProgress)
            {
                if ((int)Program.GetGameClock().ElapsedMilliseconds > currentClockForSpawn + timeBetweenSpawns)
                {
                    ObjectSpawner.SpawnZombie();
                    currentClockForSpawn = (int)Program.GetGameClock().ElapsedMilliseconds;
                }
            }
            else
            {
                if ((int)Program.GetGameClock().ElapsedMilliseconds > timeBeforeWave)
                    StartWave();
            }
        }        
        static void StartWave()
        {
            waveInProgress = true;
        }
        static void EndWave()
        {
            waveInProgress = false;
        }
    }
}
