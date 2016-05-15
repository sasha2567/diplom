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

        public FirstLevel(int count_type, List<int> count_claims)
        {
            this.countType = count_type;
            this.countClaims = count_claims;
            this.mi = new List<int>(this.countType);
            this.npi = new List<int>(this.countType);
            this.I = new List<int>(this.countType);
        }

        public bool GenerateSolution()
        {
            return false;
        }

        public void GenerateStartSolution()
        {
            int claim = 2;
            this.A1 = new List<List<int>>(this.countType);
            this.A1.Add(new List<int>());
            for (int i = 1; i <= this.countType; i++)
            {
                this.I.Add(1);
                this.mi.Add(claim);
                this.npi.Add(1);
                this.A1.Add(new List<int>());
                this.A1[i].Add(0);
                this.A1[i].Add(this.countClaims[i - 1] - claim);
                this.A1[i].Add(claim);
            }
            for (int i = 1; i <= this.countType; i++)
            {
                if (this.A1[i][1] < 2 || this.A1[i][1] < this.A1[i][1])
                {
                    this.A1[i].Clear();
                    this.A1[i].Add(0);
                    this.A1[i].Add(this.countClaims[i - 1]);
                    this.mi[i - 1] = 1;
                    this.npi[i - 1] = 0;
                    this.I[i - 1] = 0;
                }
            }
            this.G = 0;
            List<List<int>> temp = new List<List<int>>();
            temp.Add(new List<int>());
            temp.Add(new List<int>());
            temp[1].Add(0);
            temp[1].Add(10);
            temp[1].Add(2);
            temp[1].Add(2);
            temp[1].Add(2);
            /*temp.Add(new List<int>());
            temp[2].Add(0);
            temp[2].Add(10);
            temp[2].Add(3);
            temp[2].Add(3);
            temp.Add(new List<int>());
            temp[3].Add(0);
            temp[3].Add(10);
            temp[3].Add(4);
            temp[3].Add(2);*/
            int countLoop = 0;
            this.A = new List<List<int>>();
            MessageBox.Show("Генерируем начальное решение");
            while (true)
            {
                if(countLoop == 0)
                    test = new BatchTypeClaims(1, 16, temp, this.A);
                else
                    test = new BatchTypeClaims(1, 16, test.ReturnA2Matrix(), this.A);
                if (test.GenerateSolution())
                {
                    test.PrintMatrix(2);
                    test.PrintMatrix();
                }
                countLoop++;
                if (countLoop == 6)
                    break;
                else
                    MessageBox.Show("Генерируем новое решение");
            }
        }

        public int GetCriterion()
        {
            return 0;
        }
    }
}
