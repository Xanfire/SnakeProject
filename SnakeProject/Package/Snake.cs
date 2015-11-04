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
        private Snake()
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
            // Lista delle vecchie posizioni del serpente
            List<Thickness> locPrec = new List<Thickness>();

            foreach(SnakeBody body in this)
            {
                locPrec.Add(body.Margin);
            }

            switch (this.Direction)
            {
                case 0:
                    if (this[0].Margin.Top < 640)
                    {
                        this[0].Margin = new Thickness(this[0].Margin.Left, this[0].Margin.Top + 10, 0, 0);

                        for (int i = 1; i < this.Count; i++)
                        {
                            this[i].Margin = locPrec[i-1];
                        }
                    }
                    break;

                case 1:
                    if (this[0].Margin.Top >= 10)
                    {
                        this[0].Margin = new Thickness(this[0].Margin.Left, this[0].Margin.Top - 10, 0, 0);

                        for (int i = 1; i < this.Count; i++)
                        {
                            this[i].Margin = locPrec[i-1];
                        }
                    }
                    break;

                case 2:
                    if (this[0].Margin.Left >= 10)
                    {
                        this[0].Margin = new Thickness(this[0].Margin.Left - 10, this[0].Margin.Top, 0, 0);

                        for (int i = 1; i < this.Count; i++)
                        {
                            this[i].Margin = locPrec[i-1];
                        }
                    }
                    break;

                case 3:
                    if (this[0].Margin.Left < 890)
                    {
                        this[0].Margin = new Thickness(this[0].Margin.Left + 10, this[0].Margin.Top, 0, 0);

                        for (int i = 1; i < this.Count; i++)
                        {
                            this[i].Margin = locPrec[i-1];
                        }
                    }
                    break;
            }
        }
    }
}
