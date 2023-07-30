using System;
using System.IO;
using System.Text;

namespace ByteBank_PT_9
{
    partial class Program
    {
        static void LidandoComStreamDiretamente_02()
        {
            //EVITANDO LIMITE DE BUFFER - LEITURA E LIMITE
            void ultimasModificacaes() // forma mais facil de definir limite de buffer
            {
                var enderecoDasContas = "C:\\Users\\Micae\\source\\repos\\EntradaESaida_IO\\contas.txt";

                using (var fluxoDoArquivo = new FileStream(enderecoDasContas, FileMode.Open))
                    //obs que esta dentro de um bloco using
                    using (var leitor = new StreamReader(fluxoDoArquivo)) // classe para leitura - StreamReader = leitor de stream
                    { // TEM QUE ESPECIFICAR PARA O StreamReader - a origem dos dados (fluxoDoArquivo)
                    //por baixo dos panos o StreamReader tem um buffer
                    //ps, como o StreamReader usa recurso do sistema operacional, disso é necessario colocar dentro de um using --- no caso usa uma IDisposable

                        //      var linha = leitor.ReadLine();
                        // ha diferentes codigos 
                        /* ReadLine --- ler uma linha por vez
                         * ReatToEnd  --- ler tudo de uma vez --- pode ser muito pesado, ja que ler tudp
                         Cuidado ao usar, pois pode crchar o pc
                         * Read  --- ler primeiro byte
                         */

                        while (!leitor.EndOfStream) // EndOfStream - indica se ja chegou ate o fim
                        {
                            string linha = leitor.ReadLine();
                            Console.WriteLine(linha);
                        }
                    }
                
            }
            void CodigoDaPTII()
            {
                var enderecoDasContas = "C:\\Users\\Micae\\source\\repos\\EntradaESaida_IO\\contas.txt";

                using (var fluxoDoArquivo = new FileStream(enderecoDasContas, FileMode.Open))
                {
                    // Observações --- cuidado ao tamanho do buffer, valor fixo tara a repetição do inicio caso ja seja preenchido
                    //ele irar ocupar todo o tamanho colocado, entao caso o arquivo seja menor, ele vai repetir o inicio

                    var buffer = new byte[1024];
                    var numeroDeBytesLido = -1;

                    while (numeroDeBytesLido != 0)
                    {
                        numeroDeBytesLido = fluxoDoArquivo.Read(buffer, 0, 1024);
                        Console.WriteLine($"A quantidade de bytes lidos foram: {numeroDeBytesLido}");

                        EscreverBuffer(buffer, numeroDeBytesLido);
                    }

                    /* Observação muito importante
                     * Sempre é bom colocar um metado que feche o arquivo
                     * Quando nos nos terminamos de usar um recuso de Stream - no caso de dados
                     */
                    /*Erros possiveis caso nao tenha um metado de fechar
                     * O fluxo do arquivo pode dar erro
                     * nos nao podemos modificar ele, alterar o nome do arquivo por exemplo enquanto nao tiver o close
                     */


                    //notificando a maquina que a execulçao do arquivo ja foi encerrada
                    //fluxoDoArquivo.Close(); --- nesse caso usando o --- using --- ja trouxe essa funcionalidade
                    //no caso ele cria o try e o finally, final chama o metado Dipose --- que de forma interna chama o close
                }
            }

            void EscreverBuffer(byte[] buffer, int bytesLidos)
            {
                var utf8 = new UTF8Encoding();

                var textoUTF8 = utf8.GetString(buffer, 0, bytesLidos);
                Console.WriteLine(textoUTF8);
            }
        }
    }
}