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
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Head.Source = new BitmapImage(new Uri(@"pack://application:,,,/"
              + Assembly.GetExecutingAssembly().GetName().Name
              + ";component/"
              + "White.png", UriKind.Absolute));

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Head.Margin.Left < 490)
            {
                Head.Margin = new Thickness(Head.Margin.Left + 10, Head.Margin.Top, 0, 0);
            }
        }
    }
}
