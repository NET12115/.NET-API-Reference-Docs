// The following code example displays the value of LongTimePattern for selected cultures.

// <snippet1>
using System;
using System.Globalization;

public class SamplesDTFI  {

   public static void Main()  {

      // Displays the values of the pattern properties.
      Console.WriteLine( " CULTURE    PROPERTY VALUE" );
      PrintPattern( "en-US" );
      PrintPattern( "ja-JP" );
      PrintPattern( "fr-FR" );
   }

   public static void PrintPattern( String myCulture )  {

      DateTimeFormatInfo myDTFI = new CultureInfo( myCulture, false ).DateTimeFormat;
      Console.WriteLine( "  {0}     {1}", myCulture, myDTFI.LongTimePattern );
   }
}

/*
This code produces the following output.

 CULTURE    PROPERTY VALUE
  en-US     h:mm:ss tt
  ja-JP     H:mm:ss
  fr-FR     HH:mm:ss

*/
// </snippet1>
