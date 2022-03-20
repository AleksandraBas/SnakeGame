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
        public int[,] Board;
        public int SnakeSquareSizePx;
        public List<SnakePart> SnakeParts;
        public GameLaw(int tableSize)
        {
            Board = new int[tableSize, tableSize];
            // 1 - snake
            // 0 - null
            // 2 - food
            // 3 - head
            Board[tableSize / 2, tableSize / 2] = 3;

            SnakePart snakePart = new SnakePart();
            SnakeParts = new List<SnakePart>();
            snakePart.X = tableSize / 2;
            snakePart.Y = tableSize / 2;
            SnakeParts.Add(snakePart);

            Food();
            Board[FoodY, FoodX] = 2;

        }
        public void GameTick()
        {
            for (int y = 0; y < Board.GetLongLength(0) - 1; y++)
            {
                for (int x = 0; x < Board.GetLongLength(0) - 1; x++)
                {
                    if (Direction == 1)
                    {
                        if (Board[y, x] == 3 && y != 0)
                        {
                            Board[y, x] = 0;
                            Board[y - 1, x] = 3;
                            if (SnakeParts.Count > 1)
                            {
                                for (int i = SnakeParts.Count - 1; i >= 1; i--)
                                {
                                    Board[SnakeParts[SnakeParts.Count - 1].Y, SnakeParts[SnakeParts.Count - 1].X] = 0;
                                    SnakeParts[i].X = SnakeParts[i - 1].X;
                                    SnakeParts[i].Y = SnakeParts[i - 1].Y;
                                    Board[SnakeParts[i].Y, SnakeParts[i].X] = 1;
                                }
                            }
                            SnakeParts[0].Y = y - 1;
                            SnakeParts[0].X = x;
                            goto nestedLoopBreak;
                        }

                    }
                    if (Direction == 2)
                    {
                        if (Board[y, x] == 3 && x != Board.GetLength(0))
                        {
                            Board[y, x] = 0;
                            Board[y, x + 1] = 3;
                            if (SnakeParts.Count > 1)
                            {
                                for (int i = SnakeParts.Count - 1; i >= 1; i--)
                                {
                                    Board[SnakeParts[SnakeParts.Count - 1].Y, SnakeParts[SnakeParts.Count - 1].X] = 0;
                                    SnakeParts[i].X = SnakeParts[i - 1].X;
                                    SnakeParts[i].Y = SnakeParts[i - 1].Y;
                                    Board[SnakeParts[i].Y, SnakeParts[i].X] = 1;
                                }
                            }
                            SnakeParts[0].Y = y;
                            SnakeParts[0].X = x + 1;
                            goto nestedLoopBreak;
                        }

                    }
                    if (Direction == 3)
                    {
                        if (Board[y, x] == 3 && y != Board.GetLength(0))
                        {
                            Board[y, x] = 0;
                            Board[y + 1, x] = 3;
                            if (SnakeParts.Count > 1)
                            {
                                for (int i = SnakeParts.Count - 1; i >= 1; i--)
                                {
                                    Board[SnakeParts[SnakeParts.Count - 1].Y, SnakeParts[SnakeParts.Count - 1].X] = 0;
                                    SnakeParts[i].X = SnakeParts[i - 1].X;
                                    SnakeParts[i].Y = SnakeParts[i - 1].Y;
                                    Board[SnakeParts[i].Y, SnakeParts[i].X] = 1;
                                }
                            }
                            SnakeParts[0].Y = y + 1;
                            SnakeParts[0].X = x;
                            goto nestedLoopBreak;
                        }

                    }
                    if (Direction == 4)
                    {
                        if (Board[y, x] == 3 && x != 0)
                        {
                            Board[y, x] = 0;
                            Board[y, x - 1] = 3;
                            if (SnakeParts.Count > 1)
                            {
                                for (int i = SnakeParts.Count - 1; i >= 1; i--)
                                {
                                    Board[SnakeParts[SnakeParts.Count - 1].Y, SnakeParts[SnakeParts.Count - 1].X] = 0;
                                    SnakeParts[i].X = SnakeParts[i - 1].X;
                                    SnakeParts[i].Y = SnakeParts[i - 1].Y;
                                    Board[SnakeParts[i].Y, SnakeParts[i].X] = 1;
                                }
                            }

                            SnakeParts[0].Y = y;
                            SnakeParts[0].X = x - 1;
                            goto nestedLoopBreak;
                        }

                    }
                }

            }
        nestedLoopBreak:
            NewFoodPosition();

        }


        public void EndOfGame()
        {
            //if head is getting on the body
            //when head hit the wall

        }

        public void MakeSnakeBigger()
        {
            SnakePart newSnakePart = new SnakePart();
            newSnakePart.X = 0;
            newSnakePart.Y = 0;
            if (SnakeParts.Count == 1)
            {
                if (Direction == 1)
                {
                    newSnakePart.X = SnakeParts[0].X;
                    newSnakePart.Y = SnakeParts[0].Y + 1;
                }
                if (Direction == 2)
                {
                    newSnakePart.X = SnakeParts[0].X - 1;
                    newSnakePart.Y = SnakeParts[0].Y;
                }
                if (Direction == 3)
                {
                    newSnakePart.X = SnakeParts[0].X;
                    newSnakePart.Y = SnakeParts[0].Y - 1;
                }
                if (Direction == 4)
                {
                    newSnakePart.X = SnakeParts[0].X + 1;
                    newSnakePart.Y = SnakeParts[0].Y;
                }
            }
            if (SnakeParts.Count > 1)
            {
                int previousX = SnakeParts[SnakeParts.Count - 1].X;
                int previousY = SnakeParts[SnakeParts.Count - 1].Y;
                int previousPreviousX = SnakeParts[SnakeParts.Count - 2].X;
                int previousPreviousY = SnakeParts[SnakeParts.Count - 2].Y;

                if (previousY < previousPreviousY)
                {
                    newSnakePart.X = previousX;
                    newSnakePart.Y = previousY - 1;
                }
                if (previousX < previousPreviousX)
                {
                    newSnakePart.X = previousX - 1;
                    newSnakePart.Y = previousY;
                }
                if (previousY > previousPreviousY)
                {
                    newSnakePart.X = previousX;
                    newSnakePart.Y = previousY + 1;
                }
                if (previousX > previousPreviousX)
                {
                    newSnakePart.X = previousX + 1;
                    newSnakePart.Y = previousY;
                }
            }
            SnakeParts.Add(newSnakePart);

        }
        public void NewFoodPosition()
        {
            bool isThereFood = false;
            for (int y = 0; y < Board.GetLongLength(0) - 1; y++)
            {
                for (int x = 0; x < Board.GetLongLength(0) - 1; x++)
                {
                    if (Board[y, x] == 2)
                    {
                        isThereFood = true;

                    }

                }
            }
            if (!isThereFood)
            {
                MakeSnakeBigger();
                Food();
                Board[FoodY, FoodX] = 2;

            }
        }

        public int FoodX = 0;
        public int FoodY = 0;

        public void Food()
        {
            Random random = new Random();
            Random random2 = new Random();

            int maxX = (int)Board.GetLength(0);
            int maxY = (int)Board.GetLength(0);
            int foodX = random.Next(0, maxX);
            int foodY = random2.Next(0, maxY);


            if (Board[foodY, foodX] == 3 || Board[foodY, foodX] == 1)
            {
                Food();
            }

            FoodX = foodX;
            FoodY = foodY;
        }
    }
}
