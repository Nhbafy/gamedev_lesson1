using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Lesson1
{
    class SpaceShip :BaseObject,ICollision
    {
        public SpaceShip(Point pos, Point dir) : base(pos, dir)
        {
            
        }
        private static Image ship = Image.FromFile("ship.png");

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(ship, Pos);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
        }

        public static void MoveUp(SpaceShip myShip)
        { 
             myShip.Pos.Y -= 17;
        }

        public static void MoveDown(SpaceShip myShip)
        {
            myShip.Pos.Y += 17;
        }

        public static void MoveRight(SpaceShip myShip)
        {
            myShip.Pos.X += 17;
        }

        public static void MoveLeft(SpaceShip myShip)
        {
            myShip.Pos.X -= 17;
        }

        public static void Shot(SpaceShip myShip)
        {
            Bullet.GetBullet = new Bullet(new Point(myShip.Pos.X + ship.Width, myShip.Pos.Y + ship.Height / 2),new Point(20,0), new Size(10,10));
        }

    }
}
