using ChessApplication.Generic;

namespace ChessApplication.Chess
{
    class King : Piece
    {
        public King(GameBoard gameBoard, Color color) : base(gameBoard, color)
        {

        }

        public override string ToString()
        {
            return " K ";
        }
    }
}
