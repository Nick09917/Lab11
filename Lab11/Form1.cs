using System.Windows.Forms;
namespace Lab11
{
    public partial class Form1 : Form
    {
        private double angle = 0; // Угол для синусоидального движения
        private int centerX, centerY; // Координаты центра окружности
        private int radius = 30; // Радиус окружности
        private int amplitude = 50; // Амплитуда синусоиды
        public Form1()
        {
            InitializeComponent();

            // Установка начальных координат центра окружности
            centerX = ClientSize.Width /4;
            centerY = ClientSize.Height /4;

            // Запуск таймера для обновления движения
             timer1.Start(); 
        }


      

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            // Вычисление новых координат окружности по синусоиде
            int x = centerX + (int)(amplitude * Math.Sin(angle));
            int y = centerY;

         
            g.FillEllipse(Brushes.Red, x - radius, y - radius, 2 * radius, 2 * radius);

        }
        private bool moveRight = true;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (moveRight)
            {
                centerX += 5; 
                if (centerX >= ClientSize.Width - radius)
                {
                    moveRight = false; 
                }
            }
            else
            {
                centerX -= 5; 
                if (centerX <= radius)
                {
                    moveRight = true; 
                }
            }

            
            centerY = (int)(ClientSize.Height / 2 + amplitude * Math.Sin(angle));

          
            angle += 0.1;

           
            Invalidate();
        }
    }
}