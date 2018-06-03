using Entity;
using Repository;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class AdquirenteBusiness : IAdquirenteBusiness
    {
        private IAdquirenteRepository _adquirenteRepository;

        public AdquirenteBusiness(IAdquirenteRepository adquirenteRepository)
        {
            _adquirenteRepository = adquirenteRepository;
        }

        public Adquirente Selecionar(int id)
        {
            return _adquirenteRepository.Selecionar(id);
        }
    }
}
