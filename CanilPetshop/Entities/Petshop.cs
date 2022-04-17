using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CanilPetshop.Entities
{
    class Petshop
    {
        public string Nome { get; set; }
        public double Distancia { get; set; }
        public double PrecoCaoPequeno { get; set; }
        public double PrecoCaoGrande { get; set; }

        public Petshop()
        {
        }
        public Petshop(string nome, double distancia, double precoCaoPequeno, double precoCaoGrande)
        {
            Nome = nome;
            Distancia = distancia;
            PrecoCaoPequeno = precoCaoPequeno;
            PrecoCaoGrande = precoCaoGrande;
        }

        public virtual double CalcularPreco(DateTime data, int qtdCaesPequenos, int qtdCaesGrandes)
        {
            return PrecoCaoPequeno * qtdCaesPequenos + PrecoCaoGrande * qtdCaesGrandes;
        }


    }
}
