using Entity;
using Repository.Interfaces;
using System.Linq;


namespace Repository
{
    public class AdquirenteRepository : IAdquirenteRepository
    {
        private readonly Contexto _context;

        public AdquirenteRepository(Contexto context)
        {
            _context = context;
        }

        public Adquirente Selecionar(int id)
        {
            return _context.Adquirente.FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}
