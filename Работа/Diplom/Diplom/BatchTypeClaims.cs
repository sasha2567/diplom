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
        private List<List<int>> A1;//Матрица составов партий требований в окресности Ок
        private List<List<int>> A2;//Матрица составов партий требований в окресности Ок+1
        private int countClaims;//Начальное количество требований для каждого типа данных
        private int np1;//Количество решений по составам партий данных , полученных на текущей (s+g)-ой  итерации алгоритма 
        private int np2;//Количество решений по составам партий данных , полученных на последующей  ((s+g)+1)-ой  итерации алгоритма 
        private int q1;//Индекс решения по составам партий данных в А1
        private int q2;//Индекс решения по составам партий данных в А2
        private int q2i;//Индекс максимального решения по составам партий данных в А2
        private int g;//Текущая итерация алгоритма
        private int h;//Номер партии, состав которой будет изменяться
        private int G;//Максимальное по модулю значение дискретного градиента
        private int j;//Дополнительный индекс к номеру партии h

        //Необходимая функция для предотвращения копирвания указателей на матрицы А1 и А2
        private void CopyMatrix(List<List<int>> valueA1)
        {
            this.A1 = new List<List<int>>(valueA1);
            this.A2 = new List<List<int>>();

            this.A2.Add(new List<int>());
            this.A2.Add(new List<int>());
            for (int i = 0; i < valueA1[1].Count; i++)
            {
                this.A2[1].Add(0);
            }
        }

        public BatchTypeClaims(int valueCountClaims, List<List<int>> valueA1)
        {
            this.np2 = 0;
            this.np1 = valueA1.Count - 1;
            this.q1 = 1;
            this.q2 = 0;
            this.q2i = 0;
            this.g = 1;
            this.CopyMatrix(valueA1);
            this.countClaims = valueCountClaims;
        }

        /*Формирование нового решения на основе рассматриваемого
         * 
         *Используются индексы q1 и q2
         *q1 - индекс текущего решения в матрице А1
         *q2 - индекс текущего решения в матрица А2
         *В результате происходит заполнение матрицы А2 значениями, полученными на основе матрицы А1
         */
        public void FormationDecisionPartMakeup()
        {
            if (this.q2 >= this.A2.Count)
            {
                this.A2.Add(new List<int>());
                for (int i = 0; i < this.A1[this.q1].Count; i++)
                {
                    this.A2[this.q2].Add(0);
                }
            }
            int summ = 0;
            if (this.q1 < this.A1.Count)
            {
                for (int i = 1; i < this.A1[this.q1].Count; i++)
                {
                    if (i != this.h)
                    {
                        this.A2[this.q2][i] = this.A1[this.q1][i];
                    }
                    else
                    {
                        this.A2[this.q2][i] = this.A1[this.q1][i] + 1;
                    }
                    if (i != 1)
                        summ += this.A2[this.q2][i];
                }
                this.A2[this.q2][1] = this.countClaims - summ;
            }
        }
        
        /*
         * Функция проверок для реализации алгоритма 
         * 
         * flag == 1 - проверка на количество требований в первой партии в соответствии с теоремой 1 на шаге 4
         * flag == 2 - проверка на количество требований в соответствии с теоремой 2 на шаге 5
         * flag == 3 - проверка на количество требований в соответствии с теоремой 2 на шаге 6
         * 
         */
        public bool CheckingMatrixA2(int flag)
        {
            switch (flag)
            {
                case 1:
                    try
                    {
                        if (this.A2[this.q2][1] < this.A2[this.q2][this.h])
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
                        if (this.A2[this.q1][this.h] == this.A2[this.q1][this.h + this.j])
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
         * Функция печати результатов алгоритма
         * 
         */ 
        public void PrintMatrix(int a = 1)
        {
            string s = "";
            if (a == 1)
            {
                s += "Матрица А2\n";
                foreach (List<int> row in this.A2)
                {
                    foreach (int colum in row)
                    {
                        s += colum + ", ";
                    }
                    s += "\n";
                }
            }
            else
            {
                s += "Матрица А1\n";
                foreach (List<int> row in this.A1)
                {
                    foreach (int colum in row)
                    {
                        s += colum + ", ";
                    }
                    s += "\n";
                }
            }
            MessageBox.Show(s);

        }

        /*
         * Функция получения неповторяющихся решений в матрице А2 на шаге 9
         *
         */
        public List<List<int>> SortedMatrixA2(List<List<int>> inMatrix)
        {
            List<List<int>> temp = new List<List<int>>();
            for (int j = 0; j < inMatrix.Count; j++)
            {
                temp.Add(new List<int>());
                for (int i = 0; i < inMatrix[j].Count; i++)
                {
                    temp[j].Add(inMatrix[j][i]);
                }
            }
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
                    int lastIndexForDel = temp.FindLastIndex(delegate(List<int> inList)
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
                    if (lastIndexForDel != i)
                    {
                        temp.RemoveAt(lastIndexForDel);
                        inMatrix.RemoveAt(lastIndexForDel);
                    }
                }
                countLoops++;
                if (countLoops > 100)
                    break;
            }
            return inMatrix;
        }

        /*
         * Основная функция работы алгоритма
         * 
         */ 
        public bool GenerateSolution()
        {
            //MessageBox.Show("Алгоритм формирования решения i-ого типа данных.Шаг 1");
            Step2:
            //MessageBox.Show("Шаг 2");
            this.h = 2;
            
            Step3:
            //MessageBox.Show("Шаг 3");
            this.q2++;
            this.FormationDecisionPartMakeup();

            //MessageBox.Show("Шаг 4");
            this.np2++;
            
            if (this.CheckingMatrixA2(1))
            {
                this.j = 1;
                Step5:
                //MessageBox.Show("Шаг 5");
                if (this.h + this.j <= this.countClaims)
                {
                    if (this.CheckingMatrixA2(2))
                    {
                        this.h += this.j;
                        goto Step3;
                    }
                    else
                    {
                        //MessageBox.Show("Шаг 6");
                        if (this.CheckingMatrixA2(3))
                        {
                            this.j++;
                            //MessageBox.Show("Шаг 5");
                            goto Step5;
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("Шаг 7");
                    goto Step8;
                }
            }
            Step8:
            //MessageBox.Show("Шаг 8");
            this.np2--;
            this.q1++;
            if (this.q1 > this.np1)
            {
                if (this.np2 > 1)
                {
                    //MessageBox.Show("Шаг 9");
                    this.A2 = this.SortedMatrixA2(this.A2);
                    this.np2 = this.A2.Count - 1;
                    this.q2 = 1;
                    this.q2i = 0;
                    this.G = 0;
                    if(this.np2 > 0)
                    {
                        goto Step11;
                    }
                }
                else
                {
                    //MessageBox.Show("Шаг 10");
                    return false;
                }
                Step11:
                //MessageBox.Show("Шаг 11");
                SecondLevel test = new SecondLevel();
            }
            else
            {
                goto Step2;
            }
            return true;
        }       
    }
}
