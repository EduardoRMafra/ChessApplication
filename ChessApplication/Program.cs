using System;
using ChessApplication.Chess;

namespace ChessApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessGame Chess = new ChessGame();

            if (!Chess.Finish)
            {
                Screen.GameScreen(Chess);
            }
        }
    }
}
