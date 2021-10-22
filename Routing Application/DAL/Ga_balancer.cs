using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Routing_Application.DAL
{

    public class Ga_balancer : Ga_pair
    {
        // список кратчайших путей
        private List<Individual> paths = new List<Individual>();
        private Random randColor = new Random();
        // конструктор
        public Ga_balancer(Network network) : base(network)
        {
        }
        // основной метод
        public List<Individual> Do_Ga_balancer(Router startRouter, Router endRouter, int max, double Pc, double Pm, int Si, int K, 
            int max_1, double Pc_1, double Pm_1, int Si_1)
        {
            // список кандидатов
            List<Individual> paths_new = new List<Individual>();
            List<Router> r = new List<Router>();
            List<Wire> w = new List<Wire>();
            //получение первой пути
            Individual number = Path_function(startRouter, endRouter, max, Pc, Pm, Si, r, w);
            paths.Add(number);
            for (int t = 1; t < K; t++)
            {
                Individual pt = paths[paths.Count - 1];
                for (int i = 0; i < pt.path_wires.Count; i++)
                {
                    List<Wire> w1 = new List<Wire>();
                    for (int u = 0; u < i; u++)
                    {
                        w1.Add(pt.path_wires[u]);
                    }
                    int rs = w1.Count;
                    foreach (Individual tr in paths)
                    {
                        if (tr.path_wires.Count >= i)
                        {
                            List<Wire> w2 = new List<Wire>();
                            for (int u = 0; u < i; u++)
                            {
                                w2.Add(tr.path_wires[u]);
                            }
                            int e = 0;
                            foreach (Wire wire in w2)
                            {
                                if (w1.Contains(wire))
                                {
                                    e++;
                                }
                            }
                            if (e == rs)
                            {
                                w1.Add(tr.path_wires[i]);
                            }
                        }
                    }
                    foreach (Individual tr in paths_new)
                    {
                        if (tr.path_wires.Count >= i)
                        {
                            List<Wire> w2 = new List<Wire>();
                            for (int u = 0; u < i; u++)
                            {
                                w2.Add(tr.path_wires[u]);
                            }
                            int e = 0;
                            foreach (Wire wire in w2)
                            {
                                if (w1.Contains(wire))
                                {
                                    e++;
                                }
                            }
                            if (e == rs)
                            {
                                w1.Add(tr.path_wires[i]);
                            }
                        }
                    }
                    Individual number1 = Path_function(pt.view_router[i], endRouter, max, Pc, Pm, Si, r, w1);
                    Individual noi = new Individual();
                    for (int j = 0; j < i; j++)
                    {
                        noi.path_wires.Add(pt.path_wires[j]);
                        noi.view_router.Add(pt.view_router[j]);
                    }
                    noi.path_wires.AddRange(number1.path_wires);
                    noi.view_router.AddRange(number1.view_router);
                    if (number1.path_wires.Count != 0)
                    {
                        paths_new.Add(noi);
                    }
                    else if (number1.path_wires.Count == 0)
                    {
                        continue;
                    }
                }
                //сортировка кандидатов
                paths_new.Sort(new namecomparee());
                //получение следующей пути
                if (paths_new.Count != 0)
                {
                    paths.Add(paths_new[0]);
                    paths_new.RemoveAt(0);
                }
            }
            // список всех ребер
            List<Wire> tong = new List<Wire>();
            for (int k = 0; k < paths.Count; k++)
            {
                tong.AddRange(paths[k].path_wires);
            }
            int s = 0;
            List<Wire> truoc = new List<Wire>();
            //список различных ребер
            List<Wire> khong = new List<Wire>();
            List<Wire> co = new List<Wire>();
            for (int i = 0; i < tong.Count; i++)
            {
                if (!truoc.Contains(tong[i]))
                {
                    khong.Add(tong[i]);
                    s += tong[i].Criterion;
                }
                if (truoc.Contains(tong[i]))
                {
                    co.Add(tong[i]);
                }
                truoc.Add(tong[i]);
            }
            // количество вхождений ребер
            foreach (Wire wire in khong)
            {
                foreach (Wire wires in tong)
                {
                    if (wire == wires)
                    {
                        wire.NumberRepeat++;
                    }
                }
            }
            // вычисление нагрузки каждой пути до балансировки
            foreach (Wire wire in khong)
            {
                List<Individual> part = new List<Individual>();
                for (int k = 0; k < paths.Count; k++)
                {
                    if (paths[k].path_wires.Contains(wire))
                    {
                        part.Add(paths[k]);
                    }
                }
                int dd1 = (wire.Criterion) / (wire.NumberRepeat);
                int dd2 = (wire.Criterion) % (wire.NumberRepeat);
                for (int k = 0; k < dd2; k++)
                {
                    part[k].tc += dd1 + 1;
                }
                for (int k = dd2; k < part.Count; k++)
                {
                    part[k].tc += dd1;
                }
            }
            //часть ГА
                List<int[]> A = new List<int[]>();
                int[] fitness = new int[max_1]; 
                // получение начальной популяции
                for (int i = 0; i < max_1; i++)
                {
                    int[] arr = new int[khong.Count];
                     for (int k = 0; k < khong.Count; k++)
                     {
                         arr[k]=1;
                     }
                    for (int k = 0; k < s-khong.Count; k++)
                    {
                        arr[ran.Next(0, s) % (khong.Count)]++;
                    }
                 A.Add(arr);
                }
                // вычисление приспособленности
                for (int i = 0; i < max_1; i++)
                {
                    fitness[i] = 0;
                    for (int k = 0; k < khong.Count; k++)
                    {
                        khong[k].Criterion = A[i][k];
                    }
                    foreach (Wire wire in khong)
                    {
                        List<Individual> part = new List<Individual>();
                        for (int k = 0; k < paths.Count; k++)
                        {
                            if (paths[k].path_wires.Contains(wire))
                            {
                                part.Add(paths[k]);
                            }
                        }
                        int dd1 = (wire.Criterion) / (wire.NumberRepeat);
                        int dd2 = (wire.Criterion) % (wire.NumberRepeat);
                        for (int k = 0; k < dd2; k++)
                        {
                            part[k].trc += dd1 + 1;
                        }
                        for (int k = dd2; k < part.Count; k++)
                        {
                            part[k].trc += dd1;
                        }
                    }
                    for (int k = 0; k < paths.Count; k++)
                    {
                        fitness[i] += Math.Abs(paths[k].trc - s / K);
                    }
                    for (int k = 0; k < khong.Count; k++)
                    {
                        khong[k].Criterion = 0;
                    }
                    for (int k = 0; k < paths.Count; k++)
                    {
                        paths[k].trc = 0;
                    }
                }
            for (int u = 0; u < Si_1; u++)
            {
                //отбор
                int[] temp = new int[max_1];
                Array.Copy(fitness, 0, temp, 0, fitness.Length);
                Array.Sort(temp);
                int nguong = temp[80 * max_1 / 100];
                for (int k = 0; k < max_1; k++)
                {
                    if (fitness[k] > nguong)
                    {

                        int[] arr = new int[khong.Count];
                        for (int k1 = 0; k1 < khong.Count; k1++)
                        {
                            arr[k1] = 1;
                        }
                        for (int kk = 0; kk < s-khong.Count; kk++)
                        {
                            arr[ran.Next(0, s) % (khong.Count)]++;
                        }
                        A[k] = new int[khong.Count];
                        arr.CopyTo(A[k], 0);
                    }
                }
                for (int i = 0; i < max_1; i++)
                {
                    fitness[i] = 0;
                    for (int k = 0; k < khong.Count; k++)
                    {
                        khong[k].Criterion = A[i][k];
                    }
                    foreach (Wire wire in khong)
                    {
                        List<Individual> part = new List<Individual>();
                        for (int k = 0; k < paths.Count; k++)
                        {
                            if (paths[k].path_wires.Contains(wire))
                            {
                                part.Add(paths[k]);
                            }
                        }
                        int dd1 = (wire.Criterion) / (wire.NumberRepeat);
                        int dd2 = (wire.Criterion) % (wire.NumberRepeat);
                        for (int k = 0; k < dd2; k++)
                        {
                            part[k].trc += dd1 + 1;
                        }
                        for (int k = dd2; k < part.Count; k++)
                        {
                            part[k].trc += dd1;
                        }
                    }
                    for (int k = 0; k < paths.Count; k++)
                    {
                        fitness[i] += Math.Abs(paths[k].trc - s / K);
                    }
                    for (int k = 0; k < khong.Count; k++)
                    {
                        khong[k].Criterion = 0;
                    }
                    for (int k = 0; k < paths.Count; k++)
                    {
                        paths[k].trc = 0;
                    }
                }

                for (int ht = 0; ht < max_1; ht++)
                {
                    //Скрещивание               
                    int pc = ran.Next(11);
                    if (pc <= Pc_1 * 10)
                    {
                        int father = ran.Next(max_1);
                        int[] arr_cha = new int[khong.Count];
                        A[father].CopyTo(arr_cha, 0);
                        int mother = ran.Next(max_1);
                        int[] arr_me = new int[khong.Count];
                        A[mother].CopyTo(arr_me, 0);
                        for (int j=1;j<khong.Count-1;j++)
                        {
                            int cha = 0;
                            for(int r1=0;r1<j+1;r1++)
                            {
                                cha += arr_cha[r1];
                            }
                            int me = 0;
                            for (int r1 = 0; r1 < j + 1; r1++)
                            {
                                me += arr_me[r1];
                            }
                            if(cha == me)
                            {
                                for (int r1 = j+1; r1 < khong.Count; r1++)
                                {
                                    int tempw = arr_cha[r1];
                                    arr_cha[r1]= arr_me[r1];
                                    arr_me[r1]=tempw;
                                }
                                int ch1 = 0;
                                for (int k = 0; k < khong.Count; k++)
                                {
                                    khong[k].Criterion = arr_cha[k];
                                }
                                foreach (Wire wire in khong)
                                {
                                    List<Individual> part = new List<Individual>();
                                    for (int k = 0; k < paths.Count; k++)
                                    {
                                        if (paths[k].path_wires.Contains(wire))
                                        {
                                            part.Add(paths[k]);
                                        }
                                    }
                                    int dd1 = (wire.Criterion) / (wire.NumberRepeat);
                                    int dd2 = (wire.Criterion) % (wire.NumberRepeat);
                                    for (int k = 0; k < dd2; k++)
                                    {
                                        part[k].trc += dd1 + 1;
                                    }
                                    for (int k = dd2; k < part.Count; k++)
                                    {
                                        part[k].trc += dd1;
                                    }
                                }
                                for (int k = 0; k < paths.Count; k++)
                                {
                                    ch1 += Math.Abs(paths[k].trc - s / K);
                                }
                                for (int k = 0; k < khong.Count; k++)
                                {
                                    khong[k].Criterion = 0;
                                }
                                for (int k = 0; k < paths.Count; k++)
                                {
                                    paths[k].trc = 0;
                                }
                                int m1 = 0;
                                for (int k = 0; k < khong.Count; k++)
                                {
                                    khong[k].Criterion = arr_me[k];
                                }
                                foreach (Wire wire in khong)
                                {
                                    List<Individual> part = new List<Individual>();
                                    for (int k = 0; k < paths.Count; k++)
                                    {
                                        if (paths[k].path_wires.Contains(wire))
                                        {
                                            part.Add(paths[k]);
                                        }
                                    }
                                    int dd1 = (wire.Criterion) / (wire.NumberRepeat);
                                    int dd2 = (wire.Criterion) % (wire.NumberRepeat);
                                    for (int k = 0; k < dd2; k++)
                                    {
                                        part[k].trc += dd1 + 1;
                                    }
                                    for (int k = dd2; k < part.Count; k++)
                                    {
                                        part[k].trc += dd1;
                                    }
                                }
                                for (int k = 0; k < paths.Count; k++)
                                {
                                    m1 += Math.Abs(paths[k].trc - s / K);
                                }
                                for (int k = 0; k < khong.Count; k++)
                                {
                                    khong[k].Criterion = 0;
                                }
                                for (int k = 0; k < paths.Count; k++)
                                {
                                    paths[k].trc = 0;
                                }
                                if(fitness[father]>ch1)
                                {
                                    A[father] = new int[khong.Count];
                                    arr_cha.CopyTo(A[father], 0);
                                }
                                if (fitness[mother] > m1)
                                {
                                    A[mother] = new int[khong.Count];
                                    arr_me.CopyTo(A[mother], 0);
                                }
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                       
                    }
                }
                for (int i = 0; i < max_1; i++)
                {
                    fitness[i] = 0;
                    for (int k = 0; k < khong.Count; k++)
                    {
                        khong[k].Criterion = A[i][k];
                    }
                    foreach (Wire wire in khong)
                    {
                        List<Individual> part = new List<Individual>();
                        for (int k = 0; k < paths.Count; k++)
                        {
                            if (paths[k].path_wires.Contains(wire))
                            {
                                part.Add(paths[k]);
                            }
                        }
                        int dd1 = (wire.Criterion) / (wire.NumberRepeat);
                        int dd2 = (wire.Criterion) % (wire.NumberRepeat);
                        for (int k = 0; k < dd2; k++)
                        {
                            part[k].trc += dd1 + 1;
                        }
                        for (int k = dd2; k < part.Count; k++)
                        {
                            part[k].trc += dd1;
                        }
                    }
                    for (int k = 0; k < paths.Count; k++)
                    {
                        fitness[i] += Math.Abs(paths[k].trc - s / K);
                    }
                    for (int k = 0; k < khong.Count; k++)
                    {
                        khong[k].Criterion = 0;
                    }
                    for (int k = 0; k < paths.Count; k++)
                    {
                        paths[k].trc = 0;
                    }
                }

                for (int ht = 0; ht < max_1; ht++)
                {
                    //мутация
                    int pm = ran.Next(11);
                    if (pm < Pm_1 * 10)
                    {
                        int db = ran.Next(max_1);
                        int f = ran.Next(khong.Count);
                        for (int z=f;z<khong.Count;z++)
                        {
                            A[db][z] = 0;
                        }
                        int[] arr_mu = new int[khong.Count-f];
                        int ss = 0;
                        for (int z = 0; z < f; z++)
                        {
                            ss+=A[db][z];
                        }
                        for (int k = 0; k < s-ss; k++)
                        {
                            arr_mu[ran.Next(0, s-ss) % (khong.Count-f)]++;
                        }
                        for (int z = f; z < khong.Count; z++)
                        {
                            A[db][z] = arr_mu[z-f];
                        }
                    }
                }
                for (int i = 0; i < max_1; i++)
                {
                    fitness[i] = 0;
                    for (int k = 0; k < khong.Count; k++)
                    {
                        khong[k].Criterion = A[i][k];
                    }
                    foreach (Wire wire in khong)
                    {
                        List<Individual> part = new List<Individual>();
                        for (int k = 0; k < paths.Count; k++)
                        {
                            if (paths[k].path_wires.Contains(wire))
                            {
                                part.Add(paths[k]);
                            }
                        }
                        int dd1 = (wire.Criterion) / (wire.NumberRepeat);
                        int dd2 = (wire.Criterion) % (wire.NumberRepeat);
                        for (int k = 0; k < dd2; k++)
                        {
                            part[k].trc += dd1 + 1;
                        }
                        for (int k = dd2; k < part.Count; k++)
                        {
                            part[k].trc += dd1;
                        }
                    }
                    for (int k = 0; k < paths.Count; k++)
                    {
                        fitness[i] += Math.Abs(paths[k].trc - s / K);
                    }
                    for (int k = 0; k < khong.Count; k++)
                    {
                        khong[k].Criterion = 0;
                    }
                    for (int k = 0; k < paths.Count; k++)
                    {
                        paths[k].trc = 0;
                    }
                }


            }
            // выбор лучшего
            int[] temp1 = new int[max_1];
            Array.Copy(fitness, 0, temp1, 0, fitness.Length);
            Array.Sort(temp1);
            int best = temp1[0];
            for (int kk = 0; kk < max_1; kk++)
            {
                if (fitness[kk] == best)
                {
                    for (int k = 0; k < khong.Count; k++)
                    {
                        khong[k].UpdateCriterion(Criterias.Metric, A[kk][k]);
                        khong[k].UpdateInfo(Criterias.Metric);
                    }
                    // вычисление нагрузки каждой пути после балансировки
                    foreach (Wire wire in khong)
                    {
                        List<Individual> part = new List<Individual>();
                        for (int k = 0; k < paths.Count; k++)
                        {
                            if (paths[k].path_wires.Contains(wire))
                            {
                                part.Add(paths[k]);
                            }
                        }
                        int dd1 = (wire.Criterion) / (wire.NumberRepeat);
                        int dd2 = (wire.Criterion) % (wire.NumberRepeat);
                        for (int k = 0; k < dd2; k++)
                        {
                            part[k].ts += dd1 + 1;
                        }
                        for (int k = dd2; k < part.Count; k++)
                        {
                            part[k].ts += dd1;
                        }
                    }
                    break;
                }
            }
            // окраска путей
            for (int k = 0; k < paths.Count; k++)
            {
                Color c = Color.FromArgb(randColor.Next(255), randColor.Next(255), randColor.Next(255));
                foreach (Wire wire in paths[k].path_wires)
                {
                    Pen ppp = new Pen(c,4 * (wire.NumberRepeat));
                    wire.Pen = ppp;
                }
            }
            return paths;
        }

    }
    public class namecomparee : IComparer<Individual>
    {
        public int Compare(Individual x, Individual y)
        {
            if (x == null || y == null)
            {
                throw new InvalidOperationException();
            }
            int sum1 = 0, sum2 = 0;
            foreach (Wire wire in x.path_wires)
            {
                sum1 += wire.Criterion;
            }
            foreach (Wire wire in y.path_wires)
            {
                sum2 += wire.Criterion;
            }
            if (sum1 < sum2)
            {
                return -1;
            }
            else if (sum1 == sum2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }


    }
}
