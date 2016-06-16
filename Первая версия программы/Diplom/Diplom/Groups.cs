using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    class Groups
    {
        public int Z = 5;//допустим
        public List<int> M=new List<int>();
        public int hi1;//dsdsdиндекс партии данных  i-го типа, размещаемой в группе  , число данных в которой соответ-ствует значению элемента   матрицы А. Я не понимаю что это но оно нужно для алгоритма
        public List<Group> groups;
        public List<int> Nz = new List<int>();//множество номеров (идентификаторов) групп партий
        public List<List<List<int>>> Nz1 = new List<List<List<int>>>();//сами группы
        public List<int> Nzt = new List<int>();//текущее (изменяемое) множество номеров групп партий, с которым оперирует алгоритм
        public int i;//тип данных, партия которых размещается в группе
        public int z;//индекс текущей рассматриваемой группы, в которую добавляется партия  -го типа;
        public List<int> k=new List<int>();//количествоелементов в Nz
        public List<int> I1 = new List<int>();//текущее (изменяемое) множество типов данных, партии которых размещаются в группах
        public List<int> I2 = new List<int>();

      public  Groups(int Z1)
        {
            this.Z = Z1;
            for (int j = 0; j < Z1; j++)
                this.I1.Add(j);
            for (int j = 0; j < Z1; j++)
                this.Nz.Add(j);
        }
      public void Set_I1(int i) {
          for (int j = 0; j < i; j++)
              this.I1.Add(j);
      }
      public void Set_I2(int i)
      {
          for (int j = 0; j < i; j++)
              this.I2.Add(j);
      }
      public void Set_M(int i)
      {
          for (int j = 0; j < i; j++)
              this.M.Add(0);
      }
      public void Set_Nzt(List<int> i)
      {
          this.Nzt.Clear();
          this.Nzt.AddRange(i);
      }
    }   
}
