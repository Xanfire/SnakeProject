using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SnakeProject
{
    class Snake : List<SnakeBody>
    {
        /// <summary>
        /// Indica la direzione:
        /// 0 = Giù; 1 = Su; 2 = Sinistra; 3 = Destra. 
        /// </summary>
        public int Direction { get; set; }
        public Snake()
        {
            this.Direction = 0;
        }

        public Snake(SnakeBody head)
            : this()
        {
            this.Add(head);
        }

        public void Allunga(SnakeBody body)
        {
            this.Add(body);
        }

        public void Move()
        {
            // Indica la posizione del pezzo di corpo precendente
            Thickness locPrec;
            switch (this.Direction)
            {
                case 0:
                    if (this[0].Margin.Top < 640)
                    {
                        this[0].Margin = new Thickness(this[0].Margin.Left, this[0].Margin.Top + 10, 0, 0);
                        locPrec = this[0].Margin;

                        foreach (SnakeBody body in this)
                        {
                            body.Margin = locPrec;
                            locPrec = body.Margin;
                        }
                    }
                    break;

                case 1:
                    if (this[0].Margin.Top >= 10)
                    {
                        this[0].Margin = new Thickness(this[0].Margin.Left, this[0].Margin.Top - 10, 0, 0);
                        locPrec = this[0].Margin;

                        foreach (SnakeBody body in this)
                        {
                            body.Margin = locPrec;
                            locPrec = body.Margin;
                        }
                    }
                    break;

                case 2:
                    if (this[0].Margin.Left >= 10)
                    {
                        this[0].Margin = new Thickness(this[0].Margin.Left - 10, this[0].Margin.Top, 0, 0);
                        locPrec = this[0].Margin;

                        foreach (SnakeBody body in this)
                        {
                            body.Margin = locPrec;
                            locPrec = body.Margin;
                        }
                    }
                    break;

                case 3:
                    if (this[0].Margin.Left < 890)
                    {
                        this[0].Margin = new Thickness(this[0].Margin.Left + 10, this[0].Margin.Top, 0, 0);
                        locPrec = this[0].Margin;

                        foreach (SnakeBody body in this)
                        {
                            body.Margin = locPrec;
                            locPrec = body.Margin;
                        }
                    }
                    break;
            }
        }
    }
}
