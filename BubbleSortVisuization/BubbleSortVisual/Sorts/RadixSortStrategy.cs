using BubbleSortVisual.Entity;
using BubbleSortVisual.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BubbleSortVisual.Sorts
{
    internal class RadixSortStrategy : ISortStrategy
    {
        public void Sort(List<Element> elements, Graphics graphic)
        {
            int maxDigits = elements.Max(x => x.Value).ToString().Length;

            Element emptyElement = new Element(new Point(0, 0), new Point(0, 0), 0); // Create an empty element

            for (int digit = 0; digit < maxDigits; digit++)
            {
                Queue<Element>[] buckets = new Queue<Element>[10];

                for (int i = 0; i < 10; i++)
                {
                    buckets[i] = new Queue<Element>();
                }

                foreach (var element in elements)
                {
                    int currentDigit = (element.Value / (int)Math.Pow(10, digit)) % 10;
                    buckets[currentDigit].Enqueue(element);
                }

                foreach (var bucket in buckets)
                {
                    while (bucket.Count > 0)
                    {
                        Element currentElement = bucket.Dequeue();
                        ElementHelper.DrawSwap(emptyElement, currentElement, graphic);
                        Thread.Sleep(ArrayOptions.Delay);
                    }
                }
            }
        }
        }
    }

