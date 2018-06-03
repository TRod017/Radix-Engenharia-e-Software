using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IAntiFraudeBusiness
    {
        string Analisar(Pedido pedido);
    }
}
