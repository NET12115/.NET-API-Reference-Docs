using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GetDataPresent2
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox textBox1;
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
            GetDataPresent2() ;

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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "textBox1";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(292, 276);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.textBox1});
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        // <snippet1>
        private void GetDataPresent2() 
        {
            // Creates a component to store in the data object.
            Component myComponent = new Component();

            // Creates a new data object and assigns it the component.
            DataObject myDataObject = new DataObject(myComponent);
 
            // Creates a type to store the type of data.
            Type myType = myComponent.GetType();
 
            // Checks whether the specified data type exists in the object.
            if (myDataObject.GetDataPresent(myType))
            {
                MessageBox.Show("The specified data is stored in the data object.");
                // Displays the type of data.
                textBox1.Text = "The data type is " + myDataObject.GetData(myType).GetType().Name + ".";
            }
            else
            {
                MessageBox.Show("The specified data is not stored in the data object.");
            }
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
