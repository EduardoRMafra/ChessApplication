using ChessApplication.Generic;


namespace ChessApplication.Chess
{
    class Bishop : Piece
    {
        public Bishop(GameBoard gameBoard, Color color) : base(gameBoard, color)
        {

        }

        public override string ToString()
        {
            return "B";
        }
    }
}
