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
        /// <summary>
        /// Posizione che aveva l'ultimo elemento della coda
        /// prima del suo allungamento
        /// </summary>
        public Thickness Waste { get; set; }
        public int Score { get; set; } 
        public Snake()
        {
            this.Score = 0;
            this.Direction = 3;
            this.Add(new SnakeBody(new Thickness(80, 150, 0, 0)));
            this.Add(new SnakeBody(new Thickness(70, 150, 0, 0)));
            this.Add(new SnakeBody(new Thickness(60, 150, 0, 0)));
            this.Add(new SnakeBody(new Thickness(50, 150, 0, 0)));
        }

        public void Stretch()
        {
            this.Add(new SnakeBody(this.Waste));
            this.Score++;
        }

        public void Move()
        {
            // Lista delle vecchie posizioni del serpente
            List<Thickness> locPrec = new List<Thickness>();

            foreach (SnakeBody body in this)
            {
                locPrec.Add(body.Margin);
            }

            this.Waste = locPrec[locPrec.Count-1];

            switch (this.Direction)
            {
                case 0:
                        this[0].Margin = new Thickness(this[0].Margin.Left, this[0].Margin.Top + 10, 0, 0);

                        for (int i = 1; i < this.Count; i++)
                        {
                            this[i].Margin = locPrec[i - 1];
                        }
                    break;

                case 1:
                        this[0].Margin = new Thickness(this[0].Margin.Left, this[0].Margin.Top - 10, 0, 0);

                        for (int i = 1; i < this.Count; i++)
                        {
                            this[i].Margin = locPrec[i - 1];
                        }
                    break;

                case 2:
                        this[0].Margin = new Thickness(this[0].Margin.Left - 10, this[0].Margin.Top, 0, 0);

                        for (int i = 1; i < this.Count; i++)
                        {
                            this[i].Margin = locPrec[i - 1];
                        }
                    break;

                case 3:
                        this[0].Margin = new Thickness(this[0].Margin.Left + 10, this[0].Margin.Top, 0, 0);

                        for (int i = 1; i < this.Count; i++)
                        {
                            this[i].Margin = locPrec[i - 1];
                        }
                    break;
            }
        }
    }
}
