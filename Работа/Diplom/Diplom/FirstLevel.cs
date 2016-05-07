using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    class FirstLevel
    {
        private List<int> mi;//Вектор количества партий данных для каждого типа данных
        private List<List<int>> A1;//Матрица составов партий требований
        private List<List<int>> A2;//
        private int countType;//количество типов
        private List<int> countClaims;//Начальное количество требований для каждого типа данных
        private BatchTypeClaims test;

        public FirstLevel(int count_type, List<int> count_claims)
        {
            this.countType = count_type;
            this.countClaims = count_claims;
        }

        public bool GenerateSolution()
        {
            return false;
        }

        public void GenerateStartSolution(int m)
        {
            int claim = 2;
            this.mi = new List<int>(this.countType);
            this.A1 = new List<List<int>>(this.countType);
            for (int i = 0; i < this.countType; i++)
            {
                this.mi.Add(m);
                this.A1.Add(new List<int>());
                this.A1[i].Add(this.countClaims[i] - claim);
                for (int j = 0; j < m; j++)
                {
                    this.A1[i].Add(claim);
                }
            }
            List<List<int>> temp = new List<List<int>>();
            temp.Add(new List<int>());
            temp.Add(new List<int>());
            temp[1].Add(0);
            temp[1].Add(12);
            temp[1].Add(2);
            temp[1].Add(2);
            temp.Add(new List<int>());
            temp[2].Add(0);
            temp[2].Add(10);
            temp[2].Add(3);
            temp[2].Add(3);
            temp.Add(new List<int>());
            temp[3].Add(0);
            temp[3].Add(10);
            temp[3].Add(4);
            temp[3].Add(2);
            test = new BatchTypeClaims(16, temp);
            if (test.GenerateSolution())
            {
                test.PrintMatrix(2);
                test.PrintMatrix();
                test = new BatchTypeClaims(16, test.ReturnA2Matrix());
                if (test.GenerateSolution())
                {
                    test.PrintMatrix(2);
                    test.PrintMatrix();
                    test = new BatchTypeClaims(16, test.ReturnA2Matrix());
                    if (test.GenerateSolution())
                    {
                        test.PrintMatrix(2);
                        test.PrintMatrix();
                        //test = new BatchTypeClaims(16, test.ReturnA2Matrix());
                    }
                }
            }
        }

        public void GenerateSolutionForType(int I)
        {

        }

        public bool CheckingInitialSolution()
        {
            
            return true;
        }

        public int GetCriterion()
        {
            return 0;
        }
    }
}
