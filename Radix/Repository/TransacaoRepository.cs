using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly Contexto _context;
        private readonly ILogger _logger;

        public TransacaoRepository(Contexto context, ILogger<LojaRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Transacao> Listar()
        {
            return _context.Transacao.ToList();
        }

        public IEnumerable<Transacao> Listar(Guid tokenLoja)
        {
            return _context.Transacao
                .Include(a => a.Adquirente)
                .Include(i => i.Loja)
                .Where(x => x.Loja.Token.Equals(tokenLoja));
        }

        public Transacao Selecionar(int id)
        {
            return _context.Transacao.FirstOrDefault(x => x.Id.Equals(id));
        }

        public bool Deletar(Transacao transacao)
        {
            bool retorno = false;
            try
            {
                _context.Transacao.Remove(transacao);
                _context.SaveChanges();
                retorno = true;
            }
            catch (Exception ex)
            {
                string mensagem = string.Format("Erro ao excluir Transacao: {0}", transacao.Id);
                _logger.LogError(mensagem, ex);
                throw;
            }

            return retorno;
        }

        public bool Alterar(Transacao transacao)
        {
            bool retorno = false;
            try
            {
                _context.Transacao.Update(transacao);
                _context.SaveChanges();
                retorno = true;
            }
            catch (Exception ex)
            {
                string mensagem = string.Format("Erro ao alterar Transacao: {0}", transacao.Id);
                _logger.LogError(mensagem, ex);
                throw;
            }

            return retorno;
        }
        public bool Salvar(Transacao transacao)
        {
            bool retorno = false;
            try
            {
                _context.Transacao.Add(transacao);
                _context.SaveChanges();
                retorno = true;
            }

            catch (Exception ex)
            {
                string mensagem = string.Format("Erro ao Incluir ao salvar a entidade Transação");
                _logger.LogError(mensagem, ex);
                throw;
            }

            return retorno;
        }

    }
}
