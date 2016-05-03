using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    class SecondLevel
    {

        Groups groups=new Groups(5),Q=new Groups(1);

       public void nach_uslov()
        {
            for (int i = 0; i < this.groups.Z;i++)
                this.groups.k.Add(0);
            this.Q.k.Add(0);
            this.groups.Set_I1(5);//допустим количество типов 5
            this.groups.Set_I2(5);//допустим количество типов 5
        }
    }
}
