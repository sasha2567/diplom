using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    /*
     * BatchTypeClaims Class
     * 
     * Необходим для реализации алгоритма получения решения в окресности О(k+1) из решений, 
     * полученных в окресности О(k)
     * 
     */
    class BatchTypeClaims
    {
        private List<List<int>> A;//Матрица составов партий требований максимальных решений
        private List<List<int>> A1;//Матрица составов партий требований в окресности Ок
        private List<List<int>> A2;//Матрица составов партий требований в окресности Ок+1
        private int countClaims;//Начальное количество требований для текущего типа данных
        private int np1;//Количество решений по составам партий данных , полученных на текущей (s+g)-ой  итерации алгоритма 
        private int np2;//Количество решений по составам партий данных , полученных на последующей  ((s+g)+1)-ой  итерации алгоритма 
        private int q1;//Индекс решения по составам партий данных в А1
        private int q2;//Индекс решения по составам партий данных в А2
        private int q2i;//Индекс максимального решения по составам партий данных в А2
        private int g;//Текущая итерация алгоритма
        private int h;//Номер партии, состав которой будет изменяться
        private int G;//Максимальное по модулю значение дискретного градиента
        private int j;//Дополнительный индекс к номеру партии h
        private int i;//Идентификатор текущего типа партии
        private int f1;//критерий, полученный с первого уровня для определения лучшего решения
        private bool inMatrixFlag = false;//флаг проверки входных зачений

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
         * Функция печати результатов алгоритма
         * 
         */
        public void PrintMatrix(int a = 1)
        {
            string s = "";
            List<List<int>> matrix = new List<List<int>>();
            switch (a)
            {
                case 1:
                    s += "Матрица А\n";
                    matrix = this.A;
                    break;
                case 2:
                    s += "Матрица А1\n";
                    matrix = this.A1;
                    break;
                case 3:
                    s += "Матрица А2\n";
                    matrix = this.A2;
                    break;
            }
            foreach (List<int> row in matrix)
            {
                foreach (int colum in row)
                {
                    s += colum + ", ";
                }
                s += "\n";
            }
            MessageBox.Show(s);
            //MessageBox.Show(s);

        }

        /*
         * Возврат полученные решения по составам партий из различных матриц
         * 
         * param == 1 - Возврат матрицы А
         * param == 2 - Возврат матрицы А1
         * param == 3 - Возврат матрицы А2
         * 
         */
        public List<List<int>> ReturnMatrix(int param)
        {
            List<List<int>> matrix = new List<List<int>>();
            switch (param)
            {
                case 1:
                    matrix = this.A;
                    break;
                case 2:
                    matrix = this.A1;
                    break;
                case 3:
                    matrix = this.A2;
                    break;
            }
            List<List<int>> ret = new List<List<int>>();
            for (int i = 0; i < matrix.Count; i++)
            {
                ret.Add(new List<int>());
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    ret[i].Add(matrix[i][j]);
                }
            }
            return ret;
        }

        /* 
         * Конструктор с параметрами
         * 
         * valueI - идентификатор текущего типа, подлежащего изменению
         * valueCountClaims - количество требований текущего типа
         * valueA1 - начальные решения, полученные на предыдущем шаге (текущее локальное решение)
         * valueA - матрица решений по всем типам данных (текущее глобальное решение)
         * 
         */
        public BatchTypeClaims(int valieCriterion, int valueI, int valueCountClaims, List<List<int>> valueA1, List<List<int>> valueA)
        {

            this.A = this.CopyMatrix(valueA);
            if (this.A[1].Count <= 1)
            {
                this.inMatrixFlag = true;
            }
            this.A1 = this.CopyMatrix(valueA1);
            this.A2 = new List<List<int>>();
            try
            {
                this.A2.Add(new List<int>());
                this.A2.Add(new List<int>());
                for (int i = 0; i < valueA1[1].Count; i++)
                {
                    this.A2[1].Add(0);
                }
            }
            catch
            {
                this.inMatrixFlag = true;
            }
            this.i = valueI;
            this.np2 = 1;
            this.np1 = this.A1.Count - 1;
            this.q2 = 0;
            this.q2i = 0;
            this.g = 1;
            this.f1 = valieCriterion;
            this.countClaims = valueCountClaims;
        }

        /*
         * Функция проверок для реализации алгоритма 
         * 
         * flag == 1 - проверка на количество требований в первой партии в соответствии с теоремой 1 на шаге 4
         * flag == 2 - проверка на количество требований в соответствии с теоремой 2 на шаге 5
         * flag == 3 - проверка на количество требований в соответствии с теоремой 2 на шаге 6
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
                        if (this.A1[this.q1][this.h] > this.A1[this.q1][this.h + this.j])
                        {
                            return true;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                    break;
                case 3:
                    try
                    {
                        if (this.A1[this.q1][this.h] == this.A1[this.q1][this.h + this.j])
                        {
                            return true;
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
         * Функция получения неповторяющихся решений в матрице А2 на шаге 9
         *
         */
        public List<List<int>> SortedMatrix(List<List<int>> inMatrix)
        {
            List<List<int>> temp = this.CopyMatrix(inMatrix);
            //сортировка буферной матрицы
            foreach (List<int> row in temp)
            {
                row.Sort(delegate(int mc1, int mc2)
                {
                    return mc1.CompareTo(mc2);
                });
            }

            //Удаление повторяющихся строк
            int countLoops = 0;
            while (true)
            {
                for (int i = 1; i < temp.Count; i++)
                {
                    int lastIndexForDelete = temp.FindLastIndex(delegate(List<int> inList)
                    {
                        int count_find = 0;
                        for (int k = 0; k < inList.Count; k++)
                        {
                            if (inList[k] == temp[i][k])
                            {
                                count_find++;
                            }
                        }
                        return count_find == inList.Count ? true : false;
                    });
                    if (lastIndexForDelete != i)
                    {
                        temp.RemoveAt(lastIndexForDelete);
                        inMatrix.RemoveAt(lastIndexForDelete);
                    }
                }
                countLoops++;
                if (countLoops > 100)
                    break;
            }
            return inMatrix;
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
            return criterion;
        }

        /*
         * Формирование нового решения на основе рассматриваемого
         * 
         *Используются индексы q1 и q2
         *q1 - индекс текущего решения в матрице А1
         *q2 - индекс текущего решения в матрица А2
         *В результате происходит заполнение матрицы А2 значениями, полученными на основе матрицы А1
         *
         */
        public void FormationDecisionPartMakeup()
        {
            if (this.q2 >= this.A2.Count)
            {
                while (this.q2 >= this.A2.Count)
                {
                    this.A2.Add(new List<int>());
                    for (int i = 0; i < this.A1[this.q1].Count; i++)
                    {
                        this.A2[this.q2].Add(0);
                    }
                }
            }
            if (this.q1 < this.A1.Count)
            {
                int summ = 0;
                for (int i = 2; i < this.A1[this.q1].Count; i++)
                {
                    if (i != this.h)
                    {
                        this.A2[this.q2][i] = this.A1[this.q1][i];
                    }
                    else
                    {
                        this.A2[this.q2][i] = this.A1[this.q1][i] + 1;
                    }
                    summ += this.A2[this.q2][i];
                }
                this.A2[this.q2][1] = this.countClaims - summ;
            }
        }
        
        /*
         * Основная функция работы алгоритма
         * 
         */ 
        public bool GenerateSolution()
        {
            if (this.inMatrixFlag)
            {
                return false;
            }
            Nachalo:
            bool step5 = false;
            this.q1 = 1;
            this.h = 2;
            this.j = 1;
            while (this.q1 <= this.np1)
            {
                if (!step5)
                {
                    step5 = false;
                    this.q2++;
                    this.FormationDecisionPartMakeup();
                    this.np2++;
                    if (!this.CheckingMatrix(1))
                    {
                        this.A2.RemoveAt(this.q2);
                        this.q2--;
                        this.np2--;
                    }
                }
                if (this.h + this.j <= this.A1[this.q1].Count - 1)
                {
                    if (this.CheckingMatrix(2))
                    {
                        this.h += this.j;
                        continue;
                    }
                    if (this.CheckingMatrix(3))
                    {
                        this.j++;
                        step5 = true;
                        continue;
                    }
                }
                this.q1++;
                this.h = 2;
                this.j = 1;
            }
            this.np2 = this.A2.Count;
            if (this.np2 > 1)
            {
                this.A2 = this.SortedMatrix(this.A2);
                this.np2 = this.A2.Count - 1;
                this.G = 0;
                if (this.np2 > 0)
                {
                    bool flagSolution = false;
                    for (int indexQ = 1; indexQ < this.A2.Count; indexQ++)
                    {
                        int f1g = 0;
                        List<List<int>> tempA = CopyMatrix(this.A);
                        tempA[this.i] = this.A2[indexQ];
                        SecondLevel secondLevel = new SecondLevel();
                        secondLevel.GenerateSolution(tempA);
                        List<List<int>> tempMatrixA = secondLevel.ReturnAMatrix();
                        f1g = this.GetCriterion(tempMatrixA);
                        Random rand = new Random();
                        int ret = rand.Next(5, 15);
                        //if (ret < 10) 
                        if (f1g >= this.f1)
                        {
                            this.q2i = indexQ;
                            this.G = f1g - this.f1;
                            this.f1 = f1g;
                            flagSolution = true;
                        }
                    }
                    if (flagSolution == false)
                    {
                        for (int ii = 1; ii < this.A2.Count; ii++)
                        {
                            this.A2[ii].Insert(0, 0);
                        }
                        this.A1 = CopyMatrix(this.A2);
                        this.q1 = this.A1.Count - 1;
                        this.np2 = 0;
                        this.q2 = 0;
                        goto Nachalo;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }      
    }
}
