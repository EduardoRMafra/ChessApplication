using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApplication.Generic
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtMovements { get; protected set; }
        public GameBoard GameB { get; protected set; }
    
        public Piece(GameBoard board, Color color)
        {
            Position = null;
            GameB = board;
            Color = color;
            QtMovements = 0;
        }
        public void IncreaseQtMoves()
        {
            QtMovements++;
        }
        public void DecreaseQtMoves()
        {
            QtMovements--;
        }
        public bool HasPosibleMoves()
        {
            bool[,] mat = PosibleMoves();
            foreach(bool p in mat)
            {
                if(p == true)
                {
                    return true;
                }
            }
            return false;
        }
        public bool PosibleMove(Position pos)
        {
            return PosibleMoves()[pos.Line, pos.Column];
        }
        public abstract bool[,] PosibleMoves();
    }
}
