using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SlideCapture
{
    public partial class MainForm : Form
    {
        private readonly System.Windows.Forms.Timer _captureTimer;
        private readonly IScreenCapture _screenCapture;
        private readonly ISlideComparator _slideComparator;
        private readonly IPDFGenerator _pdfGenerator;
        private readonly List<Bitmap> _slides;
        private readonly Rectangle _captureRegion;

        // Inject dependencies through the constructor
        public MainForm(IScreenCapture screenCapture, ISlideComparator slideComparator, IPDFGenerator pdfGenerator)
        {
            InitializeComponent();

            _screenCapture = screenCapture;
            _slideComparator = slideComparator;
            _pdfGenerator = pdfGenerator;
            _slides = new List<Bitmap>();

            // Define capture region here
            _captureRegion = Screen.PrimaryScreen.Bounds; // Adjust based on Zoom meeting area

            // Set up the capture timer
            _captureTimer = new System.Windows.Forms.Timer();
            _captureTimer.Interval = 5000; // Capture every 5 seconds
            _captureTimer.Tick += CaptureTimer_Tick;

            LogMessage("Application started. Ready to capture slides.");
        }

        // Capture and compare slides
        private void CaptureTimer_Tick(object sender, EventArgs e)
        {
            Bitmap currentSlide = _screenCapture.CaptureRegion(_captureRegion);

            if (!_slideComparator.IsDuplicate(currentSlide))
            {
                _slides.Add(currentSlide);
                LogMessage($"New slide captured. Total slides: {_slides.Count}");
            }
            else
            {
                LogMessage("Duplicate slide detected. Skipping capture.");
            }
        }

        // Log messages to console (or UI if needed)
        private void LogMessage(string message)
        {
            Console.WriteLine($"[MainForm] {message}");
        }

        // Start slide capturing
        private void btnStart_Click(object sender, EventArgs e)
        {
            LogMessage("Slide capturing started.");
            _captureTimer.Start();
        }

        // Stop slide capturing
        private void btnStop_Click(object sender, EventArgs e)
        {
            LogMessage("Slide capturing stopped.");
            _captureTimer.Stop();
        }

        // Generate PDF from captured slides
        private void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            // Get the Downloads folder path
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

            // Base file name
            string baseFileName = "LectureSlides.pdf";

            // Full file path
            string outputPath = Path.Combine(downloadsPath, baseFileName);

            // Check if file exists, and append a timestamp if it does
            if (File.Exists(outputPath))
            {
                // Create a unique filename with timestamp to avoid overwriting
                string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                outputPath = Path.Combine(downloadsPath, $"LectureSlides_{timeStamp}.pdf");
            }

            // Generate the PDF
            _pdfGenerator.GeneratePDF(_slides, outputPath);
            MessageBox.Show("PDF Generated Successfully: " + outputPath);
        }
    }
}
