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
            K_paths = K_paths + 2;
            List<Individual> best_populations = new List<Individual>();
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
                    double[] priority = new double[m];
                    bool dk = true;
                    double e = ran.NextDouble();
                    for (int j = i+1; j < N; j++)
                    {
                        if (population[i].fitness >= population[j].fitness)
                        {
                            dk = false;
                            //tong binh phuong khoang cach giua hai dom dom
                            double r2 = 0;
                            for (int j1 = 0; j1 < m; j1++)
                            {
                                double number= population[i].code_path[j1] - population[j].code_path[j1];
                                r2 = r2 + Math.Pow(number, 2);
                            }
                            double beta = b * Math.Exp(-y * r2);
                            for (int j2 = 0; j2 < m; j2++)
                            {
                                priority[j2] = population[i].code_path[j2] + beta*(population[j].code_path[j2] - population[i].code_path[j2]) + a*e;
                            }
                            break;
                        }
                    }
                    if (dk)
                    {
                        for (int j2 = 0; j2 < m; j2++)
                        {
                            priority[j2] = population[i].code_path[j2] + a * e;
                        }
                    }
                        //scale to -1;1
         laplai:    double mn = double.MaxValue;
                    double mx = double.MinValue;
                    for (int j2 = 0; j2 < m; j2++)
                    {
                        if (mn > priority[j2])
                        {
                            mn = priority[j2];
                        }
                        if (mx < priority[j2])
                        {
                            mx = priority[j2];
                        }
                    }
                    double[] priority_2 = new double[m];
                    for (int j2 = 0; j2 < m; j2++)
                    {
                        priority_2[j2] = -1 + 2 * (priority[j2] - mn) / (mx - mn);
                    }
                    Individual path33 = Particle_Decoding(startRouter, endRouter, priority_2, list_rtrs);
                    if (path33.path_wires.Count != 0)
                    {
                        population[i].code_path.Clear();
                        for (int j3 = 0; j3 < m; j3++)
                        {
                            population[i].code_path.Add(priority_2[j3]);
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
                    else
                    {
                        double e_2 = ran.NextDouble();
                        for (int j2 = 0; j2 < m; j2++)
                        {
                            priority[j2] = priority[j2]-a*e+a*e_2;
                        }
                        goto laplai;
                    }
                }
                //tim k duong tot nhat tai iteration thu k
                population.Sort(new NameCompare());
                List<Individual> best = new List<Individual>();
                best.Add(population[0].DeepCopy());
                for (int i = 1; i < N; i++)
                {
                    if (best.Count == K_paths)
                    {
                        break;
                    }
                    bool dk = true;
                    for (int j = 0; j < best.Count; j++)
                    {
                        if (Enumerable.SequenceEqual(population[i].path_wires, best[j].path_wires))
                        {
                            dk = false;
                            break;
                        }
                    }
                    if (dk)
                    {
                        best.Add(population[i].DeepCopy());
                    }
                }
                foreach (Individual indiv in best)
                {
                    best_populations.Add(indiv.DeepCopy());
                }
            }
            //tim k duong tot nhat
            best_populations.Sort(new NameCompare());
            List<Individual> population_norepeat = new List<Individual>();
            population_norepeat.Add(best_populations[0].DeepCopy());
            for (int i = 1; i < best_populations.Count; i++)
            {
                bool dk = true;
                for (int j = 0; j < population_norepeat.Count; j++)
                {
                    if (Enumerable.SequenceEqual(best_populations[i].path_wires, population_norepeat[j].path_wires))
                    {
                        dk = false;
                        break;
                    }
                }
                if (dk)
                {
                    population_norepeat.Add(best_populations[i].DeepCopy());
                }
            }
            return population_norepeat;
        }
    }
}
