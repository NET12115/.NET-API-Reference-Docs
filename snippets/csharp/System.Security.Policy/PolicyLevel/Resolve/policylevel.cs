//<snippet1>
// This sample demonstrates how to set code access permissions programmatically.  It creates a
// new parent and child code group pair, and allows the user to optionally delete the child group 
// and/or the parent code group.  It also shows the result of a ResolvePolicy call, and displays 
// the permissions for the three security levels; Enterprise, Machine, and User.
using System;
using System.Collections;
using System.Security;
using System.Security.Policy;
using System.Security.Permissions;
using System.Reflection;
using System.Globalization;

class PolicyLevelSample
{
	
    static void Main()
    {
        Console.WriteLine("*************************************************************************************");
        Console.WriteLine("Create an AppDomain policy level.");
        Console.WriteLine("Use the AppDomain to demonstrate PolicyLevel methods and properties.");
        Console.WriteLine("*************************************************************************************");
        CreateAPolicyLevel();
        Evidence intranetZoneEvidence = new Evidence(new object[] { new Zone(SecurityZone.Intranet) }, null);
        Console.WriteLine("*************************************************************************************");
        Console.WriteLine("Show the result of ResolvePolicy on this computer for LocalIntranet zone evidence.");
        Console.WriteLine("*************************************************************************************");
        CheckEvidence(intranetZoneEvidence);
        Console.WriteLine("*************************************************************************************");
        Console.WriteLine("Enumerate the permission sets for Machine policy level.");
        Console.WriteLine("*************************************************************************************");
        ListMachinePermissionSets();
        Console.Out.WriteLine("Press the Enter key to exit.");
        string consoleInput = Console.ReadLine();
    }
		
    public static void CreateAPolicyLevel()
    {
        try
        {
            //<Snippet2> 
            // Create an AppDomain policy level.
            PolicyLevel pLevel = PolicyLevel.CreateAppDomainLevel();
            //</Snippet2>
            // The root code group of the policy level combines all
            // permissions of its children.
            UnionCodeGroup rootCodeGroup;
            PermissionSet ps = new PermissionSet(PermissionState.None);
            ps.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));

            rootCodeGroup = new UnionCodeGroup(
                new AllMembershipCondition(),
                new PolicyStatement(ps, PolicyStatementAttribute.Nothing));
			
            // This code group grants FullTrust to assemblies with the strong
            // name key from this assembly.
            UnionCodeGroup myCodeGroup = new UnionCodeGroup(
                new StrongNameMembershipCondition(
                new StrongNamePublicKeyBlob(GetKey()),
                null,
                null),
                new PolicyStatement(new PermissionSet(PermissionState.Unrestricted),
                PolicyStatementAttribute.Nothing)
                );
            myCodeGroup.Name = "My CodeGroup";

            //<Snippet4>  
            // Add the code groups to the policy level.
            rootCodeGroup.AddChild(myCodeGroup);
            pLevel.RootCodeGroup = rootCodeGroup;
            Console.WriteLine("Permissions granted to all code running in this AppDomain level: ");
            Console.WriteLine(rootCodeGroup.ToXml());
            Console.WriteLine("Child code groups in RootCodeGroup:");
            IList codeGroups = pLevel.RootCodeGroup.Children;
            IEnumerator codeGroup = codeGroups.GetEnumerator();
            while (codeGroup.MoveNext())
            {
                Console.WriteLine("\t" + ((CodeGroup)codeGroup.Current).Name);
            }
            //</Snippet4>
            //<Snippet5>  
            Console.WriteLine("Demonstrate adding and removing named permission sets.");
            Console.WriteLine("Original named permission sets:");
            ListPermissionSets(pLevel);
            NamedPermissionSet myInternet = pLevel.GetNamedPermissionSet("Internet");
            //</Snippet5>
            myInternet.Name = "MyInternet";
            //<Snippet6> 
            pLevel.AddNamedPermissionSet(myInternet);
            //</Snippet6>
            Console.WriteLine("\nNew named permission sets:");
            ListPermissionSets(pLevel);
            myInternet.RemovePermission(typeof(System.Security.Permissions.FileDialogPermission));
            //<Snippet7> 
            pLevel.ChangeNamedPermissionSet("MyInternet",myInternet);
            //</Snippet7>
            //<Snippet8>
            pLevel.RemoveNamedPermissionSet("MyInternet");
            //</Snippet8>
            Console.WriteLine("\nCurrent permission sets:");
            ListPermissionSets(pLevel);
            pLevel.AddNamedPermissionSet(myInternet);
            Console.WriteLine("\nUpdated named permission sets:");
            ListPermissionSets(pLevel);
            //<Snippet9> 
            pLevel.Reset();
            //</Snippet9>
            Console.WriteLine("\nReset named permission sets:");
            ListPermissionSets(pLevel);
            //<Snippet10> 
            Console.WriteLine("\nType property = " + pLevel.Type.ToString());
            //</Snippet10>
            //<Snippet11> 
            Console.WriteLine("The result of GetHashCode is " + pLevel.GetHashCode().ToString());
            //</Snippet11>
            Console.WriteLine("StoreLocation property for the AppDomain level is empty, since AppDomain policy " + 
                "cannot be saved to a file.");
            Console.WriteLine("StoreLocation property = " + pLevel.StoreLocation);
            //<Snippet12> 
            PolicyLevel pLevelCopy = PolicyLevel.CreateAppDomainLevel();
            // Create a copy of the PolicyLevel using ToXml/FromXml.
            pLevelCopy.FromXml(pLevel.ToXml());

            if (ComparePolicyLevels(pLevel, pLevelCopy))
            {
                Console.WriteLine("The ToXml/FromXml roundtrip was successful.");
            }
            else
            {
                Console.WriteLine("ToXml/FromXml roundtrip failed.");
            }
            //</Snippet12>
            Console.WriteLine("Show the result of resolving policy for evidence unique to the AppDomain policy level.");
            Evidence myEvidence = new Evidence(new object[] { myCodeGroup }, null);
            CheckEvidence(pLevel,myEvidence);
            return;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
    }
    // Compare two PolicyLevels using ToXml and FromXml.
    private static bool ComparePolicyLevels(PolicyLevel pLevel1, PolicyLevel pLevel2)
    {
        bool retVal = false;
        PolicyLevel firstCopy = PolicyLevel.CreateAppDomainLevel();
        PolicyLevel secondCopy = PolicyLevel.CreateAppDomainLevel();
        // Create copies of the two PolicyLevels passed in.
        // Convert the two PolicyLevels to their canonical form using ToXml and FromXml.
        firstCopy.FromXml(pLevel1.ToXml());
        secondCopy.FromXml(pLevel2.ToXml());
        if(firstCopy.ToXml().ToString().CompareTo(secondCopy.ToXml().ToString())== 0)
            retVal = true;
        return retVal;
    }
	
    //<Snippet13>  
    // Demonstrate the use of ResolvePolicy for the supplied evidence and a specified policy level.
    private static void CheckEvidence(PolicyLevel pLevel, Evidence evidence)
    {
        // Display the code groups to which the evidence belongs.
        Console.WriteLine("\tResolvePolicy for the given evidence: ");
        IEnumerator codeGroup = evidence.GetEnumerator();
        while (codeGroup.MoveNext())
        {
            Console.WriteLine("\t\t" + ((CodeGroup)codeGroup.Current).Name);
        }
        Console.WriteLine("The current evidence belongs to the following root CodeGroup:");
        // pLevel is the current PolicyLevel, evidence is the Evidence to be resolved.
        CodeGroup cg1 = pLevel.ResolveMatchingCodeGroups(evidence);
        Console.WriteLine(pLevel.Label + " Level");
        Console.WriteLine("\tRoot CodeGroup = " + cg1.Name);

        // Show how Resolve is used to determine the set of permissions that 
        // the security system grants to code, based on the evidence.

        // Show the granted permissions. 
        Console.WriteLine("\nCurrent permissions granted:");
        PolicyStatement pState = pLevel.Resolve(evidence);
        Console.WriteLine(pState.ToXml().ToString());

        return;
    }
    //</Snippet13>
    //<Snippet14> 
    private static void ListPermissionSets(PolicyLevel pLevel)
    {
        IList namedPermissions = pLevel.NamedPermissionSets;
        IEnumerator namedPermission = namedPermissions.GetEnumerator();
        while (namedPermission.MoveNext())
        {
            Console.WriteLine("\t" + ((NamedPermissionSet)namedPermission.Current).Name);
        }
    }
    //</Snippet14>

    private static byte[] GetKey()
    {
        return Assembly.GetCallingAssembly().GetName().GetPublicKey();
    }
    //<Snippet15>  
    // Demonstrate the use of ResolvePolicy for passed in evidence.
    private static void CheckEvidence(Evidence evidence)
    {
        // Display the code groups to which the evidence belongs.
        Console.WriteLine("ResolvePolicy for the given evidence.");
        Console.WriteLine("\tCurrent evidence belongs to the following code groups:");
        IEnumerator policyEnumerator = SecurityManager.PolicyHierarchy();
        // Resolve the evidence at all the policy levels.
        while (policyEnumerator.MoveNext())
        {

            PolicyLevel currentLevel = (PolicyLevel)policyEnumerator.Current;	
            CodeGroup cg1 = currentLevel.ResolveMatchingCodeGroups(evidence);
            Console.WriteLine("\n\t" + currentLevel.Label + " Level");
            Console.WriteLine("\t\tCodeGroup = " + cg1.Name);
            IEnumerator cgE1 = cg1.Children.GetEnumerator();
            while (cgE1.MoveNext())
            {
                Console.WriteLine("\t\t\tGroup = " + ((CodeGroup)cgE1.Current).Name);
            }
            Console.WriteLine("\tStoreLocation = " + currentLevel.StoreLocation);
        }

        return;
    }
    //</Snippet15>

    //<Snippet16> 
    private static void ListMachinePermissionSets()
    {
        Console.WriteLine("\nPermission sets in Machine policy level:");
        IEnumerator policyEnumerator = SecurityManager.PolicyHierarchy();
        while (policyEnumerator.MoveNext())
        {

            PolicyLevel currentLevel = (PolicyLevel)policyEnumerator.Current;	
            if (currentLevel.Label == "Machine")
            {
			
                IList namedPermissions = currentLevel.NamedPermissionSets;
                IEnumerator namedPermission = namedPermissions.GetEnumerator();
                while (namedPermission.MoveNext())
                {
                    Console.WriteLine("\t" + ((NamedPermissionSet)namedPermission.Current).Name);
                }
            }
        }
    }
    //</Snippet16>
}
//</Snippet1>
