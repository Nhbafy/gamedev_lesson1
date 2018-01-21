using System;
using System.Drawing;
namespace Lesson1
{
    abstract class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected Brush br;
        


        protected BaseObject(Point pos, Point dir, Size size) : this (pos,dir)
        {
            Size = size;
        }
        protected BaseObject(Point pos, Point dir)
        {
            Pos = pos;
            Dir = dir;
        }

        public abstract void Draw();
        public abstract void Update();
    }
}
