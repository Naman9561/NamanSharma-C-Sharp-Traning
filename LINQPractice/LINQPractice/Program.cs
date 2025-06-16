// Specify the data source.
using System.Xml.Linq;

int[] scores = [97, 92, 81, 60];
// Define the query expression.
IEnumerable<int> scoreQuery =
    from score in scores
    where score > 80
    select score;

// Execute the query.
foreach (var i in scoreQuery)
{
    Console.Write(i + " ");
}

//****************************************************************
Console.WriteLine("\n");
// 1. Data source.
int[] numbers = [0, 1, 2, 3, 4, 5, 6];

// 2. Query creation.
// numQuery is an IEnumerable<int>
var numQuery = from num in numbers
               where (num % 2) == 0
               select num;
// 3. Query execution.
foreach (int num in numQuery)
{
    Console.Write("{0,1} ", num);
}
Console.WriteLine("\n");

int evenNumCount = scoreQuery.Count();
Console.WriteLine($"Count of even numbers: {evenNumCount}");
Console.WriteLine("\n");

List<int> numQuery2 = (from num in numbers
                       where (num % 2) == 0
                       select num).ToList();
foreach (int num in numQuery2)
{
    Console.Write(num + " ");
}


// ****************************************************************
Console.WriteLine("\n");
// Create a data source from an XML document.
// using System.Xml.Linq;
XElement contacts = XElement.Load(@"C:\Users\ACER\OneDrive\Desktop\complex-nested.xml");
Console.WriteLine(contacts);

// ****************************************************************
