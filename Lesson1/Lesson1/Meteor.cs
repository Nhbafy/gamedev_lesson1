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
        public Meteor(Point pos, Point dir) : base(pos, dir)
        {
            this.Dir.X = random.Next(-15, 15);
            this.Dir.Y = random.Next(-15, 15);
        }

        public override void Draw()
        {
            br = new SolidBrush(Color.LightGreen);

            Point[] polygon = new Point[9];
            for (int i = 0; i < polygon.Length; i++)
            {
                polygon[0] = new Point(Pos.X, Pos.Y);
                polygon[1] = new Point(Pos.X + 4, Pos.Y - 4);
                polygon[2] = new Point(Pos.X + 8, Pos.Y - 4);
                polygon[3] = new Point(Pos.X + 12, Pos.Y);
                polygon[4] = new Point(Pos.X + 12, Pos.Y + 8);
                polygon[5] = new Point(Pos.X + 8, Pos.Y + 12);
                polygon[6] = new Point(Pos.X + 4, Pos.Y + 12);
                polygon[7] = new Point(Pos.X, Pos.Y + 4);
                polygon[8] = new Point(Pos.X, Pos.Y);
            }
            Game.Buffer.Graphics.FillPolygon(br, polygon);

        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width - 30) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height - 50) Dir.Y = -Dir.Y;
        }
    }
}
