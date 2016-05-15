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
        private List<int> mi;//Вектор количества партий данных для каждого типа данных
        private List<int> npi;//задание для каждого i-го типа данных количества решений по составам партий данных i-ых типов, сформированных на текущей ите-рации алгоритма
        private List<List<int>> A1;//Матрица составов партий требований
        private List<List<int>> A2;//Матрица составов партий требований
        private List<List<int>> A;//Матрица составов партий требований максимальных решений
        private int countType;//количество типов
        private List<int> countClaims;//Начальное количество требований для каждого типа данных
        private BatchTypeClaims test;
        private int i;//идентификатор текущего изменяемого типа
        private int G;
        private int q1;
        private int q2;
        private int k;
        private List<int> f1;//Критерии начальных решений всех типов данных

        /*
         * 
         * 
         */ 
        public FirstLevel(int count_type, List<int> count_claims)
        {
            this.countType = count_type;
            this.countClaims = count_claims;
            this.mi = new List<int>(this.countType);
            this.npi = new List<int>(this.countType);
            this.I = new List<int>(this.countType);
        }

        /*
         * 
         * 
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
                this.mi.Add(claim);
                this.npi.Add(1);
                this.A.Add(new List<int>());
                this.A[i].Add(0);
                this.A[i].Add(this.countClaims[i - 1] - claim);
                this.A[i].Add(claim);
            }
            for (int i = 1; i <= this.countType; i++)
            {
                if (this.A[i][1] < 2 || this.A[i][1] < this.A[i][1])
                {
                    this.A[i].Clear();
                    this.A[i].Add(0);
                    this.A[i].Add(this.countClaims[i - 1]);
                    this.mi[i - 1] = 1;
                    this.npi[i - 1] = 0;
                    this.I[i - 1] = 0;
                }
            }
            this.G = 0;    
        }

        /*
         * 
         * 
         * 
         */ 
        public int GetCriterion()
        {
            return 0;
        }

        /*
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */ 
        public bool GenerateSolution()
        {
            this.GenerateStartSolution();
            SecondLevel secondLevel = new SecondLevel();
            secondLevel.GenerateSolution(this.A);
            //Добавить вычисление значения критерия
            for (int j = 0; j < this.I.Count; j++)
            {
                if (j > this.i && this.I[j] != 0)
                {
                    this.i = j;
                    break;
                }
            }
            if (this.npi[this.i] > 0)
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
                test = new BatchTypeClaims(this.i, this.countClaims[this.i], this.A1, this.A);
                List<List<int>> tempA = test.ReturnMatrixA2();
                if (tempA.Count == 0)
                {
                    this.mi[this.i]++;
                    this.q2 = 1;
                    this.A2 = new List<List<int>>();
                    this.A2.Add(new List<int>());
                    this.A2.Add(new List<int>());
                    this.A2[this.q2].Add(0);
                    this.A2[this.q2].Add(0);
                    int sum = 0;
                    for (int j = 0; j < this.mi[this.q2]; j++)
                    {
                        this.A2[this.q2].Add(2);
                        sum += 2;
                    }
                    this.A2[this.q2][1] = this.countClaims[this.q2] - sum;
                }
            }
            //ТЕстовый запуск алгоритма формирования решений i-ого типа
            MessageBox.Show("Генерируем начальное решение");
            List<List<int>> temp = new List<List<int>>();
            temp.Add(new List<int>());
            temp.Add(new List<int>());
            temp[1].Add(0);
            temp[1].Add(10);
            temp[1].Add(2);
            temp[1].Add(2);
            temp[1].Add(2);
            int countLoop = 0;
            while (true)
            {
                if (countLoop == 0)
                    test = new BatchTypeClaims(1, 16, temp, this.A);
                else
                    test = new BatchTypeClaims(1, 16, test.ReturnMatrixA2(), this.A);
                if (test.GenerateSolution())
                {
                    test.PrintMatrix(2);
                    test.PrintMatrix();
                }
                countLoop++;
                if (countLoop == 5)
                    break;
                else
                    MessageBox.Show("Генерируем новое решение");
            }
            this.GenerateStartSolution();
            return true;
        }
    }
}
