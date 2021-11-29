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
            pos.SetPosition(Position.Line - 1, Position.Column);
            while (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameB.piece(pos) != null)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }
            //baixo
            pos.SetPosition(Position.Line + 1, Position.Column);
            while (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameB.piece(pos) != null)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }
            //esquerda
            pos.SetPosition(Position.Line, Position.Column - 1);
            while (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameB.piece(pos) != null)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }
            //direita
            pos.SetPosition(Position.Line, Position.Column + 1);
            while (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameB.piece(pos) != null)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }
            return mat;
        }
        public override string ToString()
        {
            return " H ";
        }
    }
}
