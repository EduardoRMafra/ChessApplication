using ChessApplication.Generic;

namespace ChessApplication.Chess
{
    class Queen : Piece
    {
        public Queen(GameBoard gameBoard, Color color) : base(gameBoard, color)
        {

        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
