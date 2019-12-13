using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project8.cs
{
    public enum PieceColor { empty, red, black };
    /// <summary>
    /// This class represents the connect 4 board.
    /// </summary>
    class Board {

        private const int row = 6;
        private const int column = 7;

        PieceColor currentTurn;
        PieceColor[,] _grid;

        public Board()
        {
            _grid = new PieceColor[6,7];
            currentTurn = PieceColor.red;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    _grid[i, j] = PieceColor.empty;
                }
            }
        }

        /// <summary>
        /// gets the value of the current turn field
        /// </summary>
        public PieceColor Turn
        {
            get
            {
                return currentTurn;
            }
            set
            {
                currentTurn = value;
            }
        }
        /// <summary>
        ///  returns the value at position [x,y] in the field array
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public PieceColor GetColor(int x, int y)
        {
            return _grid[x, y];
        }
        /// <summary>
        ///  returns whether the given player has four in a row, column, or diagonal
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool IsWinner(PieceColor player)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column -3; j++)
                {
                    if (_grid[i, j] == PieceColor.empty)
                    {
                        continue;

                    }
                    if (_grid[i, j] == _grid[i, j + 1] && _grid[i, j] == _grid[i, j + 2] && _grid[i, j] == _grid[i, j + 3] && _grid[i, j] == player)
                    {
                        return true;
                    }
                }
            }
            for (int i = 0; i < row -3; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (_grid[i, j] == PieceColor.empty)
                    {
                        continue;

                    }
                    if (_grid[i, j] == _grid[i + 1, j] && _grid[i, j] == _grid[i + 2, j] && _grid[i, j] == _grid[i + 3, j] && _grid[i, j] == player)
                    {
                        return true;
                    }
                }
            }
            for (int i = 0; i < row - 3; i++)
            {
                for (int j = 0; j < column - 3; j++)
                {
                    if (_grid[i, j] == PieceColor.empty)
                    {
                        continue;

                    }
                    if (_grid[i, j] == _grid[i + 1, j + 1] && _grid[i, j] == _grid[i + 2, j + 2] && _grid[i, j] == _grid[i + 3, j + 3] && _grid[i, j] == player)
                    {
                        return true;
                    }
                }
            }
            for (int i = row - 1; i > row-3; i--)
            {
                for (int j = 0; j < column - 3; j++)
                {
                    if (_grid[i, j] == PieceColor.empty)
                    {
                        continue;

                    }
                    if (_grid[i, j] == _grid[i - 1, j + 1] && _grid[i, j] == _grid[i - 2, j + 2] && _grid[i, j] == _grid[i - 3, j + 3] && _grid[i, j] == player)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// returns whether the board is full
        /// </summary>
        /// <returns></returns>
        public bool CheckTie()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (_grid[i, j] == PieceColor.empty)
                    {
                        return false;
                    }
                    
                }
                 
            }
            return true;
        }
        /// <summary>
        /// switches the turn field between (from red to black or black to red)
        /// </summary>
        public void SwitchTurns()
        {
            if (currentTurn == PieceColor.red) currentTurn = PieceColor.black;
            else currentTurn = PieceColor.red;
        }
        
        /// <summary>
        /// determines if player can make move
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        private bool IsValid(int col)
        {
            if (_grid[0, col] == PieceColor.empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// steps through the rows when making the moves 
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public int getRow(int col)
        {
            for (int i = row - 1; i >= 0; i--)
            {
                if (_grid[i, col] == PieceColor.empty)
                {
                    return i;
                }
               

            }
            return -1;
        }
        /// <summary>
        ///  drops a piece of the current turn color into the given column. Returns whether the move was successful (false if the column was already full, and true otherwise).
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool Move(int col)
        {
            int row1 = getRow(col);

            if (IsValid(col))
            {
                _grid[row1, col] = currentTurn;
                return true;
            }
            else
            {
                return false;
            }

        }
   }
}




