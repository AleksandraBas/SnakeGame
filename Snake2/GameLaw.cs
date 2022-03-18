using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2
{
    public class GameLaw
    {
        public int Direction;
        public int[,] board;
        public GameLaw(int tableSize)
        {
            board = new int[tableSize, tableSize];
            // 1 - snake
            // 0 - null
            // 2 - food
            // 3 - head
            board[tableSize / 2, tableSize / 2] = 3;
        }

        public void GameTick()
        {
            for (int y = 0; y < board.GetLongLength(0) - 1; y++)
            {
                for (int x = 0; x < board.GetLongLength(0) - 1; x++)
                {
                    if (Direction == 1)
                    {
                        if (board[y,x] == 3 && y != 0)
                        {
                            board[y, x] = 0;
                            board[y - 1, x] = 3;
                            return;
                        }
                       
                    }
                    if (Direction == 2)
                    {
                        if (board[y, x] == 3 && x!=19)
                        {
                            board[y, x] = 0;
                            board[y, x + 1] = 3;
                            return;
                        }
                       
                    }
                    if (Direction == 3)
                    {
                        if (board[y, x] == 3 && y != 19)
                        {
                            board[y, x] = 0;
                            board[y + 1, x] = 3;
                            return;
                        }
                        
                    }
                    if (Direction == 4)
                    {
                        if (board[y, x] == 3 && x != 0)
                        {
                            board[y, x] = 0;
                            board[y, x - 1] = 3;
                            return;
                        }
                    
                    }
                }

            }
            // dir -> arr
        }

    }
}
