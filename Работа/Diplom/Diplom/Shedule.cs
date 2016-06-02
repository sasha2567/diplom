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

        void construction_schedules()   
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
            if (Nz.Sum() > 17)
                return true;
            else
                return false;

        } 
    }

}
