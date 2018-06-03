using Entity;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class LojaBusiness : ILojaBusiness
    {
        private ILojaRepository _LojaRepository;

        public LojaBusiness(ILojaRepository LojaRepository)
        {
            _LojaRepository = LojaRepository;
        }

        public IEnumerable<Loja> Listar()
        {
            return _LojaRepository.Listar();
        }

        public Loja Selecionar(int id)
        {
            return _LojaRepository.Selecionar(id);
        }

        public Loja Selecionar(Guid token)
        {
            return _LojaRepository.Selecionar(token);
        }

        public bool Deletar(int id)
        {
            Loja loja = this.Selecionar(id);

            return _LojaRepository.Deletar(loja);
        }

        public bool Alterar()
        { return false; }

        public bool Salvar(Loja loja)
        {
            return _LojaRepository.Salvar(loja);
        }
    }
}
