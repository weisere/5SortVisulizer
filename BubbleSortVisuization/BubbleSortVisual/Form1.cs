using BubbleSortVisual.Entity;
using BubbleSortVisual.Options;
using BubbleSortVisual.Sorts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleSortVisual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Graphics graphic;
        private List<Element> elements = new List< Element>();
        private ISortStrategy sortStrategy;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void pnlMonitor_Paint(object sender, PaintEventArgs e)
        {
            var rand = new Random();

            int padding = ArrayOptions.padding;

            //create random array
            for (int index = 0; index < ArrayOptions.Length; index++)
            {
                var start = new Point(padding, MonitorOptions.Height);
                int value = MonitorOptions.Height - rand.Next(50) * 10;
                var end = new Point(padding, value);
                var element = new Element(start, end, MonitorOptions.Height-value);

                elements.Add(element);
                padding += ArrayOptions.Width + ArrayOptions.Space;
            }

            //draw to panel
            elements.ForEach(c =>
            {
                c.Draw(graphic);
            });
        }

        private void btnBubbleSort_Click(object sender, EventArgs e)
        {
            sortStrategy.Sort(elements, graphic);
        }

        public void setSortStrategy(ISortStrategy iss)
        {
            sortStrategy = iss;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graphic = pnlMonitor.CreateGraphics();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSort = checkedListBox1.SelectedItem.ToString();

            // Set the strategy based on the selected item
            switch (selectedSort)
            {
                case "Counting Sort":
                    setSortStrategy(new CountingSortStrategy());
                    break;
                case "Radix Sort":
                    setSortStrategy(new RadixSortStrategy());
                    break;
                case "Bubble Sort":
                    setSortStrategy(new BubbleSortStrategy());
                    break;
                case "Insertion Sort":
                    setSortStrategy(new InsertionSortStrategy());
                    break;
                case "Quick Sort":
                    setSortStrategy(new QuickSortStrategy());
                    break;
                
                default:
                    
                    // Handle default case or error condition
                    break;
            }
        }
    }
}
