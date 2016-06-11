using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    class FirstLevel
    {
        private List<int> I;//Вектор интерпритируемых типов данных
        private List<int> Ii;//Вектор интерпритируемых типов данных на текущем шагу алгоритма
        private List<int> mi;//Вектор количества партий данных для каждого типа данных
        private List<int> np1i;//задание для каждого i-го типа данных количества решений по составам партий данных i-ых типов, сформированных на текущей ите-рации алгоритма
        private List<int> np2i;//задание для каждого i-го типа данных количества решений по составам партий данных i-ых типов, сформированных на текущей ите-рации алгоритма
        private List<List<int>> A1i;//Буферизированная матрица составов партий требований на k+1 шаге 
        private List<List<int>> A1;//Матрица составов партий требований на k+1 шаге 
        private List<List<int>> A2;//Матрица составов партий требований фиксированного типа
        private List<List<int>> A;//Матрица составов партий требований на k шаге
        private List<List<int>> ABuf;//Буферизированная матрица составов партий требований
        private int countType;//количество типов
        private List<int> countClaims;//Начальное количество требований для каждого типа данных
        private BatchTypeClaims test;
        private int i;//идентификатор текущего изменяемого типа
        private int G;
        private int q2;
        private int k;
        private List<int> fi;//Критерии решений всех типов данных
        private int f1;//Критерий текущего решения для всех типов
        private int f1Buf;//Критерий текущего решения для всех типов
        private bool solutionFlag;

        /* 
         * Конструктор с параметрами
         * 
         * count_type - количество типов рассматриваемых данных
         * count_claims - количество требований всех типов данных
         * 
         */
        public FirstLevel(int count_type, List<int> count_claims)
        {
            this.countType = count_type;
            this.countClaims = count_claims;
            this.mi = new List<int>(this.countType);
            this.np1i = new List<int>(this.countType);
            this.np2i = new List<int>(this.countType);
            this.I = new List<int>(this.countType);
            this.Ii = new List<int>(this.countType);
        }

        /*
         * Функция копирования значений между матрицами, предотвращающая копирование указателей
         * 
         */
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

        /*
         * Алгоритм формирования начальных решений по составам партий всех типов
         *  
         */ 
        public void GenerateStartSolution()
        {
            int claim = 2;
            this.A = new List<List<int>>();
            this.A.Add(new List<int>());
            for (int i = 1; i <= this.countType; i++)
            {
                this.I.Add(1);
                this.Ii.Add(1);
                this.mi.Add(claim);
                this.np1i.Add(1);
                this.np2i.Add(1);
                this.A.Add(new List<int>());
                this.A[i].Add(0);
                this.A[i].Add(this.countClaims[i - 1] - claim);
                this.A[i].Add(claim);
            }
            for (int i = 1; i <= this.countType; i++)
            {
                if (this.A[i][1] < 2 || this.A[i][1] < this.A[i][2])
                {
                    this.A[i].Clear();
                    this.A[i].Add(0);
                    this.A[i].Add(this.countClaims[i - 1]);
                    this.mi[i - 1] = 1;
                    this.np1i[i - 1] = 0;
                    this.I[i - 1] = 0;
                    this.Ii[i - 1] = 0;
                }
            }
            this.G = 0;    
        }

        /*
         * Функция вычисления f1 критерия
         * 
         */
        public int GetCriterion(List<List<int>> inMatrix)
        {
            int criterion = 0;
            for (int i = 1; i < inMatrix.Count; i++)
            {
                for (int j = 1; j < inMatrix[i].Count; j++)
                {
                    criterion += inMatrix[i][j];
                }
            }
            int criterionA = 0;
            for (int i = 1; i < this.A.Count; i++)
            {
                for (int j = 1; j < this.A[i].Count; j++)
                {
                    criterionA += this.A[i][j];
                }
            }
            return criterionA - criterion;
            /*Random rand = new Random();
            int ret = rand.Next(5,15);
            return ret;*/
        }

        /*
         * Функция проверок для реализации алгоритма 
         * 
         * flag == 1 - проверка на количество требований в соответствии с теоремой 1
         * flag == 2 - проверка на количество требований в первой партии в соответствии с теоремой 1
         * 
         */
        public bool CheckingMatrix(int flag)
        {
            switch (flag)
            {
                case 1:
                    try
                    {
                        for (int i = 2; i < this.A2[1].Count; i++)
                            if (this.A2[1][1] < this.A2[1][i])
                            {
                                return false;
                            }
                    }
                    catch
                    {
                        return false;
                    }
                    break;
               case 2:
                    try
                    {
                        if (this.A2[1][1] < 2)
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }

        /*
         * Функция проверки наличия оставшихся в рассмотрении типов
         * 
         */ 
        private bool CheckType(List<int> type)
        {
            int count = 0;
            for (int j = 0; j < this.countType; j++)
            {
                if (type[j] != 0)
                    count++;
            }
            if (count == 0)
                return true;
            return false;
        }

        /*
         * Алгоритм формирования решения по составам паритй всех типов данных
         * 
         */ 
        public void GenerateSolution()
        {
            this.GenerateStartSolution();
            //SecondLevel secondLevel = new SecondLevel();
            //List<List<int>> temp = this.CopyMatrix(this.A);
            //secondLevel.GenerateSolution(temp);
            //List<List<int>> tmpMatrixA = secondLevel.ReturnAMatrix();
            this.k = 0;
            //this.f1 = this.GetCriterion(tmpMatrixA);
            this.f1 = 20;
            this.f1Buf = this.f1;
            //Добавить вычисление значения критерия
            while (!this.CheckType(this.I))
            {
                this.solutionFlag = false;
                //1 - Копируем I в Ii
                this.fi = new List<int>();
                for (int j = 0; j < this.countType; j++)
                {
                    this.Ii[j] = this.I[j];
                    this.fi.Add(0);
                }
                this.ABuf = this.CopyMatrix(A);
                //Для каждого рассматриваемого типа
                for (int iter = 0; iter < this.Ii.Count; iter++)
                {
                    if (this.Ii[iter] != 0)
                    {
                        this.i = iter;
                        if (this.np1i[this.i] > 0)
                        {
                            this.A1 = this.CopyMatrix(this.A);
                            this.G = f1;
                            //MessageBox.Show("Решение по составу партий данных " + (this.i + 1) + " типа на " + (this.k + 1) + " шаге алгоритма");
                            //Получение состава партий фиксированного типа
                            List<List<int>> toBatchAlgoritm = new List<List<int>>();
                            toBatchAlgoritm.Add(new List<int>());
                            toBatchAlgoritm.Add(new List<int>());
                            toBatchAlgoritm[1] = this.A1[this.i + 1];
                            test = new BatchTypeClaims(this.f1, this.i + 1, this.countClaims[this.i], toBatchAlgoritm, this.A1);
                            test.GenerateSolution();
                            
                            //test.PrintMatrix(2);
                            //test.PrintMatrix(3);
                            
                            List<List<int>> tempA2 = test.ReturnMatrix(3);
                            if (tempA2.Count < 2)
                            {
                                this.mi[this.i]++;
                                this.A2 = new List<List<int>>();
                                this.A2.Add(new List<int>());
                                this.A2.Add(new List<int>());
                                this.A2[1].Add(0);
                                this.A2[1].Add(0);
                                int sum = 0;
                                for (int j = 1; j < this.mi[this.i]; j++)
                                {
                                    this.A2[1].Add(2);
                                    sum += 2;
                                }
                                this.A2[1][1] = this.countClaims[this.i] - sum;
                                if (!this.CheckingMatrix(1) && !this.CheckingMatrix(2))
                                {
                                    this.I[this.i] = 0;
                                    continue;
                                }
                            }
                            else
                            {
                                this.A2 = this.CopyMatrix(tempA2);
                            }

                            //Буферизируем текущее решение для сравнения
                            this.A1i = this.CopyMatrix(this.A1);

                            for (this.q2 = 1; this.q2 < this.A2.Count; this.q2++)
                            {
                                for (int h = 0; h < this.A2[this.q2].Count; h++)
                                    if (this.A1i[this.i + 1].Count < this.A2[this.q2].Count)
                                    {
                                        this.A1i[this.i + 1].Add(this.A2[this.q2][h]);
                                    }
                                    else
                                    {
                                        this.A1i[this.i + 1][h] = this.A2[this.q2][h];
                                    }
                                SecondLevel secondLevel = new SecondLevel();
                                List<List<int>> tempA = CopyMatrix(this.A1i);
                                secondLevel.GenerateSolution(tempA);
                                List<List<int>> tempMatrixA = secondLevel.ReturnAMatrix();
                                int f1g = 5;// = this.GetCriterion(tempMatrixA);
                                Random rand = new Random();
                                int ret = rand.Next(5, 15);
                                if(ret < 10)
                                //if (f1g - this.f1 <= 0 && f1g < this.f1Buf)
                                {
                                    this.fi[this.i] = f1g;
                                    this.f1Buf = this.fi[this.i];
                                    this.solutionFlag = true;
                                    this.ABuf = this.CopyMatrix(this.A1i);
                                }
                            }
                        }
                    }
                }
                this.k++;
                if (this.solutionFlag)
                {
                    this.f1 = this.f1Buf;
                    this.A = this.CopyMatrix(ABuf);
                }
                else
                {
                    MessageBox.Show("На текущем шаге не найдено ни одного решения");
                    break;
                }
            }
            test.PrintMatrix(1);
        }
    }
}
