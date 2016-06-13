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
        private List<List<int>> StartProcessing;
        private List<List<int>> EndProcessing;
        //List<List<int>> Pi=new List<List<int>>();   
        //List<List<int>> А = new List<List<int>>();
        //int s;
        //List<int> m = new List<int>();
        //List<List<int>> M = new List<List<int>>();
        //int g;
        //int v;
        //int h;

        public Shedule(List<List<int>> r, int l)
        {
            this.R = r;
            this.L = l;
            
            this.StartProcessing = new List<List<int>>();
            this.EndProcessing = new List<List<int>>();
            for (int i = 0; i <= this.L; i++)
            {
                this.StartProcessing.Add(new List<int>());
                this.EndProcessing.Add(new List<int>());
                for (int j = 0; j <= this.R.Count; j++)
                {
                    this.StartProcessing[i].Add(0);
                    this.EndProcessing[i].Add(0);
                }
            }
        }

        public void SetTime(List<int> tTreatment, List<List<int>> tSwitching)
        {
            this.TSwitching = tSwitching;
            this.TTreatment = tTreatment;
        }

        private int CalculateShedule(List<List<int>> inR)
        {
            int yy, zz;
            for (int i = 1; i <= this.L; i++)
            {
                yy = 0;
                zz = 0;
                for (int k = 1; k <= inR.Count; k++)
                {
                    int index = this.ReturnRIndex(k);
                    int timeToSwitch = this.TSwitching[k][zz];
                    if (k == zz)
                        timeToSwitch = 0;
                    this.StartProcessing[i][k] = Math.Max(this.StartProcessing[i][zz] + this.TSwitching[k][zz], this.StartProcessing[i - 1][k]);
                    //rasp.tstart[i][k] = max(rasp.tstop[i][zz] + perenastr[i][xx], rasp.tstop[i - 1][k]);
                    this.EndProcessing[i][k] = this.StartProcessing[i][k] + inR[k][index] * this.TTreatment[k];
                    //rasp.tstop[i][k] = rasp.tstart[i][k] + obrabot[i][j];
                    //count += inR[k][index] * this.TTreatment[k];
                    this.timeConstructShedule = this.StartProcessing[i][k];
                    //yy = index;
                    zz = k;
                }
            }
            return this.timeConstructShedule;
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



        void create_shed_test()
        {

        }


        public bool shedule1(List<List<int>> Nz) 
        {
         //   CalculateShedule(Nz);
            int sum=0;
            for (int i = 0; i < Nz.Count(); i++)
                sum += Nz[i].Sum();


                //  if (this.timeConstructShedule > 100)//здесь вместо суммы нужно вставить f3
                if (sum > 14)
                    return true;
                else
                    return false;
        } 
    }

}
