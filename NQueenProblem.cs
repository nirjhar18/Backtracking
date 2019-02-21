using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class NQueenProblem
    {
        static int N;
        public static void printBoard(int[,] board)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.Write("\n");
            }
        }


        //If it is not safe, we check next row with same column value
        //If it is safe, then we check next column starting with first row. But if that row already has a queen, then we move to next row
        //Basically every row can only have one queen
        public static bool IsSafe(int[,] board, int row, int col)
        {
            int i, j;

            //Check if the row has queen in it. Queen is represented by 1.
            for (i = 0; i < col; i++)
            {
                if (board[row, i] == 1)
                {
                    return false;
                }
            }

            //First check if the position you are trying to put in has a queen there or not.
            //Then subtract the row and column value to check diagonal value.
            // For example: If you are trying to add queen to board[1,2] then first check board[1,2] == 1 and next
            // check if board[0,1] == 1 has a queen.
            //Check if the column has queen in it. Also check if previous row has queen diagonally
            //Check for the same row that you are working on
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }

            //Check next row with same column has queen in it and also check if there is a queen
            // diagonally in the next row
            // For example: If you are trying to add queen to board[1,2] then first check board[1,2] == 1 and next
            // check if board[2,1] == 1 has a queen.
            for (i = row, j = col; j >= 0 && i < N; i++, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }
            return true;

        }

        public static Boolean theBoardSolver(int[,] board, int col)
        {
            N = board.GetLength(0);
            if (col >= N)
            {
                return true;
            }

            //Loop through rows and add queen
            for (int i = 0; i < N; i++)
            {
                if (IsSafe(board, i, col))
                {
                    board[i, col] = 1;

                    //Once you add queen to any position, you need to recursively solve the board by adding 1 to the column 
                    // in the board
                    //For example: If you add queen to board[2,1] ==1, then solve the board again with new board but column to be 2
                    // Then it will start from first row with new column.
                    if (theBoardSolver(board, col + 1))
                    {
                        return true;
                    }

                    // If the solution does not work, change the last updated value back to 0
                    board[i, col] = 0;
                }
            }
            return false;
        }

    }
}
