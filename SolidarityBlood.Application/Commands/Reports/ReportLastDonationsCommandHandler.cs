using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.StyledXmlParser.Node;
using MediatR;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.Reports
{
    public class ReportLastDonationsCommandHandler : IRequestHandler<ReportLastDonationsCommand, Unit>
    {
        private readonly IReportRepository _reportRepository;
        public ReportLastDonationsCommandHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<Unit> Handle(ReportLastDonationsCommand request, CancellationToken cancellationToken)
        {
            var get = await _reportRepository.ReportLastDonation();

            //var list = get.Select(f => new ReportLastDonationsCommand(
            //    f.DonationId,
            //    f.DateDonation,
            //    f.QuantityMl,
            //    f.Status,
            //    f.DonorId,
            //    f.FullName,
            //    f.Email,
            //    f.Gender,
            //    f.BloodTypes,
            //    f.RHFactor
            //    ));

            // Passa o nome do arquivo e ainda me passa a pasta em que vai ser gerado o documento
            PdfWriter writer = new PdfWriter("C:\\Users\\eduar\\OneDrive\\Área de Trabalho\\Mentoria\\Projetos\\Relatórios de Projetos\\Doações dos últimos 30 dias.pdf");

            // Representação na memoria do documento PDF, ele vai abrir um documento PDF no modo de escrita
            PdfDocument pdf = new PdfDocument(writer);

            // Cria um documento a partir do PdfDocument na memória
            Document document = new Document(pdf);
            
            // adicionada essas margens no documento e assim foi possível colocar a tabela mais centralizada, sem deixar para mais um lado que o outro
            document.SetMargins(20, 20, 20, 20);

            // Cria um parágrafo mas no meu caso estou usando mais para criar um título
            Paragraph header = new Paragraph("Doações dos últimos 30 dias")
                .SetTextAlignment(TextAlignment.CENTER) // alinhamento do meu texto
                .SetFontSize(23); // tamanho da fonte do meu texto

            document.Add(header);

            // Separador de linha que eu botei pra dar uma quebra entre o nome do relatório e das tabelas
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);


            // Criando a tabela
            Table tabela = new Table(10, false);
            tabela.SetHorizontalAlignment(HorizontalAlignment.LEFT);

            // COLUNAS
            Cell cell1 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Id Doação"))
                .SetFontSize(9);

            Cell cell2 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Data Doação"))
                .SetFontSize(9);

            Cell cell3 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Quantidade ML"))
                .SetFontSize(9);

            Cell cell4 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Status"))
                .SetFontSize(9);

            Cell cell5 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Id Doador"))
                .SetFontSize(9);

            Cell cell6 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Nome"))
                .SetFontSize(9);

            Cell cell7 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Email"))
                .SetFontSize(9);

            Cell cell8 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Gênero"))
                .SetFontSize(9);

            Cell cell9 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Tipo Sanguíneo"))
                .SetFontSize(9);

            Cell cell10 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Fator RH"))
                .SetFontSize(9);

            // Adicionando as colunas
            tabela.AddCell(cell1);
            tabela.AddCell(cell2);
            tabela.AddCell(cell3);
            tabela.AddCell(cell4);
            tabela.AddCell(cell5);
            tabela.AddCell(cell6);
            tabela.AddCell(cell7);
            tabela.AddCell(cell8);
            tabela.AddCell(cell9);
            tabela.AddCell(cell10);


            // Adicionando os dados nas respectivas colunas
            foreach (var f in get)
            {
                tabela.AddCell(new Cell().Add(new Paragraph(f.Id.ToString()))).SetFontSize(9);
                tabela.AddCell(new Cell().Add(new Paragraph(f.DateDonation.ToString("dd/MM/yyyy")))).SetFontSize(9);
                tabela.AddCell(new Cell().Add(new Paragraph(f.QuantityMl.ToString()))).SetFontSize(9);
                tabela.AddCell(new Cell().Add(new Paragraph(f.Status.ToString()))).SetFontSize(9);
                tabela.AddCell(new Cell().Add(new Paragraph(f.DonorId.ToString()))).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
                tabela.AddCell(new Cell().Add(new Paragraph(f.FullName.ToString()))).SetFontSize(9);
                tabela.AddCell(new Cell().Add(new Paragraph(f.Email.ToString()))).SetFontSize(11);
                tabela.AddCell(new Cell().Add(new Paragraph(f.Gender.ToString()))).SetFontSize(9);
                tabela.AddCell(new Cell().Add(new Paragraph(f.BloodTypes.ToString()))).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
                tabela.AddCell(new Cell().Add(new Paragraph(f.RHFactor.ToString()))).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
            }


            //  Cria um espaço superior entre a tabela e o elemento anterior (a linha separadora)
            tabela.SetMarginTop(15);
            
            // Vai adicionar a minha tabela no relatório
            document.Add(tabela);

            // Numero de páginas
            int n = pdf.GetNumberOfPages();
            for (int i = 1; i <= n; i++)
            {
                document.ShowTextAligned(new Paragraph(String.Format("página " + i + " de " + n))
                    .SetFontSize(8),
                    559, 806, i, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            }


            // Fecha o meu Relatório
            document.Close();


            // Comando que abre o Relatório
            Process.Start(new ProcessStartInfo
            {
                FileName = "C:\\Users\\eduar\\OneDrive\\Área de Trabalho\\Mentoria\\Projetos\\Relatórios de Projetos\\Doações dos últimos 30 dias.pdf",
                UseShellExecute = true
            });

            return Unit.Value;
        }
    }
}