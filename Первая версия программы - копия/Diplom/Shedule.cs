using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    class Shedule
    {
        private List<List<int>> R = new List<List<int>>();
        public static List<List<int>> TTreatment;
        public static List<List<List<int>>> TSwitching;
        private int timeConstructShedule;
        public static int L;
        private List<List<List<int>>> StartProcessing;
        private List<List<List<int>>> EndProcessing;
        public static int maxTimeSwitching = 4;
        public static int maxTimeTreatment = 4;
        


        public Shedule(List<List<int>> r, int l)
        {
            this.R = r;
            L = l;
            //this.SetTime();
        }

        private void SetTime()
        {
            TSwitching = new List<List<List<int>>>();
            TTreatment = new List<List<int>>();
            Random rand = new Random();
            for (int i = 0; i < L; i++)
            {
                TTreatment.Add(new List<int>());
                TSwitching.Add(new List<List<int>>());
                for (int j = 0; j < this.R.Count; j++)
                {
                    //int otnosh = 2;
                    TTreatment[i].Add(rand.Next(2, maxTimeTreatment));
                    TSwitching[i].Add(new List<int>());
                    for (int k = 0; k < this.R.Count; k++)
                    {
                        TSwitching[i][j].Add(rand.Next(2, maxTimeSwitching));
                    }
                }
            }
        }

        private void CalculateShedule()
        {
            this.StartProcessing = new List<List<List<int>>>();
            this.EndProcessing = new List<List<List<int>>>();
            for (int i = 0; i < L; i++)//количество приборов
            {
                this.StartProcessing.Add(new List<List<int>>());
                this.EndProcessing.Add(new List<List<int>>());
                for (int k = 0; k < this.R[0].Count; k++)
                {
                    int ind = this.ReturnRIndex(k);
                    if (ind != -1)
                    {
                        if (this.R[ind][k] > 0)
                        {
                            this.StartProcessing[i].Add(new List<int>());
                            this.EndProcessing[i].Add(new List<int>());
                            for (int p = 0; p < this.R[ind][k]; p++)//количество требований
                            {
                                this.StartProcessing[i][k].Add(0);
                                this.EndProcessing[i][k].Add(0);
                            }
                        }
                    }
                }
            } 
            int yy, zz, xx;
            for (int i = 0; i < L; i++)
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
                                int timeToSwitch = TSwitching[i][xx][index];
                                if (index == xx && j != 0)
                                    timeToSwitch = 0;
                                this.StartProcessing[i][j][k] = Math.Max(this.EndProcessing[i][yy][zz] + timeToSwitch, this.EndProcessing[i - 1][j][k]);
                                this.EndProcessing[i][j][k] = this.StartProcessing[i][j][k] + TTreatment[i][index];
                                this.timeConstructShedule = this.EndProcessing[i][j][k];
                                yy = j;
                                zz = k;
                                xx = index;
                            }
                            else
                            {
                                int timeToSwitch = TSwitching[i][xx][index];
                                if (index == xx && j != 0)
                                    timeToSwitch = 0;
                                this.StartProcessing[i][j][k] = this.EndProcessing[i][yy][zz] + timeToSwitch;
                                this.EndProcessing[i][j][k] = this.StartProcessing[i][j][k] + TTreatment[i][index];
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
                    indd1 = i;
                }
                if (this.R[i][ind2] > 0)
                {
                    indd2 = i;
                }
            }
            temp = this.R[indd1][ind1];
            this.R[indd1][ind1] = 0;
            this.R[indd2][ind1] = this.R[indd2][ind2];
            this.R[indd2][ind2] = 0;
            this.R[indd1][ind2] = temp;
        }

        private List<int> CopyList(List<int> inList)
        {
            List<int> ret = new List<int>();
            for (int i = 0; i < inList.Count; i++)
            {
                ret.Add(inList[i]);
            }
            return ret;
        }

        private void ChangeColumTime(int ind1, int ind2)
        {
            for (int i = 0; i < L; i++)
            {
                List<int> temp = this.CopyList(this.StartProcessing[i][ind1]);
                this.StartProcessing[i][ind1] = this.CopyList(this.StartProcessing[i][ind2]);
                this.StartProcessing[i][ind2] = temp;
                List<int> temp1 = this.CopyList(this.EndProcessing[i][ind1]);
                this.EndProcessing[i][ind1] = this.CopyList(this.EndProcessing[i][ind2]);
                this.EndProcessing[i][ind2] = temp1;
            }
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
                    //this.ChangeColumTime(0, 1);
                    this.CalculateShedule();
                    if (tempTime < this.timeConstructShedule)
                    {
                        this.R = tempR;
                        this.timeConstructShedule = tempTime;
                    }
                    break;
                default:
                    this.CalculateShedule();
                    tempR = CopyMatrix(this.R);
                    tempTime = this.timeConstructShedule;
                    for (int i = this.R[0].Count - 1; i > 0; i--)
                    {
                        this.ChangeColum(i - 1, i);
                        //this.ChangeColumTime(i - 1, i);
                        this.CalculateShedule();
                        if (tempTime < this.timeConstructShedule)
                        {
                            this.R = tempR;
                            this.timeConstructShedule = tempTime;
                        }
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
