namespace encryption
{
    class Program
    {
        static void Main()
        {
            Dictionary<char, int> letter_freq = new Dictionary<char, int>();
            var min_heap = new MinHeap();
            string pathtoFile = @"C:\Users\Admin\RiderProjects\encryption\encryption\our_file.txt";
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

            Dictionary<char, string> codes = new Dictionary<char, string>();
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

            BuildHuffmanTree(min_heap, letter_freq);
            string encodedText = "";
            string originalText = File.ReadAllText(pathtoFile);
            foreach (char symbol in originalText)
            {
                string code = codes[symbol];
                encodedText += code;
            }
            File.WriteAllText(@"C:\Users\Admin\RiderProjects\encryption\encryption\encoded_file.txt", encodedText);
            
            Console.WriteLine($"Encoded Text: {encodedText}");
            
            string decodedText = Decode(encodedText, codes);
            Console.WriteLine($"Decoded Text: {decodedText}");
            
            foreach (var pair in codes)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        static Node BuildHuffmanTree(MinHeap min_heap, Dictionary<char, int> letter_freq)
        {
            List<Node> haffman_tree = new List<Node>();
            List<int> steps = new List<int>();
            

            while (min_heap.data.Count > 1)
            {
                Node node1 = min_heap.Pop();
                Node node2 = min_heap.Pop();

                Node internalNode = new Node()
                {
                    Frequency = node1.Frequency + node2.Frequency,
                    LeftChild = node1,
                    RightChild = node2
                };

                min_heap.Add(internalNode);
                haffman_tree.Add(internalNode);
            }
            Node Root = haffman_tree[haffman_tree.Count() - 1];
            foreach (var i in letter_freq)
            {
                List<int> path = Root.Search(i.Key, new List<int>());
                steps.AddRange(path);
                Console.Write($"{i.Key}: ");
                foreach (var j in path)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
            return min_heap.Pop();
        }
        
        static string Decode(string encodedText, Dictionary<char, string> codes)
        {
            string decodedText = "";
            string buffer = "";
            foreach (char symbol in encodedText)
            {
                buffer += symbol;
                foreach (var pair in codes)
                {
                    if (pair.Value == buffer)
                    {
                        decodedText += pair.Key;
                        buffer = "";
                    }
                }
            }
            return decodedText;
        }
    }
}



