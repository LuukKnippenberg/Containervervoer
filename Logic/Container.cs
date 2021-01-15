using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Container
    {
        public int Weight { get; private set; } //In Tons
        private int MaxWeight = 30;
        public int MinWeight { get; private set; } = 4;

        public bool Coolable { get; private set; }
        public bool Valuable { get; private set; }
        public ContainerTypes Type { get; private set; }

        public enum ContainerTypes
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

        private ContainerTypes SetType()
        {
            if (!Valuable && !Coolable)
            {
                return (ContainerTypes)1;
            }

            if (Valuable && !Coolable)
            {
                return (ContainerTypes)2;
            }

            if (!Valuable && Coolable)
            {
                return (ContainerTypes)3;
            }

            if (Valuable && Coolable)
            {
                return (ContainerTypes)4;
            }

            return (ContainerTypes)1;
        }

        public string ReturnContainerInfoString()
        {
            return $"Weight: {Weight} Valuable: {Valuable} Coolable: {Coolable}"; ;
        }
    }
}
