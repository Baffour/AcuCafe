using System;
using System.Collections.Generic;
using System.Linq;

namespace AcuCafe
{
    public class AcuCafe
    {
        public static Drink OrderDrink(string type, Topping[] toppings)
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

            IEnumerable<Topping> invalidToppings = toppings.Except(drink.ValidToppings());
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
                Console.WriteLine("We are unable to prepare your drink.");
                System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
            }

            return drink;
        }
    }
}