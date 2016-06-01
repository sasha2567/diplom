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
        private List<List<int>> A1;//Матрица составов партий требований
        private List<List<int>> A2;//Матрица составов партий требований
        private List<List<int>> A;//Матрица составов партий требований максимальных решений
        private int countType;//количество типов
        private List<int> countClaims;//Начальное количество требований для каждого типа данных
        private BatchTypeClaims test;
        private int i;//идентификатор текущего изменяемого типа
        private int G;
        private int g;
        private List<int> Gi;
        private int q1;
        private int q2;
        private int q2i;
        private int k;
        private List<int> f1i;//Критерии начальных решений всех i-ого типа данных
        private int f1;//Критерий текущего решения для всех типов

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
            this.Gi = new List<int>(this.countType);
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
                this.Gi.Add(0);
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
                for (int j = 1; j < inMatrix[i].Count; i++)
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
            //return criterionA - criterion;
            return -1;
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
                        for (int i = 2; i < this.A2[this.q2].Count; i++)
                            if (this.A2[this.q2][1] < this.A2[this.q2][i])
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
                        if (this.A2[this.q2][1] < 2)
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
            this.f1i = new List<int>();
            for (int i = 0; i < this.countType; i++)
            {
                this.f1i.Add(0);
            }
            this.GenerateStartSolution();
            SecondLevel secondLevel = new SecondLevel();
            secondLevel.GenerateSolution(this.A);
            List<List<int>> tmpMatrixA = secondLevel.ReturnAMatrix();
            this.f1 = 0;//this.GetCriterion(tmpMatrixA);
            //Добавить вычисление значения критерия
            for (int j = 0; j < this.countType; j++)
            {
                this.Ii[j] = this.I[j];
            }
            for (int iter = 0; iter < this.Ii.Count; iter++)
            {
                if (this.Ii[iter] != 0)
                {
                    this.i = iter;
                    if (this.np1i[this.i] > 0)
                    {
                        this.q1 = 1;
                        this.k = 0;
                        this.A1 = new List<List<int>>();
                        this.A1.Add(new List<int>());
                        for (int i = 1; i < this.A.Count; i++)
                        {
                            this.A1.Add(new List<int>());
                            for (int j = 0; j < this.A[i].Count; j++)
                            {
                                this.A1[i].Add(this.A[i][j]);
                            }
                        }
                        List<List<int>> toBatchAlgoritm = new List<List<int>>();
                        toBatchAlgoritm.Add(new List<int>());
                        toBatchAlgoritm.Add(new List<int>());
                        toBatchAlgoritm[1] = this.A1[this.i + 1];
                        test = new BatchTypeClaims(this.f1i[this.i], this.i, this.countClaims[this.i], toBatchAlgoritm, this.A);
                        test.GenerateSolution();
                        MessageBox.Show("Решение по составу партий данных "+ this.i + " типа");
                        test.PrintMatrix(2);
                        test.PrintMatrix(3);
                        List<List<int>> tempA2 = test.ReturnMatrix(3);
                        if (tempA2.Count == 0)
                        {
                            this.mi[this.i]++;
                            this.q2 = 1;
                            this.Gi[this.i] = 0;
                            this.g = 1;
                            this.A2 = new List<List<int>>();
                            this.A2.Add(new List<int>());
                            this.A2.Add(new List<int>());
                            this.A2[this.q2].Add(0);
                            this.A2[this.q2].Add(0);
                            int sum = 0;
                            for (int j = 1; j < this.mi[this.i]; j++)
                            {
                                this.A2[this.q2].Add(2);
                                sum += 2;
                            }
                            this.A2[this.q2][1] = this.countClaims[this.q2] - sum;
                            if (this.CheckingMatrix(1) && this.CheckingMatrix(2))
                            {
                                for (int h = 0; h < this.A2[this.q2].Count; h++)
                                    if (this.A[this.i + 1].Count < this.A2[this.q2].Count)
                                    {
                                        this.A[this.i + 1][h] = this.A2[this.q2][h];
                                    }
                                    else
                                    {
                                        this.A[this.i + 1].Add(this.A2[this.q2][h]);
                                    }
                                secondLevel.GenerateSolution(this.A);
                                List<List<int>> tempMatrixA = secondLevel.ReturnAMatrix();
                                int f1g = this.GetCriterion(tempMatrixA);
                                if (f1g - this.f1 <= 0)
                                {
                                    this.q2i = this.q2;
                                    this.Gi[this.i] = f1g - this.f1;
                                }
                            }
                            else
                            {
                                this.I[this.i] = 0;
                            }    
                        }
                        else
                        {
                            this.A2 = tempA2;
                            this.q2 = 1;
                            for (this.q2 = 1; this.q2 < this.A2.Count; this.q2++)
                            {
                                for (int h = 0; h < this.A2[this.q2].Count; h++)
                                    if (this.A[this.i + 1].Count < this.A2[this.q2].Count)
                                    {
                                        this.A[this.i + 1][h] = this.A2[this.q2][h];
                                    }
                                    else
                                    {
                                        this.A[this.i + 1].Add(this.A2[this.q2][h]);
                                    }
                                secondLevel.GenerateSolution(this.A);
                                List<List<int>> tempMatrixA = secondLevel.ReturnAMatrix();
                                int f1g = this.GetCriterion(tempMatrixA);
                                if (f1g - this.f1 <= 0)
                                {
                                    this.q2i = this.q2;
                                    this.Gi[this.i] = f1g - this.f1;
                                }
                            }
                        }
                    }
                    if (this.CheckType(this.I))
                    {
                        return;
                    }
                    else
                    {
                        for (int j = 0; j < this.countType; j++)
                        {
                            this.Ii[j] = this.I[j];
                        }
                        int count = 0;
                        for (int j = 0; j < this.countType; j++)
                        {
                            if (this.Gi[j] < 0)
                            {
                                count++;
                            }
                        }
                        if (count > 0)
                        {
                            this.q2i = 0;
                            for (int ind = 0; ind < this.countType; ind++)
                            {
                                if (this.G > this.Gi[ind] && this.G < 0 && this.Gi[ind] < 0)
                                {
                                    this.q2i = ind + 1;
                                    this.G = this.Gi[ind];
                                }
                            }
                            if (this.q2i != 0)
                            {
                                this.A[this.i + 1] = this.A2[this.q2i];
                            }
                        }
                    }
                }
            }
            
            //Тестовый запуск алгоритма формирования решений i-ого типа
            MessageBox.Show("Генерируем начальное решение");
            List<List<int>> temp = new List<List<int>>();
            temp.Add(new List<int>());
            temp.Add(new List<int>());
            temp[1].Add(0);
            temp[1].Add(14);
            temp[1].Add(2);
            /*temp.Add(new List<int>());
            temp[2].Add(0);
            temp[2].Add(5);
            temp[2].Add(5);
            temp[2].Add(3);
            temp[2].Add(3);
            temp.Add(new List<int>());
            temp[3].Add(0);
            temp[3].Add(5);
            temp[3].Add(4);
            temp[3].Add(4);
            temp[3].Add(3);*/
            int countLoop = 0;
            while (true)
            {
                if (countLoop == 0)
                    test = new BatchTypeClaims(10, 1, 16, temp, this.A);
                else
                    test = new BatchTypeClaims(10, 1, 16, test.ReturnMatrix(3), this.A);
                if (test.GenerateSolution())
                {
                    test.PrintMatrix(2);
                    test.PrintMatrix(3);
                }
                countLoop++;
                if (countLoop == 7)
                    break;
                else
                    MessageBox.Show("Генерируем новое решение");
            }
            this.GenerateStartSolution();
            return;
        }
    }
}
