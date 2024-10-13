using Tesseract;

public class SlideComparator : ISlideComparator
{
    private string _previousText = "";

    public bool IsDuplicate(Bitmap currentSlide)
    {
        string currentText = ExtractTextFromImage(currentSlide);

        if (currentText == _previousText)
        {
            LogMessage("Duplicate slide detected based on AI text recognition.");
            return true;
        }
        _previousText = currentText;
        return false;
    }

    private string ExtractTextFromImage(Bitmap image)
    {
        string tessdataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tessdata");
        using (var engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default))

        {
            using (var pix = ConvertBitmapToPix(image)) // Convert Bitmap to Pix
            {
                using (var page = engine.Process(pix))
                {
                    string extractedText = page.GetText();
                    LogMessage("Text extracted from the slide: " + extractedText);
                    return extractedText.Trim();
                }
            }
        }
    }

    private Pix ConvertBitmapToPix(Bitmap image)
    {
        using (var stream = new MemoryStream())
        {
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Png); // Save image as PNG
            stream.Position = 0; // Reset stream position to the beginning
            return Pix.LoadFromMemory(stream.ToArray()); // Load Pix from stream
        }
    }

    private void LogMessage(string message)
    {
        Console.WriteLine("[AI Comparator] " + message);
    }
}
