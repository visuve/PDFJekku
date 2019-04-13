using BitMiracle.Docotic.Pdf;
using CommandLine;
using System;
using System.IO;

namespace PDFJekku
{
    internal static class Program
    {
        internal class Options
        {
            [Option("js", Required = true, HelpText = "Path to JavaScript file")]
            public string JavaScript { get; set; }

            [Option("pdf", Required = false, HelpText = "Path to existing PDF file")]
            public string PdfFile { get; set; }

            [Option("out", Required = true, HelpText = "Output path for resulting PDF file")]
            public string Out { get; set; }
        }

        internal static void Run(Options opt)
        {
            using (var pdf = string.IsNullOrEmpty(opt.PdfFile) ? new PdfDocument() : new PdfDocument(opt.PdfFile))
            {
                string js = File.ReadAllText(opt.JavaScript);
                pdf.OnOpenDocument = pdf.CreateJavaScriptAction(js);
                pdf.Save(opt.Out);
            }
        }

        internal static void Main(string[] args)
        {
            try
            {
                Parser.Default.ParseArguments<Options>(args).WithParsed(Run);
            }
            catch (Exception e)
            {
                Console.WriteLine($"FUBAR {e.Message}: {e.StackTrace}");
            }
        }
    }
}