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
        private List<Stack> stackList = new List<Stack>();
        public ReadOnlyCollection<Stack> stackListReadable
        {
            get { return stackList.AsReadOnly(); }
        }
        public int Width { get; private set; }
        public Row(int width)
        {
            Width = width;
        }

        public bool TryToAddContainer(Container container)
        {
            if(stackList.Count == 0)
            {
                stackList.Add(new Stack());
            }

            for (int i = 0; i < stackList.Count; i++)
            {
                if (stackList[i].TryToAddContainerToStack(container))
                {
                    return true;
                }
                else
                {
                    if(i == (stackList.Count - 1))
                    {
                        if(stackList.Count < Width)
                        {
                            
                            stackList.Add(new Stack());
                            if(stackList[(stackList.Count - 1)].TryToAddContainerToStack(container))
                            {
                                //Debug.WriteLine("stackList.Count: " + stackList.Count + " Width: " + Width);
                                return true;
                            }
                            
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }

    }
}
