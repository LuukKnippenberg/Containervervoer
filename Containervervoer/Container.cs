using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer
{
    class Container
    {
        public int Weight { get; private set; } //In Tons
        private int maxWeight = 30;
        public int minWeight { get; private set; } = 4;
        public int Type { get; private set; }

        enum ContainerTypes
        {
            Normal = 1,
            Valuable,
            Coolable,
            CoolableValuable
        }

        public Container(int weight, int type)
        {
            Weight = SetWeigth(weight);
            Type = Convert.ToInt32(SetContainerType(type));
        }

        private ContainerTypes SetContainerType(int type)
        {
            ContainerTypes currentType = ContainerTypes.Normal; //Defaults to normal

            if(type == 1)
            {
                currentType = ContainerTypes.Normal;
            }
            else if (type == 2)
            {
                currentType = ContainerTypes.Valuable;
            }
            else if (type == 3)
            {
                currentType = ContainerTypes.Coolable;
            }
            else if (type == 4)
            {
                currentType = ContainerTypes.CoolableValuable;
            }
            else
            {
                //Throw exception
                
            }

            return currentType;
        }

        public int SetWeigth(int weight)
        {
            /*
            if (Weight < minWeight)
            {
                throw new Exception("Weight minimum is 4 tons");
            }
            else if ( weight > maxWeight)
            {
                throw new Exception("Weight maximum is 30 tons");
            }
            */

            return weight;
        }
    }
}
