﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    class Shedule
    {
        //int L;
        //List<List<int>> P = new List<List<int>>();
        private List<List<int>> R = new List<List<int>>();
        private List<int> TTreatment;
        private List<List<int>> TSwitching;
        private int timeConstructShedule;
        //List<List<int>> Pi=new List<List<int>>();   
        //List<List<int>> А = new List<List<int>>();
        //int s;
        //List<int> m = new List<int>();
        //List<List<int>> M = new List<List<int>>();
        //int g;
        //int v;
        //int h;

        public Shedule(List<List<int>> r, List<int> tTreatment, List<List<int>> tSwitching)
        {
            this.R = r;
            this.TSwitching = tSwitching;
            this.TTreatment = tTreatment;
        }

        private int CalculateShedule(List<List<int>> inR)
        {
            int calc = 0;
            for (int j = 1; j < this.R[1].Count; j++)
            {
                for (int i = 1; i < this.R.Count; i++)
                {

                }
            }
            return calc;
        }

        public List<List<int>> ConstructShedule()
        {
            switch (this.R[1].Count)
            {
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            return this.R;
        }

        void construction_schedules()   
        {
            //h = 1;//1 


            //int Vmax = m[s - 1] + 1;//2

            //P[1][Vmax] = 1;
            //R[1][Vmax] = 1;//3

            //v = Vmax;
            //g = 1;//4

        }
        public bool shedule1(List<int> Nz) 
        {
            if (Nz.Sum() > 16)
                return true;
            else
                return false;

        } 
    }

}
