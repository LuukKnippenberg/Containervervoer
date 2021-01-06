using System;
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
        private List<Container> containerList = new List<Container>();
        public ReadOnlyCollection<Container> containerListReadable
        {
            get { return containerList.AsReadOnly(); }
        }
        public int maxWeight = 120; //Ton
        public int currentWeight { get; private set; }
        public bool isFull { get; private set; } = false;
        public Stack()
        {

        }

        public bool TryToAddContainerToStack(Container container)
        {
            switch (container.Type)
            {
                case 0:
                    
                    break;
                case 1:
                    
                    break;
                case 2:
                    
                    break;
                case 3:
                    TryToAddContainerToStack(container);
                    break;
                default:
                    break;
            }

            if(container.Type == 3 || container.Type == 2)
            {
                
            }
            if((currentWeight + container.Weight) <= maxWeight)
            {
                containerList.Add(container);
                currentWeight += container.Weight;

                if((currentWeight + container.minWeight) >= maxWeight)
                {
                    isFull = true;
                }

                return true;
            }
            
            return false;
        }
        public bool CheckIfFrontRow(Container container)
        {
            

            return false;
        }
    }    
}
