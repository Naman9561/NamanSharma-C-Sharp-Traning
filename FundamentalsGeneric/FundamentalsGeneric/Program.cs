// Declare the generic class.
public class GenericList<T>
{
    private List<T> items = new();

    public void Add(T item)
    {
        items.Add(item);
    }

    public override string ToString()
    {
        return $"GenericList<{typeof(T).Name}>: [{string.Join(", ", items)}]";
    }
}
public class ExampleClass { }

class TestGenericList
{
    static void Main()
    {
        // Create a list of type int.
        GenericList<int> list1 = new();
        list1.Add(1);
        Console.WriteLine(list1);

        // Create a list of type string.
        GenericList<string> list2 = new();
        list2.Add("");
        Console.WriteLine(list2);

        // Create a list of type ExampleClass.
        GenericList<ExampleClass> list3 = new();
        list3.Add(new ExampleClass());
        Console.WriteLine(list3);
    }
}