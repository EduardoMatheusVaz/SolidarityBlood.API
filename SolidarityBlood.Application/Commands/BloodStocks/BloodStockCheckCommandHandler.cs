using MailKit.Net.Smtp;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MimeKit;
using SolidarityBlood.Application.DTOs.BloodStocks;
using SolidarityBlood.Application.DTOs.Email;
using SolidarityBlood.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.BloodStocks
{
    public class BloodStockCheckCommandHandler : IRequestHandler<BloodStockCheckCommand, Unit>
    {
        // Para injetar o SmtpSettings corretamente tive que usar o IOptions, pois sem ele não estava conseguindo acessar os valores das propriedades,
        // nisso quando configurei certo consegui acessar os valores, bastou dar um  " .Value "  que passou

        private readonly IOptions<SmtpSettings> _appsettings;
        private readonly SolidarityBloodDbContext _dbContext;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public BloodStockCheckCommandHandler(SolidarityBloodDbContext dbContext, IOptions<SmtpSettings> appSettings, IServiceScopeFactory serviceScopeFactory)
        {
            _dbContext = dbContext;
            _appsettings = appSettings;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<Unit> Handle(BloodStockCheckCommand request, CancellationToken cancellationToken)
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var scopedLife = scope.ServiceProvider.GetRequiredService<SolidarityBloodDbContext>();

                var quantityMl = await scopedLife.Donation.Select(qm => qm.QuantityMl).SumAsync();
                //var quantitysMl = await _dbContext.Donation.Select(qm => qm.QuantityMl).SumAsync();
                // Anteriormente estava tendo erro por causa do dbContentex, entao passei a usar o meu scopedLife que configurei


                if (quantityMl < 10000)
                {
                    try
                    {
                        var message = new MimeMessage();

                        message.From.Add(new MailboxAddress(_appsettings.Value.Name, _appsettings.Value.UserName));
                        message.To.Add(new MailboxAddress("destino", _appsettings.Value.UserName));
                        message.Subject = ("!! Notificação do Estoque de Sangue !!");
                        message.Body = new TextPart("html")
                        {
                            Text = "Venho através deste email informar que o Estoque de Sangue segue abaixo do limite..." +
                            "\n \n \nCordialmente, Almofadinhas"
                        };


                        using (var client = new SmtpClient())
                        {
                            await client.ConnectAsync(_appsettings.Value.Host, _appsettings.Value.Porta, MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
                            client.AuthenticationMechanisms.Remove("XOAUTH2");
                            client.Authenticate(_appsettings.Value.UserName, "sua senha");

                            await client.SendAsync(message);
                            client.Disconnect(true);
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new InvalidOperationException(exception.Message);
                    }
                }


            }

            return Unit.Value;

        }
    }
}
