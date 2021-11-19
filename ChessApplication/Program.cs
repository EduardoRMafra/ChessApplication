using System;
using ChessApplication.Chess;
using ChessApplication.Generic;
using ChessApplication.Exceptions;

namespace ChessApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessGame Chess = new ChessGame();

            while (!Chess.Finish)
            {
                try
                {
                    Console.Clear();
                    Screen.GameScreen(Chess);

                    Console.WriteLine();

                    Console.Write("Initial Position: ");
                    Position initial = Screen.ReadChessPosition().toPosision();
                    Console.Clear();
                    
                    Screen.GameScreen(Chess);
                    Console.WriteLine();

                    Console.Write("Destination Position: ");
                    Position destination = Screen.ReadChessPosition().toPosision();

                    Chess.MovePiece(initial, destination);
                
                }
                catch(GameBoardExceptions e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
