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
        public int SnakeSquareSizePx;
        public GameLaw(int tableSize)
        {
            board = new int[tableSize, tableSize];
            // 1 - snake
            // 0 - null
            // 2 - food
            // 3 - head
            board[tableSize / 2, tableSize / 2] = 3;
            Food();
            board[FoodY, FoodX] = 2;

        }

        public void GameTick()
        {
            for (int y = 0; y < board.GetLongLength(0) - 1; y++)
            {
                for (int x = 0; x < board.GetLongLength(0) - 1; x++)
                {
                    if (Direction == 1)
                    {
                        if (board[y, x] == 3 && y != 0)
                        {
                            board[y, x] = 0;
                            board[y - 1, x] = 3;
                            goto nestedLoopBreak;
                        }

                    }
                    if (Direction == 2)
                    {
                        if (board[y, x] == 3 && x != 19)
                        {
                            board[y, x] = 0;
                            board[y, x + 1] = 3;
                            goto nestedLoopBreak;
                        }

                    }
                    if (Direction == 3)
                    {
                        if (board[y, x] == 3 && y != 19)
                        {
                            board[y, x] = 0;
                            board[y + 1, x] = 3;
                            goto nestedLoopBreak;
                        }

                    }
                    if (Direction == 4)
                    {
                        if (board[y, x] == 3 && x != 0)
                        {
                            board[y, x] = 0;
                            board[y, x - 1] = 3;
                            goto nestedLoopBreak;
                        }

                    }
                }

            }
        nestedLoopBreak:
            var z = 1;
            NewFoodPosition();

        }

        public void NewFoodPosition()
        {
            int isThereFood = 0;
            for (int y = 0; y < board.GetLongLength(0) - 1; y++)
            {
                for (int x = 0; x < board.GetLongLength(0) - 1; x++)
                {
                    if (board[y, x] == 2)
                    {
                        isThereFood = 1;

                    }

                }
            }
            if (isThereFood == 0)
            {
                Food();
                board[FoodY, FoodX] = 2;

            }
        }

        public int FoodX = 0;
        public int FoodY = 0;

        public void Food()
        {
            Random random = new Random();
            Random random2 = new Random();

            int maxX = (int)board.GetLength(0);
            int maxY = (int)board.GetLength(0);
            int foodX = random.Next(0, maxX);
            int foodY = random2.Next(0, maxY);


            if (board[foodY, foodX] == 3 || board[foodY, foodX] == 1)
            {
                Food();
            }

            FoodX = foodX;
            FoodY = foodY;
        }
    }
}
