' <Snippet1>
Imports System.IO
Imports System.Text
Imports System.Xml.Serialization


' This is the class that will be serialized.
Public Class OrderedItem
    Public ItemName As String
    Public Description As String
    Public UnitPrice As Decimal
    Public Quantity As Integer
    Public LineTotal As Decimal
    
    'A custom method used to calculate price per item.
    Public Sub Calculate()
        LineTotal = UnitPrice * Quantity
    End Sub
End Class


Public Class Test
    
    Public Shared Sub Main()
        Dim t As New Test()
        ' Write a purchase order.
        t.SerializeObject("simple.xml")
    End Sub
    
    Private Sub SerializeObject(ByVal filename As String)
        Console.WriteLine("Writing With TextWriter")
        
        Dim serializer As New XmlSerializer(GetType(OrderedItem))
        Dim i As New OrderedItem()

        With i
            .ItemName = "Widget"
            .Description = "Regular Widget"
            .Quantity = 10
            .UnitPrice = CDec(2.3)
            .Calculate()
        End With
        
        ' Create a StreamWriter to write with. First create a FileStream
        ' object, and create the StreamWriter specifying an Encoding to use. 
        Dim fs As New FileStream(filename, FileMode.Create)
        Dim writer As New StreamWriter(fs, New UTF8Encoding())
        ' Serialize using the XmlTextWriter.
        serializer.Serialize(writer, i)
        writer.Close()
    End Sub
End Class

' </Snippet1>
