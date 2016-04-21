using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    class BatchesGroup
    {
        private List<Batch> listBatch;

        public BatchesGroup(List<Batch> value)
        {
            this.listBatch = value;
        }
        
        public List<Batch> getListBatch()
        {
            return this.listBatch;
        }

        public void modificationBatches(int indexIncrement, int indexDecrement, int value)
        {
            this.listBatch[indexIncrement].incrementCountBid(value);
            this.listBatch[indexDecrement].decrementCountBid(value);
        }

        public string printList()
        {
            string str = "";
            foreach (Batch temp in this.listBatch)
            {
                str += temp.getCountBid() + "\n";
            }
            return str;
        }
    }
}
