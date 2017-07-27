using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcuCafe
{
    public abstract class Drink
    {
        public const double MilkCost = 0.5;
        public const double SugarCost = 0.5;

        public bool HasMilk { get; set; }

        public bool HasSugar { get; set; }
        public abstract string Description { get; }

        public abstract double BaseCost { get; }

        public double Cost()
        {
            var cost = this.BaseCost;
            if (HasMilk)
                cost += MilkCost;

            if (HasSugar)
                cost += SugarCost;

            return cost;
        }

        public void Prepare()
        {
            string message = "We are preparing the following drink for you: " + Description;
            if (HasMilk)
                message += "with milk";
            else
                message += "without milk";

            if (HasSugar)
                message += "with sugar";
            else
                message += "without sugar";

            Console.WriteLine(message);
        }
    }

    public class Expresso : Drink
    {
        public override string Description => "Expresso";
        public override double BaseCost => 1.8;
    }

    public class Tea : Drink
    {
        public override string Description => "Hot tea";
        public override double BaseCost => 1;

    }

    public class IceTea : Drink
    {
        public override string Description => "Ice tea";
        public override double BaseCost => 1.5;

    }
}
