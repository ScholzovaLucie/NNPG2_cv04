using System;
using System.Collections.Generic;
using System.Drawing;
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

        public double DistancePointToLine(Point point, Point lineStart, Point lineEnd)
        {
            double A = point.X - lineStart.X;
            double B = point.Y - lineStart.Y;
            double C = lineEnd.X - lineStart.X;
            double D = lineEnd.Y - lineStart.Y;

            double dot = A * C + B * D;
            double len_sq = C * C + D * D;
            double param = dot / len_sq;

            double xx, yy;

            if (param < 0)
            {
                xx = lineStart.X;
                yy = lineStart.Y;
            }
            else if (param > 1)
            {
                xx = lineEnd.X;
                yy = lineEnd.Y;
            }
            else
            {
                xx = lineStart.X + param * C;
                yy = lineStart.Y + param * D;
            }

            double dx = point.X - xx;
            double dy = point.Y - yy;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        public Point FindClosestPointOnLine(Point lineStart, Point lineEnd, Point point)
        {
            double dx = lineEnd.X - lineStart.X;
            double dy = lineEnd.Y - lineStart.Y;

            if (dx == 0 && dy == 0)
                return lineStart;

            double t = ((point.X - lineStart.X) * dx + (point.Y - lineStart.Y) * dy) / (dx * dx + dy * dy);

            t = Math.Max(0, Math.Min(1, t));

            double closestX = lineStart.X + t * dx;
            double closestY = lineStart.Y + t * dy;
            return new Point((int)closestX, (int)closestY);
        }


    }
}
