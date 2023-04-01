using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Core.Models.Compras
{
    public enum CompraStatus
    {
        [EnumMember(Value="Pendente")]
        Pendente,
        [EnumMember(Value="Pagamento Recebido")]
        PagamentoRecebido,
        [EnumMember(Value="Pagamento Falhou")]
        PagamentoFalhou,
    }
}