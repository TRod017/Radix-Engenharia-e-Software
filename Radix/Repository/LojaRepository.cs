using Entity;
using Repository.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class LojaRepository : ILojaRepository
    {
        private readonly Contexto _context;
        private readonly ILogger _logger;

        public LojaRepository(Contexto context, ILogger<LojaRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Loja> Listar()
        {
            return _context.Loja.ToList();
        }

        public Loja Selecionar(int id)
        {
            return _context.Loja.FirstOrDefault(x => x.Id.Equals(id));
        }

        public Loja Selecionar(Guid token)
        {
            return _context.Loja.Include(a => a.LojaAdquirentes).FirstOrDefault(x => x.Token.Equals(token));
        }

        public bool Deletar(Loja loja)
        {
            bool retorno = false;
            try
            {
                _context.Loja.Remove(loja);
                _context.SaveChanges();
                retorno = true;
            }
            catch (Exception ex)
            {
                string mensagem = string.Format("Erro ao excluir loja: {0} - {1}", loja.Id, loja.Nome);
                _logger.LogError(mensagem, ex);
                throw;
            }

            return retorno;
        }

        public bool Alterar(Loja loja)
        {
            bool retorno = false;
            try
            {
                _context.Loja.Update(loja);
                _context.SaveChanges();
                retorno = true;
            }
            catch (Exception ex)
            {
                string mensagem = string.Format("Erro ao alterar loja: {0} - {1}", loja.Id, loja.Nome);
                _logger.LogError(mensagem , ex);
                throw;
            }

            return retorno;
        }

        public bool Salvar(Loja loja)
        {
            bool retorno = false;
            try
            {
                _context.Loja.Add(loja);
                _context.SaveChanges();
                retorno = true;
            }

            catch (Exception ex)
            {
                string mensagem = string.Format("Erro ao Incluir a loja: {0}", loja.Nome);
                _logger.LogError(mensagem, ex);
                throw;
            }

            return retorno;
        }
    }
}
