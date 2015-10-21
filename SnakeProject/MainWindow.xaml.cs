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
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        Image tail;
        string direction = "";
        public MainWindow()
        {
            InitializeComponent();
            /*
            tail = new Image();
            tail.Margin = new Thickness(30, 150, 0, 0);
            tail.Height = 10;
            tail.Width = 10;
            tail.IsVisible = Visibility.Visible;
            */
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;

            this.KeyUp += new KeyEventHandler(OnButtonKeyDown);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Head.Source = new BitmapImage(new Uri(@"pack://application:,,,/"
              + Assembly.GetExecutingAssembly().GetName().Name
              + ";component/"
              + "White.png", UriKind.Absolute));

            tail.Source = new BitmapImage(new Uri(@"pack://application:,,,/"
              + Assembly.GetExecutingAssembly().GetName().Name
              + ";component/"
              + "White.png", UriKind.Absolute));

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            switch (direction)
            {
                case "down":
                    if (Head.Margin.Top < 490)
                    {
                        Head.Margin = new Thickness(Head.Margin.Left, Head.Margin.Top + 10, 0, 0);
                    }
                    break;

                case "up":
                    if (Head.Margin.Top >= 10)
                    {
                        Head.Margin = new Thickness(Head.Margin.Left, Head.Margin.Top -10, 0, 0);
                    }
                    break;

                case "left":
                    if (Head.Margin.Left >= 10)
                    {
                        Head.Margin = new Thickness(Head.Margin.Left - 10, Head.Margin.Top, 0, 0);
                    }
                    break;

                case "right":
                    if (Head.Margin.Left < 490)
                    {
                        Head.Margin = new Thickness(Head.Margin.Left + 10, Head.Margin.Top, 0, 0);
                    }
                    break;
                default:
                    if (Head.Margin.Left < 490)
                    {
                        Head.Margin = new Thickness(Head.Margin.Left + 10, Head.Margin.Top, 0, 0);
                    }
                    break;
            }
            
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down:
                    if (direction != "down") {
                        direction = "down";
                    }
                    break;
                case Key.Up:
                    if (direction != "up")
                    {
                        direction = "up";
                    }
                    break;
                case Key.Left:
                    if (direction != "left")
                    {
                        direction = "left";
                    }
                    break;
                case Key.Right:
                    if (direction != "right")
                    {
                        direction = "right";
                    }
                    break;
            }

        }
    }
}
