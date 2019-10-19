using System;

namespace ChessMove
{
    public abstract class PieceBase
    {
        private readonly Game game;

        public PieceBase(Game game, int x = -1, int y = -1)
        {
            this.game = game;
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public void Move(int toX, int toY)
        {
            string oldName = ToString();
            var rangeResult = BaseValidation(toX, toY);
            if (!rangeResult.Equals(PositionCheck.CanMove))
            {
                Console.WriteLine($"{oldName} move is invalid: out of board!");
                return;
            }
            var isValid = ValidateStep(toX, toY);
            if (!isValid)
            {
                Console.WriteLine($"{ oldName} move is invalid: bad new position given [{PieceBaseExtensions.GetChessPosition(toX, toY)}]!");
                return;
            }
            var killedPiece = Step(toX, toY);
            Console.WriteLine(
                "{0} move is valid, took down {1}.",
                oldName,
                killedPiece?.ToString() ?? "nothing"
                );
        }

        protected abstract bool ValidateStep(int toX, int toY);

        private PositionCheck BaseValidation(int toX, int toY)
        {
            if (!InRangeX(toX))
            {
                return PositionCheck.OutX;
            }
            if (!InRangeY(toY))
            {
                return PositionCheck.OutY;
            }
            return X == toX && Y == toY ? PositionCheck.NoChange : PositionCheck.CanMove;
        }

        private bool InRangeX(int toX)
        {
            if (toX > X && X + toX > 7)
            {
                return false;
            }
            else if (toX < X && X - toX < 0)
            {
                return false;
            }
            return true;
        }

        private bool InRangeY(int toY)
        {
            if (toY > Y && Y + toY > 7)
            {
                return false;
            }
            else if (toY < Y && Y - toY < 0)
            {
                return false;
            }
            return true;
        }

        private PieceBase Step(int toX, int toY)
        {
            var otherPiece = game.Board[toX, toY];
            game.Board[X, Y] = this;
            X = toX;
            Y = toY;
            return otherPiece;
        }

        private enum PositionCheck
        {
            CanMove,
            NoChange,
            OutX,
            OutY
        }

        public override string ToString()
        {
            return $"{GetType().Name}[{this.GetChessPosition()}]";
        }
    }
}
