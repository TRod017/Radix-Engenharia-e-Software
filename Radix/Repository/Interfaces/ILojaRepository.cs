using Entity;
using System;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface ILojaRepository
    {
        IEnumerable<Loja> Listar();
        Loja Selecionar(int id);
        Loja Selecionar(Guid token);
        bool Deletar(Loja loja);
        bool Alterar(Loja loja);
        bool Salvar(Loja loja);

    }
}
