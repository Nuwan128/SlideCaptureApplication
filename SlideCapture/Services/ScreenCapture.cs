using System.Drawing.Imaging;

public class ScreenCapture : IScreenCapture
{
    public Bitmap CaptureRegion(Rectangle region)
    {
        LogMessage("Starting screen capture for region: " + region.ToString());
        Bitmap bmp = new Bitmap(region.Width, region.Height, PixelFormat.Format32bppArgb);

        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.CopyFromScreen(region.Left, region.Top, 0, 0, region.Size, CopyPixelOperation.SourceCopy);
        }

        LogMessage("Screen capture completed.");
        return bmp;
    }

    private void LogMessage(string message)
    {
        Console.WriteLine("[ScreenCapture] " + message);
    }
}
