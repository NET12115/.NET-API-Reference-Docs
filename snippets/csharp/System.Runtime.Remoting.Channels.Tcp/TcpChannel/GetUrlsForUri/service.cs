using System;

public class HelloService : MarshalByRefObject {

    static int n_instances;

    public HelloService() {
        n_instances++;
        Console.WriteLine("");
        Console.WriteLine("HelloService activated - instance # {0}.", n_instances);
    }

    ~HelloService()  {
        Console.WriteLine("HelloService instance {0} destroyed.", n_instances);
        n_instances--;
    }

    public String HelloMethod(String name)  {

        Console.WriteLine("HelloMethod called on HelloService instance {0}.", n_instances);
        return "Hi there " + name + ".";
    }
}
