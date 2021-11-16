using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApplication.Chess;
using ChessApplication.Generic;

namespace ChessApplication
{
    static class Screen
    {
        public static void GameScreen(ChessGame chess)
        {
            GameBoardScreen(chess.BoardG);
        }

        public static void GameBoardScreen(GameBoard gBoard)
        {
            ConsoleColor StartBackgroundBoardG = ConsoleColor.Red;
            ConsoleColor BackgroundBoardG = ConsoleColor.Red;

            CreateEdge("          Chess Game        ", ConsoleColor.Black, ConsoleColor.Yellow);
            CreateEdge("   a  b  c  d  e  f  g  h   ");
            for (int i = 0; i < gBoard.Line; i++)
            {
                CreateEdge(8 - i + " ",ConsoleColor.Green , ConsoleColor.White, false);
                Console.BackgroundColor = StartBackgroundBoardG;
                for (int j = 0; j < gBoard.Column; j++)
                {
                    GameBoardPieces(gBoard.piece(i,j));
                    BackgroundChange(BackgroundBoardG, out BackgroundBoardG);
                    Console.BackgroundColor = BackgroundBoardG;
                }
                CreateEdge(8 - i + " ");
                BackgroundChange(StartBackgroundBoardG, out StartBackgroundBoardG);
                BackgroundBoardG = StartBackgroundBoardG;
            }

            CreateEdge("   a  b  c  d  e  f  g  h   ");
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
        static void CreateEdge(string s, ConsoleColor c = ConsoleColor.Green, ConsoleColor b = ConsoleColor.White, bool nextLine = true)
        {
            Console.BackgroundColor = b;
            Console.ForegroundColor = c;
            Console.Write(s);
            Console.ResetColor();
            if (nextLine)
            {
                //Conserta um bug que mesmo resetando a cor para o padrão, ao mudar o tamanho da janela o fundo da esquerda ficava totalmente branco
                Console.WriteLine("|");
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
    }
}
