﻿using ChessApplication.Generic;


namespace ChessApplication.Chess
{
    class Bishop : Piece
    {
        public Bishop(GameBoard gameBoard, Color color) : base(gameBoard, color)
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

            //diagonal cima esq
            pos.SetPosition(Position.Line - 1, Position.Column - 1);
            while (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameB.piece(pos) != null)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
                pos.Column = pos.Column - 1;
            }
            //diagonal cima dir
            pos.SetPosition(Position.Line - 1, Position.Column + 1);
            while (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameB.piece(pos) != null)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
                pos.Column = pos.Column + 1;
            }
            //diagonal baixo esq
            pos.SetPosition(Position.Line + 1, Position.Column - 1);
            while (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameB.piece(pos) != null)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
                pos.Column = pos.Column - 1;
            }
            //diagonal baixo dir
            pos.SetPosition(Position.Line + 1, Position.Column + 1);
            while (GameB.PositionValided(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameB.piece(pos) != null)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
                pos.Column = pos.Column + 1;
            }
            return mat;
        }
        public override string ToString()
        {
            return " B ";
        }
    }
}
