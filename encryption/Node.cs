namespace encryption;



public class Node
{
    public char Symbol;
    public int Frequency;
    public Node RightChild;
    public Node LeftChild;

    public List<int> Search(char symbol, List<int> path)
    {
        // Leaf
        if (RightChild == null && LeftChild == null)
        {
            if (symbol == this.Symbol)
            {
                return path;
            }
            else
            {
                return null;
            }
        }
        else
        {
            List<int> path_left = null;
            List<int> path_right = null;

            if (LeftChild != null)
            {
                var leftPath = new List<int>();
                leftPath.AddRange(path);
                leftPath.Add(0);

                path_left = LeftChild.Search(symbol, leftPath);
            }

            if (RightChild != null)
            {
                var rightPath = new List<int>();
                rightPath.AddRange(path);
                rightPath.Add(1);
                path_right = RightChild.Search(symbol, rightPath);
            }

            if (path_left != null)
            {
                return path_left;
            }
            else
            {
                return path_right;
            }
        }
    }
}