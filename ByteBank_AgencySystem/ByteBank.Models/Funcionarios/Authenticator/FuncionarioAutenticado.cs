using ByteBank.Models.Interface_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Funcionarios.Authenticator
{
    public abstract class FuncionarioAutenticado : Funcionario, IAutenticador
    {
        public FuncionarioAutenticado(string _cpf, double _salario) : base(_cpf, _salario) {  }

        private AutenticacaoHelper _autenticacaoHelper = new AutenticacaoHelper();


        public string Senha { get; set; }


        public bool Autenticar(string _senha)
        {
            return _autenticacaoHelper.CompararSenhas(Senha, _senha);
        }
    }
}
