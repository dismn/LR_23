using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_23
{
    
    public partial class Form1 : Form
    {
        private double a;
        private void DrawGraph()
        {
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics graphics = Graphics.FromImage(bitmap);

            // Очистити площу малювання
            graphics.Clear(Color.White);

            // Визначити область визначення
            double tMin = -10;
            double tMax = 10;

            // Визначення розмірів площі малювання
            int width = pictureBox.Width;
            int height = pictureBox.Height;

            // Масштабування
            double scale = Math.Min(width / (tMax - tMin), height / (tMax - tMin));

            // Малювання осей координат
            Pen axisPen = new Pen(Color.Black, 2);
            graphics.DrawLine(axisPen, 0, height / 2, width, height / 2); // Ось X
            graphics.DrawLine(axisPen, width / 2, 0, width / 2, height); // Ось Y

            // Малювання поділок на осях
            Font font = new Font("Arial", 8);
            SolidBrush brush = new SolidBrush(Color.Black);
            int divisionSize = 10;

            for (int i = -width / 2; i < width / 2; i += divisionSize)
            {
                graphics.DrawLine(Pens.LightGray, width / 2 + i, 0, width / 2 + i, height);
                graphics.DrawString((i / scale).ToString(), font, brush, width / 2 + i, height / 2 + 2);
            }

            for (int i = -height / 2; i < height / 2; i += divisionSize)
            {
                graphics.DrawLine(Pens.LightGray, 0, height / 2 + i, width, height / 2 + i);
                graphics.DrawString((-i / scale).ToString(), font, brush, width / 2 + 2, height / 2 + i);
            }

            // Обчислити та намалювати точки на графіку
            for (double t = tMin; t <= tMax; t += 0.01)
            {
                double x = a * (t - Math.Sin(t * t));
                double y = a * (t - Math.Cos(t * t));

                int pixelX = (int)(width / 2 + x * scale); // Масштабування і перетворення координат
                int pixelY = (int)(height / 2 - y * scale); // Масштабування і перетворення координат

                bitmap.SetPixel(pixelX, pixelY, Color.Black);
            }

            pictureBox.Image = bitmap;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonPlot_Click(object sender, EventArgs e)
        {
            try
            {
                a = double.Parse(tbA.Text); // Отримати значення коефіцієнта a
                DrawGraph();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
