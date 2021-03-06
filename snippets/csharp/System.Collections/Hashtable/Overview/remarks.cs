using System;
using System.Collections;

public class Remarks
{
    public static void Main()
    {
        // Create a new hash table.
        //
        Hashtable myHashtable = new Hashtable();

        // Add some elements to the hash table. There are no
        // duplicate keys, but some of the values are duplicates.
        myHashtable.Add("txt", "notepad.exe");
        myHashtable.Add("bmp", "paint.exe");
        myHashtable.Add("dib", "paint.exe");
        myHashtable.Add("rtf", "wordpad.exe");

        // When you use foreach to enumerate hash table elements,
        // the elements are retrieved as KeyValuePair objects.
        // <snippet01>
        foreach(DictionaryEntry de in myHashtable)
        {
            // ...
        }
        // </snippet01>
    }
}
