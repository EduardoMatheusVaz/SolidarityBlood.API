using MediatR;
using SolidarityBlood.Application.Commands.BloodStocks;

namespace SolidarityBlood.API.Services
{
    public class StockCheckHostedService : IHostedService, IDisposable
    {
        // ILogger, nos permite retornar informações sobre execuções, erros e avisos do nosso sistema
        // O ILogger é uma API ou biblioteca presente no .NET onde podemos "escrever" mensagens durante a execução

        // O Timer é uma classe que prove um mecanismo que permite especificar uma frequencia de tempo em que uma determinada ação deve ser executada
        // O Timer também é uma classe que gera eventos em intervalos de tempo definidos pelo usuário, como por exemplo bloquear o computador após um periodo de tempo

        private readonly IMediator _mediator;
        private readonly ILogger<StockCheckHostedService> _logger;
        private Timer _timer;
        int disparos;

        public StockCheckHostedService(IMediator mediator, ILogger<StockCheckHostedService> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            
            _timer = new Timer              // 1 - cria uma instancia do Timer pra executar o ExecuteAsync
            (
                call => ExecuteAsync()      // 2 - aqui é onde o método será chamado periodicamente, e onde a expressao lambda vai chamar o método em cada disparo
                , null                      // 3 - vai passar um valor nulo para o estado inicial do método executado pelo timer
                , TimeSpan.FromSeconds(5)   // 4 - define o ATRASO INICIAL antes do primeiro disparo (5 segundos)
                , TimeSpan.FromSeconds(4)   // 5 - define o intervalo entre os disparos
             );

            return Task.CompletedTask;      // 6 - método concluido
        }

        public Task StopAsync(CancellationToken cancellationToken) // o método é executado automaticamente quando o serviço é encerrado
        {
            return Task.CompletedTask;                             // o básico, finaliza o método
        }

        public async Task ExecuteAsync()
        {
            var command = new BloodStockCheckCommand();
            await _mediator.Send(command);

            disparos++;  // vai incrementar o valor toda vez que o método for disparado
            _logger.LogCritical($"Olá, fui disparado pelo hosted service {disparos}");
        }

    }
}
