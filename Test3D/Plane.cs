using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Test3D
{
    public class Plane
    {
        public decimal A { get; set; }
        public decimal B { get; set; }
        public decimal C { get; set; }
        public decimal D { get; set; }

        public Plane(decimal x, decimal y, decimal z, decimal d)
        {
            A = x;
            B = y;
            C = z;
            D = d;
        }

        public Plane()
        {
            A = 0;
            B = 0;
            C = 0;
            D = 0;
        }

        public Plane GetPlane(Vertex ver1, Vertex ver2, Vertex ver3)
        {
            Vector3 p1 = new Vector3((float)Math.Round(ver1.PoziceX, 4), (float)Math.Round(ver1.PoziceY, 4), (float)Math.Round(ver1.PoziceZ, 4));
            Vector3 p2 = new Vector3((float)Math.Round(ver2.PoziceX, 4), (float)Math.Round(ver2.PoziceY, 4), (float)Math.Round(ver2.PoziceZ, 4));
            Vector3 p3 = new Vector3((float)Math.Round(ver3.PoziceX, 4), (float)Math.Round(ver3.PoziceY, 4), (float)Math.Round(ver3.PoziceZ, 4));

            Vector3 v1 = p2 - p1;
            Vector3 v2 = p3 - p1;

            // Normála roviny
            Vector3 normal = Vector3.Cross(v1, v2);

            // Rovnice roviny: A(x - x0) + B(y - y0) + C(z - z0) = 0
            // nebo: Ax + By + Cz + D = 0
            float A = normal.X;
            float B = normal.Y;
            float C = normal.Z;
            float D = -(A * p1.X + B * p1.Y + C * p1.Z);

            return new Plane((decimal)A, (decimal)B, (decimal)C, (decimal)D);

            /*
            Vector v1 = Vector.GetVectorFromVertexes(ver1, ver2);
            Vector v2 = Vector.GetVectorFromVertexes(ver1, ver3);

            //Vector nV1 = Vector.NormalizeVector(v1);
            //Vector nV2 = Vector.NormalizeVector(v2);

            Vector kolV = Vector.GetperpendicularVector(v1, v2);
            //Vector norKolV = Vector.NormalizeVector(kolV);

            decimal Dnumber = -(kolV.X * ver1.PoziceX + kolV.Y * ver1.PoziceY + kolV.Z * ver1.PoziceZ);

            return new Plane(kolV.X, kolV.Y, kolV.Z, Dnumber);
            */
        }


    }
}
