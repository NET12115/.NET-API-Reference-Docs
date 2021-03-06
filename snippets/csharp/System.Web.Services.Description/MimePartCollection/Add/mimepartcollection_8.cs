// System.Web.Services.Description.MimePartCollection.MimePartCollection()
// System.Web.Services.Description.MimePartCollection.Item[System.Int32 index]
// System.Web.Services.Description.MimePartCollection.Insert
// System.Web.Services.Description.MimePartCollection.IndexOf
// System.Web.Services.Description.MimePartCollection.Add
// System.Web.Services.Description.MimePartCollection.Contains
// System.Web.Services.Description.MimePartCollection.CopyTo
// System.Web.Services.Description.MimePartCollection.Remove

/* This program demonstrates constructor, 'Item' property ,'Insert','IndexOf','Add',
   'Contains','CopyTo',and 'Remove' methods of 'MimePartCollection' class.
   It takes 'MimePartCollection_8_Input_cs.wsdl' as an input file which contains
   one 'MimePart' object that supports 'HttpPost'. A mimepartcollection object is
   created and new mimepart objects are added to mimepartcollection using 'Insert'
   and 'Add' methods. A mimepart object is removed from the mimepartcollection using
   'Remove' method. The ServiceDescription is finally written into output wsdl file
   'MimePartCollection_8_out_CS.wsdl'.
*/

using System;
using System.Collections;
using System.Xml;
using System.Web.Services.Description;

public class MyMimePartCollection
{
   public static void Main()
   {
      ServiceDescription myServiceDescription =
         ServiceDescription.Read("MimePartCollection_8_Input_cs.wsdl");
      ServiceDescriptionCollection myServiceDescriptionCol =
         new ServiceDescriptionCollection();
      myServiceDescriptionCol.Add(myServiceDescription);
      XmlQualifiedName myXmlQualifiedName =
             new XmlQualifiedName("MimeServiceHttpPost","http://tempuri.org/");
      // Create a binding object.
      Binding myBinding = myServiceDescriptionCol.GetBinding(myXmlQualifiedName);
      OperationBinding myOperationBinding= null;
      for(int i=0; i<myBinding.Operations.Count; i++)
      {
         if(myBinding.Operations[i].Name.Equals("AddNumbers"))
         {
            myOperationBinding =myBinding.Operations[i];
         }
      }
      OutputBinding myOutputBinding = myOperationBinding.Output;
// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>
      MimeMultipartRelatedBinding myMimeMultipartRelatedBinding = null;
      IEnumerator myIEnumerator = myOutputBinding.Extensions.GetEnumerator();
      while(myIEnumerator.MoveNext())
      {
         myMimeMultipartRelatedBinding=(MimeMultipartRelatedBinding)myIEnumerator.Current;
      }
      // Create an instance of 'MimePartCollection'.
      MimePartCollection myMimePartCollection = new MimePartCollection();
      myMimePartCollection= myMimeMultipartRelatedBinding.Parts;
      Console.WriteLine("Total number of mimepart elements in the collection initially"+
                           " is: " +myMimePartCollection.Count);
      // Get the type of first 'Item' in collection.
      Console.WriteLine("The first object in collection is of type: "
                        +myMimePartCollection[0].ToString());
      MimePart myMimePart1=new MimePart();
      // Create an instance of 'MimeXmlBinding'.
      MimeXmlBinding myMimeXmlBinding1 = new MimeXmlBinding();
      myMimeXmlBinding1.Part = "body";
      myMimePart1.Extensions.Add(myMimeXmlBinding1);
      //  a mimepart at first position.
      myMimePartCollection.Insert(0,myMimePart1);
      Console.WriteLine("Inserting a mimepart object...");
      // Check whether 'Insert' was successful or not.
      if(myMimePartCollection.Contains(myMimePart1))
      {
         // Display the index of inserted 'MimePart'.
         Console.WriteLine("'MimePart' is successfully inserted at position: "
                              +myMimePartCollection.IndexOf(myMimePart1));
      }
// </Snippet4>
// </Snippet3>
// </Snippet2>
// </Snippet1>
      Console.WriteLine("Total number of mimepart elements after inserting is: "
                           + myMimePartCollection.Count);

// <Snippet5>
// <Snippet6>
      MimePart myMimePart2=new MimePart();
      MimeXmlBinding myMimeXmlBinding2 = new MimeXmlBinding();
      myMimeXmlBinding2.Part = "body";
      myMimePart2.Extensions.Add(myMimeXmlBinding2);
      // Add a mimepart to the mimepartcollection.
      myMimePartCollection.Add(myMimePart2);
      Console.WriteLine("Adding a mimepart object...");
      // Check if collection contains added mimepart object.
      if(myMimePartCollection.Contains(myMimePart2))
      {
         Console.WriteLine("'MimePart' is successfully added at position: "
                              +myMimePartCollection.IndexOf(myMimePart2));
      }
// </Snippet6>
// </Snippet5>
      Console.WriteLine("Total number of mimepart elements after adding is: "
         +myMimePartCollection.Count);

// <Snippet7>
      MimePart[] myArray = new MimePart[myMimePartCollection.Count];
      // Copy the mimepartcollection to an array.
      myMimePartCollection.CopyTo(myArray,0);
      Console.WriteLine("Displaying the array copied from mimepartcollection");
      for(int j=0;j<myMimePartCollection.Count;j++)
      {
         Console.WriteLine("Mimepart object at position : " + j);
         for(int i=0;i<myArray[j].Extensions.Count;i++)
         {
            MimeXmlBinding myMimeXmlBinding3 = (MimeXmlBinding)myArray[j].Extensions[i];
            Console.WriteLine("Part: "+(myMimeXmlBinding3.Part));
         }
      }
// </Snippet7>
// <Snippet8>
      Console.WriteLine("Removing a mimepart object...");
      // Remove the mimepart from the mimepartcollection.
      myMimePartCollection.Remove(myMimePart1);
      // Check whether the mimepart is removed or not.
      if(!myMimePartCollection.Contains(myMimePart1))
      {
         Console.WriteLine("Mimepart is successfully removed from mimepartcollection");
      }
// </Snippet8>
      Console.WriteLine("Total number of elements in collection after removing is: "
                            +myMimePartCollection.Count);
      MimePart[] myArray1 = new MimePart[myMimePartCollection.Count];
      myMimePartCollection.CopyTo(myArray1,0);
      Console.WriteLine("Dispalying the 'MimePartCollection' after removing");
      for(int j=0;j<myMimePartCollection.Count;j++)
      {
         Console.WriteLine("Mimepart object at position :" + j);
         for(int i=0;i<myArray1[j].Extensions.Count;i++)
         {
            MimeXmlBinding myMimeXmlBinding3 = (MimeXmlBinding)myArray1[j].Extensions[i];
            Console.WriteLine("part:  "+(myMimeXmlBinding3.Part));
         }
      }
      myServiceDescription.Write("MimePartCollection_8_output.wsdl");
      Console.WriteLine("MimePartCollection_8_output.wsdl has been generated successfully.");
   }
}
