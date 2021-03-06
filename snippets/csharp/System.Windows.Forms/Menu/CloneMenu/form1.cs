using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CloneMenu_CS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
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
			CloneMyMainMenu();		}

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
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 276);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		// <snippet1>
		private void CloneMyMainMenu()
		{
			// Create the main menu.
			MainMenu mainMenu1 = new MainMenu();

			// Create the menu items to add.
			MenuItem menuItem1 = new MenuItem();
			MenuItem menuItem2 = new MenuItem();
			MenuItem menuItem3 = new MenuItem();
   
			// Set the caption for the menu items.
			menuItem1.Text = "File";
			menuItem2.Text = "Edit";
			menuItem3.Text = "View";

			// Add the menu item to mainMenu1.
			mainMenu1.MenuItems.Add(menuItem1);
			mainMenu1.MenuItems.Add(menuItem2);
			mainMenu1.MenuItems.Add(menuItem3);

			// Clone the mainMenu1 and name it mainMenu2.
			MainMenu mainMenu2 = mainMenu1.CloneMenu();
			
			// Assign mainMenu2 to the form.
			Menu = mainMenu2;
		}
		// </snippet1>

		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		}
	}
}
