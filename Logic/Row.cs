using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer.Logic
{
    class Row
    {
        private List<Stack> StackList = new List<Stack>();
        public ReadOnlyCollection<Stack> stackListReadable
        {
            get { return StackList.AsReadOnly(); }
        }
        public int Width { get; private set; }
        public RowSide Side { get; private set; }
        public int MaxHeight { get; private set; }
        
        public Row(int width, int side, int maxHeight)
        {
            Width = width;
            MaxHeight = maxHeight;
            StackList = InitializeStackList();
            Side = (RowSide)side;
            
        }

        public enum RowSide
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
                    if(ValuableContainerReservationCheck(container, i))
                    {
                        return true;
                    }

                    return true;
                }
            }

            return false;
        }

        private bool ValuableContainerReservationCheck(Container container, int index)
        {
            if (container.Valuable)
            {
                if (StackList[index].IsBack || StackList[index].IsFront)
                {
                    return true;
                }
                else if (!StackList[(index - 1)].Reserved && (index + 1) < (StackList.Count))
                {
                    StackList[index + 1].SetReserved();
                    return true;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private List<Stack> InitializeStackList()
        {
            List<Stack> tempStackList = new List<Stack>();

            for (int i = 0; i < Width; i++)
            {
                bool isFront = false;
                bool isBack = false;
                if (i == 0)
                    isFront = true;

                if((i + 1) == Width)
                    isBack = true;

                tempStackList.Add(new Stack(i, MaxHeight, isFront, isBack));
            }

            return tempStackList;
        }        
    }
}
