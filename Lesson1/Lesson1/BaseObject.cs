using System;
using System.Drawing;
namespace Lesson1
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected Brush br;
        


        public BaseObject(Point pos, Point dir, Size size) : this (pos,dir)
        {
            Size = size;
        }
        public BaseObject(Point pos, Point dir)
        {
            Pos = pos;
            Dir = dir;

        }

        public virtual void Draw()
        {
           
        }
        public virtual void Update()
        {

        }
    }
}
