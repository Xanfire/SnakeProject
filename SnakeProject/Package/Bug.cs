using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SnakeProject
{
    class Bug : Image
    {
        Random R;
        public Bug()
        {
            this.Height = 10;
            this.Width = 10;
            this.Source = new BitmapImage(new Uri(@"pack://application:,,,/"
              + Assembly.GetExecutingAssembly().GetName().Name
              + ";component/"
              + "Bug.png", UriKind.Absolute));
            this.R = new Random();
            this.Margin = new Thickness(R.Next(1, 50)*10, R.Next(1, 50) * 10, 0, 0);
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
        }
    }
}
