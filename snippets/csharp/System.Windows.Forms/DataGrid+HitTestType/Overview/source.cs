using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
// <Snippet1>
private void dataGrid1_MouseDown
(object sender, System.Windows.Forms.MouseEventArgs e)
{
   string newLine = "\n";
   Console.WriteLine(newLine);
   System.Windows.Forms.DataGrid.HitTestInfo myHitTest;
   // Use the DataGrid control's HitTest method with the x and y properties.
   myHitTest = dataGrid1.HitTest(e.X,e.Y);
   Console.WriteLine(myHitTest);
   Console.WriteLine("Column " + myHitTest.Column);
   Console.WriteLine("Row " + myHitTest.Row);
   Console.WriteLine("Type " + myHitTest.Type);
   Console.WriteLine("ToString " + myHitTest.ToString());
   Console.WriteLine("Hit " + ReturnHitTest(myHitTest.Type ));
}
 
 private string ReturnHitTest(System.Windows.Forms.DataGrid.HitTestType  hit ){
    // Use this function to return the part of the grid clicked.   
    switch(hit) {
    case(System.Windows.Forms.DataGrid.HitTestType.Cell):
       return "Cell";

    case(System.Windows.Forms.DataGrid.HitTestType.Caption):
       return "Caption";
       
    case(System.Windows.Forms.DataGrid.HitTestType.ColumnHeader):
        return "ColumnHeader";
          
    case(System.Windows.Forms.DataGrid.HitTestType.ColumnResize):
       return "Resize";
          
    case(System.Windows.Forms.DataGrid.HitTestType.ParentRows):
       return "ParentRows";
          
    case(System.Windows.Forms.DataGrid.HitTestType.RowHeader):
       return "RowHeader";
          
    case(System.Windows.Forms.DataGrid.HitTestType.RowResize):
       return "RowResize";
          
    case(System.Windows.Forms.DataGrid.HitTestType.None):
       return "None";
    default:return "Unknown";
    }
 }

// </Snippet1>
}
