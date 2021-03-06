// This example demonstrates using the following members: 
// ComboBox.FindStringExact(string)
// ComboBox.FindStringExact(string, integer), 
// ComboBox.ObjectCollection.AddRange(),
// ComboBox.ObjectCollection.RemoveAt(), and ComboBox.MaxDropDownItems, 
// and TextBox.ReadOnly.

// CAUTION   This code exposes a known bug: If the index passed to the 
// FindStringExact(searchString, index) method is the last index of 
// the array,the code throws an exception.

//<snippet0>
using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form

{
	public Form1() : base()
	{        
		InitializeComboBox();
		InitializeTextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.SuspendLayout();
		this.Label1.Location = new System.Drawing.Point(8, 24);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(120, 32);
		this.Label1.TabIndex = 1;
		this.Label1.Text = "Use drop-down to choose a name:";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.Label1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);
	}

	public static void Main()
	{
		Application.Run(new Form1());
	}

	internal System.Windows.Forms.Label Label1;

	//<snippet3>

	// Declare and initialize the text box.
	// This text box text will be update programmatically. The user is not 
	// allowed to update it, so the ReadOnly property is set to true.
	internal System.Windows.Forms.TextBox TextBox1;

	private void InitializeTextBox()
	{
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.TextBox1.ScrollBars = ScrollBars.Vertical;
		this.TextBox1.Location = new System.Drawing.Point(64, 128);
		this.TextBox1.Multiline = true;
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.ReadOnly = true;
		this.TextBox1.Size = new System.Drawing.Size(184, 120);
		this.TextBox1.TabIndex = 4;
		this.TextBox1.Text = "Employee and Number of Awards:";
		this.Controls.Add(this.TextBox1);
	}
	//</snippet3>

	//<snippet1>
	// Declare comboBox1 as a ComboBox.
	internal System.Windows.Forms.ComboBox ComboBox1;
    
	// This method initializes the combo box, adding a large string array
	// but limiting the drop-down size to six rows so the combo box doesn't 
	// cover other controls when it expands.
	private void InitializeComboBox()
	{
		this.ComboBox1 = new System.Windows.Forms.ComboBox();
		string[] employees = new string[]{"Hamilton, David", "Hensien, Kari",
				"Hammond, Maria", "Harris, Keith", "Henshaw, Jeff D.", 
				"Hanson, Mark", "Harnpadoungsataya, Sariya", 
				"Harrington, Mark", "Harris, Keith", "Hartwig, Doris", 
				"Harui, Roger", "Hassall, Mark", "Hasselberg, Jonas", 
				"Harnpadoungsataya, Sariya", "Henshaw, Jeff D.", 
				"Henshaw, Jeff D.", "Hensien, Kari", "Harris, Keith", 
				"Henshaw, Jeff D.", "Hensien, Kari", "Hasselberg, Jonas",
				"Harrington, Mark", "Hedlund, Magnus", "Hay, Jeff", 
				"Heidepriem, Brandon D."};

		ComboBox1.Items.AddRange(employees);
		this.ComboBox1.Location = new System.Drawing.Point(136, 32);
        this.ComboBox1.IntegralHeight = false;
        this.ComboBox1.MaxDropDownItems = 5;
		this.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
		this.ComboBox1.Name = "ComboBox1";
		this.ComboBox1.Size = new System.Drawing.Size(136, 81);
		this.ComboBox1.TabIndex = 0;
		this.Controls.Add(this.ComboBox1);
		
		// Associate the event-handling method with the 
		// SelectedIndexChanged event.
		this.ComboBox1.SelectedIndexChanged += 
			new System.EventHandler(ComboBox1_SelectedIndexChanged);
	}
	//</snippet1>

	//<snippet2>
	// This method is called when the user changes his or her selection.
	// It searches for all occurrences of the selected employee's
	// name in the Items array and adds the employee's name and 
	// the number of occurrences to TextBox1.Text.

	// CAUTION   This code exposes a known bug: If the index passed to the 
	// FindStringExact(searchString, index) method is the last index 
	// of the array, the code throws an exception.
	private void ComboBox1_SelectedIndexChanged(object sender, 
		System.EventArgs e)
	{

		ComboBox comboBox = (ComboBox) sender;

		// Save the selected employee's name, because we will remove
		// the employee's name from the list.
		string selectedEmployee = (string) ComboBox1.SelectedItem;

		int count = 0;
		int resultIndex = -1;

		// Call the FindStringExact method to find the first 
		// occurrence in the list.
		resultIndex = ComboBox1.FindStringExact(selectedEmployee);

		// Remove the name as it is found, and increment the found count. 
		// Then call the FindStringExact method again, passing in the 
		// index of the current found item so the search starts there 
		// instead of at the beginning of the list.
		while (resultIndex!=-1)
		{
			ComboBox1.Items.RemoveAt(resultIndex);
			count += 1;
			resultIndex = ComboBox1.FindStringExact(selectedEmployee, 
				resultIndex);
		}
		// Update the text in Textbox1.
		TextBox1.Text = TextBox1.Text+ "\r\n" + selectedEmployee + ": "
			+ count;
	}
	//</snippet2>
}
//</snippet0>
