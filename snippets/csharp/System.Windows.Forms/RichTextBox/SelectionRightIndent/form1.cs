using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace RTBRightSelectionIndentEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.RichTextBox richTextBox1;
      private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         this.richTextBox1 = new System.Windows.Forms.RichTextBox();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // richTextBox1
         // 
         this.richTextBox1.Location = new System.Drawing.Point(8, 8);
         this.richTextBox1.Name = "richTextBox1";
         this.richTextBox1.Size = new System.Drawing.Size(400, 168);
         this.richTextBox1.TabIndex = 0;
         this.richTextBox1.Text = "richTextBox1";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(312, 192);
         this.button1.Name = "button1";
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(416, 382);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button1,
                                                                      this.richTextBox1});
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);
      }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

      private void button1_Click(object sender, System.EventArgs e)
      {
         WriteIndentedTextToRichTextBox();
      }

		//<Snippet1>
		private void WriteIndentedTextToRichTextBox()
		{
			// Clear all text from the RichTextBox;
			richTextBox1.Clear();
		    // Specify a 20 pixel right indent in all paragraphs.
      	    richTextBox1.SelectionRightIndent = 20;
			// Set the font for the text.
			richTextBox1.Font = new Font("Lucinda Console", 12);
			// Set the text within the control.
			richTextBox1.SelectedText = "All text is indented 20 pixels from the right edge of the RichTextBox.";
			richTextBox1.SelectedText = "You can use this property with the SelectionIndent property to provide right and left margins.";
			richTextBox1.SelectedText = "After this paragraph the indentation will end.\n\n";
            // Remove all right indentation.
            richTextBox1.SelectionRightIndent = 0;
			richTextBox1.SelectedText = "This paragraph has no right indentation. All text should flow as normal.";
		}
		//</Snippet1>
	}
}
