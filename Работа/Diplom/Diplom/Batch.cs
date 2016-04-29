using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    class Batch
    {
        private int countClaims;
        private int typeClaims;
        private List<int> claims;

        public Batch(int valueCount, int valueType)
        {
            this.setCountBid(valueCount);
            this.setTypeBid(valueType);
        }

        public int getCountBid()
        {
            return this.countClaims;
        }

        public int getTypeBid()
        {
            return this.typeClaims;
        }

        public void setCountBid(int value)
        {
            this.countClaims = value;
        }

        public void setTypeBid(int value)
        {
            this.typeClaims = value;
        }

        public void incrementCountBid(int value)
        {
            this.countClaims += value;
        }

        public void decrementCountBid(int value)
        {
            this.countClaims -= value;
        }
    }
}
