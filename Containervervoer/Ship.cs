﻿using System;
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

        public Ship(int length, int width)
        {
            Length = length;
            Width = width;
            MaxWeigth = (length * width) * 150;
            MinWeigth = MaxWeigth / 2;
        }

        public void AddContainerToShip()
        {
            containerList.Add(new Container(30, 0));
            DistrubuteContainers();
        }

        private void DistrubuteContainers()
        {
            ResetRowList();
            if (rowList.Count == 0)
            {
                rowList.Add(new Row());
            }

            for (int i = 0; i < containerList.Count; i++)
            {
                for (int x = 0; x < rowList.Count; x++)
                {
                    rowList[x].TryToAddContainer(containerList[i]);
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
            for (int z = 0; z < rowList.Count; z++)
            {
                //Length / Depth
                Debug.WriteLine(z);

                for (int x = 0; x < rowList[z].stackListReadable.Count; x++)
                {
                    //Width 
                    Debug.WriteLine(x);
                    if(x > 0)
                    {
                        stack += ',';
                    }

                    for (int y = 0; y < rowList[z].stackListReadable[x].containerListReadable.Count; y++)
                    {
                        //Height
                        Debug.WriteLine(y);
                        stack += '1';
                    }
                }
            }
            System.Diagnostics.Process.Start("https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length="+Length+"&width="+Width+"&stacks="+ stack +"");
        }
    }
}