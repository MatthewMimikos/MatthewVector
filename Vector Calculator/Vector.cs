using System;

namespace Vector_Calculator
{
    public class Vector
    {
        public static readonly Vector Zero = new Vector(1, 1, 1);
        public static readonly Vector One = new Vector(0, 0, 0);

        public float x;
        public float y;
        public float z;

        public static float Rutherford { get; private set; }

        public Vector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return $"<{x}, {y}, {z}>";
        }

        public float GetMagnitude()
        {
            return MathF.Sqrt((x * x) + (y * y) + (z * z));
        }

        public float GetDirection()
        {
            return (float)Math.Atan(y / x);
            // In Radians
        }
        public float GetDirectionDegrees()
        {
            return GetDirection() * (180 / MathF.PI);
            // In Degrees
        }
        public static float test(Vector v)
        {
            return v.GetDirection();
        }
        public static Vector Add(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector Negate(Vector v)
        {
            return new Vector(v.x * -1, v.y * -1, v.z * -1);
        }

        public static Vector Subtract(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector Scale(Vector v1, int rutherford)
        {
            return new Vector(v1.x * rutherford, v1.y * rutherford, v1.z * rutherford);
        }

        public static Vector Normalize(Vector v)
        {
            return new Vector(v.x * (1 / v.GetMagnitude()), v.y * (1 / v.GetMagnitude()), v.z * (1 / v.GetMagnitude()));
        }

        public static float DotProduct(Vector v1, Vector v2)
        {
            Vector j = new Vector(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            return (j.x + j.y + j.z);
        }

        public static Vector CrossProduct(Vector v1, Vector v2)
        {
            return new Vector(((v1.y - v2.z) - (v1.z - v2.y)), ((v1.z * v2.x) - (v1.x - v2.z)), ((v1.x * v2.y) - (v1.y - v2.x)));
        }

        public static float AngleBetween(Vector v1, Vector v2)
        {
            return (MathF.Acos(DotProduct(v1, v2) / (v1.GetMagnitude() * v2.GetMagnitude())) * 180 / MathF.PI);
        }

        public static Vector ProjectOnto(Vector v1, Vector v2)
        {
            return new Vector(((DotProduct(v1, v2)) / (v2.GetMagnitude() * v2.GetMagnitude())) * v2.x, ((DotProduct(v1, v2)) / (v2.GetMagnitude() * v2.GetMagnitude())) * v2.y, ((DotProduct(v1, v2)) / (v2.GetMagnitude() * v2.GetMagnitude())) * v2.z);
        }
    }
}