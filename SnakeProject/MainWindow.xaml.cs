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

            this.InitSnake();            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            snake.Move();
            BodyCollisionControl();
            if (EatControl())
            {
                //E' necessario per far si che non venga creato un nuovo insetto
                //sopra al precedente
                Thickness xPoint = bug.Margin;

                SnakeGrid.Children.Remove(bug);

                snake.Stretch();            
                SnakeGrid.Children.Add(snake[snake.Count - 1]);

                {                 
                    bug = new Bug();                       
                } while (EatControl() && bug.Margin == xPoint);

                SnakeGrid.Children.Add(bug);
                Score.Content = "Score: " + snake.Score;
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

        private void BodyCollisionControl()
        {
            for (int i = 1; i < snake.Count; i++)
            {
                if (snake[0].Margin == snake[i].Margin)
                {
                    GameOver();
                }
            }
            if (snake[0].Margin.Top > 590 || snake[0].Margin.Top < 0 
                || snake[0].Margin.Left < 0 || snake[0].Margin.Left > 590)
            {
                GameOver();
            }
        }
        private bool EatControl()
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

        private void InitSnake()
        {
            snake = new Snake();
            for(int i = 0; i < snake.Count; i++)
            {
                SnakeGrid.Children.Add(snake[i]);
            }
            bug = new Bug();
            SnakeGrid.Children.Add(bug);
            Score.Content = "Score: 0";
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
            NewGame.IsEnabled = false;
        }

        private void GameOver()
        {
            MessageBox.Show("Game Over \n Score: " + snake.Score);
            timer.Stop();
            foreach (SnakeBody body in snake)
            {
                SnakeGrid.Children.Remove(body);
            }
            SnakeGrid.Children.Remove(bug);
            InitSnake();
            NewGame.IsEnabled = true;
        }
    }
}
