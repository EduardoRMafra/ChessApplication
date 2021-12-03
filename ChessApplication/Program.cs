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

            StartGame();

            void StartGame()
            {

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
                    catch (GameBoardExceptions e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                        Console.ResetColor();
                    }
                }

                char r = 'a';

                while (r != 'y' && r != 'n')
                {
                    try
                    {
                        Console.Clear();
                        Screen.GameScreen(Chess);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("The player " + Chess.CurrentPlayer + " wins!");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Do you wanna start a new game (y/n)? ");
                        Console.ResetColor();

                        if (!char.TryParse(Console.ReadLine().ToLower(), out r))
                        {
                            throw new GameBoardExceptions("invalid answer!");
                        }
                        if(r != 'y' && r != 'n')
                        {
                            throw new GameBoardExceptions("invalid answer!");
                        }
                    }
                    catch (GameBoardExceptions e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                        Console.ResetColor();
                    }
                }

                switch (r)
                {
                    case 'n':
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Bye Bye!");
                        Console.ResetColor();
                        break;
                    case 'y':
                        Chess = new ChessGame();
                        StartGame();
                        break;
                }
            }
        }
    }
}
