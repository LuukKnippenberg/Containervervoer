using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer
{
    class Row
    {
        private List<Stack> StackList = new List<Stack>();
        public ReadOnlyCollection<Stack> stackListReadable
        {
            get { return StackList.AsReadOnly(); }
        }
        public int Width { get; private set; }
        public Row(int width)
        {
            Width = width;
            StackList = InitializeStackList();
        }

        public bool TryToAddContainer(Container container)
        {
            for (int i = 0; i < StackList.Count; i++)
            {
                if (StackList[i].TryToAddContainerToStack(container))
                {
                    if (container.Valuable)
                    {
                        if((i+1) < (StackList.Count))
                        {
                            StackList[i + 1].SetReserved();
                        }
                    }

                    return true;
                }
                else
                {
                    if (container.Coolable) 
                    {
                        return false;
                    }
                    
                }
            }

            return false;
        }

        private List<Stack> InitializeStackList()
        {
            List<Stack> tempStackList = new List<Stack>();

            for (int i = 0; i < Width; i++)
            {
                tempStackList.Add(new Stack(i));
            }

            return tempStackList;
        }
    }
}
