using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    class Batch
    {
        //Структура, необходимая для работы второго уровня (составов групп партий данных)
        public int countClaims;//так ты их описал
        public int typeClaims;
        public List<int> claims;

        public Batch(int valueCount, int valueType, List<int> valueClaims)
        {
            this.setCountClaims(valueCount, valueClaims);
            this.setTypeClaims(valueType);
        }

        public int getCountClaims()
        {
            return this.countClaims;
        }

        public int getTypeBid()
        {
            return this.typeClaims;
        }

        public void setCountClaims(int value, List<int> valueClaims)
        {
            this.countClaims = value;
            this.claims = new List<int>(this.countClaims);
        }

        public void setTypeClaims(int value)
        {
            this.typeClaims = value;
        }

        public void incrementCountClaims(int value)
        {
            this.countClaims += value;
        }

        public void decrementCountClaims(int value)
        {
            this.countClaims -= value;
        }
    }
}
