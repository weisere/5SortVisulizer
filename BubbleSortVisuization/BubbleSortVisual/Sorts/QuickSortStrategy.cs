using BubbleSortVisual.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortVisual.Sorts
{
    internal class QuickSortStrategy : ISortStrategy
    {
        public void Sort(List<Element> elements, Graphics graphic)
        {
            QuickSort(elements, 0, elements.Count - 1, graphic);
        }

        private void QuickSort(List<Element> arr, int low, int high, Graphics graphic)
        {
            if (low < high)
            {
                int partitionIndex = Partition(arr, low, high, graphic);

                QuickSort(arr, low, partitionIndex - 1, graphic);
                QuickSort(arr, partitionIndex + 1, high, graphic);
            }
        }

        private int Partition(List<Element> arr, int low, int high, Graphics graphic)
        {
            int pivot = arr[high].Value;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j].Value < pivot)
                {
                    i++;
                    ElementHelper.DrawSwap(arr[i], arr[j], graphic);
                    ElementHelper.ElementSwap(arr, i, j);
                }
            }

            ElementHelper.DrawSwap(arr[i + 1], arr[high], graphic);
            ElementHelper.ElementSwap(arr, i + 1, high);

            return i + 1;
        }
    }
}

