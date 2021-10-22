using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Routing_Application.DAL
{
    /// <summary>
    /// класс, реализующий алгоритм Дейкстры
    /// </summary>
    public class Yen : Dejkstra_pair
    {
        
        List<List<Wire>> paths = new List<List<Wire>>();
        private Random randColor = new Random();
        // конструктор
        public Yen(Network network) : base(network)
        {
        }

        // основной метод
        public void Do_yen(Router startRouter, Router endRouter)
        {
            List<Wire> number_1 = Parth(startRouter, endRouter);
            paths.Add(number_1);
            foreach (Wire wire in number_1)
            {
                int temp = wire.Criterion;
                wire.Criterion = Const.INF;
                paths.Add(Parth(startRouter, endRouter));
                wire.Criterion = temp;

            }
                paths.Sort(new namecomparer());
                Pen ppp = new Pen(Color.FromArgb(randColor.Next(255), randColor.Next(255), randColor.Next(255)), 5);
                foreach (Wire wire in paths[0])
                {
                    //sum[i] += wire.Criterion;

                    wire.Pen = ppp;

                }

        }
        

        public class namecomparer : IComparer<List<Wire>>
        {
            public int Compare(List<Wire> x, List<Wire> y)
            {
                if (x == null || y == null)
                {
                    throw new InvalidOperationException();
                }
                int sum1 = 0, sum2 = 0;
                foreach (Wire wire in x)
                {
                    sum1 += wire.Criterion;
                }
                foreach (Wire wire in y)
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
}
