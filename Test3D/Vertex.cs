using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Test3D
{
    public class Vertex
    {
        public decimal PoziceX {  get; set; }
        public decimal PoziceY { get; set; }
        public decimal PoziceZ { get; set; }
        public List<Vertex>? PripojeneVertexy { get; set; }

        public Vertex(decimal poziceX, decimal poziceY, decimal poziceZ)
        {
            PoziceX = poziceX;
            PoziceY = poziceY;
            PoziceZ = poziceZ;
            PripojeneVertexy = null;
        }

        public decimal GetDistanceFromPlane(Plane p)
        {
            decimal numerator = Math.Abs(p.A * PoziceX + p.B * PoziceY + p.C * p.D + p.D);
            double helpVar = (double)Math.Round(p.A * p.A + p.B * p.B + p.C * p.C, 15);
            decimal denominator = (decimal)Math.Sqrt(helpVar);

            decimal distance = numerator / denominator;
            return distance;
        }
    }
}
