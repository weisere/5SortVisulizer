using BubbleSortVisual.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortVisual.Sorts
{
    public interface ISortStrategy
    {
        void Sort(List<Element> elements, Graphics graphic);
    }
}
