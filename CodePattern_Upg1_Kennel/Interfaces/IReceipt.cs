using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePattern_Upg1_Kennel.Interfaces
{
    public interface IReceipt
    {
        public IStandardService StandardService { get; set; }
        public IWash Wash { get; set; }
        public IClawCutting ClawCutting { get; set; }
        public decimal TotalCost { get; set; }

        public void ShowReceipt(IStandardService standardService, IClawCutting clawCutting, IWash wash, List<IAnimal> animals, IAnimal animal);
    }
}
