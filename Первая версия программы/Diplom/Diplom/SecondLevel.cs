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
        private int countL = 10;
        int Tz = 100;//вот здесь надо менять время обработки при 40 оно успеваетполностьюобработать все партии
                    
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
            while (true)
            {
                this.groups.Set_Nzt(this.groups.Nz);//1

                int i1 = this.groups.I2.Min();//2
                this.groups.I1.Remove(i1);//2

                this.groups.z = this.groups.Nzt.Min();//4
                this.groups.Nzt.Remove(this.groups.Nzt.Min());//4

                this.groups.hi1 = 1;//5
                
                //6
                //нужны данные   1 уроня все партии i` типа

                for (int i = 1; i < groups.Nz1.Count(); i++)
                  //  if (groups.Nz1[i] == A[i1])
                {
                    groups.Nz1[i].Add(A[i1]);
                    break;
                }
            }
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
                            groups.Nz1[logi][i].Remove(A[i][j]);
                            j--;
                            logi++;
                        }
                    }
                }
            }
            
            if((Q.Nz1[0].Count()>0)&&(c))
            Algoritm_3();
             
            return groups.Nz1;//изменить
        }

        
        public void Algoritm_3()
        {
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
                            groups.Nz1[k][i].Remove(Q.Nz1[0][i][j]);
                        }
                        else
                        {
                            Q.Nz1[0][i].Remove(Q.Nz1[0][i][j]);
                        }
                    }
                }
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
            return true;
        }
    }
}
