using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace Routing_Application.DAL
{

    public class FA : Algorithm
    {
        public Random ran = new Random();
        private Random randColor = new Random();
        public FA(Network network) : base(network)
        {
        }
        // основной метод
        public List<Individual> Paths_FA(Router startRouter, Router endRouter, List<Individual> population_starting, int N, double y, double b, double a, int Max, int K_paths)
        {
            //danh sach tat ca cac canh
            List<Wire> list_wires = network.Wires;
            //danh sach tat ca cac dinh
            List<Router> list_routers = network.Routers;
            Router[] list_rtrs = new Router[list_routers.Count];
            list_rtrs[0] = startRouter;
            int ii = 1;
            foreach (Router rt in list_routers)
            {
                if (rt != startRouter && rt != endRouter)
                {
                    list_rtrs[ii] = rt;
                    ii++;
                }
            }
            list_rtrs[list_routers.Count - 1] = endRouter;
            //khoi tao cac duong di duoc ma hoa
            int m = list_routers.Count;
            List<Individual> population = new List<Individual>();
            for (int i = 0; i < N; i++)
            {
                population.Add(new Individual());
            }
            for (int i = 0; i < N; i++)
            {
                population[i] = population_starting[i].DeepCopy();
            }
            //danh gia ham muc tieu fitness
            for (int i = 0; i < N; i++)
            {
                double leng = 0;
                foreach (Wire wire in population[i].path_wires)
                {
                    leng = leng + wire.Criterion;
                }
                population[i].fitness = leng;
            }
            // thuat toan FA
            for (int k = 0; k < Max; k++)
            {
                for (int i = 0; i < N-1; i++)
                {
                    for (int j = i+1; j < N; j++)
                    {
                        if (population[i].fitness >= population[j].fitness)
                        {
                            //tong binh phuong khoang cach giua hai dom dom
                            double r2 = 0;
                            for (int j1 = 0; j1 < m; j1++)
                            {
                                double number= population[i].code_path[j1] - population[j].code_path[j1];
                                r2 = r2 + Math.Pow(number, 2);
                            }
                            double beta = b * Math.Exp(-y * r2);
                            double e = ran.NextDouble();
                            //kiem tra invalid population
                            double[] priority = new double[m];
                            for (int j2 = 0; j2 < m; j2++)
                            {
                                priority[j2] = population[i].code_path[j2] + beta*(population[j].code_path[j2] - population[i].code_path[j2]) + a*e;
                                priority[j2] = priority[j2] - (int)priority[j2];
                            }
                            Individual path33 = Particle_Decoding(startRouter, endRouter, priority, list_rtrs);
                            if (path33.path_wires.Count != 0)
                            {
                                population[i].code_path.Clear();
                                for (int j3 = 0; j3 < m; j3++)
                                {
                                    population[i].code_path.Add(priority[j3]);
                                }
                                double leng = 0;
                                population[i].path_wires.Clear();
                                foreach (Wire wire in path33.path_wires)
                                {
                                    population[i].path_wires.Add(wire);
                                    leng = leng + wire.Criterion;
                                }
                                population[i].fitness = leng;
                            }
                        }
                    }
                }
            }
            population.Sort(new NameCompare());
            List<Individual> population_noRepeat = new List<Individual>();
            population_noRepeat.Add(population[0].DeepCopy());
            for (int i = 1; i < N; i++)
            {
                bool dk = true;
                for (int j = 0; j < population_noRepeat.Count; j++)
                {
                    if (Enumerable.SequenceEqual(population[i].path_wires, population_noRepeat[j].path_wires))
                    {
                        dk = false;
                        break;
                    }
                }
                if (dk)
                {
                    population_noRepeat.Add(population[i].DeepCopy());
                }
            }
            return population_noRepeat;
        }
    }
}
