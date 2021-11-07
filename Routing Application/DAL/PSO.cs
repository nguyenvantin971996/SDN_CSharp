using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace Routing_Application.DAL
{

    public class PSO : Algorithm
    {
        public Random ran = new Random();
        private Random randColor = new Random();
        public PSO(Network network) : base(network)
        {
        }
        // основной метод
        public List<Individual> Paths_PSO(Router startRouter, Router endRouter, List<Individual> population_starting, int N, double w, double c1, double c2, int Max, int K_paths)
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
            foreach(Router rt in list_routers)
            {
                if(rt!=startRouter && rt!=endRouter)
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
            //khoi tao van toc
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    population[i].velocity.Add(population[i].code_path[j]* 0.1);
                }
            }
            //local
            for(int i = 0; i < N; i++)
            {
                population[i].best_fitness = double.MaxValue;
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    population[i].best_code_path.Add(0);
                }
            }
            //global
            Individual best_individual = new Individual();
            best_individual.fitness = double.MaxValue;
            for (int j = 0; j < m; j++)
            {
                best_individual.code_path.Add(0);
            }
            for (int k = 0; k < Max; k++)
            {
                double min_fitness = double.MaxValue;
                int index_min = 0;
                //danh gia ham muc tieu fitness
                for (int i = 0; i < N; i++)
                {
                    double[] priority = new double[m];
                    for (int j = 0; j < m; j++)
                    {
                        priority[j] = population[i].code_path[j];
                    }
                    Individual path3 = Particle_Decoding(startRouter, endRouter, priority, list_rtrs);
                    double leng = 0;
                    population[i].path_wires.Clear();
                    foreach (Wire wire in path3.path_wires)
                    {
                        population[i].path_wires.Add(wire);
                        leng = leng + wire.Criterion;
                    }
                    population[i].fitness = leng;
                    if (population[i].fitness <= min_fitness)
                    {
                        min_fitness = population[i].fitness;
                        index_min = i;
                    }
                }
                //tim gia tri global
                if (population[index_min].fitness <= best_individual.fitness)
                {
                    best_individual.fitness = population[index_min].fitness;
                    for (int j = 0; j < m; j++)
                    {
                        best_individual.code_path[j]=population[index_min].code_path[j];
                    }
                }
                //tim gia tri local
                for (int i = 0; i < N; i++)
                {
                    if(population[i].fitness <= population[i].best_fitness)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            population[i].best_code_path[j] = population[i].code_path[j];
                        }
                        population[i].best_fitness = population[i].fitness;
                    }
                }
                //update velocity
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        double r1 = ran.NextDouble();
                        double r2 = ran.NextDouble();
                        population[i].velocity[j] = w* population[i].velocity[j] + c1*r1*(population[i].best_code_path[j] - population[i].code_path[j]) +
                            c2*r2*(best_individual.code_path[j]- population[i].code_path[j]);
                    }
                }
                //update populations
                double[,] population_2 = new double[N, m];
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        population_2[i, j] = population[i].code_path[j] + population[i].velocity[j];
                    }
                }
                //scale to -1;1;ti le
                for (int i = 0; i < N; i++)
                {
                    double mn = double.MaxValue;
                    double mx = double.MinValue;
                    for (int j = 0; j < m; j++)
                    {
                        if (mn > population_2[i, j])
                        {
                            mn = population_2[i, j];
                        }
                        if (mx < population_2[i, j])
                        {
                            mx = population_2[i, j];
                        }
                    }
                    for (int j = 0; j < m; j++)
                    {
                        population_2[i, j] = -1 + 2 * (population_2[i, j] - mn) / (mx - mn);
                    }
                }
                //kiem tra invalid populations
                for (int i = 0; i < N; i++)
                {
                    double[] priorit = new double[m];
                    for (int j = 0; j < m; j++)
                    {
                        priorit[j] = population_2[i, j];
                    }
                    Individual path = Particle_Decoding(startRouter, endRouter, priorit, list_rtrs);
                    if (path.path_wires.Count == 0)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            population_2[i, j] = population[i].code_path[j];
                        }
                    }
                }
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        population[i].code_path[j]=population_2[i, j];
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
