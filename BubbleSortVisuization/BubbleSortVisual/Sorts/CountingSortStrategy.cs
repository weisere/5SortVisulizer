using BubbleSortVisual.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortVisual.Sorts
{
    internal class CountingSortStrategy : ISortStrategy
    {
        public void Sort(List<Element> elements, Graphics graphic)
        {
            int maxValue = elements.Max(x => x.Value) + 1; // Find the maximum value in the elements

            int[] count = new int[maxValue]; // Create a count array to store occurrences of each value
            List<Element> sorted = new List<Element>(elements.Count);

            // Count occurrences of each value
            foreach (var element in elements)
            {
                count[element.Value]++;
            }

            int idx = 0;
            for (int i = 0; i < maxValue; i++)
            {
                while (count[i] > 0)
                {
                    // Visualize the updating of elements using ElementHelper.DrawSwap
                    ElementHelper.DrawSwap(elements[idx], new Element(elements[idx].Start, elements[idx].End, i), graphic);

                    // Update the value in the original array
                    elements[idx].Value = i;

                    // Move to the next element and decrease count
                    count[i]--;
                    idx++;
                }
            }
        }
    }
}
