using System;
using System.Globalization;
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
            bool fecharPrograma = false;
            while (!fecharPrograma)
            {
                Console.Clear();
                TelaInicial();
                string[] entrada = Console.ReadLine().Split(' ');
                Console.WriteLine();
                EncontrarMelhorPetshop(entrada);
                Console.WriteLine();
                Console.Write("Deseja rodar o programa novamente?(S/N): ");
                char resposta = char.Parse(Console.ReadLine());
                if(resposta !='s' && resposta != 'S')
                {
                    fecharPrograma=true;
                }
            }

        }
        static void TelaInicial()
        {
            Console.WriteLine("---------------------------------- ENCONTRAR O MELHOR PETSHOP --------------------------------");
            Console.WriteLine();
            Console.WriteLine("O formato da entrada é <dd/mm/yyyy> <quantidade de cães pequenos> <quantidade de cães grandes>");
            Console.WriteLine("Ex: 17/04/2022 3 7");
            Console.WriteLine();
            Console.Write("Digite a entrada: ");
        }
        static void EncontrarMelhorPetshop(string[] entrada)
        {
            try
            {
                DateTime data = DateTime.Parse(entrada[0]); 
                int qtdCaesPequenos = int.Parse(entrada[1]); 
                int qtdCaesGrandes = int.Parse(entrada[2]); 



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
                    
                }
                
                Console.WriteLine($"O melhor petshop para levar os cães é o {petshopEscolhido.Nome} e o preço total dos banhos é de R${menorPreco.ToString("F2",CultureInfo.InvariantCulture)}.");
                Console.WriteLine();


            }
            catch (FormatException ex)
            {
                Console.WriteLine("Erro: Formato inválido. O formato de entrada não está de acordo com o formato padrão.");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Erro: Faltou algum valor de entrada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
