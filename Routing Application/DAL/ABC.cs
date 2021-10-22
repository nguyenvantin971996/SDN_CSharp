using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Routing_Application.DAL
{

    public class ABC : Algorithm
    {
        public Random ran = new Random();
        private Random randColor = new Random();
        public ABC(Network network) : base(network)
        {
        }
        // основной метод
        public List<Individual> Paths_ABC(Router startRouter, Router endRouter, List<Individual> population_starting, int N, int Max, int K_paths)
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
            int m = list_routers.Count;
            //khoi tao cac duong di duoc ma hoa
            List<Individual> population = new List<Individual>();
            for (int i = 0; i < N; i++)
            {
                population.Add(new Individual());
            }
            //bo dem danh cho scout phase
            double[] counter = new double[N];
            int limit = (int)(m * N / 2);
            //THUAT TOAN ABC
            //initialization_phase
            for (int i = 0; i < N; i++)
            {
            tt1:
                double[] priority = new double[m];
                for (int j = 0; j < m; j++)
                {
                    priority[j] = population_starting[i].code_path.Min()+ran.NextDouble()*(population_starting[i].code_path.Max()- population_starting[i].code_path.Min());
                }
                Individual path = Particle_Decoding(startRouter, endRouter, priority, list_rtrs);
                if (path.path_wires.Count == 0)
                {
                    goto tt1;
                }
                else
                {
                    for (int j = 0; j < m; j++)
                    {
                        population[i] = path.DeepCopy();
                    }
                }
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
            //danh gia ham muc tieu 1/(1+fitness)
            for (int i = 0; i < N; i++)
            {
                population[i].fitness_vector = 1 / (1 + population[i].fitness);
            }
            for (int k = 0; k < Max; k++)
            {
                //EMPLOYEED PHASE
                List<Individual> population_copy = new List<Individual>();
                for (int i = 0; i < N; i++)
                {
                    population_copy.Add(new Individual());
                }
                for (int i = 0; i < N; i++)
                {
                    population_copy[i] = population[i].DeepCopy();
                }
                //sinh giai phap moi cho tung ong tho
                for (int i = 0; i < N; i++)
                {
                sinhmoi: double[] new_solution = new double[m];
                    //chon ngau nhien mot chieu can thay doi
                    int d = ran.Next(m);
                //chon ngau nhien mot hang xom
                chonlai:
                    int h = ran.Next(N);
                    if (h == i)
                    {
                        goto chonlai;
                    }
                    //chon gia tri ngau nhien fi
                    double fi = ran.NextDouble() * 2 - 1;
                    //sinh giai phap moi
                    for (int j = 0; j < m; j++)
                    {
                        if (j == d)
                        {
                            new_solution[j] = population[i].code_path[j] + fi * (population[i].code_path[j] - population[h].code_path[j]);

                        }
                        else
                        {
                            new_solution[j] = population[i].code_path[j];
                        }
                    }
                    //scale to -1;1
                    double mn = double.MaxValue;
                    double mx = double.MinValue;
                    for (int j = 0; j < m; j++)
                    {
                        if (mn > new_solution[j])
                        {
                            mn = new_solution[j];
                        }
                        if (mx < new_solution[j])
                        {
                            mx = new_solution[j];
                        }
                    }
                    for (int j = 0; j < m; j++)
                    {
                        new_solution[j] = -1 + 2 * (new_solution[j] - mn) / (mx - mn);
                    }
                    Individual path3 = Particle_Decoding(startRouter, endRouter, new_solution, list_rtrs);
                    if (path3.path_wires.Count == 0)
                    {
                        goto sinhmoi;
                    }
                    else
                    {
                        double leng = 0;
                        foreach (Wire wire in path3.path_wires)
                        {
                            leng = leng + wire.Criterion;
                        }
                        double fitness_v = 1 / (1 + leng);
                        if (fitness_v >= population_copy[i].fitness_vector)
                        {
                            population_copy[i].path_wires.Clear();
                            foreach (Wire wire in path3.path_wires)
                            {
                                population_copy[i].path_wires.Add(wire);
                            }
                            population_copy[i].path_routers.Clear();
                            foreach (Router router in path3.path_routers)
                            {
                                population_copy[i].path_routers.Add(router);
                            }
                            population_copy[i].code_path.Clear();
                            for (int jj = 0; jj < m; jj++)
                            {
                                population_copy[i].code_path.Add(new_solution[jj]);
                            }
                            population_copy[i].fitness_vector = fitness_v;
                            population_copy[i].fitness = leng;
                            counter[i] = 0;
                        }
                        else
                        {
                            counter[i]++;
                        }
                    }
                }
                for (int i = 0; i < N; i++)
                {
                    population[i] = population_copy[i].DeepCopy();
                }
                double sum_mau = 0;
                for (int i = 0; i < N; i++)
                {
                    sum_mau = sum_mau + population[i].fitness_vector;
                }
                //tinh toan xac suat de chuan bi cho ong quan sat
                double[] probability_solutions = new double[N];
                for (int i = 0; i < N; i++)
                {
                    probability_solutions[i] = population[i].fitness_vector / sum_mau;
                }
                //ONLOOKED PHASE
                List<Individual> population_copy_2 = new List<Individual>();
                for (int i = 0; i < N; i++)
                {
                    population_copy_2.Add(new Individual());
                }
                for (int i = 0; i < N; i++)
                {
                    population_copy_2[i] = population[i].DeepCopy();
                }
                //sinh giai phap moi theo ong quan sat
                for (int i = 0; i < N; i++)
                {
                    //giai phap thu index_solution dc bien doi
                    int index_solution = 0;
                    double pr = ran.NextDouble();
                    if (pr <= probability_solutions[0])
                    {
                        index_solution = 0;
                    }
                    else
                    {
                        for (int j = 0; j < N - 1; j++)
                        {
                            double sum_pr = 0;
                            for (int c = 0; c <= j; c++)
                            {
                                sum_pr = sum_pr + probability_solutions[c];
                            }
                            if ((sum_pr < pr) && (pr <= (sum_pr + probability_solutions[j + 1])))
                            {
                                index_solution = j + 1;
                                break;
                            }
                        }
                    }
                sinhmoi1: double[] new_solution = new double[m];
                    //chon ngau nhien mot chieu can thay doi
                    int d = ran.Next(m);
                //chon ngau nhien mot hang xom
                chonlai1:
                    int h = ran.Next(N);
                    if (h == index_solution)
                    {
                        goto chonlai1;
                    }
                    //chon gia tri ngau nhien fi
                    double fi = ran.NextDouble() * 2 - 1;
                    //sinh giai phap moi
                    for (int j = 0; j < m; j++)
                    {
                        if (j == d)
                        {
                            new_solution[j] = population[index_solution].code_path[j] + fi * (population[index_solution].code_path[j] - population[h].code_path[j]);
                        }
                        else
                        {
                            new_solution[j] = population[index_solution].code_path[j];
                        }
                    }
                    //scale to -1;1
                    double mn = double.MaxValue;
                    double mx = double.MinValue;
                    for (int j = 0; j < m; j++)
                    {
                        if (mn > new_solution[j])
                        {
                            mn = new_solution[j];
                        }
                        if (mx < new_solution[j])
                        {
                            mx = new_solution[j];
                        }
                    }
                    for (int j = 0; j < m; j++)
                    {
                        new_solution[j] = -1 + 2 * (new_solution[j] - mn) / (mx - mn);
                    }
                    Individual path4 = Particle_Decoding(startRouter, endRouter, new_solution, list_rtrs);
                    if (path4.path_wires.Count == 0)
                    {
                        goto sinhmoi1;
                    }
                    else
                    {
                        double leng = 0;
                        foreach (Wire wire in path4.path_wires)
                        {
                            leng = leng + wire.Criterion;
                        }
                        double fitness_v = 1 / (1 + leng);
                        if (fitness_v >= population_copy_2[index_solution].fitness_vector)
                        {
                            population_copy_2[index_solution].path_wires.Clear();
                            foreach (Wire wire in path4.path_wires)
                            {
                                population_copy_2[index_solution].path_wires.Add(wire);
                            }
                            population_copy_2[index_solution].path_routers.Clear();
                            foreach (Router router in path4.path_routers)
                            {
                                population_copy_2[index_solution].path_routers.Add(router);
                            }
                            population_copy_2[index_solution].code_path.Clear();
                            for (int jj = 0; jj < m; jj++)
                            {
                                population_copy_2[index_solution].code_path.Add(new_solution[jj]);
                            }
                            population_copy_2[index_solution].fitness_vector = fitness_v;
                            population_copy_2[index_solution].fitness = leng;
                            counter[index_solution] = 0;
                        }
                        else
                        {
                            counter[index_solution]++;
                        }
                    }
                }
                for (int i = 0; i < N; i++)
                {
                    population[i] = population_copy_2[i].DeepCopy();
                }
                //SCOUT PHASE
                for (int i = 0; i < N; i++)
                {
                    if (counter[i] > limit)
                    {
                    ttt:
                        double[] priority = new double[m];
                        for (int j = 0; j < m; j++)
                        {
                            priority[j] = population[i].code_path.Min() + ran.NextDouble() * (population[i].code_path.Max() - population[i].code_path.Min());
                        }
                        Individual path = Particle_Decoding(startRouter, endRouter, priority, list_rtrs);
                        if (path.path_wires.Count == 0)
                        {
                            goto ttt;
                        }
                        else
                        {
                            for (int j = 0; j < m; j++)
                            {
                                population[i] = path.DeepCopy();
                            }
                            double leng = 0;
                            foreach (Wire wire in path.path_wires)
                            {
                                leng = leng + wire.Criterion;
                            }
                            population[i].fitness = leng;
                            population[i].fitness_vector = 1 / (1 + population[i].fitness);
                            counter[i] = 0;                
                        }
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
                foreach(Individual indiv in best)
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
