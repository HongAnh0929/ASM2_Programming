using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ASM1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string customer_name = GetCustomerName();

            double lastmonth = 0;
            double thismonth = 0;

            double water_consumption = GetConsumption(out lastmonth, out thismonth);
            Console.WriteLine("Water consumption:  " + water_consumption + "m3");

            string type = GetCustomerType();
            Console.WriteLine("Customer type: " + type);

            double water_bill = GetWaterBill(type, water_consumption);
            Console.WriteLine("Water bill = " + water_bill + "VND");

            double evm = GetEnvironment(water_bill);
            Console.WriteLine("Environment = " + evm + "VND");

            double total_bill = GetTotalBill(water_bill, evm);
            Console.WriteLine("Total bill = " + total_bill + "VND");

            double VAT = GetVAT(total_bill);
            Console.WriteLine("VAT = " + VAT + "VND");

            double total_amount = GetTotalAmount(total_bill, evm);
            Console.WriteLine("Total amount = " + total_amount + "VND");

            PrintInvoice(customer_name, lastmonth, thismonth, type, water_bill, total_amount);

            Console.WriteLine("Press any key to continue.....");

            Console.ReadLine();

            Console.Clear();
        }

        static string GetCustomerName()
        {
            Console.Write("Customer name: ");
            string customer_name = Console.ReadLine();

            return customer_name;
        }

        static string GetCustomerType()
        {
            Console.WriteLine("1. Household customers");
            Console.WriteLine("2. Administrative agencies and public");
            Console.WriteLine("3. Production unit");
            Console.WriteLine("4. Business services");
            Console.WriteLine("Customer Type:");
            string type = Console.ReadLine();


            while (type != "1" && type != "2" && type != "3" && type != "4")
            {
                Console.WriteLine("The program prompts the user to re-enter the customer type");
                Console.WriteLine("Re-enter the customer type: ");
                type = Console.ReadLine();
            }
            
            return type;
        }
        static double GetConsumption(out double lastmonth, out double thismonth)
        {
            double consumption = 0;

            bool isVaild = false;

            do
            {
                Console.Write("Last month's water meter readings: ");

                while (!double.TryParse(Console.ReadLine(), out lastmonth) || lastmonth <= 0)
                {
                    Console.WriteLine("Please re-enter last month's water meter readings: ");
                }

                Console.Write("This month's water meter readings: ");

                while (!double.TryParse(Console.ReadLine(), out thismonth) || thismonth <= 0)
                {
                    Console.WriteLine("Please re-enter this month's water meter readings: ");
                }

                if (lastmonth >= thismonth)
                {
                    Console.WriteLine("Error message: Invalid value!.");
                    Console.WriteLine("Please re-enter the value:");
                }
                else
                {
                    consumption = thismonth - lastmonth;
                    isVaild = true;
                }
            }
            while (!isVaild);

            return consumption;
        }

        static double GetWaterBill(string type, double water_consumption)
        {

            double water_bill = 0;

            switch (type)
            {
                case "1":
                    Console.WriteLine("Household customers");

                    Console.Write("Enter the number of people: ");
                    int the_number_people = int.Parse(Console.ReadLine());

                    if (water_consumption <= 10)
                    {
                        water_bill = 10 * 5973;
                        break;
                    }
                    else if (water_consumption > 10 && water_consumption <= 20)
                    {
                        water_bill = 10 * 5973 + 10 * 7052;
                        break;
                    }
                    else if (water_consumption > 20 && water_consumption <= 30)
                    {
                        water_bill = 10 * 5973 + 10 * 7052 + 10 * 8699;
                        break;
                    }
                    else
                    {
                        water_bill = 10 * 5973 + 10 * 7052 + 10 * 8699 + (water_consumption - 30) * 15929;
                    }
                    break;
                case "2":
                    Console.WriteLine("Administrative agencies and public services");
                    water_bill = water_consumption * 9955;
                    break;
                case "3":
                    Console.WriteLine("Production unit");
                    water_bill = water_consumption * 11615;
                    break;
                case "4":
                    Console.WriteLine("Business service");
                    water_bill = water_consumption * 22068;
                    break;
            }
            return water_bill;
        }

        static double GetEnvironment(double water_bill)
        {
            double evm = 0.1 * water_bill;

            return evm;
        }
        static double GetTotalBill (double water_bill, double evm)
        {
            double total_bill = water_bill + evm;
                       
            return total_bill;
        }

        static double GetVAT(double total_bill)
        {
            double VAT = 0.1 * total_bill;

            return VAT;
        }

        static double GetTotalAmount(double total_bill, double VAT)
        {
            double total_amount = total_bill + VAT;

            return total_amount;
        }

        static void PrintInvoice(string customer_name, double lastmonth, double thismonth, string type, double water_bill, double total_amount)
        {
            Console.WriteLine("                                         MONTHLY WATER BILL                                      ");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                                                                 ");
            Console.WriteLine("Customer name: " + customer_name);
            Console.WriteLine("Last month's water meter readings: " + lastmonth);
            Console.WriteLine("This month's water meter readings: " + thismonth);
            Console.WriteLine("Customer type: " + type);
            Console.WriteLine("Amount of water consumed: " + water_bill + "VND");
            Console.WriteLine("Total amount: " + total_amount + "VND");
        }
    }
}