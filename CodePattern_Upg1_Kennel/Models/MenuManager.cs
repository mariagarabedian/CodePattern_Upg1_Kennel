using CodePattern_Upg1_Kennel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePattern_Upg1_Kennel.Models
{
    public class MenuManager : IMenuManager
    {
        public void ShowMenu()
        {
            Console.WriteLine(" \n=====================\n Välj ett alternativ\n =====================\n");
            Console.WriteLine("[1]  Registrera ny kund");
            Console.WriteLine("[2]  Visa registrerade kunder");
            Console.WriteLine("[3]  Registrera ny Hund");
            Console.WriteLine("[4]  Visa registrerade Hundar");
            Console.WriteLine("[5]  Se vilka hundar som tillhör vilka kunder");
            Console.WriteLine("[6]  Anmäla en hund som inlämnad");
            Console.WriteLine("[7]  Anmäla en hund som hämtad");
            Console.WriteLine("[8]  Se vilka hundar som är inlämnade och vem som är ägare till dessa");
            Console.WriteLine("[9]  Lägga till extratjänster på din hund");
            Console.WriteLine("[10] Avsluta");
            Console.WriteLine("\nDitt val:");

        }


        public void Menu()
        {
            ICustomer customer = Factory.CreateCustomer();
            IAnimal animal = Factory.CreateAnimal();
            IStandardService standardService = Factory.CreateStandardService();
            IWash wash = Factory.CreateWash();
            IClawCutting clawCutting = Factory.CreateClowCutting();
            IReceipt receipt = Factory.CreateReceipt();

            List<ICustomer> customers = new List<ICustomer>();
            List<IAnimal> animals = new List<IAnimal>();

            animals = MockupDataForTesting.CreateMockAnimals();
            customers = MockupDataForTesting.CreateMockCustomers();

            Console.WriteLine("\n Välkommen till Kennel! \n");
            bool menyRunning = true;

            while (menyRunning)
            {
                ShowMenu();
                var userSelection = UserSelection();

                Console.Clear();

                switch (userSelection)
                {
                    case 1:
                        customer.CreateNewCustomer(customers);
                        break;
                    case 2:
                        customer.GetCustomers(customers);
                        break;
                    case 3:
                        animal.CreateNewAnimal(animals, customers);
                        break;
                    case 4:
                        animal.GetAnimals(animals);
                        break;
                    case 5:
                        animal.GetAnimalsWithOwner(animals);
                        break;
                    case 6:
                        animal.CheckInAnimal(animals, animal);
                        break;
                    case 7:
                        animal.CheckOutAnimal(animals, animal, receipt, standardService, clawCutting, wash);
                        break;
                    case 8:
                        animal.GetAnimalsCeckedIn(animals);
                        break;
                    case 9:
                        animal.SetExtraServices(animals, animal);
                        break;
                    case 10:
                        Console.WriteLine("\n Avslutar.... \nTack för ditt besök!");
                        System.Threading.Thread.Sleep(1000);
                        menyRunning = false;
                        break;
                    default:
                        Console.WriteLine("\n Du valde ett ogiltigt alternativ, var god gör nytt försök.");
                        break;
                }
                Console.WriteLine();
            }
        }

        public int UserSelection()
        {
            Int32.TryParse(Console.ReadLine(), out int usersChoise);
            return usersChoise;
        }
    }
}
