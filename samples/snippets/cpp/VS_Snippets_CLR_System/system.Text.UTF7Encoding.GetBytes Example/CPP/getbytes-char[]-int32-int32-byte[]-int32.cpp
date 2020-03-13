
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
int main()
{
   array<Byte>^bytes;
   
   // Unicode characters.
   
   // Pi
   // Sigma
   array<Char>^chars = {L'\u03a0',L'\u03a3',L'\u03a6',L'\u03a9'};
   UTF7Encoding^ utf7 = gcnew UTF7Encoding;
   int byteCount = utf7->GetByteCount( chars, 1, 2 );
   bytes = gcnew array<Byte>(byteCount);
   int bytesEncodedCount = utf7->GetBytes( chars, 1, 2, bytes, 0 );
   Console::WriteLine( "{0} bytes used to encode characters.", bytesEncodedCount );
   Console::Write( "Encoded bytes: " );
   IEnumerator^ myEnum = bytes->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Byte b = safe_cast<Byte>(myEnum->Current);
      Console::Write( "[{0}]", b );
   }

   Console::WriteLine();
}

// </Snippet1>
