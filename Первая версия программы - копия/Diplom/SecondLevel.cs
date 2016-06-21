using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Diplom
{
    class SecondLevel
    {
        public static bool c;
        private Groups groups, Q;
        private Shedule shedule;
        private List<List<int>> A;
        public static int countL = 4;
        public static int Tz = 80;//вот здесь надо менять время обработки при 40 оно успеваетполностьюобработать все партии
        public int[] Prostoi = new int[4];   
        public SecondLevel()
        {
            this.groups = new Groups(5);
            this.Q = new Groups(5);
        }

        public void InitialConditions(int j)//this.groups.Z
        {
            for (int i = 0; i < this.groups.Z;i++)
                this.groups.k.Add(0);
            this.Q.k.Add(0);
            this.groups.Set_I1(j);//допустим
            this.groups.Set_I2(j);//допустим 
            this.groups.Set_M(j);//допустим 
            this.Q.Set_M(1);//допустим
        }

        private List<List<int>> BuildR(List<List<int>> N)
        {
            List<List<int>> Res=new List<List<int>>();
            for (int i = 0; i < N.Count(); i++)
            {
                Res.Add(new List<int>());
            }
            int sum = 0, count = 0;
            for (int i = 0; i < N.Count(); i++)
            {
                sum += N[i].Count();
            }
            for (int i = 0; i < N.Count(); i++)
            {
                for (int j = 0; j < sum; j++)
                {
                    Res[i].Add(0);
                }
            }
            for (int i = 0; i < N.Count(); i++)
            {
                for (int j = 0; j < N[i].Count(); j++)
                {

                    Res[i][count] = N[i][j];
                    count++;
                }
            }
            return Res;
        }

        public void Algoritm_1()
        {
            int buff,buff2;

            for (int i = 0; i < groups.Nz1.Count; i++)
            {
                for (int j = 0; j < groups.Nz1[i].Count; j++)
                {
                    for (int k = 0; k < groups.Nz1[i][j].Count; k++)
                    {
                        for (int l = 0; l < Q.Nz1[0].Count; l++)
                        {
                            for (int t = 0; t < Q.Nz1[0][l].Count; t++)
                            {
                                this.shedule = new Shedule(this.BuildR(groups.Nz1[i]), countL);
                                this.shedule.ConstructShedule();
                                buff2 = shedule.GetTime();
                                buff = groups.Nz1[i][j][k];
                                groups.Nz1[i][l][k] = Q.Nz1[0][l][t];
                                this.shedule = new Shedule(this.BuildR(groups.Nz1[i]), countL);
                                this.shedule.ConstructShedule();
                                if (shedule.GetTime() > buff2)
                                {
                                    groups.Nz1[i][j][k] = buff;
                                }
                            }
                        }
                    }
                }
            }
            Algoritm_3();
        }
        public List<List<List<int>>> Algoritm_2()
        {
            int logi = 0;//номер группы текущий расматриваемый 
            //A.Clear();
            /*for (int i = 0; i < 4; i++)
            {
                List<int> w = new List<int>();
                A.Add(w);
            }*/

            //A[0].Add(12); A[0].Add(2); A[0].Add(2);
            //A[1].Add(13); A[1].Add(3);
            //A[2].Add(10); A[2].Add(2); A[2].Add(2); A[2].Add(2);
            //A[3].Add(8); A[3].Add(2); A[3].Add(2); A[3].Add(2); A[3].Add(2);

            if (this.A[0].Count == 0)
            {
                A.RemoveAt(0);
                for (int i = 0; i < A.Count(); i++)
                    A[i].RemoveAt(0);
            }
            
            for (int i = 0; i < 4; i++)
            {
                groups.Nz1.Add(new List<List<int>>());
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    groups.Nz1[i].Add(new List<int>());
                }
            }


            Q.Nz1.Add(new List<List<int>>());
            for (int i = 0; i < 4; i++)
                Q.Nz1[0].Add(new List<int>());

            for (int i = 0; i < A.Count(); i++)
            {
                for (int j = 0; j < A[i].Count(); j++)
                {
                    if (logi >= 4)
                    {
                        Q.Nz1[0][i].Add(A[i][j]);

                    }
                    else
                    {
                        groups.Nz1[logi][i].Add(A[i][j]);
                        this.shedule = new Shedule(this.BuildR(groups.Nz1[logi]), countL);
                        this.shedule.ConstructShedule();
                         
                         if(this.shedule.GetTime() > Tz) 
                        {
                            groups.Nz1[logi][i].RemoveAt(groups.Nz1[logi][i].Count-1);
                            j--;
                            logi++;
                        }
                    }
                }
            }

            int sum=0;
            for (int i = 0; i < Q.Nz1[0].Count; i++)
                sum += Q.Nz1[0][i].Count;
            if((sum>0)&&c)
            Algoritm_3();
        
            return groups.Nz1;//изменить
        }

        
        public void Algoritm_3()
        {
            int buff=0;
            for (int k = 0; k < groups.Nz1.Count(); k++)
            {
                for (int i = 0; i < Q.Nz1[0].Count(); i++)
                {
                    for (int j = 0; j < Q.Nz1[0][i].Count(); j++)
                    {
                        groups.Nz1[k][i].Add(Q.Nz1[0][i][j]);

                        this.shedule = new Shedule(this.BuildR(groups.Nz1[k]), countL);
                        this.shedule.ConstructShedule();
                        if (shedule.GetTime() > Tz)
                        {
                            groups.Nz1[k][i].RemoveAt(groups.Nz1[k][i].Count-1);
                            
                        }
                        else
                        {
                            Q.Nz1[0][i].RemoveAt(j);
                        }
                    }
                }
            }
            for (int k = 0; k < groups.Nz1.Count(); k++)
            {
                this.shedule = new Shedule(this.BuildR(groups.Nz1[k]), countL);
                this.shedule.ConstructShedule();

                Prostoi[k]=Tz - shedule.GetTime();

                //MessageBox.Show(Convert.ToString(Tz - shedule.GetTime()));

            }
        }

        public List<List<int>> ReturnAMatrix()
        {
            List<List<int>> A1 = new List<List<int>>();
            A1.Add(new List<int>());
            for (int i = 0; i < this.A.Count(); i++)
            {
                A1.Add(new List<int>());
                A1[i + 1].Add(0);
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < groups.Nz1[i].Count(); j++)
                {
                    for (int k = 0; k < groups.Nz1[i][j].Count(); k++)
                    {
                        A1[j + 1].Add(groups.Nz1[i][j][k]);
                    }
                }
            }
            return A1;
        }
        public bool GenerateSolution(List<List<int>> matrixA)
        {
            this.A = matrixA;
            this.Algoritm_2();
            //this.Algoritm_1();
            return true;
        }
    }
}
