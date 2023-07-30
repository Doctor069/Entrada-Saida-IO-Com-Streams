using System;
using System.IO;

namespace ByteBank_PT_9
{
    partial class Program
    {
        void EscritaBinaria_PT4()
        {
            using(var fs = new FileStream("contaCorrenteBinaria.txt", FileMode.Create)) // fs de file stream
            {
                using(var escritor = new BinaryWriter(fs))
                {
                    escritor.Write(645); // pode ser escolhido o que sera escrito - Numero da Agencia
                    escritor.Write(35655); // Numero da conta
                    escritor.Write(900.50); // Saldo
                    escritor.Write("Nicolas"); // titular
                }
            }
        }

        void LeituraBinaria_PT4()
        {
            using (var fs = new FileStream("contaCorrenteBinario.txt", FileMode.Open))
            {
                using(var leitor = new BinaryReader(fs))
                {
                    var NumeroAgencia = leitor.ReadInt32();
                    var NumeroConta = leitor.ReadInt32();
                    var Saldo = leitor.ReadDouble();

                    var Titular = leitor.ReadString();

                    Console.WriteLine($"{NumeroAgencia} / {NumeroConta} --- {Saldo} - {Titular}");
                }
            }
        }
    }
}
