using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer
{
    class Row
    {
        private List<Stack> stackList = new List<Stack>();
        public ReadOnlyCollection<Stack> stackListReadable
        {
            get { return stackList.AsReadOnly(); }
        }
        public int Width { get; private set; }
        public Row()
        {

        }

        public void TryToAddContainer(Container container)
        {
            if(stackList.Count == 0)
            {
                stackList.Add(new Stack());
            }
            for (int i = 0; i < stackList.Count; i++)
            {
                stackList[i].TryToAddContainerToStack(container);
            }
        }
    }
}
