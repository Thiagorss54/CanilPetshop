using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanilPetshop.Entities
{
     class VaiRex: Petshop
    {
        public VaiRex() : base("Vai Rex", 1.7, 15.0, 50.0)
        {
        }

        public override double CalcularPreco(DateTime data, int qtdCaesPequenos, int qtdCaesGrandes)
        {
            if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
            {
                return 20 * qtdCaesPequenos + 55 * qtdCaesGrandes;
            }
            else 
            {
                return base.CalcularPreco(data, qtdCaesPequenos, qtdCaesGrandes);
            }
        }
    }
}
