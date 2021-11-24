using CodePattern_Upg1_Kennel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePattern_Upg1_Kennel.Models
{
    public class Receipt : IReceipt
    {
        public IStandardService StandardService { get; set; }
        public IWash Wash { get; set; }
        public IClawCutting ClawCutting { get; set; }
        public decimal TotalCost { get; set; }



        ISetServicePriceAndName setServicePriceAndName = Factory.CreateSetPriceAndName();
        public void ShowReceipt(IStandardService standardService, IClawCutting clawCutting, IWash wash, List<IAnimal> animals, IAnimal animal)
        {
            setServicePriceAndName.SetServicePrice(standardService, wash, clawCutting);
            setServicePriceAndName.SetServiceName(standardService, wash, clawCutting);

            Console.Write($"\n Vill du ha kvitto för {animal.AnimalName}? (ja/nej) ");
            var _kvitto = Console.ReadLine();

            if (_kvitto.ToLower() == "ja")
            {
                Console.WriteLine("\n ==== KVITTO ====");
                if (animal.Wash.Status == true && animal.ClawCutting.Status == true)
                {
                    var totalCost = standardService.Price + wash.Price + clawCutting.Price;
                    Console.WriteLine($" {standardService.Name}    {standardService.Price}\n {clawCutting.Name}    {clawCutting.Price}\n {wash.Name}           {wash.Price} \n Totalkostnad:  {totalCost}");
                }
                else if (animal.Wash.Status == true && animal.ClawCutting.Status == false)
                {
                    var totalCost = standardService.Price + wash.Price;
                    Console.WriteLine($" {standardService.Name}    {standardService.Price}\n {wash.Name}           {wash.Price} \n Totalkostnad:  {totalCost}");
                }
                else if (animal.Wash.Status == false && animal.ClawCutting.Status == true)
                {
                    var totalCost = standardService.Price + clawCutting.Price;
                    Console.WriteLine($" {standardService.Name}    {standardService.Price} \n {clawCutting.Name}    {clawCutting.Price} \n Totalkostnad:  {totalCost}");
                }
                else if (animal.Wash.Status == false && animal.ClawCutting.Status == false)
                {
                    var totalCost = standardService.Price;
                    Console.WriteLine($" {standardService.Name}    {standardService.Price} \n Totalkostnad:  {totalCost}");
                }
                else
                {
                    Console.Write(" ");
                }               
            }
        }
    }
}
