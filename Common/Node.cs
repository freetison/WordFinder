namespace Common
{
    public class Node
    {
        public Node(int right, int down)
        {
            Right = right;
            Down = down;
        }

        public int Right { get; set; }
        public int Down { get; set; }
    }
}