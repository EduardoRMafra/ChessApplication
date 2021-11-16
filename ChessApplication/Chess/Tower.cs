using ChessApplication.Generic;

namespace ChessApplication.Chess
{
    class Tower : Piece
    {
        public Tower(GameBoard gameBoard, Color color) : base(gameBoard,color)
        {

        }

        public override string ToString()
        {
            return " T ";
        }
    }
}
