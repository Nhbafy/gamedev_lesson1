﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Planet : BaseObject
    {
        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            
        }

        public override void Draw()
        {
            br = new SolidBrush(Color.Crimson);
            Game.Buffer.Graphics.FillEllipse(br ,Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
