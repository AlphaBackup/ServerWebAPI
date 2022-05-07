using System;
using System.Collections.Generic;
using System.IO;
using WebApplication1.Models;

namespace WebApplication1.Utils
{
    public class ReportFile : IDisposable
    {
        private string fileName;
        public string FilePath { get { return this.fileName; } }

        public ReportFile(List<Stats> stats)
        {
            this.fileName = this.ReportFileName();

            //Creating a html file with passed stats
            var f = File.Create(this.fileName);
            f.Close();
            File.WriteAllText(this.fileName, new HTMLReportBuilder(stats).GetHtml());
        }

        public void Dispose()
        {
            File.Delete(this.fileName);
        }

        private string ReportFileName(int n = 0)
        {
            return File.Exists($"ReportFile_{n}.html")
                ? ReportFileName(n + 1)
                : $"ReportFile_{n}.html";
        }
    }
}
