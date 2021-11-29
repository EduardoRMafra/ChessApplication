using ChessApplication.Generic;

namespace ChessApplication.Chess
{
    class King : Piece
    {
        public King(GameBoard gameBoard, Color color) : base(gameBoard, color)
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
            pos.SetPosition(Position.Line - 1, Position.Column);
            if (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //baixo
            pos.SetPosition(Position.Line + 1, Position.Column);
            if (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //esquerda
            pos.SetPosition(Position.Line, Position.Column - 1);
            if (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //direita
            pos.SetPosition(Position.Line, Position.Column + 1);
            if (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //diagonal cima esq
            pos.SetPosition(Position.Line - 1, Position.Column - 1);
            if (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //diagonal cima dir
            pos.SetPosition(Position.Line - 1, Position.Column + 1);
            if (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //diagonal baixo esq
            pos.SetPosition(Position.Line + 1, Position.Column - 1);
            if (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //diagonal baixo dir
            pos.SetPosition(Position.Line + 1, Position.Column + 1);
            if (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }
        public override string ToString()
        {
            return " K ";
        }
    }
}
