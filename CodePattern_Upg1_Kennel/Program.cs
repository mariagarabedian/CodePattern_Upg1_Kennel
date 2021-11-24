using CodePattern_Upg1_Kennel.Interfaces;
using System;

namespace CodePattern_Upg1_Kennel
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenuManager Menumanager = Factory.CreateMenu();

            Menumanager.Menu();
        }
    }
}
