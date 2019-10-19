namespace ChessMove
{
    public class Bishop : PieceBase
    {
        public Bishop(Game game, int x, int y) : base(game, x, y) { }

        private int Diagonal => GetDiagonalIndex(X, Y);

        private int AntiDiagonal => GetAntiDiagonalIndex(X, Y);

        protected override bool ValidateStep(int toX, int toY)
        {
            if (Diagonal == GetDiagonalIndex(toX, toY))
            {
                return true;
            }
            else if (AntiDiagonal == GetAntiDiagonalIndex(toX, toY))
            {
                return true;
            }
            return false;
        }

        private int GetDiagonalIndex(int x, int y)
        {
            return (x - y) & 15;
        }

        private int GetAntiDiagonalIndex(int x, int y)
        {
            return (x + y) ^ 7;
        }
    }
}
