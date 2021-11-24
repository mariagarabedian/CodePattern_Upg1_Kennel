using CodePattern_Upg1_Kennel.Interfaces;
using CodePattern_Upg1_Kennel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePattern_Upg1_Kennel
{
    public class Factory
    {
        // Creating new instans of classes
        public static IMenuManager CreateMenu()
        {
            return new MenuManager();
        }


        public static ICustomer CreateCustomer()
        {
            return new Customer();
        }


        public static IAnimal CreateAnimal()
        {
            return new Animal();
        }

        public static IStandardService CreateStandardService()
        {
            return new StandardService();
        }
        public static IWash CreateWash()
        {
            return new Wash();
        }

        public static IClawCutting CreateClowCutting()
        {
            return new ClawCutting();
        }

        public static IReceipt CreateReceipt()
        {
            return new Receipt();
        }

        public static ISetServicePriceAndName CreateSetPriceAndName()
        {
            return new SetServicePriceAndName();
        }
    }
}
