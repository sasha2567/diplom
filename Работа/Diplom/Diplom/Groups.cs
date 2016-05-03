using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    class Groups
    {
        int Z = 5;//допустим
        public List<int> M;
        public List<int> h;//индекс партии данных  i-го типа, размещаемой в группе  , число данных в которой соответ-ствует значению элемента   матрицы А. Я не понимаю что это но оно нужно для алгоритма
        public List<int> I;//текущее (изменяемое) множество типов данных, партии которых размещаются в группах
        public List<Group> groups;
        public List<int> Nz;//множество номеров (идентификаторов) групп партий
        public List<int> Nzt;//текущее (изменяемое) множество номеров групп партий, с которым оперирует алгоритм
        public int i;//тип данных, партия которых размещается в группе
        public int z;//индекс текущей рассматриваемой группы, в которую добавляется партия  -го типа;
      public  int k;//количествоелементов в Nz
    }
}
