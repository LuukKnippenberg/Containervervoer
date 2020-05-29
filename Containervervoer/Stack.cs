using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public Stack()
        {

        }

        public void TryToAddContainerToStack(Container container)
        {
            containerList.Add(container);
        }
    }
}
