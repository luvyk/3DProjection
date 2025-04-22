using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3D
{
    internal class Vector
    {
        public decimal X {  get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }

        public Vector(decimal x, decimal y, decimal z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Vector GetVectorFromVertexes(Vertex prvniVertex, Vertex druhyVertex)
        {
            decimal Xvector = druhyVertex.PoziceX - prvniVertex.PoziceX;
            decimal Yvector = druhyVertex.PoziceY - prvniVertex.PoziceY;
            decimal Zvector = druhyVertex.PoziceZ - prvniVertex.PoziceZ;

            return new Vector(Xvector, Yvector, Zvector);
        }

        public static Vector NormalizeVector(Vector v)
        {
            //zlatý javascript...
            decimal magnitude = (decimal)Math.Sqrt((double)v.X * (double)v.X + (double)v.Y * (double)v.Y + (double)v.Z * (double)v.Z);
            decimal nX = v.X / magnitude;
            decimal nY = v.Y / magnitude;
            decimal nZ = v.Z / magnitude;

            return new Vector(nX, nY, nZ);
        }
        public Vertex MoveByVectorAndLenght(Vertex ver, decimal lenght)
        {
            decimal xNew = ver.PoziceX + lenght * X;
            decimal yNew = ver.PoziceY + lenght * Y;
            decimal zNew = ver.PoziceZ + lenght * Z;

            return new Vertex(xNew, yNew, zNew);
        }
        public static Vector GetperpendicularVector(Vector v1, Vector v2)
        {
            Vector v = new Vector(v1.Y * v2.Z - v1.Z * v2.Y,
                                v1.Z * v2.X - v1.X * v2.Z,
                                v1.X * v2.Y - v1.Y * v2.X);
            return v;
        }
        public static Vector SwitchVector(Vector v)
        {
            return new Vector(-v.X, -v.Y, -v.Z);
        }
    }
}
