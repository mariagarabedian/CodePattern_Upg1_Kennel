using CodePattern_Upg1_Kennel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePattern_Upg1_Kennel.Models
{
    public class SetServicePriceAndName : ISetServicePriceAndName
    {
        public void SetServicePrice(IStandardService standardService, IWash wash, IClawCutting clawCutting)
        {
            standardService.Price = 399;
            wash.Price = 99;
            clawCutting.Price = 99;
        }

        public void SetServiceName(IStandardService standardService, IWash wash, IClawCutting clawCutting)
        {
            standardService.Name = "Dagpassning";
            wash.Name = "Tvätt";
            clawCutting.Name = "Kloklippning";
        }
    }
}
