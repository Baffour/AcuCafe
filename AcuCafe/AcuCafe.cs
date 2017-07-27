using System;
using System.Collections.Generic;
using System.Linq;

namespace AcuCafe
{
    public class AcuCafe
    {
        public static Dictionary<string, Func<Drink>> DrinkConstructors = new Dictionary<string, Func<Drink>>
        {
            { "Expresso", () => new Expresso()  },
            { "HotTea", () => new Tea()  },
            { "IceTea", () => new IceTea()  },
        };
        public static Drink OrderDrink(string type, Topping[] toppings)
        {
            Drink drink;
            if (DrinkConstructors.ContainsKey(type))
            {
                var construct = DrinkConstructors[type];
                drink = construct();
            }
            else
            {
                throw new ArgumentException(string.Format(Constants.InvalidTypeExceptionMessage, type));
            }

            IEnumerable<Topping> invalidToppings = toppings.Except(drink.ValidToppings);
            if (invalidToppings.Any())
            {
                var invalidToppingMessage = string.Format(Constants.InvalidToppingExceptionMessage, type, invalidToppings.First());
                throw new InvalidOperationException(invalidToppingMessage);
            }

            try
            {
                drink.Toppings = toppings;
                drink.Prepare();
            }
            catch (Exception ex)
            {
                throw new Exception("We are unable to prepare your drink.", ex);
            }

            return drink;
        }
    }
}