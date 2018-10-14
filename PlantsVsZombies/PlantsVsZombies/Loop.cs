using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSPG;
using System.Threading;

namespace PlantsVsZombies
{
    static class Loop
    {
        const int sixtyFPS = 33;

        public static void Update()
        {
            Utility.LockConsole(true);
            Program.GetPlayer().Update();
            GameBoard.Update();
            WaveController.Update();
            for (int i = 0; i < ObjectPooler.GetPlants().Count; i++)
            {
                if (ObjectPooler.GetPlants()[i].GetEnabled())
                    ObjectPooler.GetPlants()[i].Update();
            }
            foreach (var zombie in ObjectPooler.GetZombies())
            {
                if (zombie.GetEnabled())
                    zombie.Update();
            }
                    
            foreach (var projectile in ObjectPooler.GetProjectiles())
            {
                if (projectile.GetEnabled())
                    projectile.Update();
            }
            for (int i = 0; i < ObjectPooler.GetMowers().Count; i++)
            {
                if (ObjectPooler.GetMowers()[i].GetWaiting())
                    ObjectPooler.GetMowers()[i].Update();
            }
            for (int i = 0; i < ObjectPooler.GetSuns().Count; i++)
            {
                if (ObjectPooler.GetSuns()[i].GetEnabled())
                    ObjectPooler.GetSuns()[i].Update();
            }
            Utility.LockConsole(false);
        }
        public static void Render()
        {
            Utility.LockConsole(true);
            Program.GetPlayer().Render();
            //LineTestor();
            //SpriteTestor();
            for (int i = 0; i < ObjectPooler.GetPlants().Count; i++)
            {
                if (ObjectPooler.GetPlants()[i].GetEnabled())
                    ObjectPooler.GetPlants()[i].Render();
            }
            foreach (var zombie in ObjectPooler.GetZombies())
            {
                if (zombie.GetEnabled())
                    zombie.Render();
            }
            
            foreach (var projectile in ObjectPooler.GetProjectiles())
            {
                if (projectile.GetEnabled())
                    projectile.Render();
            }
            foreach (var mower in ObjectPooler.GetMowers())
            {
                if (mower.GetEnabled())
                    mower.Render();
            }

            for (int i = 0; i < ObjectPooler.GetSuns().Count; i++)
            {
                if (ObjectPooler.GetSuns()[i].GetEnabled())
                    ObjectPooler.GetSuns()[i].Render();
            }
            Utility.LockConsole(false);
        }
        public static void TimeStep()
        {
            Thread.Sleep(sixtyFPS);
        }
        public static void LineTestor()
        {
            for (int i = 0; i < ObjectPooler.GetPlants().Count; i++)
            {
                Tools.EasyWriter(25, 0 + i, ObjectPooler.GetPlants()[i].GetX().ToString());
                Tools.EasyWriter(50, 0 + i, ObjectPooler.GetPlants()[i].GetY().ToString());
                Tools.EasyWriter(75, 0 + i, ObjectPooler.GetPlants()[i].GetGridPosition().ToString());
            }
            for(int i = 0; i < GameBoard.GetGridPosX().Length; i++)
            { 
                Tools.EasyWriter(100, 0 + i, GameBoard.GetGridPosX()[i].ToString());
            }
            for (int i = 0; i < GameBoard.GetGridPosY().Length; i++)
            {
                Tools.EasyWriter(125, 0 + i, GameBoard.GetGridPosY()[i].ToString());
            }
            //for (int i = 0; i < GameBoard.GetGrids().Length; i++)
            //{
            //    Tools.EasyWriter(100, 0 + i, GameBoard.GetGrids()[i].ToString());
            //}
            //for (int i = 0; i < GameBoard.GetSSS().Length; i++)
            //{
            //    Tools.EasyWriter(50, 0 + i, GameBoard.GetSSS()[i]);
            //}
        }
        public static void SpriteTestor()
        {
            //string[] sprite = {
            //"         ",
            //"         ",
            //"|        ",
            //" \m_/|\  ",
            //" || || \ ",
            //" ||\||_/|",
            //" w__w__||",
            //"(___(___)"

            //for (int i = 0; i < sprite.Length; i++)
            //{
            //    Tools.EasyWriter(100, 50 + i, sprite[i]);
            //}
        }
    }
}
