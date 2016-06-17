namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Fighter : Entity, IMovable, IShooter, IBomber
    {
        private char figure;
        private ConsoleColor color;

        public char Figure
        {
            get
            {
                return this.figure;
            }

            private set
            {
                this.figure = value;
            }
        }

        public ConsoleColor Color
        {
            get
            {
                return this.color;
            }

            private set
            {
                this.color = value;
            }
        }

        private static List<Pixel> FighterBody(Point2D pos)
        {
            List<Pixel> body = new List<Pixel>();

            body.Add(new Pixel(0, 0, '=', ConsoleColor.Black));

            body.Add(new Pixel(-1, 0, '>', ConsoleColor.Red));

            body.Add(new Pixel(0, -2, '-', ConsoleColor.Black));
            body.Add(new Pixel(0, -1, '\\', ConsoleColor.Black));
            body.Add(new Pixel(0, 1, '/', ConsoleColor.Black));
            body.Add(new Pixel(0, 2, '-', ConsoleColor.Black));

            body.Add(new Pixel(1, -1, '\\', ConsoleColor.Black));
            body.Add(new Pixel(1, 0, '=', ConsoleColor.Black));
            body.Add(new Pixel(1, 1, '/', ConsoleColor.Black));

            body.Add(new Pixel(2, 0, '=', ConsoleColor.Black));

            body.Add(new Pixel(3, 0, '=', ConsoleColor.DarkCyan));
            body.Add(new Pixel(4, 0, '>', ConsoleColor.DarkCyan));

            return body;
        }

        public Fighter(Field field, Point2D position) : this(field, position, Fighter.FighterBody(position))
        { 
        }

        public Fighter(Field field, Point2D position, List<Pixel> body) : base(field, position, body)
        {
        }

        public override void Clear()
        {
            foreach (Pixel pixel in this.Body)
            {
                pixel.Clear();
            }
        }

        public override void Draw()
        {
            foreach (Pixel pixel in this.Body)
            {
                pixel.Draw();
            }
        }

        public void Move()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (userInput.Key == ConsoleKey.LeftArrow && this.Position.X > this.RestrictionLeft)
                {
                    this.Position.X--;
                }
                else if (userInput.Key == ConsoleKey.RightArrow && this.Position.X < this.RestrictionRight)
                {
                    this.Position.X++;
                }
                else if (userInput.Key == ConsoleKey.DownArrow && this.Position.Y < this.RestrictionBottom)
                {
                    this.Position.Y++;
                }
                else if (userInput.Key == ConsoleKey.UpArrow && this.Position.Y > this.RestrictionTop)
                {
                    this.Position.Y--;
                }

                this.ReCalculateBody();
            }
        }
        
        public void Shoot()
        {
            throw new NotImplementedException();
        }

        public void ThrowBomb()
        {
            throw new NotImplementedException();
        }
    }
}
