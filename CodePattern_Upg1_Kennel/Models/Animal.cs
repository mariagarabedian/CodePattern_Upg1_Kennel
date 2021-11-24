using CodePattern_Upg1_Kennel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePattern_Upg1_Kennel.Models
{
    public class Animal : IAnimal
    {
        public string AnimalName { get; set; }
        public bool IsCheckedIn { get; set; }
        public ICustomer Owner { get; set; }
        public IStandardService StandardService { get; set; }
        public IWash Wash { get; set; }
        public IClawCutting ClawCutting { get; set; }



        // Funktioner

        public void CreateNewAnimal(List<IAnimal> animals, List<ICustomer> customers)
        {
            IAnimal animal = Factory.CreateAnimal();
            ICustomer customer = Factory.CreateCustomer();
            IWash wash = Factory.CreateWash();
            IClawCutting clawCutting = Factory.CreateClowCutting();

            animal.AnimalName = "";
            animal.IsCheckedIn = false;
            animal.ClawCutting = clawCutting;
            clawCutting.Status = false;
            animal.Wash = wash;
            wash.Status = false;
            animal.Owner = customer;

            Console.WriteLine("  ==== Registrera djur ====\n");
            Console.WriteLine(" Vad heter djuret?");
            animal.AnimalName = Console.ReadLine();

            while (animal.AnimalName == "")
            {
                Console.WriteLine(" Var god och skriv namn:");
                animal.AnimalName = Console.ReadLine();
            }


            Console.WriteLine("\n Vad har ägaren för namn?");
            var inputName = Console.ReadLine();

            while (inputName == "")
            {
                Console.WriteLine(" Var god och skriv namn:");
                inputName = Console.ReadLine();
            }

            //customer = customers.FirstOrDefault(x => x.UserName == inputName);
            customer = customers.Where(x => x.UserName == inputName).FirstOrDefault();

            if (customer != null)
            {
                animal.Owner = customer;
                animal.SaveAnimal(animal, animals);
                Console.WriteLine("\n Djuret är registrerad\n");
            }
            else
            {
                Console.WriteLine("\n Den här kunden finns inte i vårat system.\n");
            }

        }


        public void SaveAnimal(IAnimal animal, List<IAnimal> animals)
        {
            animals.Add(animal);
        }


        public void GetAnimals(List<IAnimal> animals)
        {
            Console.WriteLine("\n ==== Alla hundar i systemet ====\n");
            foreach (var animal in animals)
            {
                Console.WriteLine($"   {animal.AnimalName}");
            }
        }


        public void GetAnimalsWithOwner(List<IAnimal> animals)
        {
            Console.WriteLine("\n ==== Alla djur i systemet samt deras ägare; ====\n");
            foreach (var animal in animals)
            {
                Console.WriteLine($"  Djur:  {animal.AnimalName}   Ägare:  {animal.Owner.UserName}");
            }
        }



        public void GetAnimalsCeckedIn(List<IAnimal> animals)
        {
            Console.WriteLine("\n ==== Dessa djur är inchekade: ====");
            foreach (var animal in animals)
            {
                if (animal.IsCheckedIn == true)
                {
                    Console.WriteLine($"\n Djur: {animal.AnimalName}, Ägare: {animal.Owner.UserName}, Status: {animal.IsCheckedIn}");
                }
                else if (animal.IsCheckedIn != true && false)
                {
                    Console.WriteLine(" Det finns inga hundar inlämnade");
                }
            }
        }

        public IAnimal GetAnimalByName(List<IAnimal> animals, IAnimal animal)
        {
            Console.Write(" Skriv in djurets namn:");
            var name = Console.ReadLine();
            while (name == "")
            {
                Console.Write(" Var god skriv djurets namn:");
                name = Console.ReadLine();
            }
            if (animals.Any(a => a.AnimalName == name))
            { animal.AnimalName = name; }

            animal = animals.FirstOrDefault(x => x.AnimalName == name);
            return animal;
        }

        public void CheckInAnimal(List<IAnimal> animals, IAnimal animal)
        {
            Console.WriteLine("\n ==== Checka in djur ====\n");
            animal = GetAnimalByName(animals, animal);

            if (animal != null)
            {
                Console.Write($" Vill du lämna in {animal.AnimalName}? (ja/nej) ");
                var _checkIn = Console.ReadLine();

                while ((_checkIn != "ja") && (_checkIn != "nej"))
                {
                    Console.Write(" Var god och svara (ja/nej)");
                    _checkIn = Console.ReadLine();
                }

                if (_checkIn.ToLower() == "ja")
                {
                    if (animal.IsCheckedIn == true)
                    {
                        Console.Write($" {animal.AnimalName} är redan inlämnad. ");
                    }
                    else
                    {
                        animal.IsCheckedIn = true;
                        Console.Write($" {animal.AnimalName} är inlämnad. ");
                    }                 
                }
                else if (_checkIn.ToLower() == "nej")
                {
                    if (animal.IsCheckedIn == true)
                    {
                        Console.Write($" {animal.AnimalName} var redan inlämnad. ");
                    }
                    else
                    {
                        Console.Write(" Ok, ingen incheckning har skett.\n");
                    }
                }
            }
            else
            {
                Console.Write(" Vi har ingen djur i systemet som heter detta");
            }
        }

        public void CheckOutAnimal(List<IAnimal> animals, IAnimal animal, IReceipt receipt, IStandardService standardService, IClawCutting clawCutting, IWash wash)
        {
            Console.WriteLine("\n ==== Ut Checkning ====\n");
            animal = GetAnimalByName(animals, animal);

            if (animal != null)
            {
                Console.Write($" Vill du hämta ditt djur {animal.AnimalName}? (ja/nej) ");
                var _checkIn = Console.ReadLine();

                while ((_checkIn != "ja") && (_checkIn != "nej"))
                {
                    Console.Write(" Var god och svara (ja/nej)");
                    _checkIn = Console.ReadLine();
                }

                if (_checkIn.ToLower() == "ja")
                {
                    if (animal.IsCheckedIn == true)
                    {
                        animal.IsCheckedIn = false;
                        Console.Write($" {animal.AnimalName} är nu hämtad. ");

                        receipt.ShowReceipt(standardService, clawCutting, wash, animals, animal);
                    }
                    else
                    {
                        Console.Write(" Ingen har checkat in detta djur. ");
                    }
                }
                if (_checkIn.ToLower() == "nej")
                {
                    if (animal.IsCheckedIn == false)
                    {
                        Console.Write(" Ingen har checkat in detta djur. ");
                    }
                    else if (animal.IsCheckedIn == true)
                    {
                        Console.Write($" {animal.AnimalName} är inte hämtad. ");
                    }
                }
            }
            else if (animal == null)
            {
                Console.Write(" Denna djur finns inte i systemet");
            }
            else
            {
                Console.Write(" Denna djur är inte inlämnad");
            }
        }

        public void SetExtraServices(List<IAnimal> animals, IAnimal animal)
        {
            Console.WriteLine("\n ==== Lägga till extratjänster på djuret ==== \n");
            Console.WriteLine(" Skriv in djurets namn:");
            var name = Console.ReadLine();

            while (name == "")
            {
                Console.Write(" Skriv in djurets namn:");
                name = Console.ReadLine();
            }

            animal = animals.FirstOrDefault(x => x.AnimalName == name);

            if (animal != null)
            {
                if (animal.IsCheckedIn == true)
                {
                    Console.WriteLine($" Vill boka kloklippnig på {animal.AnimalName}? (ja/nej) ");
                    var _cut = Console.ReadLine();

                    while ((_cut != "ja") && (_cut != "nej"))
                    {
                        Console.Write(" Var god och svara (ja/nej)");
                        _cut = Console.ReadLine();
                    }

                    if (_cut.ToLower() == "ja")
                    {
                        var search = animals.FirstOrDefault(x => x.AnimalName == name);
                        if (search.ClawCutting.Status == false)
                        {
                            if (search != null)
                            {
                                search.ClawCutting.Status = true;
                                Console.WriteLine($" Kloklippning är bokad ");
                            }
                        }
                    }

                    Console.WriteLine($"\n Vill du boka tvätt på {animal.AnimalName}? (ja/nej) ");
                    var _wash = Console.ReadLine();

                    while ((_wash != "ja") && (_wash != "nej"))
                    {
                        Console.Write(" Var god och svara (ja/nej)");
                        _wash = Console.ReadLine();
                    }

                    if (_wash.ToLower() == "ja")
                    {
                        var search = animals.FirstOrDefault(x => x.AnimalName == name);
                        if (search.Wash.Status == false)
                        {
                            if (search != null) search.Wash.Status = true;
                            Console.Write($"\n Tvätt är bokad.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine(" Detta djur är inte inchekad");
                }
            }
            else
            {
                Console.Write(" Vi har inget djur i systemet som heter detta");
            }
        }
    }
}
