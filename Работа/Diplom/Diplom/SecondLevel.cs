﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Diplom
{
    class SecondLevel
    {

        Groups groups=new Groups(5),Q=new Groups(1);

        public void nach_uslov(int j)//this.groups.Z
        {
            for (int i = 0; i < this.groups.Z;i++)
                this.groups.k.Add(0);
            this.Q.k.Add(0);
            this.groups.Set_I1(j);//допустим
            this.groups.Set_I2(j);//допустим 
            this.groups.Set_M(j);//допустим 
            this.Q.Set_M(1);//допустим
           
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

                


            }
        }

        public bool GenerateSolution(List<List<int>> matrixA)
        {
            return true;
        }

        public List<List<int>> ReturnAMatrix()
        {
            List<List<int>> ret = new List<List<int>>();//Сюда добавь код для построения матрицы А
            //из партий требований, добавленных в группы (МАКСИМАЛЬНОЕ решение по составам партий)
            //Либо верни все партии удовлетворяющие критерию по расписанию
            //То биж все группы партий, вошедшие в обработку
            return ret;
        }
    }
}
