using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Drawing.Imaging;

public class PDFGenerator : IPDFGenerator
{
    public void GeneratePDF(List<Bitmap> slides, string outputPath)
    {
        LogMessage("Starting PDF generation with " + slides.Count + " slides.");

        PdfDocument document = new PdfDocument();

        foreach (var slide in slides)
        {
            PdfPage page = document.AddPage();
            page.Width = XUnit.FromMillimeter(slide.Width * 0.264583);
            page.Height = XUnit.FromMillimeter(slide.Height * 0.264583);

            using (MemoryStream ms = new MemoryStream())
            {
                slide.Save(ms, ImageFormat.Png);
                XImage xImage = XImage.FromStream(ms);

                XGraphics gfx = XGraphics.FromPdfPage(page);
                gfx.DrawImage(xImage, 0, 0, page.Width, page.Height);
            }
        }

        document.Save(outputPath);
        LogMessage("PDF generation completed. Saved at: " + outputPath);
    }

    private void LogMessage(string message)
    {
        Console.WriteLine("[PDFGenerator] " + message);
    }
}
