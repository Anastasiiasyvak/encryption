namespace encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> letter_freq = new Dictionary<char, int>();
            var min_heap = new MinHeap();
            // List<Node> haffman_tree = new List<Node>();
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

            // Build the Huffman tree
            Node root = BuildHuffmanTree(min_heap);

            // Traverse the Huffman tree and print the binary code for each character
            Dictionary<char, string> codes = new Dictionary<char, string>();
            // TraverseHuffmanTree(root, "", codes);
            Console.WriteLine("Huffman codes:");
            foreach (var pair in codes)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        static Node BuildHuffmanTree(MinHeap min_heap)
        {
            List<Node> haffman_tree = new List<Node>();
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
                haffman_tree.Add(internalNode);
            }

            // The last remaining node in the heap is the root of the Huffman tree
            return min_heap.Pop();
        }
        
        
    }
}



