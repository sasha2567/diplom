using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    class Batch
    {
        private int countBid;
        private int typeBid;

        public Batch(int valueCount, int valueType)
        {
            this.setCountBid(valueCount);
            this.setTypeBid(valueType);
        }

        public int getCountBid()
        {
            return this.countBid;
        }

        public int getTypeBid()
        {
            return this.typeBid;
        }

        public void setCountBid(int value)
        {
            this.countBid = value;
        }

        public void setTypeBid(int value)
        {
            this.typeBid = value;
        }

        public void incrementCountBid(int value)
        {
            this.countBid += value;
        }

        public void decrementCountBid(int value)
        {
            this.countBid -= value;
        }
    }
}
