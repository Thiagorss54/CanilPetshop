using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanilPetshop.Entities
{
     class MeuCaninoFeliz: Petshop
    {
        public MeuCaninoFeliz() : base("Meu Canino Feliz", 2.0, 20.0, 40.0) { }

        public override double CalcularPreco(DateTime data, int qtdCaesPequenos, int qtdCaesGrandes)
        {
            if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
            {
                return base.CalcularPreco(data, qtdCaesPequenos, qtdCaesGrandes) * 1.2;
            }
            else {
                return base.CalcularPreco(data, qtdCaesPequenos, qtdCaesGrandes);
            }
        }

    }
}
