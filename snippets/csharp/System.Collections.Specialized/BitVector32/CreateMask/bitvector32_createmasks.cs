// The following code example shows how to create and use masks.

// <snippet1>
using System;
using System.Collections.Specialized;

public class SamplesBitVector32  {

   public static void Main()  {

      // Creates and initializes a BitVector32 with all bit flags set to FALSE.
      BitVector32 myBV = new BitVector32( 0 );

      // Creates masks to isolate each of the first five bit flags.
      int myBit1 = BitVector32.CreateMask();
      int myBit2 = BitVector32.CreateMask( myBit1 );
      int myBit3 = BitVector32.CreateMask( myBit2 );
      int myBit4 = BitVector32.CreateMask( myBit3 );
      int myBit5 = BitVector32.CreateMask( myBit4 );
      Console.WriteLine( "Initial:               \t{0}", myBV.ToString() );

      // Sets the third bit to TRUE.
      myBV[myBit3] = true;
      Console.WriteLine( "myBit3 = TRUE          \t{0}", myBV.ToString() );

      // Combines two masks to access multiple bits at a time.
      myBV[myBit4 + myBit5] = true;
      Console.WriteLine( "myBit4 + myBit5 = TRUE \t{0}", myBV.ToString() );
      myBV[myBit1 | myBit2] = true;
      Console.WriteLine( "myBit1 | myBit2 = TRUE \t{0}", myBV.ToString() );
   }
}

/*
This code produces the following output.

Initial:                BitVector32{00000000000000000000000000000000}
myBit3 = TRUE           BitVector32{00000000000000000000000000000100}
myBit4 + myBit5 = TRUE  BitVector32{00000000000000000000000000011100}
myBit1 | myBit2 = TRUE  BitVector32{00000000000000000000000000011111}

*/
// </snippet1>
