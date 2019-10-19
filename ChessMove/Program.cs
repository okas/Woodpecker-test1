using System;

namespace ChessMove
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 2; i++)
            {
                var game = new Game();
                if (i == 1)
                {
                    game.AddToBoard<Rook>(7, 0);
                    game.AddToBoard<Bishop>(0, 7);
                }
                else
                {
                    game.AddToBoard<Bishop>(7, 0);
                    game.AddToBoard<Rook>(0, 7);
                }
                Console.WriteLine($"\nRound #{i}: \"{game.Board[7, 0].GetType().Name}\" vs \"{game.Board[0, 7].GetType().Name}\".");
                game.Board[7, 0].Move(0, 7);
            }
        }
    }
}
