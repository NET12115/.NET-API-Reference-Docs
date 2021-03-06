// System.Net.WebClient.QueryString

/*This program demonstrates the 'QueryString' property of 'WebClient' class.
 It accepts a search phrase as user input and invokes the search of www.google.com for  
 the user-entered search-phrase,using the 'QueryString' property of WebClient. The result is 
 then saved into the current 
 filesystem folder as 'searchresult.htm'. 
 */

using System;
using System.Collections.Specialized;
using System.Net;

public class WebClient_QueryString 
{
	public static void Main() 
	{
		try 
		{
// <Snippet1>			
			string uriString = "http://www.contoso.com/search";
			// Create a new WebClient instance.
			WebClient myWebClient = new WebClient();
			// Create a new NameValueCollection instance to hold the QueryString parameters and values.
			NameValueCollection myQueryStringCollection = new NameValueCollection();
			Console.Write("Enter the word(s), separated by space character to search for in " +  uriString + ": ");
			// Read user input phrase to search for at uriString.
			string searchPhrase = Console.ReadLine();
			if (searchPhrase.Length > 1)
				// Assign the user-defined search phrase.
				myQueryStringCollection.Add("q",searchPhrase);
			else
				// If error, default to search for 'Microsoft'.
				myQueryStringCollection.Add("q","Microsoft");		
			// Assign auxilliary parameters required for the search.
			Console.WriteLine("Searching " + uriString + " .......");
			// Attach QueryString to the WebClient.
			myWebClient.QueryString = myQueryStringCollection;
			// Download the search results Web page into 'searchresult.htm' for inspection.
			myWebClient.DownloadFile (uriString, "searchresult.htm");
			Console.WriteLine("\nDownload of " + uriString + " was successful. Please see 'searchresult.htm' for results.");
// </Snippet1>
			// Get the collection of Headers sent back in response to the WebClient request.
			WebHeaderCollection myWebHeaderCollection = myWebClient.ResponseHeaders;
			Console.WriteLine("\nDisplaying Response Headers\n");
			// Loop through the ResponseHeader collection and display the Headers as name/value pairs.
			for (int i=0; i < myWebHeaderCollection.Count ; i++) 
				// Display the Headers as 'Name = Value' pairs.
				Console.WriteLine ("\t" + myWebHeaderCollection.GetKey(i) + " = " + myWebHeaderCollection.Get(i));
		} 
		catch (WebException e) 
		{
			Console.WriteLine ("The following WebException was raised: "+ e.Message );
		}
		catch(Exception e)
		{
			Console.WriteLine ("The following Exception was raised: "+ e.Message );
		}
	}
}
