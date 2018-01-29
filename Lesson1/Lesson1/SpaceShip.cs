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
        private int _health = 3;
        public int Health { get => _health; set => _health = value; }
        public static Image Ship { get => ship; set => ship = value; }

        public SpaceShip(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            
        }
        private static Image ship = Image.FromFile("ship.png");

       

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Ship, Pos);
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
            Bullet._Bullet = new Bullet(new Point(myShip.Pos.X + Ship.Width, myShip.Pos.Y + Ship.Height / 2),new Point(20,0), new Size(10,10));
        }

        public static event Message MessageDie;

        public void Die()
        {
            MessageDie?.Invoke();
        }

    }
}
