using System;
using System.IO;
using ByteBank.Models;
using ByteBank.Models.Client;

namespace ByteBank_PT_9
{
    public partial class Program
    {
        public void FazendoParseAndStreamWriter()
        {
            void codigo_PTIII()
            {
                var enderecoDasContas = "C:\\Users\\Micae\\source\\repos\\EntradaESaida_IO\\contas.txt";

                using (var fluxoDoArquivo = new FileStream(enderecoDasContas, FileMode.Open))
                {
                    using (var leitor = new StreamReader(fluxoDoArquivo))
                    {
                        while (!leitor.EndOfStream)
                        {
                            var linha = leitor.ReadLine();

                            //usando os separadores criando
                            var CurrentAccountResulted = ConvesorStringParaCurrentAccount_PT3(linha);

                            Console.WriteLine($"Titular: {CurrentAccountResulted.Titular.Nome} --- " +
                                $"Numero da conta: {CurrentAccountResulted.NumeroDaConta}. --- " +
                                $"Numero da agencia: {CurrentAccountResulted.NumeroDaAgencia}. --- " +
                                $"Saldo: {CurrentAccountResulted.Saldo}.");
                        }
                    }

                }
                Console.ReadLine();
            }
            CurrentAccount ConvesorStringParaCurrentAccount_PT3(string linha)
            {
                //primeiro passo, quebrar os campos do arquivo
                var campos_partes = linha.Split(','); //esse metado vai separar a partir do caractere separador que nos definimos
                //nao usamos o espaço apenas, por conta que estava tendo erro - caso tenha sobrenome a pessoa nao iria aparecer
                //o arquivo txt tambem foi alterado! - ha um comando basico de trocar caracteres nele - trocou o espaço pela virgula

                //as posiçoes sao de acordo com a quebrar feita - primeiro ta agencia, depois numero da conta...
                var agencia_conversor = campos_partes[0];
                var conta_conversor = campos_partes[1];
                var saldo_conversor = campos_partes[2].Replace('.', ',');
                var nomeTitular_conversor = campos_partes[3];

                //----------------------------------------------------------

                //transformar string para um numero inteiro
                var agencia_tranformado = int.Parse(agencia_conversor);
                var conta_tranformado = int.Parse(conta_conversor);

                //tranformar em double 
                var saldo_tranformado = double.Parse(saldo_conversor);

                //----------------------------------------------------------

                //nao foi preciso converter
                var titular = new Cliente();
                titular.Nome = nomeTitular_conversor;

                //nao é possivel usar string nos campos declarados como int - disso dar erro caso nao transforme
                var resultado = new CurrentAccount(agencia_tranformado, conta_tranformado);
                resultado.Depositar(saldo_tranformado);

                resultado.Titular = titular;

                return resultado;
            }
            codigo_PTIII();
        }
    }
}