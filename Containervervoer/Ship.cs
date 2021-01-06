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
        private List<Container> containerList = new List<Container>();
        public ReadOnlyCollection<Container> containerListRead
        {
            get { return containerList.AsReadOnly(); }
        }

        private List<Row> rowList = new List<Row>();
        public int Length { get; private set; }
        public int Width { get; private set; }
        public int MaxWeigth { get; private set; }
        public int MinWeigth { get; private set; }

        private Random rnd = new Random();

        public Ship(int length, int width)
        {
            Length = length;
            Width = width;
            MaxWeigth = (length * width) * 150;
            MinWeigth = MaxWeigth / 2;
        }

        public void AddContainerToShip(int weight, int type)
        {
            containerList.Add(new Container(30, type));
            DistrubuteContainers();
        }

        private void DistrubuteContainers()
        {
            ResetRowList();
            if (rowList.Count == 0)
            {
                rowList.Add(new Row(Width));
            }

            //Debug.WriteLine("rowList Count: " + rowList.Count);

            for (int i = 0; i < containerList.Count; i++)
            {
                for (int x = 0; x < rowList.Count; x++)
                {
                    if (rowList[x].TryToAddContainer(containerList[i]))
                    {
                        
                    }
                    else
                    {
                        //Debug.WriteLine((rowList.Count - 1) + " " + x);
                        if (x < (rowList.Count))
                        {
                            if (rowList.Count < Length)
                            {
                                rowList.Add(new Row(Width));
                                
                                if(rowList[(rowList.Count - 1)].TryToAddContainer(containerList[i]))
                                {
                                    
                                }
                                
                                
                            }
                        }
                    }
                }
            }
        }

        private void ResetRowList()
        {
            rowList = new List<Row>();
        }

        public void OpenContainerVisualizer()
        {
            string stack = "";
            string weight = "";
            for (int z = 0; z < rowList.Count; z++)
            {
                //Length / Depth
                Debug.WriteLine(z);
                if(z > 0)
                {
                    stack += '/';
                    weight += '/';
                }


                for (int x = 0; x < rowList[z].stackListReadable.Count; x++)
                {
                    //Width 
                    Debug.WriteLine(x);
                    if(x > 0)
                    {
                        stack += ',';
                        weight += ',';
                    }

                    for (int y = 0; y < rowList[z].stackListReadable[x].containerListReadable.Count; y++)
                    {
                        Container container = rowList[z].stackListReadable[x].containerListReadable[y];

                        //Height
                        //Debug.WriteLine(y);
                        
                        stack += Convert.ToString(container.Type);
                        weight += "30";
                        if(y < (rowList[z].stackListReadable[x].containerListReadable.Count - 1))
                        {
                            weight += "-";
                        }
                        
                    }
                }
            }
            Process.Start("https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length="+Length+"&width="+Width+"&stacks="+ stack +"&weights="+ weight+"");
        }
    }
}
