namespace DominoApi.Commands.Dto
{
    public class Domino
    {
        public int Left { get; set; }
        public int Right { get; set; }

        public Domino(int left, int right)
        {
            Left = left;
            Right = right;
        }

        public void Flip()
        {
            (Left, Right) = (Right, Left);
        }

        public override string ToString()
        {
            return $"[{Left}|{Right}]";
        }
    }
}
