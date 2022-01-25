using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
namespace Routing_Application.DAL
{

    public class CreateKPaths : Algorithm
    {
        public Random ran = new Random();
        private Random randColor = new Random();
        public List<Color> mausac = new List<Color> { Color.Green, Color.Red, Color.Blue, Color.Yellow, Color.Orange, Color.Violet };
        public CreateKPaths(Network network) : base(network)
        {
        }
        // основной метод
        public List<double> Create(List<Individual> population_noRepeat ,int K_paths)
        {
            // нахождение k-кратчайшие пути
            List<Individual> PATHS = new List<Individual>();
            for(int i = 0; i < K_paths; i++)
            {
                PATHS.Add(population_noRepeat[i]);
            }
            //tinh gia tri cho bang ket qua
            double sum1 = 0;
            double ss = 0;
            double CD = 0;
            List<double> ketqua_0 = new List<double>();
            for (int k1 = 0; k1 < K_paths; k1++)
            {
                ketqua_0.Add(PATHS[k1].fitness);
                CD += PATHS[k1].fitness;
            }
            List<double> ketqua_1 = new List<double>();
            for (int k1 = 0; k1 < K_paths; k1++)
            {
                sum1 += (1 / PATHS[k1].fitness);
            }
            for (int k1 = 0; k1 < K_paths-1; k1++)
            {
                double round = (1 / PATHS[k1].fitness)*100 / sum1;
                round = Math.Round(round, 1);
                ss = ss + round;
                ketqua_1.Add(round);
            }
            ketqua_1.Add(100 - ss);
            List<double> ketqua_2 = new List<double>();
            for (int k1 = 0; k1 < K_paths; k1++)
            {
                double round = PATHS[k1].fitness / PATHS[k1].path_wires.Count;
                ketqua_2.Add(Math.Round(round,1));
            }
            List<double> ketqua_3 = new List<double>();
            for (int k1 = 0; k1 < K_paths; k1++)
            {
                double x = PATHS[k1].fitness / PATHS[k1].path_wires.Count;
                double sum2 = 0;
                foreach (Wire wire in PATHS[k1].path_wires)
                {
                    sum2 += ((x - wire.Criterion) * (x - wire.Criterion));
                }
                double sd = Math.Sqrt(sum2 / PATHS[k1].path_wires.Count);
                ketqua_3.Add(Math.Round(sd,1));
            }
            List<double>[] minmax = new List<double>[K_paths];
            for (int k1 = 0; k1 < K_paths; k1++)
            {
                minmax[k1] = new List<double>();
            }
                for (int k1 = 0; k1 < K_paths; k1++)
            {
                double mn = 99999;
                double mx = 0;
                foreach (Wire wire in PATHS[k1].path_wires)
                {
                    if (mn > wire.Criterion)
                    {
                        mn = wire.Criterion;
                    }
                    if(mx < wire.Criterion)
                    {
                        mx = wire.Criterion;
                    }
                }
                minmax[k1].Add(mx);
                minmax[k1].Add(mn);
            }
            double jiter = (1 - PATHS[0].fitness / PATHS[K_paths-1].fitness) * 100;
            jiter = Math.Round(jiter,1);
            List<Wire> all_wires = new List<Wire>();
            for (int k1 = 0; k1 < K_paths; k1++)
            {
                all_wires.AddRange(PATHS[k1].path_wires);
            }
            List<Wire> truoc = new List<Wire>();
            List<Wire> no_repeat = new List<Wire>();
            List<Wire> repeat = new List<Wire>();
            for (int i = 0; i < all_wires.Count; i++)
            {
                if (!truoc.Contains(all_wires[i]))
                {
                    no_repeat.Add(all_wires[i]);
                }
                if (truoc.Contains(all_wires[i]))
                {
                    repeat.Add(all_wires[i]);
                }
                truoc.Add(all_wires[i]);
            }
            // вычисление количество вхождений ребер
            foreach (Wire wire in no_repeat)
            {
                foreach (Wire wires in all_wires)
                {
                    if (wire == wires)
                    {
                        wire.NumberRepeat++;
                    }
                }
            }
            // окраска путей
            List<Color> color = new List<Color>();
            for (int k1 = 0; k1 < K_paths; k1++)
            {
                    foreach (Wire wire in PATHS[k1].path_wires)
                    {
                        Pen ppp = new Pen(mausac[k1], 4 * (wire.NumberRepeat));
                        wire.Pen = ppp;
                    }
            }
            List<List<int>> result_int = new List<List<int>>();
            for (int k1 = 0; k1 < K_paths; k1++)
            {
                List<int> aa = new List<int>();
                for (int k2 = 0; k2 < PATHS[k1].path_routers.Count(); k2++)
                {
                    aa.Add(PATHS[k1].path_routers[k2].Number);
                }
                result_int.Add(new List<int>(aa));
            }
            List<string> result = new List<string>();
            for (int k1 = 0; k1 < K_paths; k1++)
            {
                string result_1 = string.Join(",", result_int[k1]);
                result.Add(result_1);
            }
            CreateResult(result);
            return ketqua_0;
        }
        public void CreateResult(List<string> result)
        {
            File.WriteAllLines("Result.txt", result);
        }
    }
}
