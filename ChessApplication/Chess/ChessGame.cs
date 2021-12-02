﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApplication.Generic;
using ChessApplication.Exceptions;

namespace ChessApplication.Chess
{
    class ChessGame
    {
        public GameBoard GameB { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finish { get; private set; }
        public bool Check { get; private set; }
        HashSet<Piece> Pieces;
        HashSet<Piece> Captured;

        public ChessGame()
        {
            GameB = new GameBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finish = false;
            Check = false;

            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PiecesToPlace();
        }
        Piece MovePiece(Position initial, Position destination)
        {
            Piece p = GameB.RemovePiece(initial);
            p.IncreaseQtMoves();
            Piece capturedPiece = GameB.RemovePiece(destination);
            GameB.PieceToPlace(p, destination);
            if(capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
            return capturedPiece;
        }
        public void UndoMove(Position initial, Position destination,Piece capturedPiece)
        {
            Piece p = GameB.RemovePiece(destination);
            p.DecreaseQtMoves();
            if(capturedPiece != null)
            {
                GameB.PieceToPlace(capturedPiece,destination);
                Captured.Remove(capturedPiece);
            }
            GameB.PieceToPlace(p, initial);
        }
        public void MakeMovement(Position initial, Position destination)
        {
            Piece capturedPiece = MovePiece(initial, destination);

            if (IsCheck(CurrentPlayer))
            {
                UndoMove(initial, destination, capturedPiece);
                throw new GameBoardExceptions("You can't put yourself in check!");
            }

            Piece p = GameB.piece(destination);

            if (IsCheck(EnemyColor(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (IsCheckMate(EnemyColor(CurrentPlayer)))
            {
                Finish = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
        }
        public void InitialPositionIsValid(Position pos)
        {
            GameB.ValidPosition(pos);

            if (GameB.piece(pos) == null)
            {
                throw new GameBoardExceptions("Has no piece in this position!");
            }
            if (CurrentPlayer != GameB.piece(pos).Color)
            {
                throw new GameBoardExceptions("This piece isn't yours!");
            }
            if (!GameB.piece(pos).HasPosibleMoves())
            {
                throw new GameBoardExceptions("Has no posible moves for this piece!");
            }
        }
        public void DestinationPositionIsValid(Position Initial, Position Destination)
        {
            if (!GameB.piece(Initial).PosibleMove(Destination))
            {
                throw new GameBoardExceptions("Invalid position!");
            }
        }
        void ChangePlayer()
        {
            if(CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }
        Color EnemyColor(Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            return Color.White;
        }
        Piece King(Color color)
        {
            foreach(Piece p in PiecesInGame(color))
            {
                if(p is King)
                {
                    return p;
                }
            }
            return null;
        }
        bool IsCheck(Color color)
        {
            Piece K = King(color);
            if(K == null)
            {
                throw new GameBoardExceptions("This color king dosn't exist!");
            }
            foreach(Piece p in PiecesInGame(EnemyColor(color)))
            {
                bool[,] mat = p.PosibleMoves();
                if(mat[K.Position.Line, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsCheckMate(Color color)
        {
            if (!IsCheck(color))
            {
                return false;
            }
            foreach(Piece p in PiecesInGame(color))
            {
                bool[,] mat = p.PosibleMoves();
                for(int i = 0;i < GameB.Line; i++)
                {
                    for(int j = 0; j < GameB.Column; j++)
                    {
                        if (mat[i, j])
                        {
                            Position initial = p.Position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = MovePiece(initial, destination);
                            bool isCheck = IsCheck(color);
                            UndoMove(initial, destination, capturedPiece);
                            if (!isCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        //verifica todas as peças capturadas de uma determinada cor
        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        //verifica todas as peças em jogo
        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }
        public void PutNewPieces(char c, int l, Piece p)
        {
            GameB.PieceToPlace(p, new ChessPosition(c, l).toPosision());
            Pieces.Add(p);
        }
        void PiecesToPlace()
        {
            //Peças Brancas
            PutNewPieces('a', 1, new Tower(GameB, Color.White));
            PutNewPieces('b', 1, new Horse(GameB, Color.White));
            PutNewPieces('c', 1, new Bishop(GameB, Color.White));
            PutNewPieces('d', 1, new Queen(GameB, Color.White));
            PutNewPieces('e', 1, new King(GameB, Color.White));
            PutNewPieces('f', 1, new Bishop(GameB, Color.White));
            PutNewPieces('g', 1, new Horse(GameB, Color.White));
            PutNewPieces('h', 1, new Tower(GameB, Color.White));
            PutNewPieces('a', 2, new Pawn(GameB, Color.White, this));
            PutNewPieces('b', 2, new Pawn(GameB, Color.White, this));
            PutNewPieces('c', 2, new Pawn(GameB, Color.White, this));
            PutNewPieces('d', 2, new Pawn(GameB, Color.White, this));
            PutNewPieces('e', 2, new Pawn(GameB, Color.White, this));
            PutNewPieces('f', 2, new Pawn(GameB, Color.White, this));
            PutNewPieces('g', 2, new Pawn(GameB, Color.White, this));
            PutNewPieces('h', 2, new Pawn(GameB, Color.White, this));
            //Peças Pretas
            PutNewPieces('a', 8, new Tower(GameB, Color.Black));
            PutNewPieces('b', 8, new Horse(GameB, Color.Black));
            PutNewPieces('c', 8, new Bishop(GameB, Color.Black));
            PutNewPieces('d', 8, new Queen(GameB, Color.Black));
            PutNewPieces('e', 8, new King(GameB, Color.Black));
            PutNewPieces('f', 8, new Bishop(GameB, Color.Black));
            PutNewPieces('g', 8, new Horse(GameB, Color.Black));
            PutNewPieces('h', 8, new Tower(GameB, Color.Black));
            PutNewPieces('a', 7, new Pawn(GameB, Color.Black, this));
            PutNewPieces('b', 7, new Pawn(GameB, Color.Black, this));
            PutNewPieces('c', 7, new Pawn(GameB, Color.Black, this));
            PutNewPieces('d', 7, new Pawn(GameB, Color.Black, this));
            PutNewPieces('e', 7, new Pawn(GameB, Color.Black, this));
            PutNewPieces('f', 7, new Pawn(GameB, Color.Black, this));
            PutNewPieces('g', 7, new Pawn(GameB, Color.Black, this));
            PutNewPieces('h', 7, new Pawn(GameB, Color.Black, this));
        }
    }
}
