using CodePattern_Upg1_Kennel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePattern_Upg1_Kennel.Models
{
    public class Customer : ICustomer
    {
        public IAnimal AnimalName { get; set; }
        public List<IAnimal> Animals { get; set; }
        public int SSO { get; set; }
        public string UserName { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }

        public void SaveCustomers(ICustomer customer, List<ICustomer> customers)
        {
            customers.Add(customer);
        }

        public void GetCustomers(List<ICustomer> customers)
        {
            Console.WriteLine("\n ==== Registrerade Kunder ==== \n");
            foreach (var customer in customers)
            {
                Console.WriteLine($" Personnr: {customer.SSO}, Namn: {customer.UserName}, Email: {customer.Email}, Telefon nr: {customer.PhoneNo}");
            }
        }

        public void CreateNewCustomer(List<ICustomer> customers)
        {
            ICustomer customer = Factory.CreateCustomer();

            customer.SSO = 0;
            customer.UserName = "";
            customer.Email = "";
            customer.PhoneNo = 0;

            Console.WriteLine("\n ==== Registrera kund ====\n ");
            Console.WriteLine(" Vad har kunden för personnr?");

            bool iswrong = true;
            while (iswrong)
            {
                try
                {
                    customer.SSO = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("\n Vad har kunden för personnr?");
                    iswrong = true;
                    continue;
                }
                iswrong = false;
            }

            Console.WriteLine("\n Vad heter kunden?");
            customer.UserName = Console.ReadLine();

            while (customer.UserName == "")
            {
                Console.WriteLine("\n Vad heter kunden?");
                customer.UserName = Console.ReadLine();
            }

            Console.WriteLine("\n Vad har kunden för Email?");
            customer.Email = Console.ReadLine();

            while (customer.Email == "")
            {
                Console.WriteLine("\n Vad har kunden för Email?");
                customer.Email = Console.ReadLine();
            }

            Console.WriteLine("\n Vad har kunden för telefonnummer?");

            iswrong = true;
            while (iswrong)
            {
                try
                {
                    customer.PhoneNo = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("\n Vad har kunden för telefonnummer?");
                    iswrong = true;
                    continue;
                }
                iswrong = false;
            }

            customer.SaveCustomers(customer, customers);
            Console.WriteLine("Kunden är nu registrerad");
        }
    }
}
