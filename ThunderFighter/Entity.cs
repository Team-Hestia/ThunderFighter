namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Entity : IDraw, IClear
    {
        private Field field;
        private Point2D position;
        private List<Pixel> relativeBody;
        private List<Pixel> body;

        private int width;
        private int height;

        internal Point2D Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
            }
        }

        public Field Field
        {
            get
            {
                return this.field;
            }

            private set
            {
                this.field = value;
            }
        }

        public List<Pixel> Body
        {
            get
            {
                return this.body;
            }

            private set
            {
                this.body = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }

        public void Draw()
        {
            foreach (Pixel pixel in this.Body)
            {
                if (!(pixel.Coordinate.X < 0 || 
                    pixel.Coordinate.X >= this.Field.Width ||
                    pixel.Coordinate.Y < 0 ||
                    pixel.Coordinate.Y >= this.Field.Height))
                {
                    pixel.Draw();
                }
            }
        }

        public void Clear()
        {
            foreach (Pixel pixel in this.Body)
            {
                if (!(pixel.Coordinate.X < 0 ||
                    pixel.Coordinate.X >= this.Field.Width ||
                    pixel.Coordinate.Y < 0 ||
                    pixel.Coordinate.Y >= this.Field.Height))
                {
                    pixel.Clear();
                }
            }
        }

        public Entity(Field field, Point2D position, List<Pixel> relativeBody)
        {
            this.Field = field;
            this.Position = position;
            this.relativeBody = relativeBody;

            this.CalculateWidthAndHeightOfEntityBody();

            // TODO refactor to not use 2 lists
            this.Body = relativeBody
                .ConvertAll(pixel => new Pixel(pixel.Coordinate.X, pixel.Coordinate.Y, pixel.Symbol, pixel.Color));
            this.ReCalculateBody();
        }

        private void CalculateWidthAndHeightOfEntityBody()
        {
            int minX = this.relativeBody.Select(pixel => pixel.Coordinate.X).Min();
            int maxX = this.relativeBody.Select(pixel => pixel.Coordinate.X).Max();
            int minY = this.relativeBody.Select(pixel => pixel.Coordinate.Y).Min();
            int maxY = this.relativeBody.Select(pixel => pixel.Coordinate.Y).Max();

            this.Width = Math.Abs(minX - maxX);
            this.Height = Math.Abs(minY - maxY);
        }

        public void ReCalculateBody()
        {
            for (int i = 0; i < this.Body.Count; i++)
            {
                this.body[i].Coordinate.X = this.Position.X + this.relativeBody[i].Coordinate.X;
                this.body[i].Coordinate.Y = this.Position.Y + this.relativeBody[i].Coordinate.Y;
            }
        }
    }
}
