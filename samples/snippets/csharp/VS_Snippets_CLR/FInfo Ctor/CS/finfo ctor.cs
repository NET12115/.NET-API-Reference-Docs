﻿// <Snippet1>
using System;
using System.IO;

class Test 
{
	
    public static void Main() 
    {
        string path = @"c:\temp\MyTest.txt";
        FileInfo fi1 = new FileInfo(path);

        if (!fi1.Exists) 
        {
            //Create a file to write to.
            using (StreamWriter sw = fi1.CreateText()) 
            {
                sw.WriteLine("Hello");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
            }	
        }

        //Open the file to read from.
        using (StreamReader sr = fi1.OpenText()) 
        {
            string s = "";
            while ((s = sr.ReadLine()) != null) 
            {
                Console.WriteLine(s);
            }
        }

        try 
        {
            string path2 = path + "temp";
            FileInfo fi2 = new FileInfo(path2);

            //Ensure that the target does not exist.
            fi2.Delete();

            //Copy the file.
            fi1.CopyTo(path2);
            Console.WriteLine("{0} was copied to {1}.", path, path2);

            //Delete the newly created file.
            fi2.Delete();
            Console.WriteLine("{0} was successfully deleted.", path2);
        } 
        catch (Exception e) 
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//Hello
//And
//Welcome
//c:\MyTest.txt was copied to c:\MyTest.txttemp.
//c:\MyTest.txttemp was successfully deleted.
// </Snippet1>
