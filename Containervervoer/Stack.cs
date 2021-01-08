﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer
{
    class Stack
    {
        private List<Container> ContainerList = new List<Container>();
        public ReadOnlyCollection<Container> ContainerListReadable
        {
            get { return ContainerList.AsReadOnly(); }
        }
        public int MaxWeight = 150; //Ton
        public int CurrentWeight { get; private set; }
        public bool IsFull { get; private set; } = false;
        public bool Reserved { get; private set; } = false;

        public int Position { get; private set; }
        public Stack(int position)
        {
            Position = position;
        }

        public bool TryToAddContainerToStack(Container container)
        {
            if (Reserved)
            {
                return false;
            }

            if (container.Coolable && Position > 0)
            {
                return false;
            }

            if((CurrentWeight + container.Weight) <= MaxWeight)
            {
                if (container.Valuable)
                {
                    if(ContainerList.Count == 0)
                    {
                        ContainerList.Add(container);
                        
                    }
                    else
                    {
                        if (!ContainerList[(ContainerList.Count - 1)].Valuable)
                        {
                            ContainerList.Add(container);
                            
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ContainerList.Insert(0, container);
                }
                
                CurrentWeight += container.Weight;

                if((CurrentWeight + container.MinWeight) >= MaxWeight)
                {
                    IsFull = true;
                }

                return true;
            }
            
            return false;
        }

        public bool CheckIfFrontRow()
        {
            if (Position == 0)
            {
                return true;
            }

            return false;
        }

        public void SetReserved()
        {
            Reserved = true;
        }
    }    
}
