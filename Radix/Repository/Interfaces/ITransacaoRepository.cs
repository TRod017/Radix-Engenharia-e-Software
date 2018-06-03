using Entity;
using System;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface ITransacaoRepository
    {
        IEnumerable<Transacao> Listar();
        IEnumerable<Transacao> Listar(Guid tokenLoja);
        Transacao Selecionar(int id);
        bool Deletar(Transacao transacao);
        bool Alterar(Transacao transacao);
        bool Salvar(Transacao transacao);
    }
}
