using System;
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
        private int L;
        private List<List<int>> Raspisanie;
        //List<List<int>> Pi=new List<List<int>>();   
        //List<List<int>> А = new List<List<int>>();
        //int s;
        //List<int> m = new List<int>();
        //List<List<int>> M = new List<List<int>>();
        //int g;
        //int v;
        //int h;

        public Shedule(List<List<int>> r, List<int> tTreatment, List<List<int>> tSwitching, int l)
        {
            this.R = r;
            this.L = l;
            this.TSwitching = tSwitching;
            this.TTreatment = tTreatment;
            this.Raspisanie = new List<List<int>>();
            /*for (int i = 0; i <= this.L; i++)
            {
                this.Raspisanie.Add(new List<int>());
                for (int j = 0; j <= this.R.Count; j++)
                {
                    this.Raspisanie[i].Add(0);
                }
            }*/
        }

        private int CalculateShedule(List<List<int>> inR)
        {
            int calc = 0;
            int yy, zz, count = 0;
            for (int i = 1; i <= this.L; i++)
            {
                yy = 0;
                zz = 0;
                for (int k = 1; k <= this.R.Count; k++)
                {
                    for (int l = 1; l <= this.R[k].Count; l++)
                    {
                        if (this.R[k][l] != 0)
                        {
                            this.Raspisanie[i][k] = Math.Max(this.Raspisanie[i][zz] + this.TSwitching[i][zz] + this.R[k][l] * this.TTreatment[k], this.Raspisanie[i - 1][k]);
                            //rasp.tstart[i][k] = max(rasp.tstop[i][zz] + perenastr[i][xx], rasp.tstop[i - 1][k]);
                            //rasp.tstop[i][k] = rasp.tstart[i][k] + obrabot[i][j];
                            count += this.R[k][l] * this.TTreatment[k];
                            yy = l;
                            zz = k;
                        }
                    }
                }
            }
            double f3;
           // for(int i=0;i<inR.Count();i++)
            //f3=TTreatment+
            return calc;
        }

        private int ReturnRIndex(int j)
        {
            for (int i = 1; i < this.R.Count; i++)
            {
                if (this.R[i][j] != 0)
                    return i;
            }
            return -1;
        }

        public List<List<int>> ConstructShedule()
        {
            switch (this.R[1].Count)
            {
                case 1:
                    this.timeConstructShedule = this.CalculateShedule(this.R);
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
        public bool shedule1(List<List<int>> Nz) 
        {
            if (Nz[0].Sum()+Nz[1].Sum()+Nz[2].Sum()+Nz[3].Sum() > 16)//здесь вместо суммы нужно вставить f3
                return true;
            else
                return false;

        } 
    }

}
