namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    abstract class Entity : IDraw, IClear
    {
        private Field field;
        private Point2D position;
        private List<Pixel> relativeBody;
        private List<Pixel> body;

        private int restrictionLeft;
        private int restrictionRight;
        private int restrictionTop;
        private int restrictionBottom;

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

        public int RestrictionLeft
        {
            get
            {
                return this.restrictionLeft;
            }
        }

        public int RestrictionRight
        {
            get
            {
                return this.restrictionRight;
            }
        }

        public int RestrictionTop
        {
            get
            {
                return this.restrictionTop;
            }
        }

        public int RestrictionBottom
        {
            get
            {
                return this.restrictionBottom;
            }
        }

        public abstract void Draw();

        public abstract void Clear();

        public Entity(Field field, Point2D position, List<Pixel> relativeBody)
        {
            this.Field = field;
            this.Position = position;
            this.relativeBody = relativeBody;

            this.CalculateRestrictions();

            this.Body = relativeBody
                .ConvertAll(pixel => new Pixel(pixel.Coordinate.X, pixel.Coordinate.Y, pixel.Symbol, pixel.Color));
            this.ReCalculateBody();
        }

        private void CalculateRestrictions()
        {
            int minX = this.relativeBody.Select(pixel => pixel.Coordinate.X).Min();
            int maxX = this.relativeBody.Select(pixel => pixel.Coordinate.X).Max();
            int minY = this.relativeBody.Select(pixel => pixel.Coordinate.Y).Min();
            int maxY = this.relativeBody.Select(pixel => pixel.Coordinate.Y).Max();

            this.restrictionLeft = minX >= 0 ? 0 : Math.Abs(minX);
            this.restrictionRight = maxX <= 0 ? this.Field.Width - 1 : this.Field.Width - 1 - Math.Abs(maxX);

            this.restrictionTop = minY >= 0 ? 0 : Math.Abs(minY);
            this.restrictionBottom = maxY <= 0 ? this.Field.Height - 1 : this.Field.Height - 1 - Math.Abs(maxY);
        }

        public void ReCalculateBody()
        {
            for (int i = 0; i < this.Body.Count; i++)
            {
                this.body[i].Coordinate.X = this.position.X + this.relativeBody[i].Coordinate.X;
                this.body[i].Coordinate.Y = this.position.Y + this.relativeBody[i].Coordinate.Y;
            }
        }
    }
}
