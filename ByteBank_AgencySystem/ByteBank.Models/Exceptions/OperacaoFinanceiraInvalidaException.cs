using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Exceptions
{
    public class OperacaoFinanceiraInvalidaException : Exception
    {
        public OperacaoFinanceiraInvalidaException() { }

        public OperacaoFinanceiraInvalidaException(string message) : base(message) { }

        public OperacaoFinanceiraInvalidaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
