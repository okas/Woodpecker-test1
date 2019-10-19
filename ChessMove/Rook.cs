namespace ChessMove
{
    public class Rook : PieceBase
    {
        public Rook(Game game, int x, int y) : base(game, x, y) { }

        protected override bool ValidateStep(int toX, int toY)
        {
            bool xChanged = X != toX;
            bool yChanged = Y != toY;
            return !(xChanged && yChanged);
        }
    }
}
