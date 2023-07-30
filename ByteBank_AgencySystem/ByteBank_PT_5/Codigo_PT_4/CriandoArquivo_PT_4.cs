using System;
using System.IO; 

namespace ByteBank_PT_9
{
    partial class Program
    {
        void TestaEscrita_PT4()
        {
            var caminhoArquivo = "teste.txt";

            using(var fluxoDeArquivos = new FileStream(caminhoArquivo, FileMode.Create))
            {
                using(var escritor = new StreamWriter(fluxoDeArquivos))
                /*StreamWriter
                 * Internamente possui um buffer - e quando tentamos escrever algo
                 * de fato nos nao escreve no arquivo - enquanto nos nao enchemos ele
                 * as informações nao é enviada
                 */
                {
                    for (int i = 0; i < 3 ; i++)
                    {
                        escritor.WriteLine($"Linha {i}");

                        escritor.Flush(); // despeja os dados do buffer para o Stream - arquivo (de imediato, mesmo sem preeencher todo o for)

                        Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter");
                        Console.ReadLine();
                    }
                    
                }
            }
        }
    }
}