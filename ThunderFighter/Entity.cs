namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Entity : IDrawable, IClearable
    {
        private Field field;
        private Point2D position;
        private List<List<Pixel>> relativeBodyStates;
        private List<Pixel> body;

        private EntityState state;

        private int width;
        private int height;

        private bool isDestroyed;

        public Entity(Field field, Point2D position, List<List<Pixel>> relativeBodyStates, EntityState state)
        {
            this.Field = field;
            this.Position = position;
            this.relativeBodyStates = relativeBodyStates;
            this.State = (int)state;

            this.CalculateWidthAndHeightOfEntityBody();

            // TODO: refactor to not use 2 lists (very difficult task)
            this.Body = relativeBodyStates[this.State]
                .ConvertAll(pixel => new Pixel(pixel.Coordinate.X, pixel.Coordinate.Y, pixel.Symbol, pixel.Color));
            this.ReCalculateBody();
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

            private set
            {
                this.height = value;
            }
        }

        public bool IsDestroyed
        {
            get
            {
                return this.isDestroyed;
            }

            private set
            {
                this.isDestroyed = value;
            }
        }

        public int State
        {
            get
            {
                return (int)this.state;
            }

            internal set
            {
                this.state = (EntityState)value;
            }
        }

        protected Point2D Position
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

        public void Draw()
        {
            int oldLeft = this.Body.Select(pixel => pixel.Coordinate.X).Min();
            int oldRight = this.Body.Select(pixel => pixel.Coordinate.X).Max();
            int oldTop = this.Body.Select(pixel => pixel.Coordinate.Y).Min();
            int oldBottom = this.Body.Select(pixel => pixel.Coordinate.Y).Max();

            if (this.state == EntityState.HalfDestroyed || this.state == EntityState.Destroyed)
            {
                this.Body = this.relativeBodyStates[this.State]
                    .ConvertAll(pixel => new Pixel(pixel.Coordinate.X, pixel.Coordinate.Y, pixel.Symbol, pixel.Color));
            }

            this.ReCalculateBody();

            int left = Math.Min(this.Field.Width - 1, Math.Max(0, Math.Min(oldLeft, this.Body.Select(pixel => pixel.Coordinate.X).Min())));
            int top = Math.Min(this.Field.Height - 1, Math.Max(0, Math.Min(oldTop, this.Body.Select(pixel => pixel.Coordinate.Y).Min())));
            int right = Math.Max(0, Math.Min(this.Field.Width - 1, Math.Max(oldRight, this.Body.Select(pixel => pixel.Coordinate.X).Max())));
            int bottom = Math.Max(0, Math.Min(this.Field.Height - 1, Math.Max(oldBottom, this.Body.Select(pixel => pixel.Coordinate.Y).Max())));

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

            if (this.state == EntityState.HalfDestroyed)
            {
                this.state = EntityState.Destroyed;
            }
            else if (this.state == EntityState.Destroyed)
            {
                this.IsDestroyed = true;
            }

            // Avoids flickering: draw just rectangle which contains old and new entity bodies
            ScreenBuffer.DrawRectangle(left, top, right, bottom);
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

        private void ReCalculateBody()
        {
            for (int i = 0; i < this.Body.Count; i++)
            {
                this.body[i].Coordinate.X =
                    this.Position.X + this.relativeBodyStates[this.State][i].Coordinate.X;
                this.body[i].Coordinate.Y =
                    this.Position.Y + this.relativeBodyStates[this.State][i].Coordinate.Y;
            }
        }

        private void CalculateWidthAndHeightOfEntityBody()
        {
            // TODO: foreach all body states to find out max width & max height
            int minX = this.relativeBodyStates[this.State].Select(pixel => pixel.Coordinate.X).Min();
            int maxX = this.relativeBodyStates[this.State].Select(pixel => pixel.Coordinate.X).Max();
            int minY = this.relativeBodyStates[this.State].Select(pixel => pixel.Coordinate.Y).Min();
            int maxY = this.relativeBodyStates[this.State].Select(pixel => pixel.Coordinate.Y).Max();

            this.Width = Math.Abs(minX - maxX);
            this.Height = Math.Abs(minY - maxY);
        }
    }
}
