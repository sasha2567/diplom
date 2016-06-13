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
        private List<List<int>> TTreatment;
        private List<List<List<int>>> TSwitching;
        private int timeConstructShedule;
        private int L;
        private List<List<List<int>>> StartProcessing;
        private List<List<List<int>>> EndProcessing;
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

            this.StartProcessing = new List<List<List<int>>>();
            this.EndProcessing = new List<List<List<int>>>();
            for (int i = 0; i < this.L; i++)
            {
                this.StartProcessing.Add(new List<List<int>>());
                this.EndProcessing.Add(new List<List<int>>());
                for (int j = 0; j < this.R.Count; j++)
                {
                    for (int k = 0; k < this.R[j].Count; k++)
                    {
                        if (this.R[j][k] > 0)
                        {
                            this.StartProcessing[i].Add(new List<int>());
                            this.EndProcessing[i].Add(new List<int>());
                            for (int p = 0; p < this.R[j][k]; p++)
                            {
                                this.StartProcessing[i][k].Add(0);
                                this.EndProcessing[i][k].Add(0);
                            }
                        }
                    }
                }
            }
        }

        private void SetTime()
        {
            this.TSwitching = new List<List<List<int>>>();
            this.TTreatment = new List<List<int>>();
            Random rand = new Random();
            for (int i = 0; i < this.L; i++)
            {
                this.TTreatment.Add(new List<int>());
                this.TSwitching.Add(new List<List<int>>());
                for (int j = 0; j < this.R.Count; j++)
                {
                    int otnosh = 2;
                    this.TTreatment[i].Add(rand.Next(2, otnosh * 2));
                    this.TSwitching[i].Add(new List<int>());
                    for(int k=0;k<this.R.Count;k++){
                        this.TSwitching[i][j].Add(rand.Next(1,5));
                    }
                }
            }
        }

        private void CalculateShedule()
        {
            this.SetTime();
            int yy, zz, xx;
            for (int i = 0; i < this.L; i++)
            {
                yy = 0;
                zz = 0;
                xx = 0;
                for (int j = 0; j < this.R[0].Count; j++)
                {
                    int index = this.ReturnRIndex(j);
                    for (int k = 0; k < this.R[index][j]; k++)
                    {
                        if (i != 0)
                        {
                            int timeToSwitch = this.TSwitching[i][xx][index];
                            if (index == xx)
                                timeToSwitch = 0;
                            //rasp.tstart[i][k][l]=max(rasp.tstop[i][zz][yy]+perenastr[i][xx][j],rasp.tstop[i-1][k][l]);
                            this.StartProcessing[i][j][k] = Math.Max(this.EndProcessing[i][yy][zz] + timeToSwitch, this.EndProcessing[i - 1][j][k]);
                            this.EndProcessing[i][j][k] = this.StartProcessing[i][j][k] + this.TTreatment[i][index];
                            this.timeConstructShedule = this.EndProcessing[i][j][k];
                            yy = j;
                            zz = k;
                            xx = index;
                        }
                        else
                        {
                            int timeToSwitch = this.TSwitching[i][xx][index];
                            if (index == xx && k != 0)
                                timeToSwitch = 0;
                            this.StartProcessing[i][j][k] = this.EndProcessing[i][yy][zz] + timeToSwitch;
                            this.EndProcessing[i][j][k] = this.StartProcessing[i][j][k] + this.TTreatment[i][index];
                            this.timeConstructShedule = this.EndProcessing[i][j][k];
                            yy = j;
                            zz = k;
                            xx = index;
                        }
                    }
                }
            }
        }

        private int ReturnRIndex(int j)
        {
            for (int i = 0; i < this.R.Count; i++)
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
                    this.CalculateShedule();
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            return this.R;
        }

        public int GetTime()
        {
            return this.timeConstructShedule;
        }

        public bool shedule1(List<List<int>> Nz) 
        {
         //   CalculateShedule(Nz);
         //   int sum=0;
          //  for (int i = 0; i < Nz.Count(); i++)
          //      sum += Nz[i].Sum();


                //  if (this.timeConstructShedule > 100)//здесь вместо суммы нужно вставить f3
         //       if (sum > 14)
            //        return true;
             //   else
            //        return false;
            //CalculateShedule();
            if (this.timeConstructShedule > 1000)//здесь вместо суммы нужно вставить f3
                return true;
            else
                return false;

        } 
    }

}
