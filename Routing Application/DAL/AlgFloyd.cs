using Routing_Application.Domain;
using Routing_Application.Enums;
using System.Collections.Generic;
using System.Drawing;
using System;
using System.Windows.Forms;
using System.Linq;

namespace Routing_Application.DAL
{

    public class AlgFloyd : Algorithm
    {
        private List<List<Wire>> Floyd;
        private double minDist;
        Random randColor;
        private int N;
        private String[,] MM;
        private Dictionary<string , List<Wire>> M;

        /* Конструктор */
        public AlgFloyd(Network network) : base(network)
        {
            this.Floyd = new List<List<Wire>>();
            this.minDist = 0;
            this.randColor = new Random();
            this.N = network.Routers.Count;
            this.MM = new string[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    MM[i, j] = i.ToString() + j.ToString();
                }
            }
            this.M = new Dictionary<string, List<Wire>>();
            foreach (Wire wire in network.Wires)
            {
                M[MM[wire.StartRouter.Number, wire.EndRouter.Number]].Add(wire);
            }
        }

        // алгоритм Floyd
        public void Do(Router startRouter, Router endRouter)
        {
            Pen pen = new Pen(Color.Gray, 1);
            // сброс цветов каналов
            foreach (Wire wire in network.Wires)
            {
                wire.Pen = pen;
            }
            
            for (int k = 0; k < N; k++)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if((SumCriterions(M[MM[i, k]]) + SumCriterions(M[MM[k, j]]))< SumCriterions(M[MM[i, j]]))
                        {
                            foreach(Wire wire in M[MM[i, k]])
                            {
                                M[MM[i, j]].Add(wire);
                            }
                            foreach (Wire wire in M[MM[k, j]])
                            {
                                M[MM[i, j]].Add(wire);
                            }
                        }
                        else
                        {
                            M[MM[i, j]] = M[MM[i, j]];
                        }
                       // M[i,j] = Math.Min(M[i,j], M[i,k] + M[k,j]);
                    }
                }
            }
            foreach (Wire wire in M[MM[startRouter.Number, endRouter.Number]])
            {
                Pen penn = new Pen(Color.Green, 5);
                wire.Pen = penn;
            }
        }
        public int SumCriterions(List<Wire> Lis)
        {
            int sum = 0;
            foreach(Wire wire in Lis)
            {
                sum += wire.Criterion;
            }
            return sum;
        }
    }
}
