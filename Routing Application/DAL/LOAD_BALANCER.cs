using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace Routing_Application.DAL
{

    public class LOAD_BALANCER : Algorithm
    {
        public Random ran = new Random();
        private Random randColor = new Random();
        public LOAD_BALANCER(Network network) : base(network)
        {
        }
        // основной метод
        public List<Individual> Do(List<Individual> PATHS)
        {
            int K_paths = PATHS.Count;
            List<Wire> tong = new List<Wire>();
            for (int k1 = 0; k1 < K_paths; k1++)
            {
                tong.AddRange(PATHS[k1].path_wires);
            }
            List<Wire> truoc = new List<Wire>();
            //danh sach cac wire khong lap lai
            List<Wire> khong = new List<Wire>();
            //danh sach cac wire lap lai it nhat 1 lan
            List<Wire> co = new List<Wire>();
            for (int i = 0; i < tong.Count; i++)
            {
                if (!truoc.Contains(tong[i]))
                {
                    khong.Add(tong[i]);
                }
                if (truoc.Contains(tong[i]))
                {
                    co.Add(tong[i]);
                }
                truoc.Add(tong[i]);
            }
            //вычисление нагрузки до балансировки
            foreach (Wire wire in khong)
            {
                List<Individual> part = new List<Individual>();
                for (int k = 0; k < K_paths; k++)
                {
                    if (PATHS[k].path_wires.Contains(wire))
                    {
                        part.Add(PATHS[k]);
                    }
                }
                int dd1 = (wire.Load) / (wire.NumberRepeat);
                int dd2 = (wire.Load) % (wire.NumberRepeat);
                for (int k = 0; k < dd2; k++)
                {
                    part[k].tc += dd1 + 1;
                }
                for (int k = dd2; k < part.Count; k++)
                {
                    part[k].tc += dd1;
                }
            }
            // сумма нагрузки
            int sum_cost = 0;
            foreach (Wire wire in khong)
            {
                sum_cost += wire.Load;
            }
            //вычисление нагрузки после балансировки
            int d1 = sum_cost / K_paths;
            int d2 = sum_cost % K_paths;
            for (int k1 = 0; k1 < K_paths; k1++)
            {
                if (d2 >= k1 + 1)
                {
                    PATHS[k1].ts = d1;
                    PATHS[k1].ts++;
                }
                else
                {
                    PATHS[k1].ts = d1;
                }
            }
            foreach (Wire wire in khong)
            {
                wire.UpdateCriterion(Criterias.Load, 0);
                wire.UpdateInfo(Criterias.Load);
            }
            for (int k1 = 0; k1 < K_paths; k1++)
            {
                int number_wires = PATHS[k1].path_wires.Count;
                int d3 = PATHS[k1].ts / number_wires;
                int d4 = PATHS[k1].ts % number_wires;
                for (int g = 0; g < number_wires; g++)
                {
                    if (d4 >= g + 1)
                    {
                        int addition = d3 + 1 + PATHS[k1].path_wires[g].Load;
                        PATHS[k1].path_wires[g].UpdateCriterion(Criterias.Load, addition);
                        PATHS[k1].path_wires[g].UpdateInfo(Criterias.Load);
                    }
                    else
                    {
                        int addition = d3 + PATHS[k1].path_wires[g].Load;
                        PATHS[k1].path_wires[g].UpdateCriterion(Criterias.Load, addition);
                        PATHS[k1].path_wires[g].UpdateInfo(Criterias.Load);
                    }
                }
            }
            return PATHS;
        }
    }
}
