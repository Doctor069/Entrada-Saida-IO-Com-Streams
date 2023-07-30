using System;
using System.IO;

namespace ByteBank_PT_9
{
    partial class Program
    {
        void UsarStreamDeEntrada_PT5()
        {
            using(var fluxoDeEntrada = Console.OpenStandardInput()) // OpenStandardInput - retorna uma Stream
            {
                using(var fs = new FileStream("entradaConsole.txt", FileMode.Create))
                {
                    var buffer = new byte[1024]; // 1 kb

                    while (true) // quando usando o while, vai permitir escrever o tanto que quiser
                    {
                        var bytesLidos = fluxoDeEntrada.Read(buffer, 0, 1024);
                        
                        fs.Write(buffer, 0, bytesLidos);
                        fs.Flush(); //caso nao colocassemos o fluss, o bloco while nunca ia acabar, ia ficar em um loop infinito em colocar os dados escritos
                        //libera o buffer

                        Console.WriteLine($"Bytes lidos da console: {bytesLidos}");
                    }
                }
            }
        }
    }
}
