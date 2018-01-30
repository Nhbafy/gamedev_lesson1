using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace Lesson1
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width;
        public static int Height;
        public static Star[] _stars;
        public static SpaceShip myShip;
        public static Planet planet1;
       // public static List<Meteor> _meteors = new List<Meteor>(15);
        public static  Meteor[] _meteors;
        private static int _hitCount;
        public static MedKit medKit;
        private static Timer _timer = new Timer() { Interval = 50 };
        public static Random Rnd = new Random();


        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60,
            FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }

        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();// Создаём объект - поверхность рисования и связываем его с формой
            // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            // Связываем буфер в памяти с графическим объектом.
            // для того, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            SpaceShip.MessageDie += Finish;
            Load();
            _timer.Start();
            _timer.Tick += Timer_Tick;
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            foreach (BaseObject obj in _stars) obj.Draw();
            myShip.Draw();
            medKit.Draw();
            planet1.Draw();
            foreach (BaseObject obj in _meteors)
            {
                if (obj != null)
                {
                    obj.Draw();
                }
            }
            for (int i = 0; i < Bullet._Bullets.Count; i++) Bullet._Bullets[i].Draw();
 
            
            Buffer.Render();
        }

        public static void Load()
        {
            _stars = new Star[40];
            for (int i = 0; i < _stars.Length; i++)
            {
                _stars[i] = new Star(new Point(), new Point(-4-i, 0), new Size(1, 1));
            }

            myShip = new SpaceShip(new Point(0, Height / 2), new Point (), new Size (SpaceShip.Ship.Width, SpaceShip.Ship.Height));

            planet1 = new Planet(new Point(650, 40), new Point(0, 0),new Size(80,80));

            _meteors = new Meteor[15];
            for (int i = 0; i < _meteors.Length; i++)
            {
                _meteors[i] = new Meteor(new Point(Width + 20, 30 + 30 * i), new Point(),new Size (25,25));
            }

            medKit = new MedKit(new Point(), new Point(), new Size(40, 40));
        }
        public static void Update()
        {
            foreach (BaseObject obj in _stars) obj.Update();
            foreach (BaseObject obj in Bullet._Bullets) obj.Update();
            for (var i = 0; i < _meteors.Length; i++)
            {
                if (_meteors[i] == null) continue;
                _meteors[i].Update();
                for (int j = 0; j < Bullet._Bullets.Count; j++)
                {
                    if (_meteors[i]!=null && Bullet._Bullets[j].Collision(_meteors[i]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        Bullet._Bullets.RemoveAt(j);
                        _meteors[i] = null; ;
                        _hitCount += 1;
                        j--;
                    }    
                }
                
                if (_meteors[i] == null || !myShip.Collision(_meteors[i])) continue;
                myShip.Health--;
                System.Media.SystemSounds.Asterisk.Play();
                if (myShip.Collision(medKit))
                {
                    myShip.Health++;
                    medKit.Update();
                }
                if (myShip.Health <= 0) myShip.Die();
            }
            if (NewMeteors(_meteors))
            {
                _meteors = new Meteor[_meteors.Length + 1];
                for (int i = 0; i < _meteors.Length; i++)
                {
                    _meteors[i] = new Meteor(new Point(Width + 20, 30 + 30 * i), new Point(), new Size(25, 25));
                }
            }
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        private static bool NewMeteors (Meteor[] metArr)
        {
            bool check = true;
            foreach (var met in metArr)
            {
                if (met != null) check = false;
            }
            return check;
        }

    }
}
