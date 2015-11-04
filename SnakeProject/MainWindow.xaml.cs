using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace SnakeProject
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        Snake snake;
        public MainWindow()
        {
            InitializeComponent();
            
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            snake = new Snake(new SnakeBody());
            snake.Allunga(new SnakeBody(new Thickness(40, 150, 0, 0)));
            snake.Allunga(new SnakeBody(new Thickness(30, 150, 0, 0)));
            snake.Allunga(new SnakeBody(new Thickness(20, 150, 0, 0)));
            MainGrid.Children.Add(snake[0]);
            MainGrid.Children.Add(snake[1]);
            MainGrid.Children.Add(snake[2]);
            MainGrid.Children.Add(snake[3]);

            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           snake.Move();       
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down:
                    if (snake.Direction != 0 && snake.Direction != 1)
                        snake.Direction = 0;
                    break;
                case Key.Up:
                    if (snake.Direction != 0 && snake.Direction != 1)
                        snake.Direction = 1;
                    break;
                case Key.Left:
                    if (snake.Direction != 2 && snake.Direction != 3)
                        snake.Direction = 2;
                    break;
                case Key.Right:
                    if (snake.Direction != 2 && snake.Direction != 3)
                        snake.Direction = 3;
                    break;
            }
        }
    }
}
