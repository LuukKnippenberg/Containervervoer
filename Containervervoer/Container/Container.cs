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
        private int MaxWeight = 30;
        public int MinWeight { get; private set; } = 4;

        public bool Coolable { get; private set; }
        public bool Valuable { get; private set; }
        public int Type { get; private set; }

        enum ContainerTypes
        {
            Normal = 1,
            Valuable = 2,
            Coolable = 3,
            CoolableValuable = 4
        }

        public Container(int weight, bool valuable, bool coolable)
        {
            Weight = SetWeigth(weight);
            Valuable = valuable;
            Coolable = coolable;
            Type = SetType();
        }

        private int SetWeigth(int weight)
        {
            if (weight < MinWeight)
            {
                throw new Exception("Weight minimum is 4 tons");
            }
            else if ( weight > MaxWeight)
            {
                throw new Exception("Weight maximum is 30 tons");
            }

            return weight;
        }

        private int SetType()
        {
            if (!Valuable && !Coolable)
            {
                return 1;
            }

            if (Valuable && !Coolable)
            {
                return 2;
            }

            if (!Valuable && Coolable)
            {
                return 3;
            }

            if (Valuable && Coolable)
            {
                return 4;
            }

            return 1;
        }

        public string ReturnContainerInfoString()
        {
            return $"Weight: {Weight} Valuable: {Valuable} Coolable: {Coolable}"; ;
        }
    }
}
