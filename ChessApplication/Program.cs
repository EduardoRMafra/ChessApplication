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
                    Chess.InitialPositionIsValid(initial);

                    bool[,] posiblePosition = Chess.GameB.piece(initial).PosibleMoves();
                    Console.Clear();
                    
                    Screen.GameBoardScreen(Chess.GameB, posiblePosition);
                    Console.WriteLine();

                    Console.Write("Destination Position: ");
                    Position destination = Screen.ReadChessPosition().toPosision();
                    Chess.DestinationPositionIsValid(initial, destination);

                    Chess.MakeMovement(initial, destination);
                
                }
                catch(GameBoardExceptions e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Screen.GameScreen(Chess);
            Console.WriteLine();
            Console.WriteLine("O jogador " + " venceu!");
        }
    }
}
