using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lesson1
{
    class SpaceShip :BaseObject
    {
        public SpaceShip(Point pos, Point dir) : base(pos, dir)
        {
            
        }
        private Image ship =  Image.FromFile("ship.PNG");

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(ship, Pos);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
           
        }
    }
}
