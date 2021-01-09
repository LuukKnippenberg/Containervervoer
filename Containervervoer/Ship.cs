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
        private List<Container> ContainerList = new List<Container>();
        public ReadOnlyCollection<Container> ContainerListRead
        {
            get { return ContainerList.AsReadOnly(); }
        }

        private List<Container> SortedContainerList = new List<Container>();

        private List<Row> RowList = new List<Row>();
        public int Width { get; private set; }
        public int Length { get; private set; }
        public int MaxWeigth { get; private set; }
        public int MinWeigth { get; private set; }
        private float WeightDifference;
        private int WeightLeft;
        private int WeightCenter;
        private int WeightRight;
        private int TotalWeight;

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

        private void ResetData()
        {
            TotalWeight = 0;
            WeightLeft = 0;
            WeightRight = 0;
            WeightCenter = 0;
            WeightDifference = 0;
            RowList = InitializeRowList();
        }

        private void DistrubuteContainers()
        {
            ResetData();
            int weightSum = GetWeightSum();
            
            //DEVELOPMENT TRUE == TRUE
            if(weightSum >= MinWeigth && weightSum <= MaxWeigth /*|| true == true*/)
            {

                SortedContainerList = ContainerList.OrderByDescending(o => o.Type).ToList();

                for (int i = 0; i < SortedContainerList.Count; i++)
                {
                    if (TryToAddContainerLeftOrRight(SortedContainerList[i], i))
                    {

                    }
                    else
                    {
                        TryToAddContainerCenter(SortedContainerList[i]);
                    }
                    /*
                    try
                    {
                        TryToAddContainerLeftOrRight(SortedContainerList[i], i);
                    }
                    catch (Exception)
                    {
                        TryToAddContainerCenter(SortedContainerList[i]);
                    }
                    */
                }
            }
        }

        private bool TryToAddContainerCenter(Container container)
        {
            for (int x = 0; x < RowList.Count; x++)
            {
                if (RowList[x].ReturnSide() == 2)
                {
                    if (RowList[x].TryToAddContainer(container))
                    {
                        WeightCenter += container.Weight;
                        TotalWeight += container.Weight;
                        UpdateWeightDifference();
                        return true;
                    }
                }
            }

            return false;
        }

        private bool TryToAddContainerLeftOrRight(Container container, int index)
        {

            for (int x = 0; x < RowList.Count; x++)
            {
                if(WeightLeft <= WeightRight)
                {
                    if(RowList[x].ReturnSide() == 1)
                    {
                        if (RowList[x].TryToAddContainer(container))
                        {
                            WeightLeft += container.Weight;
                            TotalWeight += container.Weight;
                            UpdateWeightDifference();
                            return true;
                        }
                    }
                }
                else if (WeightLeft >= WeightRight)
                {
                    if (RowList[x].ReturnSide() == 3)
                    {
                        if (RowList[x].TryToAddContainer(container))
                        {
                            WeightRight += container.Weight;
                            TotalWeight += container.Weight;
                            UpdateWeightDifference();
                            return true;
                        }
                    }
                }

                /*
                if (RowList[x].TryToAddContainer(container))
                {
                    int returnSide = RowList[x].ReturnSide();

                    switch (returnSide)
                    {
                        case 1:
                            WeightLeft += container.Weight;
                            break;
                        case 2:
                            WeightCentre += container.Weight;
                            break;
                        case 3:
                            WeightRight += container.Weight;
                            break;
                        default:
                            break;
                    }
                    TotalWeight += container.Weight;
                    UpdateWeightDifference();
                    return true;
                }
                */
            }

            return false;
        }      

        public void OpenContainerVisualizer()
        {
            string stack = "";
            string weight = "";
            for (int z = 0; z < RowList.Count; z++)
            {
                //Length / Depth
                //Debug.WriteLine(z + " z");
                if(z > 0)
                {
                    stack += '/';
                    weight += '/';
                }


                for (int x = 0; x < RowList[z].stackListReadable.Count; x++)
                {
                    //Width 
                    //Debug.WriteLine(x + " x");
                    if(x > 0)
                    {
                        stack += ",";
                        weight += ",";
                    }

                    for (int y = 0; y < RowList[z].stackListReadable[x].ContainerListReadable.Count; y++)
                    {
                        Container container = RowList[z].stackListReadable[x].ContainerListReadable[y];

                        //Height
                        //Debug.WriteLine(y + " y");

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

        private int GetWeightSum()
        {
            int weightSum = 0;

            for (int i = 0; i < ContainerList.Count; i++)
            {
                weightSum += ContainerList[i].Weight;
            }

            return weightSum;
        }

        private List<Row> InitializeRowList()
        {
            List<Row> tempRowList = new List<Row>();
            
            if (Width % 2 == 0) //Is Even
            {
                double middle = Width / 2;

                for (int i = 0; i < Width; i++)
                {
                    int side;
                    if (i < middle)
                    {
                        side = 1;
                    }
                    else
                    {
                        side = 3;
                    }

                    tempRowList.Add(new Row(Length, side));
                }

            }
            else //Is Odd
            {
                double middle = (Math.Round((Width / 2f)) - 1);
                for (int i = 0; i < Width; i++)
                {
                    int side = 2;
                    if (i < middle)
                    {
                        side = 1;
                    }
                    else if (i > middle)
                    {
                        side = 3;
                    }

                    tempRowList.Add(new Row(Length, side));
                }
            }
            

            

            return tempRowList;
        }

        private void UpdateWeightDifference()
        {
            float centerPercentage = (WeightCenter / TotalWeight) * 100;
            float leftPercentage = (WeightLeft / TotalWeight) * 100;
            float rightPercentage = (WeightRight / TotalWeight) * 100;

            WeightDifference = Math.Abs(leftPercentage - rightPercentage);

            Console.WriteLine($"Left: {WeightLeft} Center: {WeightCenter} Right: {WeightRight}");

            //Console.WriteLine($"Left {leftPercentage }%");
            //Console.WriteLine($"Centre {centrePercentage }%");
            //Console.WriteLine($"Right {rightPercentage }%");
            //Console.WriteLine($"{WeightDifference}%");

        }
    }
}
