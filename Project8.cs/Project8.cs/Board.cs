using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project8.cs
{
    public enum PieceColor { empty, red, black };
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

        //PieceColor currentTurn = new PieceColor();
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

        public PieceColor GetColor(int x, int y)
        {
            return _grid[x, y];
        }
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
                    return true;
                }
                 
            }
            return false;
        }
        public void SwitchTurns()
        {
            if (currentTurn == PieceColor.red) currentTurn = PieceColor.black;
            else currentTurn = PieceColor.red;
            }
        
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




