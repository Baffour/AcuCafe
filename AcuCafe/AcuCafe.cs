using System;

namespace AcuCafe
{
    public class AcuCafe
    {
        public static Drink OrderDrink(string type, bool hasMilk, bool hasSugar)
        {
            Drink drink;
            if (type == "Expresso")
            {
                drink = new Expresso();
            }
            else if (type == "HotTea")
            {
                drink = new Tea();
            }
            else if (type == "IceTea")
            {
                drink = new IceTea();
            }
            else
            {
                throw new ArgumentException(string.Format(Constants.InvalidTypeExceptionMessage, type));
            }

            try
            {
                drink.HasMilk = hasMilk;
                drink.HasSugar = hasSugar;
                drink.Prepare();
            }
            catch (Exception ex)
            {
                Console.WriteLine("We are unable to prepare your drink.");
                System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
            }

            return drink;
        }
    }

    public abstract class Drink
    {
        public const double MilkCost = 0.5;
        public const double SugarCost = 0.5;

        public bool HasMilk { get; set; }

        public bool HasSugar { get; set; }
        public string Description { get; }

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
        public new string Description
        {
            get { return "Expresso"; }
        }

        public override double BaseCost { get { return 1.8; } }
    }

    public class Tea : Drink
    {
        public new string Description
        {
            get { return "Hot tea"; }
        }

        public override double BaseCost { get { return 1; } }

    }

    public class IceTea : Drink
    {
        public new string Description
        {
            get { return "Ice tea"; }
        }

        public override double BaseCost { get { return 1.5; } }

    }
}