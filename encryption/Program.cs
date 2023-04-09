Dictionary<char, int> ourElements = new Dictionary<char, int>();
string ourFile = File.ReadAllText(@"C:\Users\Admin\RiderProjects\encryption\encryption\our_file.txt");
foreach (char element in ourFile)
{
    if (ourElements.ContainsKey(element))
    {
        ourElements[element]++;
    }
    else
    {
        ourElements[element] = 1;
    }
}

foreach (var pair in ourElements)
{
    Console.WriteLine("Key = {0}, Value = {1}", pair.Key, pair.Value);
}

var queue = new Queue<Node>();
foreach (var pair in ourElements)
{
    queue.Enqueue(new Node { Symbol = pair.Key, Frequency = pair.Value });
}

while (queue.Count > 1)
{
    var first = queue.Dequeue();
    var second = queue.Dequeue();
    var parent = new Node
    {
        Frequency = first.Frequency + second.Frequency,
        LeftChild = first,
        RightChild = second
    };
    queue.Enqueue(parent);
}
var root = queue.Dequeue();