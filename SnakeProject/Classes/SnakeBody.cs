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
    class SnakeBody : Image
    {
        public SnakeBody() {
            this.Height = 10;
            this.Width = 10;
            this.Source = new BitmapImage(new Uri(@"pack://application:,,,/"
              + Assembly.GetExecutingAssembly().GetName().Name
              + ";component/"
              + "White.png", UriKind.Absolute));
            this.Margin = new Thickness(50, 150, 0, 0);
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
        }

        public SnakeBody(Thickness newMargin)
        {
            this.Height = 10;
            this.Width = 10;
            this.Source = new BitmapImage(new Uri(@"pack://application:,,,/"
              + Assembly.GetExecutingAssembly().GetName().Name
              + ";component/"
              + "White.png", UriKind.Absolute));
            this.Margin = newMargin;
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
        }
    }
}
