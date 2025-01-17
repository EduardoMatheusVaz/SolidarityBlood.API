using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
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
    public class ReportStockCheckCommandHandler : IRequestHandler<ReportStockCheckCommand, Unit>
    {
        private readonly IReportRepository _reportRepository;

        public ReportStockCheckCommandHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<Unit> Handle(ReportStockCheckCommand request, CancellationToken cancellationToken)
        {
            var getList = await _reportRepository.ReportStockCheck();


            // Passa o nome do arquivo e ainda me passa a pasta em que vai ser gerado o documento
            PdfWriter writer = new PdfWriter("C:\\Users\\eduar\\OneDrive\\Área de Trabalho\\Mentoria\\Projetos\\Relatórios de Projetos\\Relatório de Estoque de Sangue por Tipo.pdf");


            // Representação na memoria do documento PDF, ele vai abrir um documento PDF no modo de escrita
            PdfDocument pdf = new PdfDocument(writer);


            // Cria um documento a partir do PDF na memória
            Document document = new Document(pdf);


            // Cria um parágrafo mas no meu caso estou usando mais para criar um título
            Paragraph header = new Paragraph("Estoque de Sangue por Tipo")
                .SetTextAlignment(TextAlignment.CENTER)  // alinhamento do meu texto
                .SetFontSize(23)  // tamanho da fonte do meu texto
                .SetMarginBottom(15);
            // Adiciona o cabeçalho ao documento
            document.Add(header);


            // Separador de linha que eu botei pra dar uma quebra entre o nome do relatório e das tabelas
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);


            // Criando a tabela do Relatório
            Table table = new Table(5, false);
            table.SetHorizontalAlignment(HorizontalAlignment.CENTER);


            // COLUNAS
            Cell cell1 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Id"))
                .SetFontSize(11);

            Cell cell2 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Tipo Sanguíneo"))
                .SetFontSize(11);

            Cell cell3 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Fator RH"))
                .SetFontSize(11);

            Cell cell4 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Quantidade em Ml"))
                .SetFontSize(11);

            Cell cell5 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Status"))
                .SetFontSize(11);


            // Adicionando as tabelas
            table.AddCell(cell1);
            table.AddCell(cell2);
            table.AddCell(cell3);
            table.AddCell(cell4);
            table.AddCell(cell5);


            // Adicionando os dados nas respectivas tabelas

            foreach (var gl in getList)
            {
                table.AddCell(new Cell().Add(new Paragraph(gl.Id.ToString()))).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(new Cell().Add(new Paragraph(gl.BloodType.ToString()))).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(new Cell().Add(new Paragraph(gl.RHFactor.ToString()))).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(new Cell().Add(new Paragraph(gl.QuantityMl.ToString()))).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(new Cell().Add(new Paragraph(gl.Status.ToString()))).SetFontSize(9);
            }


            // Aqui vai criar um espaço superior entre a tabela e o elemento anterior (a linha separadora)
            table.SetMarginTop(30);

            // Vai adicionar a minha tabela no relatório
            document.Add(table);


            // Numero de páginas
            int n = pdf.GetNumberOfPages();
            for (int i = 1; i <= n; i++)
            {
                document.ShowTextAligned(new Paragraph(String.Format("página " + i + " de " + n))
                    .SetFontSize(8),
                    559, 806, i, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            }


            // Fecha o documento
            document.Close();


            // Comando que abre o documento
            Process.Start(new ProcessStartInfo
            {
                FileName = "C:\\Users\\eduar\\OneDrive\\Área de Trabalho\\Mentoria\\Projetos\\Relatórios de Projetos\\Relatório de Estoque de Sangue por Tipo.pdf",
                UseShellExecute = true
            });

            return Unit.Value;

        }
    }
}
