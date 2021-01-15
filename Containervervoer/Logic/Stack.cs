using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer
{
    public class Stack
    {
        private List<Container> ContainerList = new List<Container>();
        public ReadOnlyCollection<Container> ContainerListReadable
        {
            get { return ContainerList.AsReadOnly(); }
        }
        public int MaxWeight { get; private set; } = 150; //Ton
        public int MaxHeight { get; private set; } 
        public int CurrentWeight { get; private set; }
        public bool IsFull { get; private set; } = false;
        public bool Reserved { get; private set; } = false;
        public bool IsFront { get; private set; }
        public bool IsBack { get; private set; }

        public int Position { get; private set; }
        public Stack(int position, int maxHeight, bool isFront, bool isBack)
        {
            MaxHeight = maxHeight;
            Position = position;
            IsFront = isFront;
            IsBack = isBack;
        }

        public bool TryToAddContainerToStack(Container container)
        {
            if(ContainerList.Count >= MaxHeight)
            {
                return false;
            }

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

        public void SetReserved()
        {
            Reserved = true;
        }
    }    
}
