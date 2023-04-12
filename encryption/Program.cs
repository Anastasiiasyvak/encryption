// namespace encryption
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Dictionary<char, int> letter_freq = new Dictionary<char, int>();
//             var min_heap = new MinHeap();
//             string pathtoFile = "/home/nastia/for_new_projects/encryption/our_file.txt";
//             foreach (char element in File.ReadAllText(pathtoFile))
//             {
//                 if (letter_freq.ContainsKey(element))
//                 {
//                     letter_freq[element]++;
//                 }
//                 else
//                 {
//                     letter_freq[element] = 1;
//                 }
//             }
//
//             foreach (var pair in letter_freq)
//             {
//
//                 if (pair.Key == 0x0A)
//                 {
//                     Console.WriteLine($"\\n - {pair.Value}");
//                 }
//                 else
//                 {
//                     Console.WriteLine($"{pair.Key} - {pair.Value}");
//                 }
//             }
//
//             foreach (var data in letter_freq)
//             {
//                 Node node = new Node()
//                 {
//                     Symbol = data.Key,
//                     Frequency = data.Value,
//                     LeftChild = null,
//                     RightChild = null
//                 };
//                 min_heap.Add(node);
//             }
//
//             min_heap.Print();
//         }
//     }
// }
//
//


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

            // Build the Huffman tree
            Node root = BuildHuffmanTree(min_heap);

            // Traverse the Huffman tree and print the binary code for each character
            Dictionary<char, string> codes = new Dictionary<char, string>();
            TraverseHuffmanTree(root, "", codes);
            Console.WriteLine("Huffman codes:");
            foreach (var pair in codes)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        static Node BuildHuffmanTree(MinHeap min_heap)
        {
            while (min_heap.data.Count > 1)
            {
                // Pop the two nodes with the lowest frequency
                Node node1 = min_heap.Pop();
                Node node2 = min_heap.Pop();

                // Create a new internal node with the sum of the frequencies
                Node internalNode = new Node()
                {
                    Frequency = node1.Frequency + node2.Frequency,
                    LeftChild = node1,
                    RightChild = node2
                };

                // Add the new internal node to the heap
                min_heap.Add(internalNode);
            }

            // The last remaining node in the heap is the root of the Huffman tree
            return min_heap.Pop();
        }

        static void TraverseHuffmanTree(Node node, string code, Dictionary<char, string> codes)
        {
            if (node.LeftChild == null && node.RightChild == null)
            {
                // Leaf node, store the binary code for the symbol
                codes[node.Symbol] = code;
            }
            else
            {
                // Internal node, traverse left and right branches
                TraverseHuffmanTree(node.LeftChild, code + "0", codes);
                TraverseHuffmanTree(node.RightChild, code + "1", codes);
            }
        }

        static Dictionary<char, string> BuildHuffmanCodeDictionary(Node root)
        {
            var codes = new Dictionary<char, string>();
            TraverseHuffmanTree(root, "", codes);
            return codes;
        }

        static Node BuildHuffmanTree(Dictionary<char, int> frequencies)
        {
            var queue = new PriorityQueue<Node>();

            // Add all characters with non-zero frequency to the priority queue
            foreach (var kvp in frequencies)
            {
                if (kvp.Value > 0)
                {
                    queue.Enqueue(new Node(kvp.Key, kvp.Value));
                }
            }

            // Build the Huffman tree by repeatedly combining the two lowest frequency nodes
            while (queue.Count > 1)
            {
                var left = queue.Dequeue();
                var right = queue.Dequeue();
                queue.Enqueue(new Node(left, right));
            }

            return queue.Dequeue();
        }
    }
}


