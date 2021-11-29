using ChessApplication.Generic;

namespace ChessApplication.Chess
{
    class Horse : Piece
    {
        public Horse(GameBoard gameBoard, Color color) : base(gameBoard, color)
        {

        }
        bool canMove(Position pos)
        {
            Piece p = GameB.piece(pos);
            return p == null || p.Color != Color;
        }
        public override bool[,] PosibleMoves()
        {
            bool[,] mat = new bool[GameB.Line, GameB.Column];

            Position pos = new Position(0, 0);

            //cima
            pos.SetPosition(Position.Line - 2, Position.Column - 1);
            if(GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetPosition(Position.Line - 2, Position.Column + 1);
            if (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //baixo
            pos.SetPosition(Position.Line + 2, Position.Column - 1);
            if (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetPosition(Position.Line + 2, Position.Column + 1);
            if (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //esquerda
            pos.SetPosition(Position.Line - 1, Position.Column - 2);
            if (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetPosition(Position.Line + 1, Position.Column - 2);
            if (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //direita
            pos.SetPosition(Position.Line - 1, Position.Column + 2);
            if (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetPosition(Position.Line + 1, Position.Column + 2);
            if (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }
        public override string ToString()
        {
            return " H ";
        }
    }
}
