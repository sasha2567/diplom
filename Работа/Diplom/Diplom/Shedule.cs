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
            this.SetTime();
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
                    //int otnosh = 2;
                    this.TTreatment[i].Add(rand.Next(2, 20));
                    this.TSwitching[i].Add(new List<int>());
                    for(int k=0;k<this.R.Count;k++){
                        this.TSwitching[i][j].Add(rand.Next(2, 20));
                    }
                }
            }

            this.StartProcessing = new List<List<List<int>>>();
            this.EndProcessing = new List<List<List<int>>>();
            for (int i = 0; i < this.L; i++)//количество приборов
            {
                this.StartProcessing.Add(new List<List<int>>());
                this.EndProcessing.Add(new List<List<int>>());
                for (int j = 0; j < this.R.Count; j++)
                {
                    for (int k = 0; k < this.R[j].Count; k++)//номер партии
                    {
                        if (this.R[j][k] > 0)
                        {
                            this.StartProcessing[i].Add(new List<int>());
                            this.EndProcessing[i].Add(new List<int>());
                            for (int p = 0; p < this.R[j][k]; p++)//количество требований
                            {
                                this.StartProcessing[i][k].Add(0);
                                this.EndProcessing[i][k].Add(0);
                            }
                        }
                    }
                }
            }
        }

        private void CalculateShedule()
        {
            
            int yy, zz, xx;
            for (int i = 0; i < this.L; i++)
            {
                yy = 0;
                zz = 0;
                xx = 0;
                for (int j = 0; j < this.R[0].Count; j++)
                {
                    int index = this.ReturnRIndex(j);
                    if (index != -1)
                    {
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

        private List<List<int>> CopyMatrix(List<List<int>> inMatrix)
        {
            List<List<int>> ret = new List<List<int>>();
            for (int i = 0; i < inMatrix.Count; i++)
            {
                ret.Add(new List<int>());
                for (int j = 0; j < inMatrix[i].Count; j++)
                {
                    ret[i].Add(inMatrix[i][j]);
                }
            }
            return ret;
        }

        private void ChangeColum(int ind1, int ind2)
        {
            int indd1 = 0, indd2 = 0, temp;
            for (int i = 0; i < this.R.Count; i++)
            {
                if (this.R[i][ind1] > 0)
                {
                    if (this.R[i][ind2] > 0)
                    {
                        temp = this.R[i][ind1];
                        this.R[i][ind1] = this.R[i][ind2];
                        this.R[i][ind2] = temp;
                        return;
                    }
                    else
                    {
                        indd1 = i;
                    }
                }
                if (this.R[i][ind2] > 0)
                {
                    indd2 = i;
                }
            }
            temp = this.R[indd1][ind1];
            this.R[indd1][ind1] = this.R[indd2][ind2];
            this.R[indd2][ind2] = temp;
        }

        private void ChangeColumTime(int ind1, int ind2)
        {
            
        }

        public List<List<int>> ConstructShedule()
        {
            List<List<int>> tempR = new List<List<int>>();
            int tempTime = 9999999;
            switch (this.R[1].Count)
            {
                case 1:
                    this.CalculateShedule();
                    break;
                case 2:
                    this.CalculateShedule();
                    tempR = CopyMatrix(this.R);
                    tempTime = this.timeConstructShedule;
                    this.ChangeColum(0, 1);
                    this.CalculateShedule();
                    if (tempTime < this.timeConstructShedule)
                        this.R = tempR;
                    break;
                default:
                    this.CalculateShedule();
                    tempR = CopyMatrix(this.R);
                    tempTime = this.timeConstructShedule;
                    for (int i = this.R[0].Count - 1; i > 0; i--)
                    {
                        this.ChangeColum(i - 1, i);
                        this.CalculateShedule();
                        if (tempTime < this.timeConstructShedule)
                            this.R = tempR;
                    }
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
            if (this.timeConstructShedule > 100)//здесь вместо суммы нужно вставить f3
                return true;
            else
                return false;
        } 
    }
}
