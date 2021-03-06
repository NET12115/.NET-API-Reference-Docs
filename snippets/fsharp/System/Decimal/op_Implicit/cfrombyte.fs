module cfrombyte

// <Snippet4>
open System

// Define a list of byte values.
let values = 
    [ Byte.MinValue; Byte.MaxValue; 0x3Fuy; 123uy; 200uy ]

// Convert each value to a Decimal.
for value in values do
    let decValue: decimal = value
    printfn $"{value} ({value.GetType().Name}) --> {decValue} ({decValue.GetType().Name})"

// The example displays the following output:
//       0 (Byte) --> 0 (Decimal)
//       255 (Byte) --> 255 (Decimal)
//       63 (Byte) --> 63 (Decimal)
//       123 (Byte) --> 123 (Decimal)
//       200 (Byte) --> 200 (Decimal)
//</Snippet4> 