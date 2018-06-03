using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IAdquirenteBusiness
    {
        Adquirente Selecionar(int id);

    }
}
