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

        /*
        enum Type
        {
            Normal,
            Valuable,
            Coolable,
            CoolableValuable
        }
        */

        public Container(int weight, int type)
        {
            //Type = type;
            Weight = SetWeigth(weight);
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
