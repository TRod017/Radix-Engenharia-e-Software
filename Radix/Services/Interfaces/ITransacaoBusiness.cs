using Entity;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ITransacaoBusiness
    {
        IEnumerable<Transacao> Listar();
        IEnumerable<Transacao> Listar(Guid tokenLoja);
        Transacao Selecionar(int id);
        bool Deletar(int id);
        bool Salvar(Transacao transacao);
        bool Salvar(Pedido pedido);
    }
}
