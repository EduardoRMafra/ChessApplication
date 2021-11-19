using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApplication.Generic
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtMovements { get; protected set; }
        public GameBoard Board { get; protected set; }
    
        public Piece(GameBoard board, Color color)
        {
            Position = null;
            Board = board;
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
    }
}
