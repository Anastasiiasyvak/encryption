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