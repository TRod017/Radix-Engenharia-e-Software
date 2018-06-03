using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IVendaBusiness
    {
        string CartadoDeCredito(Pedido pedido);
    }
}
