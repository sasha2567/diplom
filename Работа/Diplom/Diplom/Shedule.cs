﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    class Shedule
    {
        int L;
        List<List<int>> P = new List<List<int>>();
        List<List<int>> R = new List<List<int>>();
        List<List<int>> Pi=new List<List<int>>();   
        List<List<int>> А = new List<List<int>>();
        int s;
        List<int> m = new List<int>();
        List<List<int>> M = new List<List<int>>();
        int g;
        int v;
        int h;

        public Shedule()
        {

        }

        void CreateSchedules(List<List<int>> P1, List<List<int>> R1)   
        {
            h = 1;//1 
            
            int Vmax = m[s - 1] + 1;//2

            P1[1][Vmax] = 1;
            R1[1][Vmax] = 1;//3

            v = Vmax;
            g = 1;//4

        }
        public bool shedule(List<int> Nz) 
        {
            Random x=new Random();
            if (x.Next(1) == 1)//заглушка //здесь алгоритм который говорит проходит ли такая группа по времени
                return true;
            else
                return false;

        } 
    }

}
