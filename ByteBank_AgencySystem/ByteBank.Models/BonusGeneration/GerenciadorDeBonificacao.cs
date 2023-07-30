using ByteBank.Models.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.BonusGeneration
{
    public class GerenciadorDeBonificacao
    {
        private double _calculadoraDasBonificacaoDadaAosFuncionarios;

        public void RegistrarFuncionario(Funcionario funcionario)
        {
            _calculadoraDasBonificacaoDadaAosFuncionarios += funcionario.GetBonificacao();
        }

        public double GetTotalDeBonificacaoDada()
        {
            return _calculadoraDasBonificacaoDadaAosFuncionarios;
        }
    }
}
