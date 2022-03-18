using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Snake2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          
        }

        public GameLaw gameLaw;
        public Display display;
        public void SetupTimer()
        {

            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.2);
            timer.Tick += SwitchSnakeGameText;
            timer.Tick += TickAndRedraw;
            timer.Start();


        }

        public static bool X = true;
        public void SwitchSnakeGameText(object sender, EventArgs e)
        {
            if (X)
            {
                SnakeGameLabel.HorizontalContentAlignment = HorizontalAlignment.Left;
                SnakeGameLabel.Content = "SNAKE";
            }
            else
            {
                SnakeGameLabel.HorizontalContentAlignment = HorizontalAlignment.Right;
                SnakeGameLabel.Content = "GAME";
            }
            X = !X;
        }

        public int TickCount = 0;
        public Rectangle rect;
        public void TickAndRedraw(object sender, EventArgs e)
        {
            gameLaw.GameTick();
            display.Render(gameLaw.board);
            
            

           /* if (rect == null)
            {
                rect = new Rectangle()
                {
                    Width = SnakeSquareSize,
                    Height = SnakeSquareSize,
                    Fill = Brushes.Green

                };
                GameArea.Children.Add(rect);
            }*/
          /*  Canvas.SetTop(rect, SnakeSquareSize * TickCount);
            Canvas.SetLeft(rect, SnakeSquareSize * TickCount);
            TickCount++;*/

        }

        public int SnakeSquareSize = 0;
        public int PreviousSnakeSquareSize = 0;
        private void DrawGameArea()
        {
            bool doneDrawingBackground = false;
            int nextX = 0, nextY = 0;
            int rowCounter = 0;
            bool nextIsOdd = false;

            while (doneDrawingBackground == false)
            {
                Rectangle rect = new Rectangle
                {
                    Width = SnakeSquareSize,
                    Height = SnakeSquareSize,
                    Fill = nextIsOdd ? Brushes.White : Brushes.AntiqueWhite
                };
                GameArea.Children.Add(rect);
                Canvas.SetTop(rect, nextY);
                Canvas.SetLeft(rect, nextX);

                nextIsOdd = !nextIsOdd;
                nextX += SnakeSquareSize;
                if (nextX >= GameArea.ActualWidth)
                {
                    nextX = 0;
                    nextY += SnakeSquareSize;
                    rowCounter++;
                    nextIsOdd = (rowCounter % 2 != 0);
                }

                if (nextY >= GameArea.ActualHeight)
                    doneDrawingBackground = true;
            }
        }
        private void DropGameArea()
        {
            bool doneDropingBackground = false;
            int nextX = 0, nextY = 0;
            int rowCounter = 0;
            bool nextIsOdd = false;

            while (doneDropingBackground == false)
            {
                Rectangle rect = new Rectangle
                {
                    Width = PreviousSnakeSquareSize,
                    Height = PreviousSnakeSquareSize,
                };
                GameArea.Children.Remove(rect);
                Canvas.SetTop(rect, nextY);
                Canvas.SetLeft(rect, nextX);

                nextIsOdd = !nextIsOdd;
                nextX += SnakeSquareSize;
                if (nextX >= GameArea.ActualWidth)
                {
                    nextX = 0;
                    nextY += SnakeSquareSize;
                    rowCounter++;
                    nextIsOdd = (rowCounter % 2 != 0);
                }

                if (nextY >= GameArea.ActualHeight)
                    doneDropingBackground = true;
            }
        }
        public void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    gameLaw.Direction = 1;
                    break;
                case Key.Right:
                    gameLaw.Direction = 2;
                    break;
                case Key.Down:
                    gameLaw.Direction = 3;
                    break;
                case Key.Left:
                    gameLaw.Direction = 4;
                    break;

            }
        }
        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (SizeComboBox.SelectedItem == null)
            {

            }
            if (SizeComboBox.SelectedItem != null)
            {
                if ((SizeComboBox.SelectedItem as ComboBoxItem).Content as string == "20 X 20")
                {
                    PreviousSnakeSquareSize = SnakeSquareSize;
                    SnakeSquareSize = 20;
                    DropGameArea();
                    DrawGameArea();
                    gameLaw = new GameLaw(20);
                    display = new Display(20, SnakeSquareSize, GameArea);
                }
                if ((SizeComboBox.SelectedItem as ComboBoxItem).Content as string == "25 X 25")
                {
                    PreviousSnakeSquareSize = SnakeSquareSize;
                    SnakeSquareSize = 16;
                    DropGameArea();
                    DrawGameArea();
                    gameLaw = new GameLaw(25);
                    display = new Display(25, SnakeSquareSize, GameArea);
                }
                if ((SizeComboBox.SelectedItem as ComboBoxItem).Content as string == "40 X 40")
                {
                    PreviousSnakeSquareSize = SnakeSquareSize;
                    SnakeSquareSize = 10;
                    DropGameArea();
                    DrawGameArea();
                    gameLaw = new GameLaw(40);
                    display = new Display(40, SnakeSquareSize, GameArea);

                }
                
                SetupTimer();
            
            }
        }

        private void TextBox_TextChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void SizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SpeedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
