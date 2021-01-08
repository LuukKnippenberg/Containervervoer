using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Containervervoer
{
    class Ship
    {
        private List<Container> ContainerList = new List<Container>();
        public ReadOnlyCollection<Container> ContainerListRead
        {
            get { return ContainerList.AsReadOnly(); }
        }

        private List<Container> SortedList = new List<Container>();

        private List<Row> RowList = new List<Row>();
        public int Width { get; private set; }
        public int Length { get; private set; }
        public int MaxWeigth { get; private set; }
        public int MinWeigth { get; private set; }

        public Ship(int length, int width)
        {
            Width = length;
            Length = width;
            MaxWeigth = (length * width) * 150;
            MinWeigth = MaxWeigth / 2;
        }

        public void AddContainerToShip(Container container)
        {
            ContainerList.Add(container);
            DistrubuteContainers();
        }

        private void DistrubuteContainers()
        {
            ResetRowList();
            if (RowList.Count == 0)
            {
                RowList.Add(new Row(Length));
            }

            SortedList = ContainerList.OrderByDescending(o => o.Type).ToList();

            //Debug.WriteLine("rowList Count: " + rowList.Count);

            for (int i = 0; i < SortedList.Count; i++)
            {
                try
                {
                    TryToAddContainer(SortedList[i], i);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private bool TryToAddContainer(Container container, int index)
        {
            for (int x = 0; x < RowList.Count; x++)
            {
                if (RowList[x].TryToAddContainer(SortedList[index]))
                {

                }
                else
                {
                    //Debug.WriteLine((rowList.Count - 1) + " " + x);
                    if (x < (RowList.Count))
                    {
                        if (RowList.Count < Width)
                        {
                            RowList.Add(new Row(Length));

                            try
                            {
                                RowList[(RowList.Count - 1)].TryToAddContainer(SortedList[index]);
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                    }
                }
            }

            return true;
        }

        private void ResetRowList()
        {
            RowList = new List<Row>();
        }

        public void OpenContainerVisualizer()
        {
            string stack = "";
            string weight = "";
            for (int z = 0; z < RowList.Count; z++)
            {
                //Length / Depth
                Debug.WriteLine(z + " z");
                if(z > 0)
                {
                    stack += '/';
                    weight += '/';
                }


                for (int x = 0; x < RowList[z].stackListReadable.Count; x++)
                {
                    //Width 
                    Debug.WriteLine(x + " x");
                    if(x > 0)
                    {
                        stack += ",";
                        weight += ",";
                    }

                    for (int y = 0; y < RowList[z].stackListReadable[x].ContainerListReadable.Count; y++)
                    {
                        Container container = RowList[z].stackListReadable[x].ContainerListReadable[y];

                        //Height
                        Debug.WriteLine(y + " y");

                        //stack += Convert.ToString(container.Type);
                        stack += Convert.ToString(container.Type);
                        weight += Convert.ToString(container.Weight);
                        if(y < (RowList[z].stackListReadable[x].ContainerListReadable.Count - 1))
                        {
                            weight += "-";
                        }
                        
                    }
                }
            }
            Process.Start($"https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length="+Length+"&width="+Width+"&stacks="+ stack +"&weights="+ weight+"");
        }
    }
}
