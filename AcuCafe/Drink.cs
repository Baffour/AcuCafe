using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcuCafe
{
    public abstract class Drink
    {
        public Dictionary<Topping, decimal> ToppingCost = new Dictionary<Topping, decimal>()
        {
            {Topping.Milk,0.5m },
            {Topping.Sugar,0.5m },
            {Topping.Chocolate,0.6m }
        };


        public abstract Topping[] ValidToppings { get; }

        public Topping[] Toppings { get; set; }

        public string Status { get; set; }

        public abstract string Description { get; }

        public abstract decimal BaseCost { get; }

        public decimal Cost()
        {
            return this.BaseCost + Toppings.Select(t => ToppingCost[t]).Sum();
        }

        public void Prepare()
        {
            string message = $"We are preparing the following drink for you: {Description}";
            foreach (var topping in this.ValidToppings)
            {
                message += this.Toppings.Contains(topping) ? " with" : " without";
                message += " " + topping.ToString();
            }

            this.Status = message;
        }
    }

    public class Expresso : Drink
    {
        public override string Description => "Expresso";
        public override decimal BaseCost => 1.8m;
        public override Topping[] ValidToppings => new Topping[] { Topping.Sugar, Topping.Milk, Topping.Chocolate };

    }

    public class Tea : Drink
    {
        public override string Description => "Hot tea";
        public override decimal BaseCost => 1;

        public override Topping[] ValidToppings => new Topping[] { Topping.Sugar, Topping.Milk };

    }

    public class IceTea : Drink
    {
        public override string Description => "Ice tea";
        public override decimal BaseCost => 1.5m;

        public override Topping[] ValidToppings => new Topping[] { Topping.Sugar };

    }

    public enum Topping
    {
        Sugar,
        Milk,
        Chocolate
    }
}
