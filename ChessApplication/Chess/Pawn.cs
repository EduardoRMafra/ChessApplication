using ChessApplication.Generic;

namespace ChessApplication.Chess
{
    class Pawn : Piece
    {
        ChessGame Chess;
        public Pawn(GameBoard gameBoard, Color color, ChessGame chess) : base(gameBoard, color)
        {
            Chess = chess;
        }
        bool CanMove(Position pos)
        {
            Piece p = GameB.piece(pos);
            return p == null || p.Color != Color;
        }
        bool HasEnemy(Position pos)
        {
            Piece p = GameB.piece(pos);
            return p != null && p.Color != Color;
        }
        bool Empty(Position pos)
        {
            return GameB.piece(pos) == null;
        }
        public override bool[,] PosibleMoves()
        {
            bool[,] mat = new bool[GameB.Line, GameB.Column];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                //movimentação normal
                pos.SetPosition(Position.Line - 1, Position.Column);
                if (GameB.PositionValided(pos) && Empty(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                //movimentação inicial
                pos.SetPosition(Position.Line - 2, Position.Column);
                if (GameB.PositionValided(pos) && Empty(pos) && QtMovements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                //capturar esquerda
                pos.SetPosition(Position.Line - 1, Position.Column - 1);
                if (GameB.PositionValided(pos) && HasEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                //capturar direita
                pos.SetPosition(Position.Line - 1, Position.Column + 1);
                if (GameB.PositionValided(pos) && HasEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                //en passant
                if(Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if(GameB.PositionValided(left) && HasEnemy(left) && GameB.piece(left) == Chess.vulnerableEnPassant)
                    {
                        mat[left.Line - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (GameB.PositionValided(right) && HasEnemy(right) && GameB.piece(right) == Chess.vulnerableEnPassant)
                    {
                        mat[right.Line - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                //movimentação normal
                pos.SetPosition(Position.Line + 1, Position.Column);
                if (GameB.PositionValided(pos) && Empty(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                //movimentação inicial
                pos.SetPosition(Position.Line + 2, Position.Column);
                if (GameB.PositionValided(pos) && Empty(pos) && QtMovements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                //capturar esquerda
                pos.SetPosition(Position.Line + 1, Position.Column - 1);
                if (GameB.PositionValided(pos) && HasEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                //capturar direita
                pos.SetPosition(Position.Line + 1, Position.Column + 1);
                if (GameB.PositionValided(pos) && HasEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                //en passant
                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (GameB.PositionValided(left) && HasEnemy(left) && GameB.piece(left) == Chess.vulnerableEnPassant)
                    {
                        mat[left.Line + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (GameB.PositionValided(right) && HasEnemy(right) && GameB.piece(right) == Chess.vulnerableEnPassant)
                    {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }
            }

            return mat;
        }
        public override string ToString()
        {
            return " P ";
        }
    }
}
