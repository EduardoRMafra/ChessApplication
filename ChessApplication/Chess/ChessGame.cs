using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApplication.Generic;

namespace ChessApplication.Chess
{
    class ChessGame
    {
        public GameBoard BoardG { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finish { get; private set; }
        public bool Check { get; private set; }
        HashSet<Piece> Pieces;
        HashSet<Piece> Captured;

        public ChessGame()
        {
            BoardG = new GameBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finish = false;
            Check = false;

            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
        }
    }
}
