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

            List<Vertex> vertexes = new List<Vertex>();
            vertexes.Add(new Vertex(0, 0, 45));

            Vertex v = new Vertex(0, 0, 0);
            Vertex x = new Vertex(0, 0, 10);

            kamera K = new kamera(v, x, 40, 40, 200, 200);
            Bitmap b = K.ProjectPoints(vertexes);
            pictureBox1.Width = 200;
            pictureBox1.Height = 200;
            pictureBox1.Image = null;
            pictureBox1.Image = b;
        }
    }
}
