using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class MedKit : BaseObject, ICollision
    {
        Random random = new Random();
        public MedKit(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Pos.X = random.Next(0, Game.Width);
            Pos.Y = random.Next(0, Game.Height);
        }

        public override void Draw()
        {
            br = new SolidBrush(Color.Goldenrod);
            Game.Buffer.Graphics.FillEllipse(br, Rect);
        }

        public override void Update()
        {
            Pos.X = random.Next(0,Game.Width);
            Pos.Y = random.Next(0, Game.Height);
        }
    }
}
