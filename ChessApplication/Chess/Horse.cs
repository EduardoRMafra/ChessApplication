using ChessApplication.Generic;

namespace ChessApplication.Chess
{
    class Horse : Piece
    {
        public Horse(GameBoard gameBoard, Color color) : base(gameBoard, color)
        {

        }

        public override string ToString()
        {
            return "H";
        }
    }
}
