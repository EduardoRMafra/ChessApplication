using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApplication.Chess;
using ChessApplication.Generic;
using ChessApplication.Exceptions;

namespace ChessApplication
{
    static class Screen
    {
        public static void GameScreen(ChessGame chess)
        {
            GameBoardScreen(chess.GameB);
            Console.WriteLine();
            GetCapturedPieces(chess);
            Console.WriteLine("Turn: " + chess.Turn);
            if (!chess.Finish)
            {
                Console.WriteLine("Waiting move: " + chess.CurrentPlayer);
                if (chess.Check)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You are in Check!");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Checkmate!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Winner: " + chess.CurrentPlayer);
                Console.ResetColor();
            }
        }

        public static void GameBoardScreen(GameBoard gBoard)
        {
            ConsoleColor StartBackgroundBoardG = ConsoleColor.Red;
            ConsoleColor BackgroundBoardG = ConsoleColor.Red;

            CreateEdge("           Chess Game        ", ConsoleColor.Yellow, ConsoleColor.Black);
            CreateEdge("    a  b  c  d  e  f  g  h   ");
            for (int i = 0; i < gBoard.Line; i++)
            {
                CreateEdge(" " + (8 - i) + " ",ConsoleColor.Green , ConsoleColor.Black, false);
                Console.BackgroundColor = StartBackgroundBoardG;
                for (int j = 0; j < gBoard.Column; j++)
                {
                    GameBoardPieces(gBoard.piece(i,j));
                    BackgroundChange(BackgroundBoardG, out BackgroundBoardG);
                    Console.BackgroundColor = BackgroundBoardG;
                }
                CreateEdge(" " + (8 - i) + " ");
                BackgroundChange(StartBackgroundBoardG, out StartBackgroundBoardG);
                BackgroundBoardG = StartBackgroundBoardG;
            }

            CreateEdge("    a  b  c  d  e  f  g  h   ");
        }
        public static void GameBoardScreen(GameBoard gBoard, bool[,] posibleMoves)
        {
            ConsoleColor StartBackgroundBoardG = ConsoleColor.Red;
            ConsoleColor BackgroundBoardG = ConsoleColor.Red;

            CreateEdge("           Chess Game        ", ConsoleColor.Yellow, ConsoleColor.Black);
            CreateEdge("    a  b  c  d  e  f  g  h   ");
            for (int i = 0; i < gBoard.Line; i++)
            {
                CreateEdge(" " + (8 - i) + " ", ConsoleColor.Green, ConsoleColor.Black, false);
                Console.BackgroundColor = StartBackgroundBoardG;
                for (int j = 0; j < gBoard.Column; j++)
                {
                    if (posibleMoves[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    GameBoardPieces(gBoard.piece(i, j));
                    BackgroundChange(BackgroundBoardG, out BackgroundBoardG);

                    Console.BackgroundColor = BackgroundBoardG;
                }
                CreateEdge(" " + (8 - i) + " ");
                BackgroundChange(StartBackgroundBoardG, out StartBackgroundBoardG);
                BackgroundBoardG = StartBackgroundBoardG;
            }

            CreateEdge("    a  b  c  d  e  f  g  h   ");
        }
        static void GameBoardPieces(Piece p)
        {
            if(p == null)
            {
                Console.Write("   ");
            }
            else
            {
                if(p.Color == Color.White)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(p);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(p);
                }
                Console.ResetColor();
            }
        }
        static void CreateEdge(string s, ConsoleColor c = ConsoleColor.Green, ConsoleColor b = ConsoleColor.Black, bool nextLine = true)
        {
            Console.BackgroundColor = b;
            Console.ForegroundColor = c;
            Console.Write(s);
            Console.ResetColor();
            if (nextLine)
            {
                Console.WriteLine();
            }
        }
        static void BackgroundChange(ConsoleColor b, out ConsoleColor c)
        {
            if(b == ConsoleColor.Red)
            {
                c = ConsoleColor.DarkRed;
            }
            else
            {
                c = ConsoleColor.Red;
            }
        }
        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            if(s.Length != 2)
            {
                throw new GameBoardExceptions("Invalid position!");
            }
            char column = s[0];
            int line;
            if (!int.TryParse(s[1] + "", out line))
            {
                throw new GameBoardExceptions("Invalid position!");
            }
            return new ChessPosition(column, line);
        }
        static void GetCapturedPieces(ChessGame chess)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Captured Pieces");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("White: ");
            GetHashPieces(chess.CapturedPieces(Color.White));
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Black: ");
            GetHashPieces(chess.CapturedPieces(Color.Black));
            Console.WriteLine();
            Console.ResetColor();

        }
        public static void GetHashPieces(HashSet<Piece> hash)
        {
            Console.Write("[");
            foreach(Piece p in hash)
            {
                Console.Write(p);
            }
            Console.WriteLine("]");
        }
    }
}
