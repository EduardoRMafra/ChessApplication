using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApplication.Generic
{
    class GameBoard
    {
        public int Line { get;private set; }
        public int Column { get;private set; }

        Piece[,] Pieces;

        public GameBoard(int line,int column)
        {
            Line = line;
            Column = column;
            Pieces = new Piece[Line, Column];
        }
    }
}
