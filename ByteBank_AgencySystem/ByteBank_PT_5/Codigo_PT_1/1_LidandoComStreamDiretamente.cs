using System;
using System.IO;
using System.Text;

namespace ByteBank_PT_9
{
    // não é possivel criar duas classe program
    //para isso é necessario usar o --- partial --- que dirar que criar varios arquivos separados, mas usará todos eles
    //quando usamos isso, é necessario usar --- partial --- em todos os Program
    partial class Program
    {
        static void LidandoComStreamDiretamente()
        {
            void CodigoPrincipal()
            {
                // codigo da parte I
                // abrindo arquivos com dados de contas criados --- contas.txt --- na mesma pasta que o projeto
                /* ha duas formas de achar o arquivo
                 * 1 - colocando todo o diretoria e local da pasta dele
                 * 2 - colocar o arquivo de texto ou qualquer outro tipo, dentro da pasta bin / debug do projeto principal
                 */

                // o caminho pode ser apenas --- contas.txt ----
                // mas isso busca de forma relativa o caminho - disso é necessario colocar no mesmo diretorio que o arquivo execultavel (Debug)
                var enderecoDasContas = "C:\\Users\\Micae\\source\\repos\\EntradaESaida_IO\\contas.txt";

                //o filestream tem varias funções, no nosso caso vamos usar a primeira
                // --- IntPtr handle --- que é o endereço do arquivo
                // --- FileAcess access --- tipo de acesso que vamos fazer, no caso vamos abrir ele - FileMode.Open -
                var fluxoDoArquivo = new FileStream(enderecoDasContas, FileMode.Open);

                //buffer é usado para inilializar um projeto, como video, sem precisar carregar todo
                //buffer é usado para informações temporarias
                var buffer = new byte[1024]; // 1024 bytes é o mesmo que 1kb
                var numeroDeBytesLido = -1; // -1 pelo motivo que nunca vai ser retornado positivo no read

                while (numeroDeBytesLido != 0) // para nao criar um array gigante de bytes, usamos o whule
                {                             // 
                    //f12 para ir para as assinaturas dos comandos
                    // ps - FileStream tem um metado chamado Read --- no caso primeiro um array de bytes, depois momento que começa a ler, depois a contagem de bytes que quer seja lido
                    //numeroDeBytesLido apenas foi criado dps
                    numeroDeBytesLido = fluxoDoArquivo.Read(buffer, 0, 1024);
                    EscreverBuffer(buffer);
                }

                Console.ReadLine();

                //Conceitos finais da parte I
                /*Compreendendo o UniCode
                 * O UniCode foi um meio usado para abrangir ainda mais caracteres na maquina,
                 * sendo que a table asctableII apenas possui 126, que acabando removendo entre
                 * alguns caracteres especiais, ou letras de outros alfabetos
                 * Sendo que na tabela do UniCode ja possui mais de 700
                 * Uma observação importante, o ultimo codigo da tabela Asctable - 127 refere a um codigo
                 * sendo que nao foi colocado na UniCode
                 * 
                 * A unicode pode ser representado como
                 * Unicode Transfomation Format - Fortamto de transformação unicode
                 * UTF   ---  protocolo de transformação para a maquina
                 * 
                 * Sobre os UTF
                 * UTF-8     ---  
                 * UTF-16    ---  representado por -- Unicode -- usar direntamente UTF16 não existe
                 * UTF-32    ---  
                 * UFT-7     ---  
                 * ... dentre varios outros tipos
                 */
            }


            //metado para escrever o buffer na tela - pt I
            void EscreverBuffer(byte[] buffer)
            {
                //Encoding representa uma forma de armazenar os carateres que compoem as strings
                var utf8 = new UTF8Encoding(); // ou apenas --- = Encoding.UTF8; ---
               // var utf8 = Encoding.UTF8;
                // ou Encoding.Default; --- recupera o encoding do sistema operacional
                                               //O tipo --- Default --- é o padrao do sistema operacional - no caso se for usado nao tera nenhum problema ja que o arquivo foi criado na mesma maquina e sistema operacional --- Windowns 11
                // UTF = Unicode Transformation Format
                
                var textoUTF8 = utf8.GetString(buffer);
                Console.WriteLine(textoUTF8);

                //Foi retirado para nao vermos os bytes
                /*foreach (var bytesUsados in buffer)
                {
                    Console.Write(bytesUsados);
                    Console.Write(" ");
                } */



                //Quebra de linha
                /*Para quebra linha na string --- \n --- pode ser colocado no meio da string
                Para ser apenas do texto tem que ser duas barras --- \\n ---
                Console.WriteLine("Quebrando linha para os numero: --- \n --- 123456789"); */
            }

        }
    }
}