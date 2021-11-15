using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApplication.Exceptions;

namespace ChessApplication.Generic
{
    class GameBoard
    {
        public int Line { get; private set; }
        public int Column { get; private set; }

        Piece[,] Pieces;

        public GameBoard(int line, int column)
        {
            Line = line;
            Column = column;
            Pieces = new Piece[Line, Column];
        }

        //Piece com sobrecarga
        public Piece piece(int l,int c)
        {
            return Pieces[l, c];
        }
        public Piece piece(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }
        public bool HasPiece(Position pos)
        {
            ValidPosition(pos);
            return (piece(pos) != null);
        }
        public void PieceToPlace(Piece p, Position pos)
        {
            if (HasPiece(pos))
            {
                throw new GameBoardExceptions("Has a piece on this place");
            }
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        bool PositionValided(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= Line || pos.Column < 0 || pos.Column >= Column)
            {
                return false;
            }
            return true;
        }
        void ValidPosition(Position pos)
        {
            if (!PositionValided(pos))
            {
                throw new GameBoardExceptions("Invalid Position!");
            }
        }
    }
}
