namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Fighter : Entity, IMovable, IShooter, IBomber
    {
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

        public void Move()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (userInput.Key == ConsoleKey.LeftArrow && this.Body.Exists(pixel => pixel.Coordinate.X > this.Width))
                {
                    this.Position.X--;
                }
                else if (userInput.Key == ConsoleKey.RightArrow && this.Body.Exists(pixel => pixel.Coordinate.X + this.Width < this.Field.Width - (this.Field.Width / 3)))
                {
                    this.Position.X++;
                }
                else if (userInput.Key == ConsoleKey.DownArrow && this.Body.Exists(pixel => pixel.Coordinate.Y + this.Height < this.Field.Height - 1))
                {
                    this.Position.Y++;
                }
                else if (userInput.Key == ConsoleKey.UpArrow && this.Body.Exists(pixel => pixel.Coordinate.Y > this.Height))
                {
                    this.Position.Y--;
                }
                else if (userInput.Key == ConsoleKey.Spacebar) // TODO handle with EventHandler(OnKeyPress)
                {
                    List<Pixel> bulletBody = new List<Pixel>();
                    bulletBody.Add(new Pixel(5, 0, '-', ConsoleColor.Black));

                    Engine.bullets.Add(new Bullet(this.Field, new Point2D(this.Position), bulletBody));
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
