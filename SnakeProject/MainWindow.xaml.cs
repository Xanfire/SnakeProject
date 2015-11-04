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
        Bug bug;
        bool keyEnable = true;
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
            bug = new Bug();
            MainGrid.Children.Add(snake[0]);
            MainGrid.Children.Add(snake[1]);
            MainGrid.Children.Add(snake[2]);
            MainGrid.Children.Add(snake[3]);
            MainGrid.Children.Add(bug);

            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            snake.Move();
            if (Collision())
            {
                Thickness xPoint = bug.Margin;
                MainGrid.Children.Remove(bug);
                snake.Allunga(new SnakeBody(snake.Scarto));               
                MainGrid.Children.Add(snake[snake.Count - 1]);
                {                 
                    bug = new Bug();                       
                } while (Collision() && bug.Margin == xPoint);
                MainGrid.Children.Add(bug);
            }
            keyEnable = true;
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            if (keyEnable == true)
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
            keyEnable = false;
        }

        public bool Collision()
        {
            foreach (SnakeBody body in snake)
            {
                if (body.Margin == bug.Margin)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
