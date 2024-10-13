namespace SlideCapture;

public partial class MainForm : Form
{
    private readonly System.Windows.Forms.Timer _captureTimer;
    private readonly IScreenCapture _screenCapture;
    private readonly ISlideComparator _slideComparator;
    private readonly IPDFGenerator _pdfGenerator;
    private readonly List<Bitmap> _slides;
    private readonly Rectangle _captureRegion;
    private ToolTip buttonToolTip;

    public MainForm(IScreenCapture screenCapture, ISlideComparator slideComparator, IPDFGenerator pdfGenerator)
    {
        InitializeComponent();

        this.TopMost = true;
        _screenCapture = screenCapture;
        _slideComparator = slideComparator;
        _pdfGenerator = pdfGenerator;
        _slides = new List<Bitmap>();

        // capture region here
        _captureRegion = Screen.PrimaryScreen.Bounds;

        // capture timer
        _captureTimer = new System.Windows.Forms.Timer();
        _captureTimer.Interval = 5000; // Capture every 5 seconds
        _captureTimer.Tick += CaptureTimer_Tick;

        // ToolTips
        buttonToolTip = new ToolTip();
        AddToolTips();

        btnStop.Enabled = false;

        LogMessage("Application started. Ready to capture slides.");
    }

    // Tooltip
    private void AddToolTips()
    {
        buttonToolTip.SetToolTip(btnStart, "Start Slide Capture");
        buttonToolTip.SetToolTip(btnStop, "Stop Slide Capture");
        buttonToolTip.SetToolTip(btnGeneratePDF, "Generate PDF of Slides");
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

    // Log messages
    private void LogMessage(string message)
    {
        Console.WriteLine($"[MainForm] {message}");
    }

    // Start capturing
    private void btnStart_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Are you sure you want to start capturing slides?",
                                      "Confirm Start", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            LogMessage("Slide capturing started.");
            _captureTimer.Start();
            btnStop.Enabled = true;
            btnStart.Enabled = false;
        }
    }

    // Stop capturing
    private void btnStop_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Are you sure you want to stop capturing slides?",
                                      "Confirm Stop", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            LogMessage("Slide capturing stopped.");
            _captureTimer.Stop();

            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }

    // Generate PDF from captured slides
    private void btnGeneratePDF_Click(object sender, EventArgs e)
    {
        
        if (_slides.Count > 0)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = "LectureSlides.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputPath = saveFileDialog.FileName;

                    _pdfGenerator.GeneratePDF(_slides, outputPath);
                    MessageBox.Show("PDF Generated Successfully: " + outputPath,
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        else
        {
            MessageBox.Show("No slides captured. Please capture slides before generating the PDF.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
