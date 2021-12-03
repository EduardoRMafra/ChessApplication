using ChessApplication.Generic;

namespace ChessApplication.Chess
{
    class King : Piece
    {
        ChessGame Chess;
        public King(GameBoard gameBoard, Color color, ChessGame chess) : base(gameBoard, color)
        {
            Chess = chess;
        }
        bool canMove(Position pos)
        {
            Piece p = GameB.piece(pos);
            return p == null || p.Color != Color;
        }
        //verifica se é possivel fazer o roque
        bool canCastling(Position pos)
        {
            Piece p = GameB.piece(pos);
            return p != null && p is Tower && p.Color == Color && p.QtMovements == 0;
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
            //jogada especial roque
            if(QtMovements == 0 && !Chess.Check)
            {
                //pequeno
                Position PosTower = new Position(Position.Line, Position.Column + 3);
                if (canCastling(PosTower))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);

                    if(GameB.piece(p1) == null && GameB.piece(p2) == null)
                    {
                        mat[Position.Line, Position.Column + 2] = true;
                    }
                }
                //grande
                Position PosTower2 = new Position(Position.Line, Position.Column - 4);
                if (canCastling(PosTower2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);

                    if (GameB.piece(p1) == null && GameB.piece(p2) == null && GameB.piece(p3) == null)
                    {
                        mat[Position.Line, Position.Column - 2] = true;
                    }
                }
            }
            return mat;
        }
        public override string ToString()
        {
            return " K ";
        }
    }
}
