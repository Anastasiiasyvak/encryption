namespace encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> letter_freq = new Dictionary<char, int>();
            var min_heap = new MinHeap();
            string pathtoFile = "/home/nastia/for_new_projects/encryption/our_file.txt";
            foreach (char element in File.ReadAllText(pathtoFile))
            {
                if (letter_freq.ContainsKey(element))
                {
                    letter_freq[element]++;
                }
                else
                {
                    letter_freq[element] = 1;
                }
            }

            foreach (var pair in letter_freq)
            {

                if (pair.Key == 0x0A)
                {
                    Console.WriteLine($"\\n - {pair.Value}");
                }
                else
                {
                    Console.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }

            foreach (var data in letter_freq)
            {
                Node node = new Node()
                {
                    Symbol = data.Key,
                    Frequency = data.Value,
                    LeftChild = null,
                    RightChild = null
                };
                min_heap.Add(node);
            }

            min_heap.Print();
        }
    }
}

// var queue = new Queue<Node>();
// foreach (var pair in letter_freq)
// {
//     queue.Enqueue(new Node { Symbol = pair.Key, Frequency = pair.Value });
// }
//
// while (queue.Count > 1)
// {
//     var first = queue.Dequeue();
//     var second = queue.Dequeue();
//     var parent = new Node
//     {
//         Frequency = first.Frequency + second.Frequency,
//         LeftChild = first,
//         RightChild = second
//     };
//     queue.Enqueue(parent);
// }
// var root = queue.Dequeue();