using ByteBank.Models.Funcionarios.Authenticator;
using ByteBank.Models.Interface_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Funcionarios
{
    public class Diretor : FuncionarioAutenticado
    {
        public Diretor(string _cpf, double _salario) : base(_cpf, _salario)
        {
        }

        public override void AumentarSalario()
        {
            Salario *= 0.15;
        }

        public override double GetBonificacao()
        {
            return Salario *= 0.10;
        }
    }
}
