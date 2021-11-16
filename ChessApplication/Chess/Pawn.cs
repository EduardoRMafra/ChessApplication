using ChessApplication.Generic;

namespace ChessApplication.Chess
{
    class Pawn : Piece
    {
        public Pawn(GameBoard gameBoard, Color color) : base(gameBoard, color)
        {

        }

        public override string ToString()
        {
            return " P ";
        }
    }
}
