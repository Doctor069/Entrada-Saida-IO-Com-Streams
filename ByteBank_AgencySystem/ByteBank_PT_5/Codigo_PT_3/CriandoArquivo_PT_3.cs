using System.IO;
using System.Text;

namespace ByteBank_PT_9
{
    partial class Program
    {
        //Criando arquivos CSV
        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";  // tipo de arquivo padrao: --- txt --- nao é necessario colocar, pois ja é por padrao, mas ja fica mais visivel o tipo
            
            using(var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var conta_String = "666, 99999, 9587.50, Nicolas Cleik"; // Numero da agencia, Numero da conta, saldo e nome em sequencia, da mesma forma que o arquivo sera criado
                var encoding = Encoding.UTF8;

                var bytes = encoding.GetBytes(conta_String);

                fluxoDeArquivo.Write(bytes, 0, bytes.Length); //offset é o indece que voce deseje que o metado write olhe no buffer
            }
        }

        //codigo sem lidar com bytes ao criar o arquivo
        static void CriarArquivoComWriter_PT3()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using(var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew))
                //Create --- quando acha um arquivo ja existente, na mesma pasta, ele apaga tal arquivo e escreve outro por cima
                //CreateNew --- verifica se ja existe o arquivo, se caso sim, lança uma execeção - nesse caso usando sera lançado
            {
                // a StreamWrite deriva o IDisposable - disso o using
                //nos podiamos usar somente o fluxoDeArquivo - mas especificamos o Encoding que esta sendo usado
                using(var escritor = new StreamWriter(fluxoDeArquivo, Encoding.UTF8)) // ja é por padrao o --- UTF8 --- mas pode ser colocado para ficar mais visivel
                {
                    escritor.Write("666, 99999, 4545.50, Nicolas Cleik");
                }
            }
        }
    }
}