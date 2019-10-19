using System;

namespace ChessMove
{
    public class Game
    {
        public PieceBase[,] Board { get; private set; } = new PieceBase[8, 8];

        public void AddToBoard<TPiece>(int x, int y) where TPiece : PieceBase
        {
            var piece = Activator.CreateInstance(typeof(TPiece), this, x, y) as TPiece;
            Board[x, y] = piece;
        }
    }
}
