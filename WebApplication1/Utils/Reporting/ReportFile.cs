using Syncfusion.HtmlConverter;
using System;
using System.Collections.Generic;
using System.IO;
using Syncfusion.Pdf;
using WebApplication1.Models;
using WebApplication1.Utils.Enums;

namespace WebApplication1.Utils
{
    public class ReportFile : IDisposable
    {
        private string fileName;
        public string FilePath { get { return this.fileName; } }

        private ReportFormat reportFormat;

        public ReportFile(List<Stats> stats, ReportFormat format)
        {
            this.reportFormat = format;
            this.fileName = this.ReportFileName();            
            this.Save(stats);
        }

        private void Save(List<Stats> stats)
        {
            HtmlToPdfConverter htmlConverter = this.reportFormat == ReportFormat.PDF 
                ? new HtmlToPdfConverter(HtmlRenderingEngine.Blink) 
                : null;

            if(this.reportFormat == ReportFormat.PDF)
            {
                using (FileStream f = new FileStream($"{this.fileName}", FileMode.CreateNew, FileAccess.ReadWrite))
                {
                    PdfDocument pdf = htmlConverter.Convert(new HTMLReportBuilder(stats).GetHtml(), "");
                    pdf.Save(f);
                };
            }
            else
            {
                var f = File.Create(this.fileName);
                f.Close();
                File.WriteAllText(this.fileName, new HTMLReportBuilder(stats).GetHtml());
            }                
        }

        private string ReportFileName(int n = 0)
        {
            string extension = this.reportFormat == ReportFormat.PDF ? "pdf" : "html";

            return File.Exists($"ReportFile_{n}.{extension}")
                ? ReportFileName(n + 1)
                : $"ReportFile_{n}.{extension}";
        }

        public void Dispose()
        {
            File.Delete(this.fileName);
        }        
    }
}
