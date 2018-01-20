using System;
using System.Windows.Forms;
using System.Drawing;
namespace Lesson1
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
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
            Load();
            Timer timer = new Timer { Interval = 50 };
            timer.Start();
            timer.Tick += Timer_Tick;

        }
        public static void Draw()
        {
            // Проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
           // Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _stars)
                obj.Draw();
            myShip.Draw();
            planet1.Draw();
            foreach (BaseObject obj in _meteors)
                obj.Draw();
            Buffer.Render();
        }
        public static Star[] _stars;
        public static SpaceShip myShip;
        public static Planet planet1;
        public static BaseObject[] _meteors;
        public static void Load()
        {
           
            _stars = new Star[40];
            for (int i = 0; i < _stars.Length; i++)
                _stars[i] = new Star(new Point(), new Point(-4-i, 0), new Size(1, 1));

             myShip = new SpaceShip(new Point(0, Height / 2), new Point (2, 0));

            planet1 = new Planet(new Point(650, 40), new Point(0, 0),new Size(80,80));

            _meteors = new Meteor[10];
            for (int i = 0; i < _meteors.Length; i++)
                _meteors[i] = new Meteor(new Point(600, 100 + 50 * i), new Point());
            //_meteors = new BaseObject[30];
            //for (int i = 0; i < _meteors.Length; i++)
            //    _meteors[i] = new BaseObject(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20));



        }
        public static void Update()
        {
            foreach (BaseObject obj in _stars)
                obj.Update();
            myShip.Update();
            foreach (BaseObject obj in _meteors)
                obj.Update();
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }


    }
}
