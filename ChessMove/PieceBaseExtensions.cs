using System.Collections.Generic;
using System.Linq;

namespace ChessMove
{
    public static class PieceBaseExtensions
    {
        public static IReadOnlyList<int> PositionsX => Enumerable.Range(1, 8).Reverse().ToList();

        public static IReadOnlyList<string> PositionsY => Enumerable.Range(char.ConvertToUtf32("A", 0), 8)
            .Select(char.ConvertFromUtf32).ToList();

        public static string GetChessPosition(this PieceBase obj)
        {
            return GetChessPosition(obj.X, obj.Y);
        }

        public static string GetChessPosition(int x, int y)
        {
            return $"{PositionsY[y]}{PositionsX[x]}";
        }
    }
}
