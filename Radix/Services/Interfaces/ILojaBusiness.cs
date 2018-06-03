using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ILojaBusiness
    {
        IEnumerable<Loja> Listar();
        Loja Selecionar(int id);
        Loja Selecionar(Guid token);
        bool Deletar(int id);
        bool Alterar();
        bool Salvar(Loja loja);
    }
}
