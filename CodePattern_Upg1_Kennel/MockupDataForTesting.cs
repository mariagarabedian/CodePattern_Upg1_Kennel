using CodePattern_Upg1_Kennel.Interfaces;
using CodePattern_Upg1_Kennel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePattern_Upg1_Kennel
{
    public class MockupDataForTesting
    {
        public static List<IAnimal> CreateMockAnimals()
        {
            // Create a list of dogs to use for testing
            var animals = new List<IAnimal>
            {
                 new Animal { AnimalName = "Bosse", Owner = new Customer() { UserName = "Åke" }, IsCheckedIn = false, ClawCutting = new ClawCutting() { Status = false }, Wash = new Wash() { Status = false }, StandardService = new StandardService() { Status = false } },
                 new Animal { AnimalName = "Lilo", Owner = new Customer() { UserName = "Jennie" }, IsCheckedIn = true, ClawCutting = new ClawCutting() { Status = false }, Wash = new Wash() { Status = false }, StandardService = new StandardService() { Status = false } },
                 new Animal { AnimalName = "Klara", Owner = new Customer() { UserName = "Maria" }, IsCheckedIn = true, ClawCutting = new ClawCutting() { Status = false }, Wash = new Wash() { Status = false }, StandardService = new StandardService() { Status = false } },
                 new Animal { AnimalName = "Uncle Bob", Owner = new Customer() { UserName = "Stefan" }, IsCheckedIn = false, ClawCutting = new ClawCutting() { Status = false }, Wash = new Wash() { Status = false }, StandardService = new StandardService() { Status = false } }
            };
            return animals;
        }

        public static List<ICustomer> CreateMockCustomers()
        {
            // Create a list of customers to use for testing
            var customers = new List<ICustomer>
            {
                new Customer { SSO = 1, UserName = "Ida", Email = "Ida@test.com", PhoneNo = 0784436562, Animals = new() {}, },
                new Customer { SSO = 1, UserName = "Jennie", Email = "Jennie@test.com", PhoneNo = 0788786653, Animals = new() { } },
                new Customer { SSO = 1, UserName = "Maria", Email = "Maria@test.com", PhoneNo = 0789766563, Animals = new() { } },
                new Customer { SSO = 1, UserName = "Stefan", Email = "Stefan@test.com", PhoneNo = 0768667996, Animals = new() { } }
            };
            return customers;
        }
    }
}
