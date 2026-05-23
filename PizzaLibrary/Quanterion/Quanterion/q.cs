using System;

namespace QuaternionStruct
{
    public struct Quaternion
    {
       
        private const double Tolerance = 1e-13;

        
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }

        
        public double Abs => Math.Sqrt(A * A + B * B + C * C + D * D);

        
        public Quaternion(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        
        public override string ToString()
        {
            
            if (IsZero(A) && IsZero(B) && IsZero(C) && IsZero(D))
                return "0";

            string result = "";

            if (!IsZero(A))
                result += A.ToString();

            result += FormatTerm(B, "i", result.Length == 0);
            result += FormatTerm(C, "j", result.Length == 0);
            result += FormatTerm(D, "k", result.Length == 0);

            return result;
        }

        
        private string FormatTerm(double val, string suffix, bool isFirst)
        {
            if (IsZero(val))
                return "";

            string res = "";
            if (val > 0)
            {
                if (!isFirst) res += "+";
            }
            else
            {
                res += "-";
            }

            double absVal = Math.Abs(val);
            
            if (Math.Abs(absVal - 1.0) < Tolerance)
            {
                res += suffix;
            }
            else
            {
                res += absVal.ToString() + suffix;
            }

            return res;
        }

        
        private static bool IsZero(double val) => Math.Abs(val) < Tolerance;

        
        public override bool Equals(object obj)
        {
            if (obj is Quaternion q)
            {
                return Math.Abs(A - q.A) < Tolerance &&
                       Math.Abs(B - q.B) < Tolerance &&
                       Math.Abs(C - q.C) < Tolerance &&
                       Math.Abs(D - q.D) < Tolerance;
            }
            throw new ArgumentException("Объект для сравнения не является кватернионом");
        }

        
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                const int p = 23;
                
                hash = hash * p + Math.Round(A, 13).GetHashCode();
                hash = hash * p + Math.Round(B, 13).GetHashCode();
                hash = hash * p + Math.Round(C, 13).GetHashCode();
                hash = hash * p + Math.Round(D, 13).GetHashCode();
                return hash;
            }
        }

        
        public static bool operator ==(Quaternion q1, Quaternion q2) => q1.Equals(q2);
        public static bool operator !=(Quaternion q1, Quaternion q2) => !q1.Equals(q2);

        
        public static Quaternion operator +(Quaternion q1, Quaternion q2) =>
            new Quaternion(q1.A + q2.A, q1.B + q2.B, q1.C + q2.C, q1.D + q2.D);

        
        public static Quaternion operator -(Quaternion q1, Quaternion q2) =>
            new Quaternion(q1.A - q2.A, q1.B - q2.B, q1.C - q2.C, q1.D - q2.D);

        
        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            return new Quaternion(
                q1.A * q2.A - q1.B * q2.B - q1.C * q2.C - q1.D * q2.D,
                q1.A * q2.B + q1.B * q2.A + q1.C * q2.D - q1.D * q2.C,
                q1.A * q2.C + q1.C * q2.A + q1.D * q2.B - q1.B * q2.D,
                q1.A * q2.D + q1.D * q2.A + q1.B * q2.C - q1.C * q2.B
            );
        }
    }
}