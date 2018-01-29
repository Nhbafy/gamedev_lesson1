using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Meteor : BaseObject
    {
        private static Random random = new Random();
        public Meteor(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            this.Dir.X = random.Next(-15, -1);
            this.Dir.Y = random.Next(-15, -1);
        }

        public override void Draw()
        {
            br = new SolidBrush(Color.LightGreen);
            Game.Buffer.Graphics.FillEllipse(br,Rect);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
