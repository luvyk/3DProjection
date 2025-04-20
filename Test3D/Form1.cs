namespace Test3D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Red);
            g.DrawEllipse(pen, 100, 100, 100, 100);

            Vertex v = new Vertex(0, 0, 0);
            Vertex x = new Vertex(0, 0, 10);

            kamera K = new kamera(v, x, 40, 40, 200, 200);
        }
    }
}
