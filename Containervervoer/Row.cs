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
        private RowSide Side;
        public int MaxHeight { get; private set; }
        
        public Row(int width, int side, int maxHeight)
        {
            Width = width;
            MaxHeight = maxHeight;
            StackList = InitializeStackList();
            Side = (RowSide)side;
            
        }

        enum RowSide
        {
            Left = 1,
            Centre = 2,
            Right = 3,
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
                tempStackList.Add(new Stack(i, MaxHeight));
            }

            return tempStackList;
        }

        public int ReturnSide()
        {
            return Convert.ToInt32(Side);
        }
        
    }
}
