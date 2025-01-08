using MediatR;
using SolidarityBlood.Application.Commands.BloodStocks;
using SolidarityBlood.Infrastructure.Persistence;

namespace SolidarityBlood.API.Services
{
    public class StockCheckHostedService : IHostedService
    {
        // ILogger, nos permite retornar informações sobre execuções, erros e avisos do nosso sistema
        // O ILogger é uma API ou biblioteca presente no .NET onde podemos "escrever" mensagens durante a execução

        // O Timer é uma classe que prove um mecanismo que permite especificar uma frequencia de tempo em que uma determinada ação deve ser executada
        // O Timer também é uma classe que gera eventos em intervalos de tempo definidos pelo usuário, como por exemplo bloquear o computador após um periodo de tempo

        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IMediator _mediator;
        private readonly ILogger<StockCheckHostedService> _logger;
        private Timer _timer;

        public StockCheckHostedService(IMediator mediator, ILogger<StockCheckHostedService> logger, IServiceScopeFactory scopeFactory, IServiceScopeFactory serviceScopeFactory)
        {
            _mediator = mediator;
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer                             // 1 - cria uma instancia do Timer pra executar o ExecuteAsync
            ( 
                  async call => await ExecuteAsync()     // 2 - aqui é onde o método será chamado periodicamente, e onde a expressao lambda vai chamar o método em cada disparo
                , null                                  // 3 - vai passar um valor nulo para o estado inicial do método executado pelo timer
                , TimeSpan.FromSeconds(5)              // 4 - define o ATRASO INICIAL antes do primeiro disparo (5 segundos)
                , TimeSpan.FromSeconds(30)            // 5 - define o intervalo entre os disparos
             );                                         

            await Task.CompletedTask;              // 6 - método concluido
        }

        public Task StopAsync(CancellationToken cancellationToken) // o método é executado automaticamente quando o serviço é encerrado
        {
            return Task.CompletedTask;                             // o básico, finaliza o método
        }

        public async Task ExecuteAsync()
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var mediatrLife = scope.ServiceProvider.GetRequiredService<IMediator>();

                var command = new BloodStockCheckCommand();

                await mediatrLife.Send(command); 
            }

            //var command = new BloodStockCheckCommand();
            //await _mediator.Send(command);

            //disparos++;
            //_logger.LogCritical($"Olá, fui disparado pelo hosted service {disparos}");
        }


    }
}
