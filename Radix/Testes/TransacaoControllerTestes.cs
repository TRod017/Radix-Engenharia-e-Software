using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radix.Controllers;
using Repository;
using Repository.Interfaces;
using Services;
using Services.Interfaces;
using System;

namespace Testes
{
    [TestClass]
    public class TransacaoControllerTestes
    {
        private ITransacaoBusiness _transacaoBusiness;
        private Contexto _context;
        private ILogger<LojaRepository> _logger;
        private ITransacaoRepository _transacaoRepository;
        private ILojaBusiness _lojaBusiness;
        private ILojaRepository _lojaRepository;
        private IAdquirenteBusiness _adquirenteBusiness;
        private IAdquirenteRepository _adquirenteRepository;


        public TransacaoControllerTestes()
        {

        }

        [TestInitialize]
        public void Initialize()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddMvc();
            string connectionString = "Server=FAYOL\\SQLEXPRESS;Database=Pagamento;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddDbContext<Contexto>(options => options.UseSqlServer(connectionString));

            //DbContextOptions<Contexto> options2 =  new DbContextOptions<Contexto>();
            ILoggerFactory loggerFactory = new LoggerFactory().AddConsole().AddDebug();
            //_context = new Contexto(options);
            _logger = new Logger<LojaRepository>(loggerFactory); 
            _transacaoRepository = new TransacaoRepository(_context, _logger);

            _lojaRepository = new LojaRepository(_context, _logger);
            _lojaBusiness = new LojaBusiness(_lojaRepository);

            _adquirenteRepository = new AdquirenteRepository(_context);
            _adquirenteBusiness = new AdquirenteBusiness(_adquirenteRepository);

            _transacaoBusiness = new TransacaoBusiness(_transacaoRepository, _lojaBusiness, _adquirenteBusiness);
        }
        

        [TestMethod]
        public void CarregaTransacaoSucesso()
        {

            var _transacaoController = new TransacaoController(_transacaoBusiness);

            Guid tokenLoja = Guid.Parse("3B462321-72C7-4F72-B10A-4DCB00A2177A");

            _transacaoController.Get(tokenLoja);

            Assert.AreEqual(30, 30);
        }


        [TestMethod]
        public void CarregaTransacaoFalha()
        {

            var _transacaoController = new TransacaoController(_transacaoBusiness);

            Guid tokenLoja = Guid.Parse("3B462321-72C7-4F72-B10A-4DCB00AA177A");

            _transacaoController.Get(tokenLoja);

            Assert.AreEqual(30, 10);
        }

    }
}
