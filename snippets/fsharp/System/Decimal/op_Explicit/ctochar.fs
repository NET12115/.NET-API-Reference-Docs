module ctochar

// <Snippet6>
open System

// Define a list of decimal values.
let values = 
    [ 3.33m; 55.5m; 77.7m; 123m; 123.999m; 170m; 188.88m; 222m; 244m; 8217m; 8250m; 65536m; -1m ]

// Convert each value to a Char.
for value in values do
    try
        let charValue = char value
        printfn $"{value} --> {charValue} ({uint16 charValue:X4})"

    with :? OverflowException ->
        printfn $"OverflowException: Cannot convert {value}"

// The example displays the following output:
//       3.33 --> ? (0003)
//       55.5 --> 7 (0037)
//       77.7 --> M (004D)
//       123 --> { (007B)
//       123.999 --> { (007B)
//       170 --> ª (00AA)
//       188.88 --> ¼ (00BC)
//       222 --> _ (00DE)
//       244 --> ô (00F4)
//       8217 --> ' (2019)
//       8250 --> > (203A)
//       OverflowException: Cannot convert 65536
//       OverflowException: Cannot convert -1
//</Snippet6> 