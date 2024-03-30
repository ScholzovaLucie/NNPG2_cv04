using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNPG2_04.Tvary
{
    internal class TvarRozsireni
    {
        
        public LinkedList<Tvar> SortLinkedListByZIndex(LinkedList<Tvar> list)
        {
            Tvar[] array = new Tvar[list.Count];
            list.CopyTo(array, 0);

            QuickSort(array, 0, array.Length - 1);

            list = new LinkedList<Tvar>(array);

            return list;
        }

        static void QuickSort(Tvar[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);

                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        static int Partition(Tvar[] array, int left, int right)
        {
            Tvar pivotValue = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j].zIndex <= pivotValue.zIndex)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, right);

            return i + 1;
        }

        static void Swap(Tvar[] array, int i, int j)
        {
            Tvar temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
