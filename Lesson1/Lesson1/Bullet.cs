using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Bullet : BaseObject
    {
        private static Bullet bullet;
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        internal static Bullet GetBullet { get => bullet; set => bullet = value; }

        public override void Draw()
        {
            br = new SolidBrush(Color.White);
            Game.Buffer.Graphics.FillRectangle(br, Pos.X, Pos.Y, 10,2);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
        }
    }
}
