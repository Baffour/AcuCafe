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
}