using BubbleSortVisual.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortVisual.Sorts
{
    public class BubbleSortStrategy : ISortStrategy
    {
         
         public void Sort(List<Element> elements, Graphics graphic)
        {
            //bubble sort
            for (int i = 0; i < elements.Count - 1; i++)
            {
                for (int j = 0; j < elements.Count - 1; j++)
                {
                    if (elements[j].Value > elements[j + 1].Value)
                    {
                        ElementHelper.DrawSwap(elements[j], elements[j + 1], graphic);
                        ElementHelper.ElementSwap(elements, j, j + 1);
                    }
                }
            }
        }

     
            }
    }
