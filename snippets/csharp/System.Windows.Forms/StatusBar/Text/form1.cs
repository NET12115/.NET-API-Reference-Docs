using System.Windows.Forms;
using System.Drawing;

public class Form1:
	System.Windows.Forms.Form

{
	#region " Windows Form Designer generated code "

	public Form1() : base()
	{        

		//This call is required by the Windows Form Designer.
		InitializeStatusBarPanels();
		InitializeSimpleStatusBar();

		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
	}

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (components != null)
			{
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	//Required by the Windows Form Designer
	private System.ComponentModel.IContainer components;

	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{

		this.SuspendLayout();
        
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);

		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);
	}

	#endregion
	//<snippet1>
	// Initialize a single-panel status bar.  This is done
	// by setting the Text property and setting ShowPanels to False.

	private void InitializeSimpleStatusBar()
	{

		// Declare the StatusBar control
		StatusBar simpleStatusBar = new StatusBar();

		// Set the ShowPanels property to False.
		simpleStatusBar.ShowPanels = false;

		// Set the text.
		simpleStatusBar.Text = "This is a single-panel status bar";

		// Set the width and anchor the StatusBar
		simpleStatusBar.Width = 200;
		simpleStatusBar.Anchor = AnchorStyles.Top;

		// Add the StatusBar to the form.
		this.Controls.Add(simpleStatusBar);
	}
	//</snippet1>
	//<snippet2>
	private StatusBar StatusBar1;

	private void InitializeStatusBarPanels()
	{
		StatusBar1 = new StatusBar();

		// Create two StatusBarPanel objects.
		StatusBarPanel panel1 = new StatusBarPanel();
		StatusBarPanel panel2 = new StatusBarPanel();

		// Set the style of the panels.  
		// panel1 will be owner-drawn.
		panel1.Style = StatusBarPanelStyle.OwnerDraw;

		// The panel2 object will be drawn by the operating system.
		panel2.Style = StatusBarPanelStyle.Text;

		// Set the text of both panels to the same date string.
		panel1.Text = System.DateTime.Today.ToShortDateString();
		panel2.Text = System.DateTime.Today.ToShortDateString();

		// Add both panels to the StatusBar.
		StatusBar1.Panels.Add(panel1);
		StatusBar1.Panels.Add(panel2);

		// Make panels visible by setting the ShowPanels 
		// property to True.
		StatusBar1.ShowPanels = true;

		// Associate the event-handling method with the DrawItem event 
		// for the owner-drawn panel.
		StatusBar1.DrawItem += 
			new StatusBarDrawItemEventHandler(DrawCustomStatusBarPanel);
            
		this.Controls.Add(StatusBar1);
	}

	// Draw the panel.
	private void DrawCustomStatusBarPanel(object sender, 
		StatusBarDrawItemEventArgs e)
	{

		// Draw a blue background in the owner-drawn panel.
		e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds);

		// Create a StringFormat object to align text in the panel.
		StringFormat textFormat = new StringFormat();

		// Center the text in the middle of the line.
		textFormat.LineAlignment = StringAlignment.Center;

		// Align the text to the left.
		textFormat.Alignment = StringAlignment.Far;

		// Draw the panel's text in dark blue using the Panel 
		// and Bounds properties of the StatusBarEventArgs object 
		// and the StringFormat object.
		e.Graphics.DrawString(e.Panel.Text, StatusBar1.Font, 
			Brushes.DarkBlue, new RectangleF(e.Bounds.X, 
			e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), textFormat);
	}
	//</snippet2>

	public static void Main()
	{
		Application.Run(new Form1());
	}
}
