using BubbleSortVisual.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortVisual.Sorts
{
    internal class InsertionSortStrategy : ISortStrategy
    {
        public void Sort(List<Element> elements, Graphics graphic)
        {
            for (int i = 1; i < elements.Count; i++)
            {
                int j = i;
                while (j > 0 && elements[j - 1].Value > elements[j].Value)
                {
                    ElementHelper.DrawSwap(elements[j], elements[j - 1], graphic);
                    ElementHelper.ElementSwap(elements, j, j - 1);
                    j--;
                }
            }
        }
    }
}
