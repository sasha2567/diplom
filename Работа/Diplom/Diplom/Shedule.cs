using System;
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

<<<<<<< HEAD
        void construction_schedules()   
=======
        public Shedule()
        {

        }

        void CreateSchedules(List<List<int>> P1, List<List<int>> R1)   
>>>>>>> 2291fcbe4cce198da09f1486cb249b4fc750ff59
        {
            h = 1;//1 


            int Vmax = m[s - 1] + 1;//2

            P[1][Vmax] = 1;
            R[1][Vmax] = 1;//3

            v = Vmax;
            g = 1;//4

        }
        public bool shedule1(List<int> Nz) 
        {
            Random x=new Random();
            if (x.Next(2) == 1)//заглушка //здесь алгоритм который говорит проходит ли такая группа по времени
                return true;
            else
                return false;

        } 
    }

}
