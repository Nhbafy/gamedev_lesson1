using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

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
        public static void Up(SpaceShip myShip)
        { 
             myShip.Pos.Y -= 17;
        }
        public static void Down(SpaceShip myShip)
        {
            myShip.Pos.Y += 17;
        }
        public static void Right(SpaceShip myShip)
        {
            myShip.Pos.X += 17;
        }
        public static void Left(SpaceShip myShip)
        {
            myShip.Pos.X -= 17;
        }
    }
}
