namespace encryption;
public class MinHeap
{

    public List<Node> data = new();

    Func<int, int> get_right_child_index = x => x * 2 + 2;
    Func<int, int> get_left_child_index = x => x * 2 + 1;
    Func<int, int> get_parent_index = x => (x - 1) / 2;

    public void Add(Node node)
    {
        data.Add(node);
        HeapifyUp(data.Count - 1);
    }

    void HeapifyUp(int index)
    {
        var parentIndex = get_parent_index(index);
        if (data[index].Frequency < data[parentIndex].Frequency)
        {
            (data[parentIndex], data[index]) = (data[index], data[parentIndex]);
            HeapifyUp(parentIndex);
        }

    }

    public void Print()
    {
        int Col_num = 0;
        int counter = 0;
        Console.WriteLine("-------------- Min Heap : -------------------");
        var shift = 80;
        var new_line = true;
        foreach (var element in data)
        {
            counter++;
            if (new_line) {Console.Write(new string(' ', shift)); new_line = false;}
            else          {Console.Write(new string(' ', shift/(6*Col_num))); }

            var ll = element.Symbol.ToString();
            if (element.Symbol == '\n')
            {
                ll = "\\n";
                
            }
            Console.Write($"'{ll}':{element.Frequency} ");
            if (counter == Math.Pow(2, Col_num))
            {
                Console.WriteLine();
                Col_num++;
                counter = 0;
                shift = shift * 9 / 10;
                new_line = true;
            }
        }

        Console.WriteLine();
        Console.WriteLine(new string('-', 45));
    }

    public Node Pop()
    {
        if (data.Count == 0)
        {
            return null;
        }
        if (data.Count > 1)
        {
            var tmp = data[0];
            data[0] = data[^1];
            data.RemoveAt(data.Count - 1);
            HeapifyDown(0);
            return tmp;
        }
        else
        {
            var tmp = data[0];
            data.RemoveAt(0);
            return tmp;
        }
    }
    
    void HeapifyDown(int index)
    {
        var left_child_index = get_left_child_index(index);
        var right_child_index = get_right_child_index(index);
        var min_index = index;

        if (left_child_index < data.Count && data[left_child_index].Frequency < data[min_index].Frequency)
        {
            min_index = left_child_index;
        }
        
        if (right_child_index < data.Count && data[right_child_index].Frequency < data[min_index].Frequency)
        {
            min_index = right_child_index;
        }
        
        if (index != min_index)
        {
            (data[min_index], data[index]) = (data[index], data[min_index]);
            HeapifyDown(min_index);
        }
    }
}