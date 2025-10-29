using System;

namespace Task08_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите позицию белого короля (например, e4)");
            var whiteKingPosition = Console.ReadLine();
            Console.WriteLine("Введите позицию черной ферзя (например, d7)");
            var blackQueenPosition = Console.ReadLine();

            if (whiteKingPosition == blackQueenPosition)
            {
                Console.WriteLine("Фигуры не могут стоять на одной клетке");
                return;
            }

            int whiteKingV, whiteKingH;
            int blackQueenV, blackQueenH;

            DecodePosition(whiteKingPosition, out whiteKingV, out whiteKingH);
            DecodePosition(blackQueenPosition, out blackQueenV, out blackQueenH);

           
            if (whiteKingV < 1 || whiteKingV > 8 || whiteKingH < 1 || whiteKingH > 8 ||
                blackQueenV < 1 || blackQueenV > 8 || blackQueenH < 1 || blackQueenH > 8)
            {
                Console.WriteLine("Недопустимая позиция");
                return;
            }

            bool queenAttacksKing = IsUnderStrikeByQueen(whiteKingPosition, blackQueenPosition);
            bool kingAttacksQueen = IsUnderStrikeByKing(blackQueenPosition, whiteKingPosition);

            if (queenAttacksKing && kingAttacksQueen)
                Console.WriteLine("Ферзь и король бьют друг друга");
            else if (queenAttacksKing)
                Console.WriteLine("Ферзь бьёт короля");
            else if (kingAttacksQueen)
                Console.WriteLine("Король бьёт ферзя");
            else
                Console.WriteLine("Фигуры не бьют друг друга");
        }

        static void DecodePosition(string position, out int vert, out int hor)
        {
            position = position.ToLower();
            vert = (int)position[0] - 0x60;
            hor = int.Parse(position[1].ToString());
        }

        static bool IsUnderStrikeByQueen(string position, string queenPosition)
        {
            int pV, pH, qV, qH;
            DecodePosition(position, out pV, out pH);
            DecodePosition(queenPosition, out qV, out qH);

          
            return pV == qV || pH == qH || Math.Abs(pV - qV) == Math.Abs(pH - qH);
        }

        static bool IsUnderStrikeByKing(string position, string kingPosition)
        {
            int pV, pH, kV, kH;
            DecodePosition(position, out pV, out pH);
            DecodePosition(kingPosition, out kV, out kH);

           
            return Math.Abs(pV - kV) <= 1 && Math.Abs(pH - kH) <= 1;
        }
    }
}