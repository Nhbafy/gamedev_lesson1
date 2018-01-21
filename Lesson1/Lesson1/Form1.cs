using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down) SpaceShip.MoveDown(Game.myShip);
            if (e.KeyData == Keys.Right) SpaceShip.MoveRight(Game.myShip);
            if (e.KeyData == Keys.Up) SpaceShip.MoveUp(Game.myShip);
            if (e.KeyData == Keys.Left) SpaceShip.MoveLeft(Game.myShip);
            if (e.KeyData == Keys.Space) SpaceShip.Shot(Game.myShip);
        }






    }
}
