using System;
using System.IO;

namespace ByteBank_PT_9
{
    partial class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("arquivoFile.txt", "Arquivo criado com o File"); // sera criado um arquivo no diretatorio do execultavel

            var bytes = File.ReadAllBytes("C:\\Users\\Micae\\source\\repos\\EntradaESaida_IO\\contas.txt");
            Console.WriteLine(bytes.Length); // quantidade de bytes

            Console.ReadLine();
            
            var Lines = File.ReadAllLines("C:\\Users\\Micae\\source\\repos\\EntradaESaida_IO\\contas.txt");
            foreach (var line in Lines)
            {
                Console.WriteLine(line); //leitura do arquivo
            }
            Console.WriteLine(Lines.Length); // quantidade de linhas
            
            Console.ReadLine();

            //por baixo do file ha desde da Stream, buffer e Flush()

            Program myObject = new Program();

            myObject.UsarStreamDeEntrada_PT5();

            Console.WriteLine(myObject);
            Console.ReadLine();
        }
    }
}
