Dictionary<char, int> our_elements = new Dictionary<char, int>();
string pathtoFile = "/home/nastia/for_new_projects/encryption/our_file.txt";
foreach (char element in File.ReadAllText(pathtoFile))
{
    if (our_elements.ContainsKey(element))
    {
        our_elements[element]++;
    }
    else
    {
        our_elements[element] = 1;
    }
}

foreach (var pair in our_elements)
{
    Console.WriteLine("Key = {0}, Value = {1}", pair.Key, pair.Value);
}
