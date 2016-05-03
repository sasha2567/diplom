using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
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

        public BatchTypeClaims(int valueH, int valueCountClaims, List<List<int>> valueA1)
        {
            MessageBox.Show("Алгоритм формирования решения i-ого типа данных.Шаг 1");
            this.np2 = 0;
            this.np1 = valueA1.Count;
            this.q1 = 1;
            this.q2 = 0;
            this.q2i = 0;
            this.g = 1;
            this.h = valueH;
            this.A1 = new List<List<int>>(valueA1);
            this.A2 = new List<List<int>>(this.A1);
            this.countClaims = valueCountClaims;
        }

        public void FormationDecisionPartMakeup()
        {
            
            if (this.q2 > this.A2.Count)
                this.A2.Add(new List<int>(this.countClaims));
            int summ = 0;
            for (int i = 1; i < this.A2[this.q1].Count; i++)
            {
                if (i != this.h)
                {
                    this.A2[this.q2][i] = this.A1[this.q1][i];
                    if(i != 1)
                        summ += this.A1[this.q1][i];
                }
                else
                {
                    this.A2[this.q2][i] = this.A1[this.q1][i] + 1;
                }
            }
            if(summ != 0)
                this.A2[this.q2][1] = this.countClaims - summ;
            else
                this.A2[this.q2][1]--;
        }

        public bool CheckingMatrixA2(int flag)
        {
            switch (flag)
            {
                case 1:
                    if (this.A2[this.q2][1] < this.A2[this.q2][this.h])
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

        public void SortedMatrixA2()
        {
            List<List<int>> temp = new List<List<int>>(this.A2);
        }

        public bool GenerateSolution()
        {
            this.q2++;
            MessageBox.Show("Шаг 2");
            this.FormationDecisionPartMakeup();
            MessageBox.Show("Шаг 3");
            this.np2++;
            MessageBox.Show("Шаг 4");
            if (this.CheckingMatrixA2(1))
            {
                this.j = 1;
                Step5:
                MessageBox.Show("Шаг 5");
                if (this.h + this.j <= this.countClaims)
                {
                    if (this.CheckingMatrixA2(2))
                    {
                        this.h += this.j;
                        MessageBox.Show("Шаг 3");
                        FormationDecisionPartMakeup();
                    }
                    else
                    {
                        MessageBox.Show("Шаг 6");
                        if (this.CheckingMatrixA2(3))
                        {
                            this.j++;
                            MessageBox.Show("Шаг 5");
                            goto Step5;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Шаг 7");
                    goto Step8;
                }
            }
            Step8:
            MessageBox.Show("Шаг 8");
            this.np2--;
            this.q1++;
            if (this.q1 > this.np1)
            {

            }
            return true;
        }       
    }
}
