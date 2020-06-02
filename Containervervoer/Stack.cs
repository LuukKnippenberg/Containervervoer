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
    }
}
