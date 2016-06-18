namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Point2D : IEquatable<Point2D>
    {
        private int x;
        private int y;

        public int X
        {
            get
            {
                return this.x;
            }

            internal set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            internal set
            {
                this.y = value;
            }
        }

        public Point2D(Point2D point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }

        public Point2D(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool Equals(Point2D other)
        {
            if (other == null)
                return false;

            if (this.X == other.X && this.Y == other.Y)
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Point2D point2D = obj as Point2D;
            if (point2D == null)
                return false;
            else
                return this.Equals(point2D);
        }

        public override int GetHashCode()
        {
            int prime = 89;
            int result = 1;
            unchecked
            {
                result = result * prime + this.X.GetHashCode();
                result = result * prime + this.Y.GetHashCode();
            }
            return result;
        }

        public static bool operator ==(Point2D point1, Point2D point2)
        {
            if (((object)point1) == null || ((object)point2) == null)
                return Object.Equals(point1, point2);

            return point1.Equals(point2);
        }

        public static bool operator !=(Point2D point1, Point2D point2)
        {
            if (((object)point1) == null || ((object)point2) == null)
                return !Object.Equals(point1, point2);

            return !(point1.Equals(point2));
        }
    }
}
