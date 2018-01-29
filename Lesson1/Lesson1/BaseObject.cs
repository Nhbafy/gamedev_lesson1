using System;
using System.Drawing;
namespace Lesson1
{
    abstract class BaseObject : ICollision
    {
        public Point Pos;
        protected Point Dir;
        protected Size Size;
        protected Brush br;

        public Rectangle Rect => new Rectangle(Pos,Size);

        protected BaseObject(Point pos, Point dir, Size size)
        {
            Size = size;
            Pos = pos;
            Dir = dir;
        }

        public abstract void Draw();
        public abstract void Update();

        public bool Collision(ICollision o)
        {
            return o.Rect.IntersectsWith(this.Rect);

        }
        public delegate void Message();

    }
}
