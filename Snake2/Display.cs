using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake2
{
    public class Display
    {
        Rectangle[,] displayRectangles;
        public Display(int numberOfRows, int pixelSize, Canvas gameArea)
        {
            displayRectangles = new Rectangle[numberOfRows, numberOfRows];
            for (int y = 0; y < numberOfRows; y++)
            {
                for (int x = 0; x < numberOfRows; x++)
                {
                    displayRectangles[y, x] = new Rectangle()
                    {
                        Width = pixelSize,
                        Height = pixelSize,
                        Fill = Brushes.Transparent

                    };
                    gameArea.Children.Add(displayRectangles[y,x]);
                    Canvas.SetTop(displayRectangles[y,x], pixelSize*y);
                    Canvas.SetLeft(displayRectangles[y, x], pixelSize*x);
                }
            }
        }

        public void Render(int[,] gameArray)
        {
            for (int y = 0; y < gameArray.GetLength(0) - 1; y++)
            {
                for (int x = 0; x < gameArray.GetLength(0) - 1; x++)
                {
                    switch (gameArray[y, x])
                    {
                        case 0:
                            displayRectangles[y, x].Fill = Brushes.Transparent;
                            break;
                        case 1:
                            displayRectangles[y, x].Fill = Brushes.LightGreen;
                            break;
                        case 2:
                            displayRectangles[y, x].Fill = Brushes.Red;
                            break;
                        case 3:
                            displayRectangles[y, x].Fill = Brushes.Green;
                            break;

                    }
                }

            }
        }

        private void InitializeGameArea()
        {
            
        }
    }
}
