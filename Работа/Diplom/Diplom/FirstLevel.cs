using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    class FirstLevel
    {
        private List<int> batchesList;
        private List<List<int>> batches;
        private List<int> tempBatchesList;
        private List<List<int>> tempBatches;
        private int countType;
        private List<int> countClaims;

        public FirstLevel(int count_type, List<int> count_claims)
        {
            this.countType = count_type;
            this.countClaims = count_claims;
        }

        public bool GenerateSolution()
        {
            return false;
        }

        public void GenerateStartSolution()
        {
            int m = 2;
            int claim = 2;
            this.batchesList = new List<int>(this.countType);
            this.batches = new List<List<int>>(this.countType);
            for (int i = 0; i < this.countType; i++)
            {
                this.batchesList.Add(m);
                this.batches.Add(new List<int>());
                this.batches[i].Add(this.countClaims[i] - claim);
                this.batches[i].Add(claim);
            }
        }

        public int GetCriterion()
        {
            return 0;
        }
    }
}
