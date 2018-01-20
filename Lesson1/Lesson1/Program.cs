using System;
using System.Windows.Forms;
// Создаём шаблон приложения, где подключаем модули
namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            Form1 form = new Form1
            {
                Width = 800,
                Height = 600
            };
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
