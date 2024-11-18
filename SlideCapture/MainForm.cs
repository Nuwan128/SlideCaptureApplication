using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace SlideCapture;

public partial class MainForm : Form
{
	// Time tracking for slide capture
	private int seconds = 0;
	private int minutes = 0;

	// Timers for slide capture and application events
	private readonly System.Windows.Forms.Timer _captureTimer;
	private readonly System.Windows.Forms.Timer _appTimer;

	// Services for screen capture, slide comparison, and PDF generation
	private readonly IScreenCapture _screenCapture;
	private readonly ISlideComparator _slideComparator;
	private readonly IPDFGenerator _pdfGenerator;

	// List of captured slides and the capture region
	private readonly List<Bitmap> _slides;
	private readonly Rectangle _captureRegion;

	// ToolTip for buttons
	private ToolTip buttonToolTip;

	// Constants for window style (shadow effect)
	private const int CS_DROPSHADOW = 0x00020000;

	// External Win32 API for window style manipulation
	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int SetClassLong(IntPtr hWnd, int nIndex, int dwNewLong);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int GetClassLong(IntPtr hWnd, int nIndex);

	// Constructor initializing necessary services and setting up timers
	public MainForm(IScreenCapture screenCapture, ISlideComparator slideComparator, IPDFGenerator pdfGenerator)
	{
		InitializeComponent();
		ApplyShadow();  // Apply window shadow effect
		this.TopMost = true;  // Keep the form always on top
		this.FormBorderStyle = FormBorderStyle.None; // Remove default borders

		_screenCapture = screenCapture;
		_slideComparator = slideComparator;
		_pdfGenerator = pdfGenerator;

		_slides = new List<Bitmap>();
		_captureRegion = Screen.PrimaryScreen.Bounds; // Define capture region to cover the entire screen

		// Initialize timers
		_captureTimer = new System.Windows.Forms.Timer { Interval = 5000 }; // Capture every 5 seconds
		_captureTimer.Tick += CaptureTimer_Tick;

		_appTimer = new System.Windows.Forms.Timer { Interval = 1000 }; // 1-second interval for app timer
		_appTimer.Tick += AppTimer_Tick; // Update time every second

		// Initialize Tooltips for buttons
		buttonToolTip = new ToolTip();
		AddToolTips();

		btnStop.Enabled = false; // Disable Stop button initially

		LogMessage("Application started. Ready to capture slides.");
	}

	// Timer to update the elapsed time displayed on the form
	private void AppTimer_Tick(object? sender, EventArgs e)
	{
		seconds++;
		if (seconds >= 60)
		{
			seconds = 0;
			minutes++;
		}

		TimeLabel.Text = $"{minutes:00}:{seconds:00}";
	}

	// Apply shadow effect to the form
	private void ApplyShadow()
	{
		int classStyle = GetClassLong(this.Handle, -200);
		SetClassLong(this.Handle, -200, classStyle | CS_DROPSHADOW);
	}

	// Set rounded corners for the form's border
	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);

		int borderRadius = 5;
		GraphicsPath path = new GraphicsPath();

		// Add rounded corners to the form
		path.AddArc(new Rectangle(0, 0, borderRadius * 2, borderRadius * 2), 180, 90);
		path.AddArc(new Rectangle(this.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2), 270, 90);
		path.AddArc(new Rectangle(this.Width - borderRadius * 2, this.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2), 0, 90);
		path.AddArc(new Rectangle(0, this.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2), 90, 90);

		path.CloseAllFigures();

		this.Region = new Region(path);
	}

	// Add Tooltips to buttons
	private void AddToolTips()
	{
		buttonToolTip.SetToolTip(btnStart, "Start Slide Capture");
		buttonToolTip.SetToolTip(btnStop, "Stop Slide Capture");
		buttonToolTip.SetToolTip(btnGeneratePDF, "Generate PDF of Slides");
	}

	// Timer that captures the screen and compares slides
	private void CaptureTimer_Tick(object sender, EventArgs e)
	{
		Bitmap currentSlide = _screenCapture.CaptureRegion(_captureRegion);

		if (!_slideComparator.IsDuplicate(currentSlide)) // Check if the slide is new
		{
			_slides.Add(currentSlide); // Add the slide to the list
			SlideCountLabel.Text = $"Slide Captured : {_slides.Count:00}";
			LogMessage($"New slide captured. Total slides: {_slides.Count}");
		}
		else
		{
			LogMessage("Duplicate slide detected. Skipping capture.");
		}
	}

	// Log messages to the console (for debugging or tracking)
	private void LogMessage(string message)
	{
		Console.WriteLine($"[MainForm] {message}");
	}

	// Start capturing slides on button click
	private void btnStart_Click(object sender, EventArgs e)
	{
		var result = MessageBox.Show("Are you sure you want to start capturing slides?", "Confirm Start", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

		if (result == DialogResult.Yes)
		{
			_appTimer.Start();
			_captureTimer.Start();
			btnStop.Enabled = true;
			btnStart.Enabled = false;
			LogMessage("Slide capturing started.");
		}
	}

	// Stop capturing slides on button click
	private void btnStop_Click(object sender, EventArgs e)
	{
		var result = MessageBox.Show("Are you sure you want to stop capturing slides?", "Confirm Stop", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

		if (result == DialogResult.Yes)
		{
			_appTimer.Stop();
			_captureTimer.Stop();
			btnStart.Enabled = true;
			btnStop.Enabled = false;
			LogMessage("Slide capturing stopped.");
		}
	}

	// Generate a PDF from captured slides
	private void btnGeneratePDF_Click(object sender, EventArgs e)
	{
		if (_slides.Count > 0) // Ensure there are slides to generate a PDF
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
				saveFileDialog.Title = "Save PDF File";
				saveFileDialog.FileName = "LectureSlides.pdf";

				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					string outputPath = saveFileDialog.FileName;
					_pdfGenerator.GeneratePDF(_slides, outputPath); // Generate the PDF
					MessageBox.Show("PDF Generated Successfully: " + outputPath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					_slides.Clear(); // Clear slides after PDF generation
					LogMessage("Slides cleared after PDF generation.");
				}
			}
		}
		else
		{
			MessageBox.Show("No slides captured. Please capture slides before generating the PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	// Minimize the application window
	private void btnMinimize_Click(object sender, EventArgs e)
	{
		this.WindowState = FormWindowState.Minimized;
	}

	// Close the application window
	private void btnClose_Click(object sender, EventArgs e)
	{
		this.Close();
	}
}
