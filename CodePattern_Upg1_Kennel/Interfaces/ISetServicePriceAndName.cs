using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePattern_Upg1_Kennel.Interfaces
{
    public interface ISetServicePriceAndName
    {
        public void SetServicePrice(IStandardService standardService, IWash wash, IClawCutting clawCutting);
        public void SetServiceName(IStandardService standardService, IWash wash, IClawCutting clawCutting);
    }
}
