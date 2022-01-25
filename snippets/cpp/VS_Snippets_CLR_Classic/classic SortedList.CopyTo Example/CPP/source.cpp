

// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( array<DictionaryEntry>^ myArr, Char mySeparator );
int main()
{
   
   // Creates and initializes the source SortedList.
   SortedList^ mySourceList = gcnew SortedList;
   mySourceList->Add( 2, "cats" );
   mySourceList->Add( 3, "in" );
   mySourceList->Add( 1, "napping" );
   mySourceList->Add( 4, "the" );
   mySourceList->Add( 0, "three" );
   mySourceList->Add( 5, "barn" );
   
   // Creates and initializes the one-dimensional target Array.
   array<String^>^tempArray = {"The","quick","brown","fox","jumps","over","the","lazy","dog"};
   array<DictionaryEntry>^myTargetArray = gcnew array<DictionaryEntry>(15);
   int i = 0;
   IEnumerator^ myEnum = tempArray->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ s = safe_cast<String^>(myEnum->Current);
      myTargetArray[ i ].Key = i;
      myTargetArray[ i ].Value = s;
      i++;
   }

   
   // Displays the values of the target Array.
   Console::WriteLine( "The target Array contains the following (before and after copying):" );
   PrintValues( myTargetArray, ' ' );
   
   // Copies the entire source SortedList to the target SortedList, starting at index 6.
   mySourceList->CopyTo( myTargetArray, 6 );
   
   // Displays the values of the target Array.
   PrintValues( myTargetArray, ' ' );
}

void PrintValues( array<DictionaryEntry>^ myArr, Char mySeparator )
{
   for ( int i = 0; i < myArr->Length; i++ )
      Console::Write( "{0}{1}", mySeparator, myArr[ i ].Value );
   Console::WriteLine();
}

/*
This code produces the following output.
 
The target Array contains the following (before and after copying):
 The quick brown fox jumps over the lazy dog      
 The quick brown fox jumps over three napping cats in the barn

*/
// </Snippet1>
