using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanilPetshop.Entities;


namespace CanilPetshop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime data;
            int qtdCaesPequenos;
            int qtdCaesGrandes;

            Console.WriteLine("Digite a entrada no formato <dd/mm/yyyy> <quantidade de cães pequenos> <quantidade de cães grandes>");
            string[] entrada = Console.ReadLine().Split(' ');
            data = DateTime.Parse(entrada[0]);
            qtdCaesPequenos = int.Parse(entrada[1]);
            qtdCaesGrandes = int.Parse(entrada[2]);

            List<Petshop> petshops = new List<Petshop>();

            petshops.Add(new MeuCaninoFeliz());
            petshops.Add(new VaiRex());
            petshops.Add(new Petshop("ChowChagas", 0.8, 30, 45));

            Petshop petshopEscolhido = petshops.First();
            double menorPreco = petshopEscolhido.CalcularPreco(data, qtdCaesPequenos, qtdCaesGrandes);

            foreach (Petshop petshop in petshops)
            {
                double precoTotal = petshop.CalcularPreco(data, qtdCaesPequenos, qtdCaesGrandes);
                if (precoTotal < menorPreco)
                {
                    petshopEscolhido = petshop;
                    menorPreco = precoTotal;
                }
                else if (precoTotal == menorPreco && petshop.Distancia < petshopEscolhido.Distancia)
                {
                    petshopEscolhido = petshop;
                    menorPreco = precoTotal;
                }
                Console.WriteLine(petshop.Nome + " " + precoTotal);

            }
            Console.WriteLine();
            Console.WriteLine("O melhor petshop para levar os cães é o " + petshopEscolhido.Nome);


        }
    }
}
