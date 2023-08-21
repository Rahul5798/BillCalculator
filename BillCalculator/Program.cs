//Assignment1 Part1
using System;

namespace BillCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variables
            string      itemPurchased;
            float       basePrice = 0.0f;
            float       discountedAmount = 0.0f;
            float       weightOfItem;
            string      methodOfPayment;
            float       subTotal;
            float       paymentFee = 0.0f;
            int         hstTax = 13;
            float       hstAmount;
            float       grandTotal;

            //Asking the user which items they purchased
            Console.WriteLine("Items available for purchse: ");
            Console.WriteLine("1. Apples");
            Console.WriteLine("2. Oranges");
            Console.WriteLine("3. Lemons");
            Console.WriteLine("4. Limes");
            Console.Write("Which item you purchased? (Either enter the number or enter the name of the item): ");
            itemPurchased = Console.ReadLine();
            switch (itemPurchased.ToLower())
            {
                case "apples":
                case "1":
                    basePrice = 0.79f;//base price for apples per kg
                    itemPurchased = "Apples";
                    break;
                case "oranges":
                case "2":
                    basePrice = 1.19f;//base price for oranges per kg
                    itemPurchased = "Oranges";
                    break;
                case "lemons":
                case "3":
                    basePrice = 0.39f;////base price for lemons per kg
                    itemPurchased = "Lemons";
                    break;
                case "limes":
                case "4":
                    basePrice = 0.99f;//base price for limes per kg
                    itemPurchased = "Lime";
                    break;
                default:
                    Console.WriteLine("Error! You have not purchased anything");
                    break;
            }

            if (basePrice != 0.0)
            {
                //Asking the user weight of the purchased item
                Console.Write($"Please enter the weight of {itemPurchased} in kg: ");
                weightOfItem = float.Parse(Console.ReadLine());
                //calculating sub total
                if (weightOfItem > 20)
                {
                    discountedAmount = basePrice * 0.9f;    //applying 10% discount for items weighing more than 20kg
                    subTotal = weightOfItem * discountedAmount;
                }
                else
                {
                    subTotal = weightOfItem * basePrice;
                }
                try
                {
                    //Asking the user method of payment
                    Console.WriteLine("Available options for payment: ");
                    Console.WriteLine("1. Credit card");
                    Console.WriteLine("2. Debit card");
                    Console.WriteLine("3. Cash");
                    Console.Write("Choose prefered payment method (Either enter the number or name of the method): ");
                    methodOfPayment = Console.ReadLine();
                    if (methodOfPayment.ToLower() == "credit card" || methodOfPayment == "1")
                    {
                        paymentFee = 1.02f;  //Additional 2% fees to the subtotal for payments using credit card
                        subTotal *= paymentFee;
                    }


                    //Displayong final output
                    Console.WriteLine("".PadRight(70, '_'));
                    Console.WriteLine($"The name of the item purchased: {itemPurchased}");
                    Console.WriteLine($"The base price: {basePrice,23:n2}");
                    Console.WriteLine($"The discount amount: {discountedAmount,18:n2}");
                    Console.WriteLine($"Payment fee amount: {paymentFee,19:n2}");
                    Console.WriteLine();
                    Console.WriteLine($"Subtotal price: {subTotal,23:n2}");
                    hstAmount = subTotal * hstTax / 100;
                    Console.WriteLine($"HST amount: {hstAmount,27:n2}");
                    Console.WriteLine();
                    grandTotal = subTotal + hstAmount;
                    Console.WriteLine($"Grand total: {grandTotal,26:n2}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadKey();
        }
    }
}
