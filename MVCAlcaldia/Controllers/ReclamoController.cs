using BussinessLogic.Logic;
using CommonSolution.Constants;
using CommonSolution.DTOs;
using iText.Barcodes;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Pdf.Xobject;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAlcaldia.Controllers
{
    [AuthorizeAttribute]
    public class ReclamoController : Controller
    {
        public ActionResult List()
        {          

            return View();
        }

        [HttpPost]
        public ActionResult GetReclamosPorFechaYestado(DtoReclamo dto)
        {
            LReclamoController lgc = new LReclamoController();

            List<DtoReclamo> colDto = lgc.GetAllReclamosByFechaYestado(dto);
            
            return PartialView("_D_List", colDto);
        }
        public ActionResult ListAll()
        {
            LReclamoController lgc = new LReclamoController();

            List<DtoReclamo> colDto = lgc.GetAllReclamos(); 

            return View(colDto);
        }


        public ActionResult Modify(int id)
        {
            
            LReclamoController lgc = new LReclamoController();
            DtoReclamo dto = lgc.GetReclamoById(id);

            return View(dto);
        }

        [HttpPost]
        public ActionResult ModifyReclamo(DtoReclamo dto)
        {
            LReclamoController lgc = new LReclamoController();

            List<string> colErrors = lgc.ModifyReclamo(dto);

            return RedirectToAction("ListAll");
        }
        public ActionResult Details(int id)
        {
            LLogReclamoController lgc = new LLogReclamoController();

            List<DtoLogReclamo> colDto = lgc.GetLogReclamoById(id);

            return View(colDto);
        }
        public ActionResult CreatePdf(int id)
        {
            LReclamoController lgc = new LReclamoController();
            DtoReclamo dto = lgc.GetReclamoById(id);
            
            var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);
            // Must have write permissions to the path folder


            // Header
            Paragraph header = new Paragraph("Orden de trabajo")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20);

            // New line
            Paragraph newline = new Paragraph(new Text("\n"));

            document.Add(newline);
            document.Add(header);

            // Add sub-header
            Paragraph subheader = new Paragraph("Reclamo")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(15);
            document.Add(subheader);

            // Line separator
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);

            // Add paragraph1
            Paragraph paragraph1 = new Paragraph("Documento de uso interno, " +
                "orden de trabajo para cuadrillas.");
            document.Add(paragraph1);
            Paragraph paragraph3 = new Paragraph("Escanear código Qr para conocer ubicación exacta.");
            document.Add(paragraph3);
            var dirección = "https://maps.google.com/?q=" + dto.LatitudReclamo + "," + dto.LongitudReclamo;
            BarcodeQRCode qrCode = new BarcodeQRCode(dirección);
            PdfFormXObject barcodeObject = qrCode.CreateFormXObject(ColorConstants.BLACK, pdf);
            Image barcodeImage = new Image(barcodeObject).SetWidth(100f).SetHeight(100f);
            document.Add(new Paragraph().Add(barcodeImage));

            // Table
            Table table = new Table(2, false);
            Cell cell11 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Tipo: "+dto.nombreTipoReclamo));
            Cell cell12 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Fecha: "+ dto.fechaYhora));


            table.AddCell(cell11);
            table.AddCell(cell12);

            document.Add(newline);
            document.Add(table);

            Paragraph paragraph2 = new Paragraph("OBSERVACIÓN CIUDADANO: "+dto.observaciones);
            document.Add(paragraph2);

            // Hyper link
            Link link = new Link("click aquí",
               PdfAction.CreateURI("https://maps.google.com/?q=" + dto.LatitudReclamo + "," + dto.LongitudReclamo));
            Paragraph hyperLink = new Paragraph("Por favor ")
               .Add(link.SetBold().SetUnderline()
               .SetItalic().SetFontColor(ColorConstants.BLUE))
               .Add("Enlace a la dirección del reclamo");

            document.Add(newline);
            document.Add(hyperLink);

            // Page numbers
            int n = pdf.GetNumberOfPages();
            for (int i = 1; i <= n; i++)
            {
                document.ShowTextAligned(new Paragraph(String
                   .Format("page" + i + " of " + n)),
                   559, 806, i, TextAlignment.RIGHT,
                   VerticalAlignment.TOP, 0);
            }

            // Close document
            document.Close();

            byte[] bytesStream = stream.ToArray();
            stream = new MemoryStream();
            stream.Write(bytesStream, 0, bytesStream.Length);
            stream.Position = 0;


            return new FileStreamResult(stream, "aplicacion/pdf");
        }
    }
}